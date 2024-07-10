using LinBeach.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LinBeach.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        private readonly IImageRep imageRep;

        public ImagesController(IImageRep imageRep)
        {
            this.imageRep = imageRep;
        }
        [HttpPost]
        public async Task<IActionResult> UploadeAsync(IFormFile file)
        {
            var imageUrl = await imageRep.UploadAsync(file);
            if(imageUrl == null) 
            {
                return Problem("Something went wrong!", null, (int)HttpStatusCode.InternalServerError);
            }
            return Json(new { link = imageUrl });
        }
    }
}
