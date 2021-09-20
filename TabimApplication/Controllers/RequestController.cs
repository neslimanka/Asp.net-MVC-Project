using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TabimApplication.Models.DataContext;
using TabimApplication.Models.Model;

namespace TabimApplication.Controllers
{
    public class RequestController : Controller
    {

        TabimDBContext db = new TabimDBContext();

        public ActionResult Index()
        {
           
            var request = db.Request.ToList();
            var yetki = Session["AuthorizationId"].ToString();

            if (yetki.Equals("1"))
            {
                request = db.Request.Where(x => x.AssessmentStatus == " 2 ").OrderBy(x=>x.EvaluationTime).ToList();
            }
            else
            {
                request = db.Request.ToList();

            }
            return View(request);
        }



        public ActionResult Create()
        {
          

            return View();
        }



        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Request request)
        {

            if (ModelState.IsValid)
            {
               
                var stabil =" 2";
                request.AssessmentStatus = stabil.ToString();
                request.EvaluationTime = System.DateTime.Now;
                request.FeedBack = "Beklemede kalın.";
                request.Email = Session["Email"].ToString();
                
                db.Request.Add(request);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(request);

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek hizmet bulunamadı ";
            }
            var request = db.Request.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int? id, Request request)
        {

            if (Session["AuthorizationId"].ToString()=="1")
            {
                string sonuc;
                if (request.AssessmentStatus == "1")
                    sonuc = "Olumsuz";
                else
                    sonuc = "Olumlu";
                
                Contact contact = new Contact();
                Request TempEmail = db.Request.Where(x => x.RequestId == request.RequestId).FirstOrDefault();
                if (ModelState.IsValid)
                {
                    var body = new StringBuilder();
                    body.AppendLine("Ad & Soyad: " + request.RequestName+" "+request.RequestSurname);
                    body.AppendLine("E-Mail Adresi: " + TempEmail.Email.ToString());
                    body.AppendLine("Konu: " + "Talep Sonucu");
                    body.AppendLine("Mesaj: Sonuç "+sonuc+" Çünkü;" + request.FeedBack);
                    
                    Mail.MailSender(body.ToString(), TempEmail.Email.ToString());
                }
            }
           

            if (ModelState.IsValid)
            {
                var re = db.Request.Where(x => x.RequestId == id).SingleOrDefault();

                re.RequestId = request.RequestId;
                re.RequestName = request.RequestName;
                re.RequestSurname = request.RequestSurname;
                re.RequestDescription = request.RequestDescription;
                re.DocumentPath = request.DocumentPath;
                re.EvaluationTime = request.EvaluationTime;
                re.AssessmentStatus = request.AssessmentStatus;
                re.FeedBack = request.FeedBack;




             


                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int? id)
        {


            Request talep = db.Request.Find(id);
            if (talep == null)
            {
                return HttpNotFound();
            }
            return View(talep);

        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Request talep = db.Request.Find(id);
            db.Request.Remove(talep);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
       


        


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Request details = db.Request.Find(id);

            if (details == null)
            {
                return HttpNotFound();
            }
            return View(details);
        }

        public ActionResult GetData()
        {

            


               var request = db.Request.ToList();
                return Json(new { data = request }, JsonRequestBehavior.AllowGet);
            
               
           
        }


    }
    }



