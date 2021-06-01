using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
	public class SettingServiceServiceImpl : SettingService
	{
		#region Injection DB

		private ProjectSem3DBContext db;

		public SettingServiceServiceImpl(ProjectSem3DBContext _db)
		{
			db = _db;
		}

		#endregion

		public Setting getSetting()
		{
			return db.Settings.First();
		}

		#region Update Setting

		public bool updateAdminSetting(Setting setting)
		{
			try
			{
				var oldSetting = db.Settings.First();
				oldSetting.NumMaxImageProperty = setting.NumMaxImageProperty;
				oldSetting.NumMaxImageNews = setting.NumMaxImageNews;
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool updateUserSetting(Setting setting)
		{
			try
			{
				var oldSetting = db.Settings.First();
				oldSetting.NumTopProperty = setting.NumTopProperty;
				oldSetting.NumPopularLocation = setting.NumPopularLocation;
				oldSetting.NumNews = setting.NumNews;
				oldSetting.NumPopularAgent = setting.NumPopularAgent;
				oldSetting.NumProperty = setting.NumProperty;
				oldSetting.NumSatisfiedCustomer = setting.NumSatisfiedCustomer;
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool updateWebsiteSetting(Setting setting)
		{
			try
			{
				var oldSetting = db.Settings.First();
				oldSetting.Phone = setting.Phone;
				oldSetting.Email = setting.Email;
				oldSetting.Address = setting.Address;
				oldSetting.Description = setting.Description;
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}
		#endregion


		#region Update Setting Thumbnail

		public bool updateThumbnailAboutUs(string imageName)
		{
			try
			{
				var oldSetting = db.Settings.First();
				oldSetting.ThumbnailAboutUs = imageName;
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}

		}

		public bool updateThumbnailHome(string imageName)
		{
			try
			{
				var oldSetting = db.Settings.First();
				oldSetting.ThumbnailHome = imageName;
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool updateThumbnailWebsite(string imageName)
		{
			try
			{
				var oldSetting = db.Settings.First();
				oldSetting.ThumbnailWebsite = imageName;
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		#endregion
		#region Get max amount

		public int getMaxNewsImage()
		{
			return db.Settings.First().NumMaxImageNews;
		}

		#endregion
	}
}
