using Medical.Models;
using Medical.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.Areas.Admin.Controllers
{
    [Area(areaName: "Admin")]
    public class AdminProductController : Controller
    {

        private readonly MedicalContext db;
        private IWebHostEnvironment _environment;
        public AdminProductController(IWebHostEnvironment myEnvironment, MedicalContext _medical)
        {
            _environment = myEnvironment;
            db = _medical;
        }

        public IActionResult ChooseView()
        {
            return View();
        }

        public IActionResult productManage()
        {
            CProductViewModel model = new CProductViewModel
            {
                productList = db.Products.ToList(),
                brandList = db.ProductBrands.ToList(),
                cateList = db.ProductCategories.ToList(),
                prodSpecList = db.ProductSpecifications.ToList()

            };

            IEnumerable<SelectListItem> brandSelectListItem = (from p in db.ProductBrands
                                                               where p.ProductBrandName != null
                                                               select p).ToList().Select(p => new SelectListItem
                                                               { Value = p.ProductBrandId.ToString(), Text = p.ProductBrandName });

            ViewBag.brandSelectListItem = brandSelectListItem;


            IEnumerable<SelectListItem> cateSelectListItem = (from p in db.ProductCategories
                                                              where p.ProductCategoryName != null
                                                              select p).ToList().Select(p => new SelectListItem
                                                              { Value = p.ProductCategoryId.ToString(), Text = p.ProductCategoryName });

            ViewBag.cateSelectListItem = cateSelectListItem;




            return View(model);
        }

        public IActionResult SelectedProduct(int? id)
        {
            ProductSpecification ps = db.ProductSpecifications.FirstOrDefault(ps => ps.ProductId == id);
            List<OtherProductImage> op = db.OtherProductImages.Where(op => op.ProductId == id).ToList();

            List<string> myop = new List<string>(); ;

            foreach(var a in op)
            {
                string optxt = a.OtherProductPhoto;
                myop.Add(optxt);
            }

            Product p = db.Products.FirstOrDefault(p => p.ProductId == id);

            string pbName = db.ProductBrands.FirstOrDefault(pb => pb.ProductBrandId == p.ProductBrandId).ProductBrandName; 
            string pcName = db.ProductCategories.FirstOrDefault(pc => pc.ProductCategoryId== p.ProductCategoryId).ProductCategoryName;


            CSelectedProductViewModel prod = new CSelectedProductViewModel()
            {


                Shelfdate = p.Shelfdate,
                Stock = p.Stock,
                ProductSpecificationId = ps.ProductSpecificationId,
                ProductId = ps.ProductId,
                ProductAppearance = ps.ProductAppearance,
                ProductColor = ps.ProductColor,
                ProductImage = ps.ProductImage,
                ProductMaterial = ps.ProductMaterial,
                ProductName = ps.Product.ProductName,
                Discontinued = p.Discontinued,
                UnitPrice = ps.UnitPrice,
                ProductBrandName = pbName,
                ProductCategoryName = pcName,
                ProductBrandId = p.ProductBrandId,
                ProductCategoryId = p.ProductCategoryId,
                otherP = myop

            };

            return Json(prod);
        }
        [HttpPost]
        public IActionResult ChangeSave(CSelectedProductViewModel cSelected/*,IFormFile photo*/ /*string myJson*/)
        {
            // CSelectedProductViewModel cSelected = JsonSerializer.Deserialize<CSelectedProductViewModel>(myJson);
            Product mp = db.Products.FirstOrDefault(p => p.ProductId == cSelected.ProductId);
            ProductSpecification mps = db.ProductSpecifications.FirstOrDefault(m => m.ProductSpecificationId == cSelected.ProductSpecificationId);




            //"{\"Discontinued\":\"false\",\"ProductId\":\"0\",\"ProductAppearance\":\"最新款黑色太陽眼鏡\",\"ProductImage\":" +
            //    "\"/images/6143e97f-4d04-439c-bc97-4741069e20db.jpg\",\"ProductMaterial\":\"soft\",\"ProductName\":\"雷朋太陽眼鏡(黑)\"," +
            //    "\"Shelfdate\":\"999\",\"Stock\":\"16\"," +
            //    "\"UnitPrice\":\"5003\",\"ProductBrandId\":\"3\",\"ProductCategoryId\":\"1\",\"ProductSpecificationId\":\"2\"}"

            if (cSelected.photo != null)
            {
                string mpName = Guid.NewGuid().ToString() + ".jpg";
                cSelected.photo.CopyTo(new FileStream(_environment.WebRootPath + "/images/" + mpName, FileMode.Create));
                mps.ProductImage = mpName;
            }

            mp.Discontinued = cSelected.Discontinued;
            mp.ProductBrandId = cSelected.ProductBrandId;
            mp.ProductCategoryId = cSelected.ProductCategoryId;
            mp.ProductName = cSelected.ProductName;
            mp.Shelfdate = cSelected.Shelfdate;
            mp.Stock = cSelected.Stock;

            mps.ProductAppearance = cSelected.ProductAppearance;
            mps.ProductColor = cSelected.ProductColor;
            mps.ProductMaterial = cSelected.ProductMaterial;
            mps.UnitPrice = cSelected.UnitPrice;
            db.SaveChanges();

            return Content("成功");
        }

        public IActionResult AddNewProd(CSelectedProductViewModel cSelected/*,IFormFile photo*/ /*string myJson*/)
        {
            // CSelectedProductViewModel cSelected = JsonSerializer.Deserialize<CSelectedProductViewModel>(myJson);
            Product mp = new Product();
            ProductSpecification mps = new ProductSpecification();

            if (cSelected.photo != null)
            {
                string mpName = Guid.NewGuid().ToString() + ".jpg";
                cSelected.photo.CopyTo(new FileStream(_environment.WebRootPath + "/images/" + mpName, FileMode.Create));
                mps.ProductImage = mpName;
            }

            mp.Discontinued = cSelected.Discontinued;
            mp.ProductBrandId = cSelected.ProductBrandId;
            mp.ProductCategoryId = cSelected.ProductCategoryId;
            mp.ProductName = cSelected.ProductName;
            mp.Shelfdate = cSelected.Shelfdate;
            mp.Stock = cSelected.Stock;
            mp.Cost = cSelected.Cost;
            db.Products.Add(mp);
            db.SaveChanges();

            mps.ProductAppearance = cSelected.ProductAppearance;
            mps.ProductColor = cSelected.ProductColor;
            mps.ProductMaterial = cSelected.ProductMaterial;
            mps.UnitPrice = cSelected.UnitPrice;
            mps.ProductId = mp.ProductId;
            db.ProductSpecifications.Add(mps);

            db.SaveChanges();


            return Content(mp.ProductId.ToString());
        }



        public IActionResult test()
        {
            return View();
        }

        public IActionResult test64(string [] multipleImgsArray,string productBeforeName)
        {
            if(multipleImgsArray.Length==0 || productBeforeName == "")
            {
                return Content("失敗");
            }
            int count = 0;
            List<OtherProductImage> others = db.OtherProductImages.Where(o => o.Product.ProductName == productBeforeName).ToList();
            int pId = db.Products.FirstOrDefault(p => p.ProductName == productBeforeName).ProductId;
            if (others.Count == 0)
            {
                foreach (var arr in multipleImgsArray)
                {

                    byte[] bit = Convert.FromBase64String(arr);
                    MemoryStream ms = new MemoryStream(bit);
                    Bitmap bmp = new Bitmap(ms);
                    string mpName = Guid.NewGuid().ToString() + ".jpg";
                    string FilePath = _environment.WebRootPath + "/images/" + mpName;

                    bmp.Save(FilePath, ImageFormat.Jpeg);

                    OtherProductImage other = new OtherProductImage();
                    other.ProductId = pId;
                    other.OtherProductPhoto = mpName;
                    db.OtherProductImages.Add(other);
                    db.SaveChanges();
                    count++;
                }
            }
            else
            {
                foreach(var arr in multipleImgsArray)
                {
                
                    byte[] bit = Convert.FromBase64String(arr);
                    MemoryStream ms = new MemoryStream(bit);
                    Bitmap bmp = new Bitmap(ms);
                    string mpName = Guid.NewGuid().ToString() + ".jpg";
                    string FilePath = _environment.WebRootPath + "/images/" + mpName;

                    bmp.Save(FilePath, ImageFormat.Jpeg);

                    others[count].OtherProductPhoto = mpName;

                    //OtherProductImage other = new OtherProductImage();
                    //other.ProductId = 1;
                    //other.OtherProductPhoto = mpName;
                    db.SaveChanges();
                    count++;
                } 
            }

            return Content("成功");
        }


        // 新增商品
        public IActionResult AddNewProduct()
        {
            IEnumerable<SelectListItem> brandSelectListItem = (from p in db.ProductBrands
                                                               where p.ProductBrandName != null
                                                               select p).ToList().Select(p => new SelectListItem
                                                               { Value = p.ProductBrandId.ToString(), Text = p.ProductBrandName });

            ViewBag.brandSelectListItem = brandSelectListItem;


            IEnumerable<SelectListItem> cateSelectListItem = (from p in db.ProductCategories
                                                              where p.ProductCategoryName != null
                                                              select p).ToList().Select(p => new SelectListItem
                                                              { Value = p.ProductCategoryId.ToString(), Text = p.ProductCategoryName });

            ViewBag.cateSelectListItem = cateSelectListItem;



            return View();
        }

        // 刪除/下架商品
        public IActionResult RemoveProduct()
        {
            CProductViewModel model = new CProductViewModel
            {
                productList = db.Products.ToList(),
                brandList = db.ProductBrands.ToList(),
                cateList = db.ProductCategories.ToList(),
                prodSpecList = db.ProductSpecifications.ToList()

            };

            return View(model);
        }

        public IActionResult MultipleDiscontinue(string[] multipleD)
        {

            return Content("成功");
        }


        // 查詢訂單
        public IActionResult QueryAllOrders()
        {


            return View();
        }
        // 評論查詢/刪除
        public IActionResult DeleteReviews()
        {


            return View();
        }
        // 退貨訂單
        public IActionResult ReturnOrderList()
        {


            return View();
        }

    }
}
