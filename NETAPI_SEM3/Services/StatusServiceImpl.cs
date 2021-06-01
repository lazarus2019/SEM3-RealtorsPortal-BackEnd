using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public class StatusServiceImpl: StatusService
    {
        private readonly DatabaseContext DatabaseContext;

        public StatusServiceImpl(DatabaseContext db)
        {
            this.DatabaseContext = db;
        }

        public IEnumerable<Status> GetAllStatus()
        {
            return DatabaseContext.Statuses.ToList();
        }
    }
}
