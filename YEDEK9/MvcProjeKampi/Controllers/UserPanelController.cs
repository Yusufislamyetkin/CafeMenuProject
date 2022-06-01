using BusinessLayer.Conctrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class UserPanelController : Controller
    {

        UserManager um = new UserManager(new EFUserDal());
        CATEGORYManager cm = new CATEGORYManager(new EFCATEGORYDal());
        PRODUCTManager pm = new PRODUCTManager(new EFPRODUCTDal());
        PROPERTYManager pp = new PROPERTYManager(new EFPROPERTYDal());
        PRODUCTPROPERTYManager ppm = new PRODUCTPROPERTYManager(new EFPRODUCTPROPERTYDal());



        public User SessionValue()
        {
            string p;
            p = (string)Session["USERNAME"];
            var UserValue = um.GetSessionValue(p);
            return UserValue;
        }

    



        [HttpGet]
        public ActionResult MenuCategoryAdd()
        {

            return View();
        }
        [HttpPost]
        public ActionResult MenuCategoryAdd(CATEGORY cat)
        {

            cat.CREATORUSERID = SessionValue().USERID;


            Random randm = new Random();

     

            if (Request.Files.Count > 0)
            {
                string rdn = Convert.ToString(randm.Next(0, 9999));
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/ımage/" + filename + rdn + uzanti;

                if (filename == "")
                {
                    cat.CATEGORYIMAGE = "/Extra/images/fooddef.png";
                }
                else
                {
                    if (yol == "~/ımage/")
                    {

                    }
                    else
                    {

                        Request.Files[0].SaveAs(Server.MapPath(yol));


                        cat.CATEGORYIMAGE = "/ımage/" + filename + rdn + uzanti;


                    }
                }


            }

            DateTime dt = DateTime.Parse(DateTime.Now.ToLongDateString());
            cat.CREATEDDATE = dt;

            CategoryValidatior cv = new CategoryValidatior();
            ValidationResult results = cv.Validate(cat);
            if (results.IsValid)
            {
                cm.AddValue(cat);
                TempData["AlertMessage1"] = "Menü Kategoriniz Eklendi.";
                return RedirectToAction("MenuCategoryAdd");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }

                return View();
            }


          


            
           
        }


        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {


            var catupdatevalue = cm.GetByID(id);


            return View(catupdatevalue);
        }

        [HttpPost]
        public ActionResult UpdateCategory(CATEGORY value)
        {


            Random randm = new Random();

            var valueforupdate = cm.GetByID(value.CATEGORYID);

            if (Request.Files.Count > 0 || Request.PathInfo != "")
            {
                string rdn = Convert.ToString(randm.Next(0, 9999));
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/ımage/" + filename + rdn + uzanti;

                if (filename == "")
                {


                    string valueımage = valueforupdate.CATEGORYIMAGE;

                    value.CATEGORYIMAGE = valueımage;

                }
                else
                {
                    if (yol == "~/ımage/")
                    {

                    }
                    else
                    {

                        Request.Files[0].SaveAs(Server.MapPath(yol));


                        value.CATEGORYIMAGE = "/ımage/" + filename + rdn + uzanti;


                    }
                }


            }




            var valueid = valueforupdate.CATEGORYID;

            value.CREATEDDATE = DateTime.Parse(DateTime.Now.ToLongTimeString());


            CategoryValidatior cv = new CategoryValidatior();
            ValidationResult results = cv.Validate(value);
            if (results.IsValid)
            {
                cm.CategoryUpdate(value, valueid);
                TempData["AlertMessage3"] = "Seçilen Kategori Güncellendi.";
            
                return RedirectToAction("SeeMenuCategories");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }

                return View(valueforupdate);
            }

       

         

      
           
        }




        public ActionResult SeeMenuCategories()
        {
            ViewBag.uservalue = SessionValue();

            var ListCategories = cm.GetList();

            return View(ListCategories);
        }


        public ActionResult SeeMenuList()
        {
            ViewBag.uservalue = SessionValue();

            var ListCategories = cm.GetByUserID(SessionValue().USERID);

            return View(ListCategories);
        }

 

        public ActionResult EditMenuContent(int id)
        {


            var ListValue = ppm.GetListCategory(id);

            return View(ListValue);
        }

        [HttpGet]
        public ActionResult EditMenuContentPage(int id)
        {

            var value = pm.GetByIDProduct(id);


            return View(value);
        }

        [HttpPost]
        public ActionResult EditMenuContentPage(PRODUCT p)
        {

            Random randm = new Random();

            if (Request.Files.Count > 0 || Request.PathInfo != "")
            {
                string rdn = Convert.ToString(randm.Next(0, 9999));
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/ımage/" + filename + rdn + uzanti;

                var getvalue = cm.GetByID(p.CATEGORYID);
                if (filename == "")
                {


                    string valueımage = getvalue.CATEGORYIMAGE;

                    p.IMAGEPATH = valueımage;

                }
                else
                {
                    if (yol == "~/ımage/")
                    {

                    }
                    else
                    {

                        Request.Files[0].SaveAs(Server.MapPath(yol));


                        p.IMAGEPATH = "/ımage/" + filename + rdn + uzanti;


                    }
                }


            }

            p.CREATEDDATE = DateTime.Parse(DateTime.Now.ToLongTimeString());

            pm.PRODUCTUpdate(p);
            
           
            return RedirectToAction("UpdateProp", new { id = p.PRODUCTID });
        }

        [HttpGet]
        public ActionResult UpdateProp(int id)
        {
            var value = ppm.GetProp(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProp(PROPERTY P)
        {



            var forıd = pm.GetByIDProduct(P.KEY);

          

            pp.PROPERTYUpdate(P);

            var updatePp = ppm.GetProp(P.KEY);

            updatePp.PRODUCTID = P.KEY;
            updatePp.PROPERTYID = P.PROPERTYID;

            ppm.PRODUCTPROPERTYUpdate(updatePp);
            TempData["AlertMessageContent001"] = "Ürün Güncellendi.";
            return RedirectToAction("EditMenuContent", new { id = forıd.CATEGORYID });

        }


        public ActionResult DeleteMenuContent(int id)
        {
            var value = pm.GetByIDProduct(id);
            value.ISDELETED = true;

            pm.PRODUCTUpdate(value);

            TempData["AlertMessageDelete"] = "Seçilen İçerik Silindi.";
            return RedirectToAction("EditMenuContent", new { id = value.CATEGORYID });
        }


       

        public ActionResult DeleteCategory(int id)
        {


            var catdeletevalue = cm.GetByID(id);
            catdeletevalue.ISDELETED = true;
            cm.CategoryUpdate(catdeletevalue, catdeletevalue.CATEGORYID);
            TempData["AlertMessage1"] = "Seçilen Kategori Silindi.";
            return RedirectToAction("SeeMenuCategories");
        }





        [HttpGet]
        public ActionResult AddProp(int id)
        {
            var value = pm.GetByIDProduct(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult AddProp(PROPERTY P)
        {



            var forıd = pm.GetByIDProduct(P.KEY);

            pp.AddValue(P);

            PRODUCTPROPERTY ppForAdd = new PRODUCTPROPERTY();
            ppForAdd.PRODUCTID = P.KEY;
            ppForAdd.PROPERTYID = P.PROPERTYID;
            ppm.AddValue(ppForAdd);
            TempData["AlertMessageContent01"] = "Yeni Ürün Eklendi.";
            return RedirectToAction("AddContent", new { id = forıd.CATEGORYID });

        }



        [HttpGet]
        public ActionResult AddContent(int id)
        {
            var value = cm.GetByID(id);


            return View(value);




        }






        [HttpPost]
        public ActionResult AddContent(PRODUCT p)
        {

            try
            {

                Random randm = new Random();



                if (Request.Files.Count > 0 || Request.PathInfo != "")
                {
                    string rdn = Convert.ToString(randm.Next(0, 9999));
                    string filename = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/ımage/" + filename + rdn + uzanti;

                    var getvalue = cm.GetByID(p.CATEGORYID);
                    if (filename == "")
                    {


                        string valueımage = getvalue.CATEGORYIMAGE;

                        p.IMAGEPATH = valueımage;

                    }
                    else
                    {
                        if (yol == "~/ımage/")
                        {

                        }
                        else
                        {

                            Request.Files[0].SaveAs(Server.MapPath(yol));


                            p.IMAGEPATH = "/ımage/" + filename + rdn + uzanti;


                        }
                    }


                }


                p.CREATEDDATE = DateTime.Parse(DateTime.Now.ToLongTimeString());
                p.CREATORUSERID = SessionValue().USERID;
                p.ISDELETED = false;

                pm.AddValue(p);



            }
            catch
            {
                TempData["AlertMessageContent2"] = "Ekleme tamamlanmadı.";
            }

            return RedirectToAction("AddProp", new { id = p.PRODUCTID });
        }






    }
}