using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDoctor.Controllers
{
    public class UsersController : Controller
    {
      
        public ActionResult MyProfile()
        {
            return View();
        }
    }
}