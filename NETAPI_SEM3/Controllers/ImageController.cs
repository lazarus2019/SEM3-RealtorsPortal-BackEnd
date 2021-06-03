using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.Security;
using NETAPI_SEM3.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{

    [Route("api/image")]
    [ApiController]
    [MyAuthorize(Roles = "SuperAdmin,Admin")]
    public class ImageController : ControllerBase
    {
        private ImageService _imageService;
        private IWebHostEnvironment _iwebHostEnvironment;
        private readonly PropertyService _propertyService;

        public ImageController(IWebHostEnvironment iwebHostEnvironment, PropertyService propertyService, ImageService imageService)
        {
            this._iwebHostEnvironment = iwebHostEnvironment;
            this._propertyService = propertyService;
            this._imageService = imageService;
        }

        [DisableRequestSizeLimit]
        [HttpPost("upload/{id}/{directName}")]
        public IActionResult UploadNews(int id, string directName, IFormFile file)
        {

            try
            {
                var folderName = Path.Combine("images", directName);
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var dateTime = DateTime.Now.ToString("ddMMyyyyHHmmss");
                    var fileName = dateTime + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(_iwebHostEnvironment.WebRootPath, "images/" + directName, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    if (id != 0)
                    {
                        if (directName.ToLower().Equals("news"))
                        {

                        }
                        if (directName.ToLower().Equals("property"))
                        {
                            var result = createPropertyImage(id, fileName);
                            if (!result)
                            {
                                return StatusCode(500, "Lỗi k tạo được newsImage");
                            }
                        }
                    }
                    else
                    {
                        return StatusCode(500, "Lỗi k nhận được id");
                    }
                    return Ok();

                }
                else
                {
                    return StatusCode(500, "Lỗi truyền file");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpDelete("delete/{id}/{name}/{directName}")]
        public IActionResult DeleteImage(int id, string name, string directName)
        {
            var result = false;
            if (directName.ToLower().Equals("property"))
            {
                result = deletePropertyImage(id);
                if (!result)
                {
                    return StatusCode(500, "Can not delete file in database");
                }
            }
            if (directName.ToLower().Equals("property"))
            {

            }

            string fullPath = Path.Combine(_iwebHostEnvironment.WebRootPath, "images/" + directName, name);

            if (result)
            {
                if (System.IO.File.Exists(fullPath))
                {
                    try
                    {
                        System.IO.File.Delete(fullPath);
                        return Ok();
                    }
                    catch
                    {
                        return StatusCode(500, "Can not delete file folder wwwroot");
                    }
                }
            }
            else
            {
                return StatusCode(500, "Can not delete file in database");
            }

            return StatusCode(500, "Can not perform delete image in database & folder!");
        }


        public bool createPropertyImage(int propertyId, string fileName)
        {
            try
            {
                var image = new Image
                {
                    PropertyId = propertyId,
                    Name = fileName
                };
                var result = _imageService.createImage(image);
                if (!result)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool deletePropertyImage(int ImageId)
        {
            if (_imageService.deleteImage(ImageId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpDelete("delete/{id:int}")]
        public IActionResult DeleteImageByPropertyId(int id)
        {
            try
            {
                _imageService.deleteImageByPropertyId(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("getmaxpropertyimage")]
        public IActionResult GetMaxPropertyImage()
        {
            try
            {
                return Ok(_imageService.GetMaxNumberImageProperty());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}