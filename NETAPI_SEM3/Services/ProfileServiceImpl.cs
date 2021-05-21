using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
	public class ProfileServiceImpl : ProfileService
	{
		#region Injection DB

		private ProjectSem3DBContext db;

		public ProfileServiceImpl(ProjectSem3DBContext _db)
		{
			db = _db;
		}

		#endregion

	}
}
