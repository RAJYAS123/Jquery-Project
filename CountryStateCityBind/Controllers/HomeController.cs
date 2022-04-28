using CountryStateCityBind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountryStateCityBind.Controllers
{
    public class HomeController : Controller
    {

        private DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {

            ViewBag.country = new SelectList(db.tblcountries, "cid", "cname");
            return View();
        }

        public JsonResult StateList(int Id)
        {
            var state = from s in db.tblstates
                        where s.cid == Id
                        select s;
            return Json(new SelectList(state.ToArray(), "stateid", "statename"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Citylist(int id)
        {
            var city = from c in db.tblcities
                       where c.stateid == id
                       select c;
            return Json(new SelectList(city.ToArray(), "cityid", "cityname"), JsonRequestBehavior.AllowGet);
        }


    }
}