using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using System.Net.Http.Headers;
namespace Hyde.Api.Controllers
{
    public class FileController : ApiController
    {
        [HttpPost]

        public async Task<HttpResponseMessage> UploadFile()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

           

            string fileSaveLocation = System.Web.HttpContext.Current.Server.MapPath("~/App_File");

            CustomMultipartFormDataStreamProvider provider = new CustomMultipartFormDataStreamProvider(fileSaveLocation);

            try
            {
                // Read all contents of multipart message into CustomMultipartFormDataStreamProvider.
                await Request.Content.ReadAsMultipartAsync(provider);
                // Send OK Response along with saved file names to the client.
                return Request.CreateResponse(HttpStatusCode.OK, provider.FileData.Select(t => t.LocalFileName));
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
        {
            public CustomMultipartFormDataStreamProvider(string path) : base(path) { }

            public override string GetLocalFileName(HttpContentHeaders headers)
            {
                return headers.ContentDisposition.FileName.Replace("\"", string.Empty);
            }

        }

    }
}
