using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
	public class UserServiceImpl : UserService
	{
		#region Injection DB

		//private MyDBContext db;

		//public CategoryServiceImpl(MyDBContext _db)
		//{
		//	db = _db;
		//} 
		#endregion
		private DatabaseContext db;
		public UserServiceImpl(DatabaseContext _db)
		{
			db = _db;
		}

        public Setting GetSetting()
        {
			var setting = db.Settings.First();
			return setting;
        }
    }
}
