// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Api.Models.PIS
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Klasa zlecenia przelewu zagranicznego SEPA / EEA Transfer Request Class
    /// </summary>
    public partial class PaymentEEARequest
    {
        /// <summary>
        /// Initializes a new instance of the PaymentEEARequest class.
        /// </summary>
        public PaymentEEARequest()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PaymentEEARequest class.
        /// </summary>
        /// <param name="tppTransactionId">ID transakcji nadany przez TPP /
        /// Transaction ID (TPP)</param>
        /// <param name="deliveryMode">Tryb pilności / Urgency mode. Possible
        /// values include: 'ExpressD0', 'StandardD1'</param>
        /// <param name="system">Droga jaką przelew ma być rozliczony / The way
        /// the transfer should be settled. Possible values include: 'SEPA',
        /// 'InstantSEPA', 'Target'</param>
        /// <param name="hold">Czy założyć blokadę (w przypadku np. zlecenia
        /// przelewu w dniu wolnym) / Indicates if payment should be
        /// holded</param>
        public PaymentEEARequest(RequestHeaderCallback requestHeader, RecipientPISForeign recipient, SenderPIS sender, TransferData transferData, string tppTransactionId, string deliveryMode, string system = default(string), bool? hold = default(bool?))
        {
            RequestHeader = requestHeader;
            Recipient = recipient;
            Sender = sender;
            TransferData = transferData;
            TppTransactionId = tppTransactionId;
            DeliveryMode = deliveryMode;
            System = system;
            Hold = hold;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "requestHeader")]
        public RequestHeaderCallback RequestHeader { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "recipient")]
        public RecipientPISForeign Recipient { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sender")]
        public SenderPIS Sender { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "transferData")]
        public TransferData TransferData { get; set; }

        /// <summary>
        /// Gets or sets ID transakcji nadany przez TPP / Transaction ID (TPP)
        /// </summary>
        [JsonProperty(PropertyName = "tppTransactionId")]
        public string TppTransactionId { get; set; }

        /// <summary>
        /// Gets or sets tryb pilności / Urgency mode. Possible values include:
        /// 'ExpressD0', 'StandardD1'
        /// </summary>
        [JsonProperty(PropertyName = "deliveryMode")]
        public string DeliveryMode { get; set; }

        /// <summary>
        /// Gets or sets droga jaką przelew ma być rozliczony / The way the
        /// transfer should be settled. Possible values include: 'SEPA',
        /// 'InstantSEPA', 'Target'
        /// </summary>
        [JsonProperty(PropertyName = "system")]
        public string System { get; set; }

        /// <summary>
        /// Gets or sets czy założyć blokadę (w przypadku np. zlecenia przelewu
        /// w dniu wolnym) / Indicates if payment should be holded
        /// </summary>
        [JsonProperty(PropertyName = "hold")]
        public bool? Hold { get; set; }

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
            if (Recipient == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Recipient");
            }
            if (Sender == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Sender");
            }
            if (TransferData == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "TransferData");
            }
            if (TppTransactionId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "TppTransactionId");
            }
            if (DeliveryMode == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DeliveryMode");
            }
            if (RequestHeader != null)
            {
                RequestHeader.Validate();
            }
            if (Recipient != null)
            {
                Recipient.Validate();
            }
            if (Sender != null)
            {
                Sender.Validate();
            }
            if (TransferData != null)
            {
                TransferData.Validate();
            }
            if (TppTransactionId != null)
            {
                if (TppTransactionId.Length > 64)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "TppTransactionId", 64);
                }
            }
        }
    }
}
