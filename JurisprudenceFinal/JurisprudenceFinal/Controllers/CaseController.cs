using JurisprudenceFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JurisprudenceFinal.Controllers
{
    public class CaseController : Controller
    {
        //
        // GET: /Case/

        public ActionResult Cases()
        {
            return View();
        }
        public ActionResult AddCase()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddCase(FormCollection fc)
        {
            JurisprudenceDBEntities _db = new JurisprudenceDBEntities();
            var User = Session["Username"];
            tbl_User tb = _db.tbl_User.Single(u => u.Email == User);

            tbl_Case tbl = new tbl_Case();
            tbl.CaseName = fc["casename"];
            tbl.CaseDetails = fc["casedetails"];
            tbl.CaseType = fc["casetype"];
            tbl.UserID = tb.UserID;
            _db.tbl_Case.Add(tbl);
            _db.SaveChanges();
            return RedirectToAction("ViewCase");
        }
        public ActionResult ViewCase()
        {
            JurisprudenceDBEntities _db = new JurisprudenceDBEntities();

            var User = Session["Username"];
            tbl_User tb = _db.tbl_User.Single(u => u.Email == User);

            var userid = tb.UserID;
            var lawname = tb.Name;
            var tblc = _db.tbl_Case.Where(u => u.UserID == userid || u.Lawyer==lawname);
            List<CaseModelClass> lstc = new List<CaseModelClass>();
            foreach (tbl_Case item in tblc)
            {
                CaseModelClass cmc = new CaseModelClass();
                cmc.CaseName = item.CaseName;
                cmc.CaseType = item.CaseType;
                cmc.CaseDetails = item.CaseDetails;
                cmc.CaseID = item.CaseID;
                cmc.Lawyer = item.Lawyer;
                lstc.Add(cmc);


            }

            return View(lstc);
        }
        public ActionResult EditCase(int id)
        {
            JurisprudenceDBEntities _db = new JurisprudenceDBEntities();
            tbl_Case tb = _db.tbl_Case.Single(u => u.CaseID == id);
            CaseModelClass cmc = new CaseModelClass();
            cmc.CaseID = tb.CaseID;
            cmc.CaseName = tb.CaseName;
            cmc.CaseType = tb.CaseType;
            cmc.CaseDetails = tb.CaseDetails;
            return View(cmc);



        }
        [HttpPost]
        public ActionResult EditCase(CaseModelClass cmc)
        {
            JurisprudenceDBEntities _db = new JurisprudenceDBEntities();
            tbl_Case tb = _db.tbl_Case.Single(u => u.CaseID == cmc.CaseID);

            tb.CaseName = cmc.CaseName;
            tb.CaseType = cmc.CaseType;
            tb.CaseDetails = cmc.CaseDetails;
            _db.SaveChanges();
            return View("Cases");



        }
        public ActionResult AssignCase()
        { 
             JurisprudenceDBEntities db = new JurisprudenceDBEntities();
            var email = Session["Username"].ToString();
            tbl_User tbl = db.tbl_User.Single(u => u.Email == email);
            if (tbl.Role == "Admin")
            {
                JurisprudenceDBEntities _db = new JurisprudenceDBEntities();
                var tblc = _db.tbl_Case;
                List<CaseModelClass> lstc = new List<CaseModelClass>();
                foreach (tbl_Case item in tblc)
                {
                    CaseModelClass cmc = new CaseModelClass();
                    cmc.CaseName = item.CaseName;
                    cmc.CaseType = item.CaseType;
                    cmc.CaseDetails = item.CaseDetails;
                    cmc.CaseID = item.CaseID;
                    cmc.Lawyer = item.Lawyer;
                    lstc.Add(cmc);


                }

                return View(lstc);
            }
            ViewBag.Message = "Please Contact Admin";
            List<CaseModelClass> lst = new List<CaseModelClass>();
            return View(lst);

        }
        public ActionResult Assign(int id)
        {


            JurisprudenceDBEntities db = new JurisprudenceDBEntities();

            tbl_Case tb = db.tbl_Case.Single(u => u.CaseID == id);
            CaseModelClass cmc = new CaseModelClass();
            cmc.CaseName = tb.CaseName;
            cmc.CaseID = tb.CaseID;
            cmc.CaseType = tb.CaseType;
            cmc.CaseDetails = tb.CaseDetails;
            cmc.Lawyer = tb.Lawyer;
            JurisprudenceDBEntities _db = new JurisprudenceDBEntities();
            ViewBag.Lawyers = _db.tbl_Lawyer;
            return View(cmc);


        }
        [HttpPost]
        public ActionResult Assign(CaseModelClass cmc,FormCollection fc)
        {
            if (cmc.Lawyer=="Choose Lawyer")
            {
                ViewBag.Message = "Please select Lawyer";
                
            }
            JurisprudenceDBEntities _db = new JurisprudenceDBEntities();
            tbl_Case tb = _db.tbl_Case.Single(u => u.CaseID == cmc.CaseID);
            int lid = Int32.Parse(fc["Lawyer"]);
            tbl_Lawyer tbl = _db.tbl_Lawyer.Single(v=>v.LawyerID==lid);
            tb.Lawyer = tbl.Name;
            _db.SaveChanges();
            return RedirectToAction("AssignCase");
        }
        public ActionResult Search() {

            return View();
        
        }
        public JsonResult GetAllUsers()
        {
            JurisprudenceDBEntities _db = new JurisprudenceDBEntities();

            var users = _db.tbl_Case.ToList();

            return Json(users, JsonRequestBehavior.AllowGet);
        }
       
    }
}

