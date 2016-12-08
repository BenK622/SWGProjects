using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATZBlog.Models.attributes
{
    public class MinPriceAttribute : ValidationAttribute
    {
        private readonly double _minPrice;

        public MinPriceAttribute(double minPrice)
        {
            _minPrice = minPrice;
            ErrorMessage = "Value must be at least $0.01";
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                return double.Parse(value.ToString()) >= _minPrice;
            }

            return false;
        }
    }
}
