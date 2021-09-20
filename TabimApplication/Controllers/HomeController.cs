using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TabimApplication.Models.DataContext;
using TabimApplication.Models.Model;

namespace TabimApplication.Controllers
{
    public class HomeController : Controller
    {

        TabimDBContext db = new TabimDBContext();
        // GET: Home
        public ActionResult Index()
        {
            var liste = db.Request.ToList();
            return View(liste);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {

            var login = db.User.Where(x => x.Email == user.Email && x.Password == user.Password).SingleOrDefault();
            if (login != null)
            {
                if (login.Email == user.Email && login.Password == user.Password)
                {

                    Session["UserId"] = login.UserId;
                    Session["Email"] = login.Email;
                    Session["AuthorizationId"] = login.AuthorizationId;
                    Session["Name"] = login.Name;
                    Session["Surname"] = login.Surname;
                    Session["Telephone"] = login.Telephone;

                    if (login.AuthorizationId==1)
                    {


                        return RedirectToAction("Index", "Home");
                    }
                    else if (login.AuthorizationId==2)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }


            }
            ViewBag.Uyari = "Kullanıcı Adı veya Şifre Yanlış";
            return View(user);
        }

        public ActionResult Logout()
        {

            Session["UserId"] = null;
            Session["Email"] = null;
            Session["AuthorizationId"] = null;
            Session["Name"] = null;
            Session["Surname"] = null;
            Session["Telephone" ]= null;

            Session.Abandon();

            return RedirectToAction("Login", "Home");

        }

        public ActionResult Signup()
        {

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Signup(User user)
        {
            if (ModelState.IsValid)
                //doğrulama
            {
                using (var database = new TabimDBContext())
                {
                    User reg = new User();

                    reg.Name = user.Name;
                    reg.Surname = user.Surname;
                    reg.Email = user.Email;
                    reg.AuthorizationId = user.AuthorizationId;
                    reg.Telephone = user.Telephone;

                  

                }
                user.AuthorizationId = 2;
                db.User.Add(user);
                db.SaveChanges();

                ViewBag.Message = "User Details Saved";


                return RedirectToAction("Login","Home");



            }
            else
            {
                return View(user);

            }

        }



    }
}