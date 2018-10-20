using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenBankingApi.Controllers
{
    using System.IO;
    using System.Security.Cryptography.X509Certificates;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        protected readonly X509Certificate2 _signCertificate = new X509Certificate2();
        protected readonly X509Certificate2 _tlsCertificate = new X509Certificate2();

        protected readonly string signCertPath = @"C:\Certificates\bank.millennium.psd2.sandbox.signing.hackathon.team.06.pfx";
        protected readonly string tlsCertPath = @"C:\Certificates\bank.millennium.psd2.sandbox.tls.hackathon.team.06.pfx";

        protected static byte[] ReadFile(string fileName)
        {
            FileStream f = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            int size = (int)f.Length;
            byte[] data = new byte[size];
            size = f.Read(data, 0, size);
            f.Close();
            return data;
        }
    }
}