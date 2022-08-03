using Medical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.Class
{
    public interface IDashboard
    {
        List<Product> GetAllProducts();
    }
}
