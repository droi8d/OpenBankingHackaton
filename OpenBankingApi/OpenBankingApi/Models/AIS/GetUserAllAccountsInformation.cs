namespace OpenBankingApi.Models.AIS
{
    public class GetUserAllAccountsInformation : AISRequestHeader
    {
        public GetUserAllAccountsInformation(string token, string requestId, string userAgent, string ipAddress, string sendDate, string tppId, string pageId, int perPage)
            : base(token, requestId, userAgent, ipAddress, sendDate, tppId)
        {
            this.isDirectPsu = true;
        }

        public bool isDirectPsu { get; set; }
        public string pageId { get; set; }
        public int perPage { get; set; }
    }
}