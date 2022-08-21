using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ADPortsTask.Data.Models.Interfaces;
using ADPortsTask.DTOs;
using ADPortsTask.DTOs.Employee;

namespace ADPortsTask.Data.Models
{
    /// <summary>
    /// Visual nesting entity, provides ability to *visually* group resources in a form of a nested set (tree).
    /// </summary>
    public class Employee : IIdentifiable<int>, ITrackable<ApplicationUser, string>, IActivable
    {
        /// <summary>
        /// Primary identity key for the tree group.
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Short designation of the tree group. Required.
        /// </summary>
        [Required]
        [MaxLength(64)]
        public string Title { get; set; }

        /// <summary>
        /// Provides deactivation functionality. Is true by default at the persistent storage.
        /// </summary>
        public bool? IsActive { get; set; }
         

        #region User-Time tracking Properties 
        // Repeating declaration to overcome current EF Core column ordering inability

        /// <summary>
        /// Time of the current entry creation. Gets set automatically by the persistent storage.
        /// </summary>
        [Required]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Time of the current entry creation. Gets set automatically by the persistent storage.
        /// </summary>
        [Required]
        public DateTime UpdatedTime { get; set; }

        /// <summary>
        /// Identifier of the user who created current entry. Required.
        /// </summary>
        
        [MaxLength(450)]
        public string CreatedUserId { get; set; }

        /// <summary>
        /// Identifier of the user who updated current entry. Required.
        /// </summary>
        
        [MaxLength(450)]
        public string UpdatedUserId { get; set; }

        /// <summary>
        /// User who created current entry.
        /// </summary>
        [ForeignKey("CreatedUserId")]
        public virtual ApplicationUser Creator { get; set; }

        /// <summary>
        /// User who updated current entry.
        /// </summary>
        [ForeignKey("UpdatedUserId")]
        public virtual ApplicationUser Updater { get; set; }

        public static explicit operator Employee(EmployeeMinimalDto Employee)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}