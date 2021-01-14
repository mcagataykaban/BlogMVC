using BlogMVC.Models;
using BlogMVC.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class BlogController : BaseController
    {
        public ActionResult Index()
        {
            var tags = db.Tags.ToList();
            foreach (var item in tags)
            {
                if (item.Articles.Count == 0)
                {
                    db.Tags.Remove(item);
                    db.SaveChanges();
                }
            }
            var vmb = new HomeBlogViewModel()
            {
                Articles = db.Articles.ToList(),
                Categories = db.Categories.ToList(),
                Tags = db.Tags.ToList()
            };
            return View(vmb);
        }

        public ActionResult TagsBlog(int? id)
        {
            if (id != null)
            {
                var tag = db.Tags.FirstOrDefault(x => x.Id == id);
                ViewBag.tagName = tag.TagName;
                var articles = db.Articles.Where(x => x.Tags.FirstOrDefault().Id == tag.Id).ToList();
                var vmb = new HomeBlogViewModel()
                {
                    Articles = articles,
                    Categories = db.Categories.ToList(),
                    Tags = db.Tags.ToList()
                };
                return View(vmb);
            }
            return HttpNotFound();
        }

        public ActionResult CategoryBlog(int? id)
        {
            if (id != null)
            {
                var category = db.Categories.FirstOrDefault(x => x.Id == id);
                ViewBag.categoryName = category.CategoryName;
                var articles = db.Articles.Where(x => x.CategoryId == category.Id).ToList();
                var vmb = new HomeBlogViewModel()
                {
                    Articles = articles,
                    Categories = db.Categories.ToList(),
                    Tags = db.Tags.ToList()
                };
                return View(vmb);
            }
            return HttpNotFound();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EmailSub(string email)
        {
            string mesaj = "";
            var _email = new EmailSub() { Email = email };
            if (ModelState.IsValid && !string.IsNullOrEmpty(_email.Email))
            {

                if (db.EmailSubs.Any(x => x.Email == _email.Email))
                {
                    mesaj = "Bu mail sisteme kayıtlı.";
                }
                else
                {
                    var emailSub = new EmailSub() { Email = _email.Email };
                    db.EmailSubs.Add(emailSub);
                    db.SaveChanges();
                    mesaj = "İşlem Başarılı";
                }
            }
            else
                mesaj = "Hatalı işlem";
            return Json(mesaj);
        }

        public ActionResult BlogTek(int? id)
        {
            if (id != null)
            {
                var article = db.Articles.FirstOrDefault(x => x.Id == id);
                var categoryName = article.Category.CategoryName;
                if (db.Articles.Where(x => x.Category.CategoryName == categoryName).ToList().Count >= 3)
                {
                    ViewBag.relatedArticles = db.Articles.Where(x => x.Category.CategoryName == categoryName).Take(3).ToList();
                }
                return View(article);
            }
            return RedirectToAction("Index");

        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentViewModel commentViewModel)
        {
            Comment comment;
            //string deneme = HttpContext.Request.LogonUserIdentity.Name;
            if (ModelState.IsValid)
            {
                comment = new Comment()
                {
                    ApplicationUserId = User.Identity.GetUserId(),
                    CommentText = commentViewModel.CommentText,
                    ArticleId = commentViewModel.ArticleId,
                    PostedDate = DateTime.Now,
                    CommentAuthor = User.Identity.GetUserName().Substring(0, User.Identity.GetUserName().IndexOf("@"))
                };
                db.Comments.Add(comment);
                db.SaveChanges();
                return Json(comment);
            }
            else
            {
                if (commentViewModel.CommentText.Length > 500)
                {
                    return Json("uzunlukHatasi");
                }
                return Json("hata");
            }
        }
    }
}