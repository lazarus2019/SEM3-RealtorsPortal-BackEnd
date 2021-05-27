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
        private readonly DatabaseContext _db;

        public StatusServiceImpl(DatabaseContext db)
        {
            this._db = db;
        }

        public IEnumerable<Status> GetAllStatus()
        {
            return _db.Statuses.ToList();
        }
    }
}
