using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ProjectsManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        public static IHostingEnvironment _environment;

        public ImageController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public async Task<string> Post(IFormFile file)
        {
            if (file.Length > 0)
            {
                try
                {
                    if (!Directory.Exists("wwwroot\\images\\"))
                    {
                        Directory.CreateDirectory("wwwroot\\images\\");
                    }

                    using (FileStream fileStream = System.IO.File.Create("wwwroot\\images\\" + file.FileName))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();

                        return "wwwroot\\images\\" + file.FileName;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Unsuccessful";
            }
        }
    }
}
