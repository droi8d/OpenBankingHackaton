// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Api.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Klasa zapytania o usunięcie zgody na dostęp do AIS
    /// </summary>
    public partial class DeleteConsentRequest
    {
        /// <summary>
        /// Initializes a new instance of the DeleteConsentRequest class.
        /// </summary>
        public DeleteConsentRequest()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DeleteConsentRequest class.
        /// </summary>
        /// <param name="consentId">Identyfikator zgody / Consent ID</param>
        public DeleteConsentRequest(string consentId)
        {
            ConsentId = consentId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets identyfikator zgody / Consent ID
        /// </summary>
        [JsonProperty(PropertyName = "consentId")]
        public string ConsentId { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ConsentId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ConsentId");
            }
        }
    }
}
