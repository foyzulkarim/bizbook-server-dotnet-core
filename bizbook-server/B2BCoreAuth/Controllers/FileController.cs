
namespace B2BCoreApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using RequestModel.Customers;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Web;

    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/File")]
    public class FileController : Controller
    {

        private readonly IHostingEnvironment hostingEnvironment;
        public FileController(IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }

        [HttpPost]
        [ActionName("UploadImage")]
        [Route("UploadImage")]
        public async Task<ActionResult> UploadImage(CustomerImageRequestModel customerImageRequest)
        {
            //if (!this.Request.Content.IsMimeMultipartContent())
                //throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            //var rootPath = "C:/images";
            //string root = HttpContext.Current.Server.MapPath("~/App_Data");

            string rootPath = Path.Combine(hostingEnvironment.WebRootPath,"images");

            //return StatusCode(200,rootPath);
            //var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                // Read the form data.
                //await Request.Content.ReadAsMultipartAsync(provider);
                string CustomerImageType = customerImageRequest.CustomerImageType;

                string imageName = CustomerImageType+ ".jpeg";
                string folderName = customerImageRequest.FolderName;
                string id = customerImageRequest.Id;
                string subPart = Path.Combine(folderName,id);
                string fullPath = Path.Combine(rootPath,subPart);


                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }

                // Combine the path with the file name
                string fullFileLocation = Path.Combine(fullPath, imageName).ToLower();

                // If your case, you might just need to open your 
                // `keys.json` and append text on it.
                // Note that there is FileMode.Append too you might want to
                // take a look.
                using (var fileStream = new FileStream(fullFileLocation, FileMode.Create))
                {
                    await customerImageRequest.File.CopyToAsync(fileStream);
                }

               
               return StatusCode(200);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        [ActionName("GetImage")]
        [Route("GetImage")]
        public HttpResponseMessage GetImage(string folderName, string id, string name)
        {
            string rootPath = Path.Combine(hostingEnvironment.WebRootPath, "images");
            string subPart = Path.Combine(folderName, id);
            string fullPath = Path.Combine(rootPath, subPart);
            string fullFileLocation = Path.Combine(fullPath, name).ToLower();

            HttpResponseMessage response = new HttpResponseMessage();
            if (System.IO.File.Exists(fullFileLocation))
            {
                response.Content = new StreamContent(new FileStream(fullPath, FileMode.Open));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            }

            return response;
        }
    }

}
