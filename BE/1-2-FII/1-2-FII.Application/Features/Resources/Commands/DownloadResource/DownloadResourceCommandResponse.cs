using _1_2_FII.Application.Responses;

namespace _1_2_FII.Application.Features.Resources.Commands.DownloadResource
{
    public class DownloadResourceCommandResponse : BaseResponse
    {
        public byte[] ResourceFileContent { get; set; }
        public string ResourceFileName { get; set; }
        public string ResourceContentType { get; set; }
        public DownloadResourceCommandResponse() : base()
        {
            
        }
    }
}
