using FlooringProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProject.Data
{
    public interface IProductRepository
    {
        Product GetProductByName(string name);

        List<Product> GetProductList();
    }
}
