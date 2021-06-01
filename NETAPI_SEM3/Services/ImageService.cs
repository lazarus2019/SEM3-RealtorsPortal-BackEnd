using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public interface ImageService
    {
        public bool createImage(Image image);

        public bool deleteImage(int imageId);

        public bool deleteImageByPropertyId(int PropertyId);

        public int GetMaxNumberImageProperty();
    }
}
