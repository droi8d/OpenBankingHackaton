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
    /// Klasa zapytania o transakcje / Transaction Information Request Class
    /// </summary>
    public partial class TransactionInfoRequest : TransactionInfoRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the TransactionInfoRequest class.
        /// </summary>
        public TransactionInfoRequest()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TransactionInfoRequest class.
        /// </summary>
        /// <param name="accountNumber">Numer rachunku / Account number</param>
        /// <param name="transactionIdFrom">Element filtru: transacje od
        /// podanego identyfikatora transakcji / Filter element</param>
        /// <param name="transactionDateFrom">Element filtru: data transakcji
        /// od, YYYY-MM-DD / Filter element</param>
        /// <param name="transactionDateTo">Element filtru: data transakcji do,
        /// YYYY-MM-DD / Filter element</param>
        /// <param name="bookingDateFrom">Element filtru: data księgowania od,
        /// YYYY-MM-DD / Filter element</param>
        /// <param name="bookingDateTo">Element filtru: data księgowania do,
        /// YYYY-MM-DD / Filter element</param>
        /// <param name="minAmount">Element filtru: kwota od / Filter
        /// element</param>
        /// <param name="maxAmount">Element filtru: kwota do / Filter
        /// element</param>
        /// <param name="pageId">Używane w celu stronicowania danych: numer
        /// transakcji rozpoczynający stronę / Transaction number beginning the
        /// page (paging info)</param>
        /// <param name="perPage">Używane w celu stronicowania danych: wielkość
        /// strony danych / Page size (paging info)</param>
        /// <param name="type">Element filtru: transakcji / Filter element.
        /// Possible values include: 'CREDIT', 'DEBIT'</param>
        public TransactionInfoRequest(RequestHeaderAIS requestHeader = default(RequestHeaderAIS), string accountNumber = default(string), string transactionIdFrom = default(string), System.DateTime? transactionDateFrom = default(System.DateTime?), System.DateTime? transactionDateTo = default(System.DateTime?), System.DateTime? bookingDateFrom = default(System.DateTime?), System.DateTime? bookingDateTo = default(System.DateTime?), string minAmount = default(string), string maxAmount = default(string), string pageId = default(string), double? perPage = default(double?), string type = default(string))
            : base(requestHeader, accountNumber, transactionIdFrom, transactionDateFrom, transactionDateTo, bookingDateFrom, bookingDateTo, minAmount, maxAmount, pageId, perPage)
        {
            Type = type;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets element filtru: transakcji / Filter element. Possible
        /// values include: 'CREDIT', 'DEBIT'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
        }
    }
}