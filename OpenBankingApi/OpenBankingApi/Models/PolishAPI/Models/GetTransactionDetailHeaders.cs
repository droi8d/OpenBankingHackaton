// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Api.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Defines headers for getTransactionDetail operation.
    /// </summary>
    public partial class GetTransactionDetailHeaders
    {
        /// <summary>
        /// Initializes a new instance of the GetTransactionDetailHeaders
        /// class.
        /// </summary>
        public GetTransactionDetailHeaders()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the GetTransactionDetailHeaders
        /// class.
        /// </summary>
        /// <param name="contentEncoding">Gzip, deflate</param>
        /// <param name="xJWSSIGNATURE">Detached JWS signature of the body of
        /// the response</param>
        public GetTransactionDetailHeaders(string contentEncoding = default(string), string xJWSSIGNATURE = default(string))
        {
            ContentEncoding = contentEncoding;
            XJWSSIGNATURE = xJWSSIGNATURE;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets gzip, deflate
        /// </summary>
        [JsonProperty(PropertyName = "Content-Encoding")]
        public string ContentEncoding { get; set; }

        /// <summary>
        /// Gets or sets detached JWS signature of the body of the response
        /// </summary>
        [JsonProperty(PropertyName = "X-JWS-SIGNATURE")]
        public string XJWSSIGNATURE { get; set; }

    }
}
