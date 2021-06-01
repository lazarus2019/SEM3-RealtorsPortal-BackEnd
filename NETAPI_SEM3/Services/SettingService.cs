using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
	public interface SettingService
	{
		public Setting getSetting();

		public bool updateWebsiteSetting(Setting setting);
		public bool updateAdminSetting(Setting setting);
		public bool updateUserSetting(Setting setting);

		public bool updateThumbnailWebsite(string imageName);
		public bool updateThumbnailAboutUs(string imageName);
		public bool updateThumbnailHome(string imageName);

		public int getMaxNewsImage();
	}
}
