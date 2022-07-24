using Medical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.ViewModel
{
    public class oddetailviewmodel
    {
        private readonly MedicalContext _context;
        public oddetailviewmodel(MedicalContext db)
        {
            _context = db;
        }


        public int? orderid { get; set; }

        public int detailid { get { return _context.OrderDetails.FirstOrDefault(n => n.OrderId == orderid).OrderDetailId; } }

        public int Quantity { get { return _context.OrderDetails.FirstOrDefault(n => n.OrderDetailId == detailid).Quantity; } }

        public DateTime? orderday { get { return _context.Orders.FirstOrDefault(n => n.OrderId == orderid).OrderDate; } }

        public int productid { get { return _context.OrderDetails.FirstOrDefault(n => n.OrderDetailId==detailid).ProductId; } }
        public string productname { get { return _context.Products.FirstOrDefault(n => n.ProductId == productid).ProductName; } }

        public string Productimage { get { return _context.ProductSpecifications.FirstOrDefault(n => n.ProductId == productid).ProductImage; } }

    }
}
