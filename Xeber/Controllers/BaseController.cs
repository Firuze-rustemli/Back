using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xeber.Models;

namespace Xeber.Controllers
{
    public class BaseController : Controller
    {
        public SendCodeViewModel model;

        protected NewsEntities  db = new NewsEntities();

        // GET: Base
        public BaseController()
        {
            //  model = _LayoutL.Populate();
            ViewBag.LayoutModel = "scjksbc";

        }
    }
}