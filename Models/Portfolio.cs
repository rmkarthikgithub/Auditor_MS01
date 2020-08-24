using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MC18_S1.Models
{
    public class Portfolio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int AuditId { get; set; }

        [ForeignKey("UserFK")]
        public AuditorUser AuditorId { get; set; }

        [Required(ErrorMessage = "Provide Portfolio Name")]
        [StringLength(50, MinimumLength = 3)]
        public string PortfolioName { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int UserFK { get; set; }
    }
}
