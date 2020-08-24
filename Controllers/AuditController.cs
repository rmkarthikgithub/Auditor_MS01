using MC18_S1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC18_S1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class AuditController : ControllerBase
    {
        private readonly ILogger<AuditController> _logger;
        private IDataAccess<AuditorUser> ctx;
        //public AuditController()
        //{
        //    this.ctx = new DataAccessRepository<Auditors>();
        //}
        public AuditController(ILogger<AuditController> logger, IDataAccess<AuditorUser> dataAccess)
        {
            _logger = logger;
            ctx = dataAccess;
        }

        [HttpGet]
        public IEnumerable<AuditorUser> GetAuditors()
        {
            return ctx.GetAll();
        }
        [HttpPost]
        public void PostAuditors(AuditorUser a)
        {
            ctx.Insert(a);
        }
        [HttpPut]
        public void updateAuditors(AuditorUser b)
        {
            ctx.Update(b);
        }
        [HttpDelete]
        public void DeleteAuditor(int Id)
        {
            ctx.Delete(Id);
        }
    }
}
