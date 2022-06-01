using BusinessLayer.Conctrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
   
    public class DashBoardController : Controller
    {
        // GET: DashBoard

      
        PRODUCTManager pm = new PRODUCTManager(new EFPRODUCTDal());
        CATEGORYManager cm = new CATEGORYManager(new EFCATEGORYDal());
        public ActionResult Index()
        {
           var catlist =  cm.GetList();
            List<String> ListeM = new List<String>();

            foreach (var item in catlist)
            {

                int value =  pm.GetByContent((item.CATEGORYID)).Count();

                String Printt = item.CATEGORYNAME + " Kategorisi Toplam Ürün Sayısı " + value;
              ListeM.Add(Printt); 
            }



            ViewBag.values = ListeM;

            return View();
        }
    }
}