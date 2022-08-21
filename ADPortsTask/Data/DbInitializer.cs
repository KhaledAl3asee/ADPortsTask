using ADPortsTask.Data.Models;
using ADPortsTask.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADPortsTask.Data
{
    public class DbInitializer
    {
        readonly ApplicationDbContext context;
        readonly UserManager<ApplicationUser> userManager;
        readonly RoleManager<IdentityRole> roleManager;

        ApplicationUser superAdmin;

        public DbInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        /// <summary>
        /// Initializes persistent storage with at least single SuperAdmin (at production). 
        /// For debugging, adds dummy users and data.
        /// <para>Enable context.Database.EnsureDeleted() to force full reseeding with each run.</para>
        /// </summary>
        public async Task Initialize(bool UseStoreProc = true)
        {
#if DEBUG
            // WARNING! Wipes the entire database.
            //context.Database.EnsureDeleted();
            //Please dont delete me  because userid will causing new token every login
#endif

#if DEBUG

            //make sure DB is created
            bool isDbFresh = context.Database.EnsureCreated();

            await EnsureCompetentSuperAdmin();
 
            if (isDbFresh)
            {
                await SeedDummyData();
            }
#endif
        }

        /// <summary>
        /// Creating/Granting competency for the SuperAdmin.
        /// </summary>
        /// <returns></returns>
        async Task EnsureCompetentSuperAdmin()
        {
            //make sure we have basic roles
            if (!await roleManager.RoleExistsAsync(RoleTypes.Admin))
                await roleManager.CreateAsync(new IdentityRole(RoleTypes.Admin));
            if (!await roleManager.RoleExistsAsync(RoleTypes.User))
                await roleManager.CreateAsync(new IdentityRole(RoleTypes.User));

            //making sure we have competent SuperAdmin
            var superAdminEmail = "superadmin@admin.adports";  //temporary: replace with the real SuperAdmin email address

            superAdmin = await userManager.FindByEmailAsync(superAdminEmail);

            if (superAdmin == null)//create new if no luck
            {
                superAdmin = new ApplicationUser() { UserName = "SuperAdmin", Email = superAdminEmail };
                await userManager.CreateAsync(user: superAdmin, password: superAdmin.UserName);//temporary: discard password once SuperAdmin has real email address
            }

            //ensuring SuperAdmin is entitled to all roles
            if (!await userManager.IsInRoleAsync(superAdmin, RoleTypes.Admin))
                await userManager.AddToRoleAsync(superAdmin, RoleTypes.Admin);

            if (!await userManager.IsInRoleAsync(superAdmin, RoleTypes.User))
                await userManager.AddToRoleAsync(superAdmin, RoleTypes.User);

            //unblocking and approving SuperAdmin
            superAdmin.ApprovalStatus = true;
            superAdmin.IsBlocked = false;
            await userManager.UpdateAsync(superAdmin);
        }


        async Task SeedDummyData()
        {
            var dummyUsernames = new[] {
                "Khalid",// 0
                "Ahmad",// 1
                "Zaid",// 2
                "Aya",// 3
                "Sofia",// 4
                "Hazel",// 5
                "Heather",// 6
                "Elen",// 7
                "Samia"// 8
            };
           
            #region Users
            var users = new Dictionary<string, ApplicationUser> { { superAdmin.UserName, superAdmin } };

            for (int i = 0; i < dummyUsernames.Length; i++)
            {
                string name = dummyUsernames[i];
                string password = name;// password == name
                bool isAdmin = i < 2;// first two dummies are admins

                bool? approvalStatus = null; // basically, all are newcomers

                if (i < 6) // approved all up to Wolf
                    approvalStatus = true;

                if (i == 3 || i == 7) // rejects: Bear & Eagle
                    approvalStatus = false;

                bool isBlocked = (i == 1 || i == 3 || i == 5);// block Elphant, Bear, Wolf

                string email = $"{name}@{(isAdmin ? RoleTypes.Admin : RoleTypes.User)}.adports".ToLower();//e.g. lion@admin.adports & camel@user.adports

                var user = new ApplicationUser() { UserName = name, Email = email };
                await userManager.CreateAsync(user, password);

                await userManager.AddToRoleAsync(user, RoleTypes.User);
                if (isAdmin)
                    await userManager.AddToRoleAsync(user, RoleTypes.Admin);

                user.IsBlocked = isBlocked;
                user.ApprovalStatus = approvalStatus;
                await userManager.UpdateAsync(user);

                users.Add(user.UserName, user);
            }
            #endregion

             

            #region Employees
            var Employees = new Dictionary<string, Employee> {
                { "Amber", new Employee() { Title = "Amber" } },
                { "Asmar", new Employee() { Title = "Asmar" } }
            };
            Employees.Add("Chev", new Employee() { Title = "Chev"});
            Employees.Add("White", new Employee() { Title = "White" });
            Employees.Add("Fadel", new Employee() { Title = "Fadel"});

            Employees.ToList().ForEach(e => e.Value.Creator = e.Value.Updater = superAdmin);

            context.Employees.AddRange(Employees.Select(e => e.Value));
            #endregion

             

            //saving changes to DB before seeding booking, so the rules have default storage values.
            context.SaveChanges();

 
        }
  }
}