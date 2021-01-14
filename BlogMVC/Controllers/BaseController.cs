﻿using BlogMVC.Models;
using BlogMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();
        public BaseController()
        {
            var articles = db.Articles.OrderByDescending(x => x.PostedDate).Take(3);
            ViewBag.denemeler = articles;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}