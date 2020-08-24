using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MC18_S1.Models
{
    public class RequestAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id;
        [ForeignKey("UserFK")]
        public AuditorUser AuditorId { get; set; }
        public int ClientId { get; set; }
        public string Comments { get; set; }
        public string Response { get; set; }
    }
}
