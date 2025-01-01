using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Controllers.HMS
{
    public class PatientInfoController : Controller
    {
        // GET: PatientInfo
        public ActionResult PatientInformation()
        {
            return View();
        }
    }
}