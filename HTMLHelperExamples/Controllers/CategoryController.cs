using HTMLHelperExamples.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace HTMLHelperExamples.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            IList<CategoryModel> cm = new List<CategoryModel>
            {
                new CategoryModel { CategoryId = 1, CategoryName = "TV" },
                new CategoryModel { CategoryId = 2, CategoryName = "Mobiles" },
                new CategoryModel { CategoryId = 3, CategoryName = "Laptop" }
            };

            IList<Gender> s = new List<Gender>
            {
                new Gender { Id = 1, Name = "Male" },
                new Gender { Id = 2, Name = "Female" },
            };

            ViewBag.categories = cm;

            ViewBag.gender = s;

            return View();
        }

        public JsonResult LoadSubCatByCategoryId(int categoryId)
        {
            var subCategoryList = GetSubCategories(categoryId);
            
            var subCategoriesData = subCategoryList.Select(m => new SelectListItem()
            {
                Value = m.SubCategoryId.ToString(),
                Text = m.SubCategoryName.ToString()
            });

            return new JsonResult(subCategoriesData);
        }

        private IList<SubCategoryModel> GetSubCategories(int categoryId)
        {
            IList<SubCategoryModel> scm = new List<SubCategoryModel>
            {
                new SubCategoryModel { SubCategoryId = 1, CategoryId = 1, SubCategoryName = "Samsumg" },
                new SubCategoryModel { SubCategoryId = 2, CategoryId = 1, SubCategoryName = "Nokia" },
                new SubCategoryModel { SubCategoryId = 3, CategoryId = 2, SubCategoryName = "iPhone" }
            };

            return scm.Where(m => m.CategoryId == categoryId).ToList();
        }
    }
}
