﻿using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Concrete;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllContent(string p)
        {
            var values = cm.GetList(p);
            //var values = c.Contents.ToList();
            return View(values);
        }
        public ActionResult ContentByHeading(int id)
        {
            var contenValues = cm.GetListByHeadingID(id);
            return View(contenValues);
        }
    }
}