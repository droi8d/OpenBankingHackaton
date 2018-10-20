using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenBankingApi.Models
{
    using System.Net.Http;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using System.Threading.Tasks;
    using Jose;

    public class RequestSigningHandler : DelegatingHandler
    {
        private readonly X509Certificate2 _certificate;

        public RequestSigningHandler(X509Certificate2 certificate)
        {
            this._certificate = certificate;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var content = await request.Content.ReadAsByteArrayAsync();

            var contentJws = JWT.EncodeBytes(content, _certificate.GetRSAPrivateKey(), JwsAlgorithm.RS256);
            var startIndex = contentJws.IndexOf('.') + 1;
            var jwsSignature = contentJws.Remove(startIndex, contentJws.IndexOf('.', startIndex) - startIndex);

            request.Headers.Remove("X-JWS-SIGNATURE");
            request.Headers.TryAddWithoutValidation("X-JWS-SIGNATURE", "TURNOFFSIGNATUREVALIDATION");// jwsSignature);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}