// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Api.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Klasa opisująca oczekującą transakcję płatniczą
    /// </summary>
    public partial class TransactionHoldInfo : TransactionInfoBase
    {
        /// <summary>
        /// Initializes a new instance of the TransactionHoldInfo class.
        /// </summary>
        public TransactionHoldInfo()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TransactionHoldInfo class.
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
        /// type (credit/debit). Possible values include: 'DEBIT'</param>
        /// <param name="holdExpirationDate">Data ważności blokady</param>
        public TransactionHoldInfo(string transactionId, string amount, string description, string transactionType, SenderRecipient sender, SenderRecipient recipient, string currency = default(string), System.DateTime? tradeDate = default(System.DateTime?), IDictionary<string, string> auxData = default(IDictionary<string, string>), string type = default(string), string holdExpirationDate = default(string), NameAddress initiator = default(NameAddress))
            : base(transactionId, amount, description, transactionType, currency, tradeDate, auxData)
        {
            Type = type;
            HoldExpirationDate = holdExpirationDate;
            Initiator = initiator;
            Sender = sender;
            Recipient = recipient;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets typ transakcji uznanie/obciążenie / Transaction type
        /// (credit/debit). Possible values include: 'DEBIT'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets data ważności blokady
        /// </summary>
        [JsonProperty(PropertyName = "holdExpirationDate")]
        public string HoldExpirationDate { get; set; }

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
        }
    }
}