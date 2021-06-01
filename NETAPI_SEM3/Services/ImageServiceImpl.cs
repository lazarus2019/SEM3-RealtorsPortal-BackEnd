using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public class ImageServiceImpl: ImageService
    {
		private readonly DatabaseContext DatabaseContext;

		public ImageServiceImpl(DatabaseContext db)
		{
			this.DatabaseContext = db;
		}

		public bool createImage(Image image)
		{
			try
			{
				DatabaseContext.Images.Add(image);
				DatabaseContext.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool deleteImage(int imageId)
		{
			try
			{
				var Image = DatabaseContext.Images.Find(imageId);
				DatabaseContext.Images.Remove(Image);
				DatabaseContext.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool deleteImageByPropertyId(int PropertyId)
		{
			try
			{
				var Image = DatabaseContext.Images.Where(i => i.PropertyId == PropertyId).ToList();
				DatabaseContext.Images.RemoveRange(Image);
				DatabaseContext.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
