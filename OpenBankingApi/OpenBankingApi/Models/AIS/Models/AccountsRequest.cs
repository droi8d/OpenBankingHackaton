// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Api.Models.AIS.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Klasa zapytania o rachunki / Accounts Request Class
    /// </summary>
    public partial class AccountsRequest
    {
        /// <summary>
        /// Initializes a new instance of the AccountsRequest class.
        /// </summary>
        public AccountsRequest()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AccountsRequest class.
        /// </summary>
        /// <param name="isDirectPsu">Znacznik informujący czy request jest
        /// przesłany bezpośrednio przez PSU / Is request sent by PSU
        /// directly</param>
        /// <param name="pageId">Używane w celu stronicowania danych: numer
        /// rachunku rozpoczynający stronę / Account number beginning the page
        /// (paging info)</param>
        /// <param name="perPage">Używane w celu stronicowania danych: wielkość
        /// strony danych / Page size (paging info)</param>
        public AccountsRequest(RequestHeaderAIS requestHeader, bool? isDirectPsu = default(bool?), string pageId = default(string), double? perPage = default(double?))
        {
            RequestHeader = requestHeader;
            IsDirectPsu = isDirectPsu;
            PageId = pageId;
            PerPage = perPage;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "requestHeader")]
        public RequestHeaderAIS RequestHeader { get; set; }

        /// <summary>
        /// Gets or sets znacznik informujący czy request jest przesłany
        /// bezpośrednio przez PSU / Is request sent by PSU directly
        /// </summary>
        [JsonProperty(PropertyName = "isDirectPsu")]
        public bool? IsDirectPsu { get; set; }

        /// <summary>
        /// Gets or sets używane w celu stronicowania danych: numer rachunku
        /// rozpoczynający stronę / Account number beginning the page (paging
        /// info)
        /// </summary>
        [JsonProperty(PropertyName = "pageId")]
        public string PageId { get; set; }

        /// <summary>
        /// Gets or sets używane w celu stronicowania danych: wielkość strony
        /// danych / Page size (paging info)
        /// </summary>
        [JsonProperty(PropertyName = "perPage")]
        public double? PerPage { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (RequestHeader == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "RequestHeader");
            }
            if (RequestHeader != null)
            {
                RequestHeader.Validate();
            }
        }
    }
}
