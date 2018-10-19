namespace OpenBankingApi.Models
{
    public class AISRequestHeader
    {
        public AISRequestHeader(string token, string requestId, string userAgent, string ipAddress, string sendDate, string tppId)
        {
            this.token = token;
            this.isDirectPsu = true;
            this.requestId = requestId;
            this.userAgent = userAgent;
            this.ipAddress = ipAddress;
            this.sendDate = sendDate;
            this.tppId = tppId;
        }

        public string token { get; set; }
        public bool isDirectPsu { get; set; }
        public string requestId { get; set; }
        public string userAgent { get; set; }
        public string ipAddress { get; set; }
        public string sendDate { get; set; }
        public string tppId { get; set; }
    }
}