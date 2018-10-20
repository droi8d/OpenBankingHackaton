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
        protected readonly X509Certificate2 _certificate = new X509Certificate2();

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