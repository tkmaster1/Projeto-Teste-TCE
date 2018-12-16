using System.Net.Http;
using System.Net.Http.Headers;

namespace Livraria.WebAPI_1.App_Start
{
    public class MultiFileUploadProvider : MultipartFormDataStreamProvider
    {
        public MultiFileUploadProvider(string rootPath) : base(rootPath) { }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            if (headers != null &&
                headers.ContentDisposition != null)
            {
                return headers
                    .ContentDisposition
                    .FileName.TrimEnd('"').TrimStart('"');
            }

            return base.GetLocalFileName(headers);
        }
    }
}