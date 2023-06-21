using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace MK.Accountancy.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        const long MaxFileSize = 4_000_000;
        readonly string[] imageExtensions = { ".JPG", ".JPEG", ".GIF", ".PNG" };
        private readonly IWebHostEnvironment _environment;

        public UploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("[action]")]
        public ActionResult Upload(IFormFile myFile,string guid)
        {
            try
            {
                var extension = Path.GetExtension(myFile.FileName).ToUpperInvariant();
                var isValidExtenstion = imageExtensions.Contains(extension);
                var isValidSize = myFile.Length <= MaxFileSize;
                if (!isValidExtenstion || !isValidSize)
                    throw new InvalidOperationException();

                var webRootPath = _environment.WebRootPath;
                var fileName = guid + ".png";
                var filePath = Path.Combine(webRootPath, "Files", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    myFile.CopyTo(fileStream);

                }
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
