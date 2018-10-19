/*
* Code is using jose-jwt nuget package
*/

using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Jose;

namespace OpenBankingApi.Handlers
{
    public class RequestSigningHandler : DelegatingHandler
    {
        private readonly X509Certificate2 _certificate = new X509Certificate2();

        public RequestSigningHandler() { }

        public static byte[] ReadFile(string fileName)
        {
            FileStream f = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            int size = (int)f.Length;
            byte[] data = new byte[size];
            size = f.Read(data, 0, size);
            f.Close();
            return data;
        }

        public RequestSigningHandler(X509Certificate2 certificate)
        {
            this._certificate = new X509Certificate2();
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var content = await request.Content.ReadAsByteArrayAsync();

            var path = "D:/cert/bank.millennium.psd2.sandbox.signing.hackathon.team.06.pfx";
            var cert = ReadFile(path);
            _certificate.Import(cert, "millennium", X509KeyStorageFlags.DefaultKeySet);

            var contentJws = JWT.Encode(content, _certificate.GetRSAPrivateKey(), JwsAlgorithm.RS256);
            var startIndex = contentJws.IndexOf('.') + 1;
            var jwsSignature = contentJws.Remove(startIndex, contentJws.IndexOf('.', startIndex) - startIndex);

            request.Headers.Remove("X-JWS-SIGNATURE");
            request.Headers.TryAddWithoutValidation("X-JWS-SIGNATURE", jwsSignature);
            request.Method = HttpMethod.Post;

            var postResult = new HttpResponseMessage();
            try
            {
                postResult = await base.SendAsync(request, cancellationToken);
            }
            catch(Exception e)
            {
                return postResult;
            }

            return postResult;
        }
    }
}
