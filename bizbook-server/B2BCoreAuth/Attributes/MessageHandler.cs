using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace B2BCoreApi.Attributes
{
    public class MessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var r = request;
            return base.SendAsync(request, cancellationToken);
        }
    }
}