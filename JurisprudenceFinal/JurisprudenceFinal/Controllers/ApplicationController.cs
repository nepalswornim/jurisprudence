using JurisprudenceFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace JurisprudenceFinal.Controllers
{
    public class ApplicationController : Controller
    {
        //
        // GET: /Application/

        public ActionResult Lawyer()
        {
            JurisprudenceDBEntities _db = new JurisprudenceDBEntities();

            var lawyers = _db.tbl_Lawyer;
            List<LawyerModelClass> lawlst = new List<LawyerModelClass>();
            foreach (tbl_Lawyer lawyer in lawyers)
            {
                LawyerModelClass lmc = new LawyerModelClass();
                lmc.LawyerID = lawyer.LawyerID;
                lmc.Name = lawyer.Name;
                lmc.Degree = lawyer.Degree;
                lmc.Address = lawyer.Address;

                lmc.Contact = lawyer.Contact;
                lmc.CasesSolved = lawyer.CasesSolved;
                lmc.Specialty = lawyer.Specialty;
                lmc.DateJoined = lawyer.DateJoined;
                lmc.Age = lawyer.Age;

                lawlst.Add(lmc);
            }

            return View(lawlst);
        }
        public ActionResult Error() {

            return View();

        }

        public ActionResult AddLawyer()
        {
             JurisprudenceDBEntities db = new JurisprudenceDBEntities();
            var email = Session["Username"].ToString();
            tbl_User tbl = db.tbl_User.Single(u => u.Email == email);
            if (tbl.Role == "Admin")
            {
                return View();
            }

            return RedirectToAction("Error");
            
        }

        [HttpPost]
        public ActionResult AddLawyer(FormCollection fc)
        {
            try
            {
                tbl_Lawyer l = new tbl_Lawyer();
                l.Name = fc["name"];
                l.Address = fc["address"];
                l.Age = Int32.Parse(fc["age"]);
                l.Degree = fc["degree"];
                l.Specialty = fc["specialty"];
                l.Contact = fc["contact"];
                l.IsActive = Boolean.Parse("True");
                l.DateJoined = DateTime.Now.ToShortDateString();
                JurisprudenceDBEntities _db = new JurisprudenceDBEntities();
                _db.tbl_Lawyer.Add(l);
                _db.SaveChanges();
                return RedirectToAction("Lawyer");
            }
            catch (Exception)
            {
                ViewBag.Message = "Some Error Occured!!";

                return View();
            }
        }

        public ActionResult LawyerDetails(int id)
        {
            JurisprudenceDBEntities _db = new JurisprudenceDBEntities();
            tbl_Lawyer l = _db.tbl_Lawyer.Single(u => u.LawyerID == id);

            LawyerModelClass lmc = new LawyerModelClass();
            lmc.LawyerID = l.LawyerID;
            lmc.Name = l.Name;
            lmc.Degree = l.Degree;
            lmc.Specialty = l.Specialty;
            lmc.Age = l.Age;
            lmc.Contact = l.Contact;
            lmc.CasesSolved = l.CasesSolved;
            lmc.Address = l.Address;
            lmc.DateJoined = l.DateJoined;

            return View(lmc);
            
        }

        public ActionResult EditLawyer(int id)
        {
            JurisprudenceDBEntities db = new JurisprudenceDBEntities();
            var email = Session["Username"].ToString();
            tbl_User tbl = db.tbl_User.Single(u => u.Email == email);
            if (tbl.Role == "Admin")
            {
                JurisprudenceDBEntities _db = new JurisprudenceDBEntities();
                tbl_Lawyer l = _db.tbl_Lawyer.Single(u => u.LawyerID == id);

                LawyerModelClass lmc = new LawyerModelClass();
                lmc.LawyerID = l.LawyerID;
                lmc.Name = l.Name;
                lmc.Degree = l.Degree;
                lmc.Specialty = l.Specialty;
                lmc.Age = l.Age;
                lmc.Contact = l.Contact;

                lmc.Address = l.Address;

                return View(lmc);
            }

            return RedirectToAction("Error");
           
        }

        [HttpPost]
        public ActionResult EditLawyer(LawyerModelClass lmc)
        {
            try
            {
                JurisprudenceDBEntities _db = new JurisprudenceDBEntities();
                tbl_Lawyer l = _db.tbl_Lawyer.Single(u => u.LawyerID == lmc.LawyerID);

                l.Name = lmc.Name;
                l.Address = lmc.Address;
                l.Age = lmc.Age;
                l.Degree = lmc.Degree;
                l.Specialty = lmc.Specialty;
                l.Contact = lmc.Contact;
                l.IsActive = Boolean.Parse("True");
                l.DateJoined = DateTime.Now.ToShortDateString();

                _db.SaveChanges();
                ViewBag.Message = "Edited Successfully";
                return RedirectToAction("Lawyer");
            }
            catch (Exception)
            {
                ViewBag.Message = "Some Error Occured!!";

                return View();
            }
        }

        [HttpGet]
        public ActionResult DeleteLawyer(int id)
        {
            JurisprudenceDBEntities db = new JurisprudenceDBEntities();
            var email = Session["Username"].ToString();
            tbl_User tbl = db.tbl_User.Single(u => u.Email == email);
            if (tbl.Role == "Admin")
            {
                JurisprudenceDBEntities _db = new JurisprudenceDBEntities();
                tbl_Lawyer l = _db.tbl_Lawyer.Single(u => u.LawyerID == id);

                LawyerModelClass lmc = new LawyerModelClass();
                lmc.LawyerID = l.LawyerID;
                lmc.Name = l.Name;
                lmc.Degree = l.Degree;
                lmc.Specialty = l.Specialty;
                lmc.Age = l.Age;
                lmc.Contact = l.Contact;

                lmc.Address = l.Address;

                return View(lmc);
            }

            return RedirectToAction("Error");
           
        }

        [HttpPost]
        public ActionResult DeleteLawyer(LawyerModelClass lmc)
        {
            try
            {
                JurisprudenceDBEntities _db = new JurisprudenceDBEntities();
                tbl_Lawyer l = _db.tbl_Lawyer.Single(u => u.LawyerID == lmc.LawyerID);

                _db.tbl_Lawyer.Remove(l);
                _db.SaveChanges();
                ViewBag.Message = "Deleted Successfully";
                return RedirectToAction("Lawyer");
            }
            catch (Exception)
            {
                ViewBag.Message = "Some Error Occured!!";

                return View();
            }
        }
    }
}