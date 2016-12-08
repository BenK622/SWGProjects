using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATZBlog.Models.attributes
{
    public class MinValueAttribute : ValidationAttribute
    {
        private readonly int _minValue;

        public MinValueAttribute(int minValue)
        {
            _minValue = minValue;
            ErrorMessage = "Value must be at least 1";
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                return int.Parse(value.ToString()) >= _minValue;
            }

            return false;
        }
    }
}
