using ADPortsTask.Data.Models;
using ADPortsTask.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADPortsTask.Services.Interfaces
{
    public interface IUserService
    {
        Task AddUserRoleAsync(string userId, string role);
        Task AddUsersRoleAsync(ApplicationUser user, IEnumerable<string> roles);
        Task<IEnumerable<ApplicationUser>> GetUsersById(IEnumerable<string> usersId);
        Task<bool> CheckPassword(ApplicationUser user, string password);
        Task CreateAdmin(ApplicationUser user);
        Task CreateUser(ApplicationUser user);
        Task CreateUser(ApplicationUser user, string password);
        Task DeleteUser(ApplicationUser user);
        Task DeleteUser(string id);
        Task<ApplicationUser> GetUserByEmail(string email);
        Task<ApplicationUser> GetUserById(string id);
        Task<ApplicationUser> GetUserByName(string userName);
        Task<PagedList<ApplicationUser>> GetUsersList(int pageNumber, int pageSize);
        Task<IList<string>> GetUserRoles(ApplicationUser user);
        Task<IList<string>> GetUserRolesById(string userId);
        Task<IEnumerable<ApplicationUser>> GetUsersByRole(string roleName);
        Task<IEnumerable<ApplicationUser>> GetUsersList();
        Task<bool> IsInRoleAsync(ApplicationUser user, string role);
        Task<bool> IsEmailExist(string email);
        Task RemoveUserRoleAsync(string userId, string role);
        Task RemoveUsersRoleAsync(ApplicationUser user, IEnumerable<string> roles);
        Task RemoveAllRolesFromUser(string userId);
        Task UpdateUser(ApplicationUser user);
        Task UserApproval(string userId, bool IsApproved);
        Task UserBlocking(string userId, bool IsBlocked);
    }
}
