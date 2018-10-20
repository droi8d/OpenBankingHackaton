// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Api.Models.AIS.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Klasa opisująca odrzuconą transakcję płatniczą
    /// </summary>
    public partial class TransactionRejectedInfo : TransactionInfoBase
    {
        /// <summary>
        /// Initializes a new instance of the TransactionRejectedInfo class.
        /// </summary>
        public TransactionRejectedInfo()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TransactionRejectedInfo class.
        /// </summary>
        /// <param name="transactionId">ID transakcji nadany przez ASPSP /
        /// Transaction ID (ASPSP)</param>
        /// <param name="amount">Kwota transakcji / Amount of the
        /// transaction</param>
        /// <param name="description">Tytuł transakcji / Description of the
        /// transaction</param>
        /// <param name="transactionType">Typ transakcji / Transaction
        /// type</param>
        /// <param name="currency">Kod ISO waluty transakcji / Currency
        /// (ISO)</param>
        /// <param name="tradeDate">Data operacji, YYYY-MM-DDThh:mm:ss[.mmm] /
        /// Date of the operation</param>
        /// <param name="type">Typ transakcji uznanie/obciążenie / Transaction
        /// type (credit/debit). Possible values include: 'CREDIT',
        /// 'DEBIT'</param>
        /// <param name="rejectionReason">Powod odrzucenia</param>
        /// <param name="rejectionDate">Data odrzucenia,
        /// YYYY-MM-DDThh:mm:ss[.mmm]</param>
        public TransactionRejectedInfo(string transactionId, string amount, string description, string transactionType, SenderRecipient sender, SenderRecipient recipient, string currency = default(string), System.DateTime? tradeDate = default(System.DateTime?), IDictionary<string, string> auxData = default(IDictionary<string, string>), string type = default(string), NameAddress initiator = default(NameAddress), string rejectionReason = default(string), System.DateTime? rejectionDate = default(System.DateTime?))
            : base(transactionId, amount, description, transactionType, currency, tradeDate, auxData)
        {
            Type = type;
            Initiator = initiator;
            Sender = sender;
            Recipient = recipient;
            RejectionReason = rejectionReason;
            RejectionDate = rejectionDate;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets typ transakcji uznanie/obciążenie / Transaction type
        /// (credit/debit). Possible values include: 'CREDIT', 'DEBIT'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "initiator")]
        public NameAddress Initiator { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sender")]
        public SenderRecipient Sender { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "recipient")]
        public SenderRecipient Recipient { get; set; }

        /// <summary>
        /// Gets or sets powod odrzucenia
        /// </summary>
        [JsonProperty(PropertyName = "rejectionReason")]
        public string RejectionReason { get; set; }

        /// <summary>
        /// Gets or sets data odrzucenia, YYYY-MM-DDThh:mm:ss[.mmm]
        /// </summary>
        [JsonConverter(typeof(DateJsonConverter))]
        [JsonProperty(PropertyName = "rejectionDate")]
        public System.DateTime? RejectionDate { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
            if (Sender == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Sender");
            }
            if (Recipient == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Recipient");
            }
            if (Initiator != null)
            {
                Initiator.Validate();
            }
            if (Sender != null)
            {
                Sender.Validate();
            }
            if (Recipient != null)
            {
                Recipient.Validate();
            }
            if (RejectionReason != null)
            {
                if (RejectionReason.Length > 140)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "RejectionReason", 140);
                }
            }
        }
    }
}
