using JurisprudenceFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Providers.Entities;

namespace JurisprudenceFinal.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Login(string redirectUrl)
        {
            if (Session["Username"] == null)
            {
                return View();
            }
            else
            {
                return this.Redirect(redirectUrl);
            }
        }

        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            JurisprudenceDBEntities _db = new JurisprudenceDBEntities();
            if (ModelState.IsValid)
            {
                string username = fc["email"];

                string password = fc["password"];
                try
                {
                    tbl_User tb = _db.tbl_User.Single(u => u.Email == username && u.Password == password);
                    if (tb != null)
                    {
                        Session.Add("Username", username);
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (Exception)
                {
                    ViewBag.Message = "Username or Password does not match";
                }
            }
            ModelState.AddModelError("", "Please write first name.");
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            Session["Username"] = "";
            return RedirectToAction("Home", "Home");
        }

        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAccount(FormCollection fc)
        {
            if (ModelState.IsValid)
            {
                JurisprudenceDBEntities _db = new JurisprudenceDBEntities();
                tbl_User umc = new tbl_User();

                umc.Name = fc["name"];
                umc.Email = fc["email"];
                umc.Contact = fc["contact"];
                umc.Address = fc["address"];
                umc.Username = fc["username"];
                umc.Password = fc["password"];
                umc.AddedDate = DateTime.Now.ToShortDateString();
                umc.IsActive = bool.Parse("True");
                _db.tbl_User.Add(umc);
                _db.SaveChanges();
                return RedirectToAction("Login", "Home");
            }

            return View();
        }

        public ActionResult EditAccount()
        {
            JurisprudenceDBEntities _db = new JurisprudenceDBEntities();
            var email = Session["Username"].ToString();
            tbl_User tb = _db.tbl_User.Single(u => u.Email == email);
            UserModelClass umc = new UserModelClass();
            umc.UserID = tb.UserID;
            umc.Name = tb.Name;
            umc.Address = tb.Address;
            umc.Contact = tb.Contact;
            umc.Email = tb.Email;
            umc.Username = tb.Username;
            umc.Password = tb.Password;

            return View(umc);
        }
        [HttpPost]
        public ActionResult EditAccount(UserModelClass umc)
        {


            JurisprudenceDBEntities _db = new JurisprudenceDBEntities();
            tbl_User tb = _db.tbl_User.Single(u => u.UserID == umc.UserID);
            tb.Name = umc.Name;
            tb.UserID = umc.UserID;
            tb.Name = umc.Name;
            tb.Address = umc.Address;
            tb.Contact = umc.Contact;
            tb.Email = umc.Email;
            tb.Username = umc.Username;
            tb.Password = umc.Password;
            _db.SaveChanges();
            return RedirectToAction("Index");




        }
        public ActionResult AccountDetails()
        {

            JurisprudenceDBEntities _db = new JurisprudenceDBEntities();
            var email = Session["Username"].ToString();
            tbl_User tb = _db.tbl_User.Single(u => u.Email == email);
            UserModelClass umc = new UserModelClass();
            umc.UserID = tb.UserID;
            umc.Name = tb.Name;
            umc.Address = tb.Address;
            umc.Contact = tb.Contact;
            umc.Email = tb.Email;
            umc.Username = tb.Username;
            umc.Password = tb.Password;

            return View(umc);


        }
        public ActionResult AssignUserRoles()
        {
            JurisprudenceDBEntities db = new JurisprudenceDBEntities();
            var email = Session["Username"].ToString();
            tbl_User tbl = db.tbl_User.Single(u => u.Email == email);
            if (tbl.Role=="Admin")
            {
                JurisprudenceDBEntities _db = new JurisprudenceDBEntities();
                var tb = _db.tbl_User;
                List<UserModelClass> ulst = new List<UserModelClass>();
                foreach (tbl_User item in tb)
                {
                    UserModelClass umc = new UserModelClass();
                    umc.UserID = item.UserID;
                    umc.Name = item.Name;
                    umc.Address = item.Address;
                    umc.Contact = item.Contact;
                    umc.Role = item.Role;
                    ulst.Add(umc);


                }
                return View (ulst);



                            }
            
                List<UserModelClass> ll = new List<UserModelClass>();

                ViewBag.Message = "Please Contact Admin";
                return View(ll); 

           
            
                
            
            
            

        }
        public ActionResult AddRole(int id)
        {
            JurisprudenceDBEntities _db = new JurisprudenceDBEntities();
            var tb = _db.tbl_User.Single(u => u.UserID == id);
            UserModelClass umc = new UserModelClass();
            umc.UserID = tb.UserID;
            umc.Name = tb.Name;

            return View(umc);
        }
        [HttpPost]
        public ActionResult AddRole( UserModelClass umc)
        {
            JurisprudenceDBEntities _db = new JurisprudenceDBEntities();
            tbl_User tb = _db.tbl_User.Single(u => u.UserID == umc.UserID);

            tb.Role = umc.Role;
            _db.SaveChanges();
            return RedirectToAction("AssignUserRoles");
        }
    }
}