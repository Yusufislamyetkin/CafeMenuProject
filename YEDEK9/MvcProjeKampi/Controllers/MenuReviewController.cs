using BusinessLayer.Conctrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class MenuReviewController : Controller
    {
        // GET: ReadQr

       


        CATEGORYManager cm = new CATEGORYManager(new EFCATEGORYDal());
     
        PRODUCTPROPERTYManager ppm = new PRODUCTPROPERTYManager(new EFPRODUCTPROPERTYDal());






        public ActionResult PublicMenu()
        {

            var ListCategories = cm.GetList();

            return View(ListCategories);


        }

        public ActionResult PublicMenuContent(int id)
        {


            //var ListContent = pm.GetByContent(id);
            var ListContent = ppm.GetListCategory(id);



            return View(ListContent);


        }





    }
}