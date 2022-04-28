using CountryStateCityBind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountryStateCityBind.Controllers
{
    public class EmployeeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        public ActionResult Bind()
        {

            return View();
        }

        public JsonResult GetCountries()
        {
            return Json(db.tblcountries.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStatesByCountryId(int countryId)
        {
            int Id = Convert.ToInt32(countryId);
            var states = from a in db.tblstates where a.cid == Id select a;
            return Json(states);
        }

        public JsonResult GetCityByStateId(int stateid)
        {
            int id = Convert.ToInt32(stateid);
            var city = from b in db.tblcities where b.stateid == stateid select b;
            return Json(city);
        }
    }
}