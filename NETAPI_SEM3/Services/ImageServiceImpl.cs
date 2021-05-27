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
		private readonly DatabaseContext _db;

		public ImageServiceImpl(DatabaseContext db)
		{
			this._db = db;
		}

		public bool createImage(Image image)
		{
			try
			{
				_db.Images.Add(image);
				_db.SaveChanges();
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
				var Image = _db.Images.Find(imageId);
				_db.Images.Remove(Image);
				_db.SaveChanges();
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
				var Image = _db.Images.Where(i => i.PropertyId == PropertyId).ToList();
				_db.Images.RemoveRange(Image);
				_db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
