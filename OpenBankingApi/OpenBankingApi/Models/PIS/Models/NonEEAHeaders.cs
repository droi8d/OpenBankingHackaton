// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Api.Models.PIS
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Defines headers for nonEEA operation.
    /// </summary>
    public partial class NonEEAHeaders
    {
        /// <summary>
        /// Initializes a new instance of the NonEEAHeaders class.
        /// </summary>
        public NonEEAHeaders()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the NonEEAHeaders class.
        /// </summary>
        /// <param name="xJWSSIGNATURE">Detached JWS signature of the body of
        /// the response</param>
        public NonEEAHeaders(string xJWSSIGNATURE = default(string))
        {
            XJWSSIGNATURE = xJWSSIGNATURE;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets detached JWS signature of the body of the response
        /// </summary>
        [JsonProperty(PropertyName = "X-JWS-SIGNATURE")]
        public string XJWSSIGNATURE { get; set; }

    }
}
