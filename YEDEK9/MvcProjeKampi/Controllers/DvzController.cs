using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            XmlDocument xml = new XmlDocument(); // yeni bir XML dökümü oluşturuyoruz.
            xml.Load("http://www.tcmb.gov.tr/kurlar/today.xml"); // bağlantı kuruyoruz.
            var Tarih_Date_Nodes = xml.SelectSingleNode("//Tarih_Date"); // Count değerini olmak için ana boğumu seçiyoruz.
            var CurrencyNodes = Tarih_Date_Nodes.SelectNodes("//Currency"); // ana boğum altındaki kur boğumunu seçiyoruz.
            int CurrencyLength = CurrencyNodes.Count; // toplam kur boğumu sayısını elde ediyor ve for döngüsünde kullanıyoruz.

            List<_Doviz> dovizler = new List<_Doviz>(); // Aşağıda oluşturduğum public class ile bir List oluşturuyoruz.
            List<string> dovizlerNew = new List<string>(); // Aşağıda oluşturduğum public class ile bir List oluşturuyoruz.
            List<string> dovizler5 = new List<string>(); // Aşağıda oluşturduğum public class ile bir List oluşturuyoruz.
            for (int i = 0; i < CurrencyLength; i++) // for u çalıştırıyoruz.
            {
                var cn = CurrencyNodes[i]; // kur boğumunu alıyoruz.
                // Listeye kur bilgirini ekliyoruz.
                dovizler.Add(new _Doviz
                {
                    Kod = cn.Attributes["Kod"].Value,
                   
                    ForexBuying =    cn.ChildNodes[3].InnerXml,
                    
                });
            }
           
              
            foreach (var item in dovizler)
            {

            

             
                    


                dovizlerNew.Add(item.ForexBuying.ToString() +" " + item.Kod);
                


            }

            for (int i = 0; i < 5; i++)
            {
                dovizler5.Add(dovizlerNew[i]);
            }
            ViewData["dovizler5"] = dovizler5; // dovizler List değerini data ya atıyoruz ön tarafta viewbag ile çekeceğiz.
            return View();
        }

        public class _Doviz
        {
           
            public string Kod { get; set; }
         
            public string ForexBuying { get; set; }
      
        }
    }
}