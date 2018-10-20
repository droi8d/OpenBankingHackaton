// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Api.Models.AIS.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Klasa informacji o koncie / Account Information Class
    /// </summary>
    public partial class AccountInfo
    {
        /// <summary>
        /// Initializes a new instance of the AccountInfo class.
        /// </summary>
        public AccountInfo()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AccountInfo class.
        /// </summary>
        /// <param name="accountNumber">Numer rachunku / Account number</param>
        /// <param name="accountTypeName">Nazwa typu rachunku (definiowana
        /// przez Bank) / Account's type name (defined by ASPSP)</param>
        /// <param name="accountNameClient">Nazwa konta ustawiona przez klienta
        /// / Account name set by the client</param>
        /// <param name="currency">Waluta rachunku / Currency</param>
        /// <param name="availableBalance">Dostępne środki - po wykonaniu
        /// transakcji / Available funds</param>
        /// <param name="bookingBalance">Saldo księgowe rachunku - po wykonaniu
        /// transakcji / Book balance of the account</param>
        public AccountInfo(string accountNumber, NameAddress nameAddress, DictionaryItem accountType = default(DictionaryItem), string accountTypeName = default(string), string accountNameClient = default(string), string currency = default(string), string availableBalance = default(string), string bookingBalance = default(string), BankAccountInfo bank = default(BankAccountInfo), IDictionary<string, string> auxData = default(IDictionary<string, string>))
        {
            AccountNumber = accountNumber;
            NameAddress = nameAddress;
            AccountType = accountType;
            AccountTypeName = accountTypeName;
            AccountNameClient = accountNameClient;
            Currency = currency;
            AvailableBalance = availableBalance;
            BookingBalance = bookingBalance;
            Bank = bank;
            AuxData = auxData;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets numer rachunku / Account number
        /// </summary>
        [JsonProperty(PropertyName = "accountNumber")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nameAddress")]
        public NameAddress NameAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "accountType")]
        public DictionaryItem AccountType { get; set; }

        /// <summary>
        /// Gets or sets nazwa typu rachunku (definiowana przez Bank) /
        /// Account's type name (defined by ASPSP)
        /// </summary>
        [JsonProperty(PropertyName = "accountTypeName")]
        public string AccountTypeName { get; set; }

        /// <summary>
        /// Gets or sets nazwa konta ustawiona przez klienta / Account name set
        /// by the client
        /// </summary>
        [JsonProperty(PropertyName = "accountNameClient")]
        public string AccountNameClient { get; set; }

        /// <summary>
        /// Gets or sets waluta rachunku / Currency
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets dostępne środki - po wykonaniu transakcji / Available
        /// funds
        /// </summary>
        [JsonProperty(PropertyName = "availableBalance")]
        public string AvailableBalance { get; set; }

        /// <summary>
        /// Gets or sets saldo księgowe rachunku - po wykonaniu transakcji /
        /// Book balance of the account
        /// </summary>
        [JsonProperty(PropertyName = "bookingBalance")]
        public string BookingBalance { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "bank")]
        public BankAccountInfo Bank { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "auxData")]
        public IDictionary<string, string> AuxData { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (AccountNumber == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "AccountNumber");
            }
            if (NameAddress == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "NameAddress");
            }
            if (NameAddress != null)
            {
                NameAddress.Validate();
            }
            if (AccountTypeName != null)
            {
                if (AccountTypeName.Length > 32)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "AccountTypeName", 32);
                }
            }
            if (AccountNameClient != null)
            {
                if (AccountNameClient.Length > 32)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "AccountNameClient", 32);
                }
            }
            if (Currency != null)
            {
                if (Currency.Length > 3)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "Currency", 3);
                }
            }
            if (Bank != null)
            {
                Bank.Validate();
            }
        }
    }
}
