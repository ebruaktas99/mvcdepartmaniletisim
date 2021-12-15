using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcproje.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        CategoryManager cm = new CategoryManager(new EfCategoryDal()); //BUL'DAN nesne üretilir.
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {

            var categoryvalues = cm.GetList(); //categoryvalues değişkeninin içine bütün kategori değerleri gelmiş olur.
            return View(categoryvalues);
        }

        [HttpGet]
        public ActionResult AddCategory( )
        {

            return View();

        }
        [HttpPost]
        public ActionResult AddCategory (Category p)
        {
            //cm.CategoryAdd(p);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(p); //validate metotu ile kontrol edilir.

            if (result.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View(); //getcategoryliste yönlendir.

        }
    }
}