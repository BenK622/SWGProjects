using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HrPortal.Models
{
    public class CategoryVM
    {
        public List<SelectListItem> Categories { get; set; }
        public string CategorySelected { get; set; }

        public CategoryVM()
        {
            Categories = new List<SelectListItem>();
        }

        public void SetCategoryItems(IEnumerable<CategoryModel> categories)
        {
            foreach (var category in categories)
            {
                Categories.Add(new SelectListItem()
                {
                    Value = category.CategoryName,
                    Text = category.CategoryName
                });
            }

           
        }

        
    }
}