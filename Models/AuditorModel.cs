using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MC18_S1.Models
{
    public class AuditorUser
    {
        //    public int UID;
        //    public string Name;
        //    public string UserName;
        //    public string UserPassword;
        //    public string Address;
        //    public string EMail;
        //    public string CreatedBy;
        //    public DateTime CreatedDate;
        //    public string ModifiedBy;
        //    public DateTime ModifiedDate;
        //    public string IsActive;
        //}

        //public class AuditorUserContext : DbContext
        //{
        //    public AuditorUserContext(DbContextOptions<AuditorUserContext> options)
        //        : base(options)
        //    {
        //    }

        //    public DbSet<AuditorUser> TodoItems { get; set; }
        //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Provide Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Length should be 2 to 100 character")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Provide Password")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Length should be 2 to 100 character")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Provide City")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Length should be 2 to 500 character")]
        public string Address { get; set; }
    }
    public class AuditorUserContext : DbContext
    {
        public AuditorUserContext()
        {
        }
        public AuditorUserContext(DbContextOptions opts) : base(opts)
        {
        }
        public DbSet<AuditorUser> Auditors { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }
        public DbSet<RequestAudit> RequestAudit { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
