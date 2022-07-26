using Medical.Models;
using Medical.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Medical.Controllers
{
    public class ProductController : Controller
    {
        private readonly MedicalContext _medicalContext;
        private IWebHostEnvironment environment;
    public ProductController(MedicalContext medicalContext, IWebHostEnvironment myEnvironment)
        {
            _medicalContext = medicalContext;
            environment = myEnvironment;
            
        }
        //歷史訂單
        //抓登入資料 會員id
        public IActionResult OrderList(Review addReviewView)
        {

            IEnumerable<OrderDetailViewModel> list = null;
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USE))
            {
                CMemberAdminViewModel vm = null;

                string logJson = "";
                logJson = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USE);
                vm = JsonSerializer.Deserialize<CMemberAdminViewModel>(logJson);
                ViewBag.name = vm.MemberName;

                list = _medicalContext.Orders.Where(a => a.MemberId == vm.MemberId)
                    .Select(a => new OrderDetailViewModel
                    {
                        Order = a,
                        Member = a.Member,
                        Orderstate = a.OrderState,
                        Paytype = a.PayType,
                        ShipType = a.ShipType
                    });
                ViewBag.count = list.Count();

                if (addReviewView.ProductId != null)
                {
                    //新增評論
                    addReviewView.MemberId = vm.MemberId;
                    _medicalContext.Reviews.Add(addReviewView);
                    _medicalContext.SaveChanges();
                    //新增評論結束  
                }
            }
            return View(list);
        }


        //關於訂單內產品新增產品評論
        //先秀出訂單明細表 
        //這裡的id是orderID
        public IActionResult OrderDetailList(int detail)
        {
            var id = _medicalContext.OrderDetails.Where(n => n.OrderId == detail);
            List<oddetailviewmodel> list = new List<oddetailviewmodel>();
            foreach (var item in id)
            {
                oddetailviewmodel t = new oddetailviewmodel(_medicalContext)
                {
                    orderid = item.OrderId
                };

                list.Add(t);
            }
            return Json(list);
        }





        //管理產品評論 (後台)
        public IActionResult ReviewList()
        {
            IEnumerable<CReviewViewModel> list = null;
            list = _medicalContext.Reviews.Select(p => new CReviewViewModel
            {
                Review = p,
                Member = p.Member,
                RatingType = p.RatingType,
                Product = p.Product
            });


            return View(list);
        }





        // ============ 柏鈞 =================
        public IActionResult productList()
        {
            return View(GetProducts(/*1*/));
        }
        [HttpPost]
        public IActionResult productList(int currentPageIndex)
        {
            return View(GetProducts(/*currentPageIndex*/));
        }


        private CProductForShowViewModel GetProducts(/*int currentPage*/)
        {
            //int maxRows = 8;
            CProductForShowViewModel prodModel = new CProductForShowViewModel()
            {
                productList = _medicalContext.Products.ToList(),
                brandList = _medicalContext.ProductBrands.Include(b => b.Products).ToList(),
                cateList = _medicalContext.ProductCategories.Include(c => c.Products).ToList(),
                prodSpec = _medicalContext.ProductSpecifications.ToList(),
                reviewList =_medicalContext.Reviews.Include(r=>r.RatingType).ToList()
            };

            prodModel.prodSpec = (from prod in this._medicalContext.ProductSpecifications
                                  select prod)
                        .Where(p=>p.Product.Discontinued==false) //條件
                        .OrderBy(prod => prod.Product.ProductName).ToList();
                        //.Skip((currentPage - 1) * maxRows)
                        //.Take(maxRows).ToList();

            //double pageCount = (double)((decimal)this._medicalContext.Products.Count() / Convert.ToDecimal(maxRows));
            //prodModel.PageCount = (int)Math.Ceiling(pageCount);

            //prodModel.CurrentPageIndex = currentPage;

            return prodModel;
        }
        public IActionResult ProductDetail(string productName)
        {
            CMemberAdminViewModel vm = null;

            int showID2 = 0;
            string logJson = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USE);

            if(logJson!=null)
            { 
                vm = JsonSerializer.Deserialize<CMemberAdminViewModel>(logJson);
                showID2 = vm.MemberId;
            }

            Product p = _medicalContext.Products.FirstOrDefault(p => p.ProductName == productName);

            if (p == null)
            {
                return RedirectToAction("productList");
            }


            ProductSpecification ps = _medicalContext.ProductSpecifications.FirstOrDefault(
                ps => ps.Product.ProductName == productName);
            
            List<Review> reviewList = _medicalContext.Reviews.Where(rw => rw.Product.ProductName == productName && rw.Shade==false).ToList();
            List<Member> memList = _medicalContext.Members.ToList();
            List<RatingType> ratings = _medicalContext.RatingTypes.ToList();
            List<ProductBrand> brandList = _medicalContext.ProductBrands.ToList();
            List<ProductCategory> cateList = _medicalContext.ProductCategories.ToList();
            List<OtherProductImage> otherP = _medicalContext.OtherProductImages.Where(op => op.Product.ProductName == productName).ToList();
            List<string> myop = new List<string>(); ;

            foreach (var o in otherP)
            {
                string optxt = o.OtherProductPhoto;
                myop.Add(optxt);
            }

            CShoppingCartViewModel cartView = new CShoppingCartViewModel()
            {
                prodReviewList = reviewList,
                prod = p,
                prodSpec = ps,
                ratingList = ratings,
                memList = memList,
                brandList = brandList,
                cateList = cateList,
                MemberID = showID2,
                otherP = myop
                

            };

            return View(cartView);
        }
        //推薦產品 隨機取9
        public IActionResult GetOthersProduct()
        {

            var otherProds = _medicalContext.ProductSpecifications.Include(ps=>ps.Product).OrderBy(ps => Guid.NewGuid()).Select(ps =>new CGetOthersProduct { 
            ProductImage = ps.ProductImage,
            ProductName = ps.Product.ProductName,
            UnitPrice = ps.UnitPrice
            }).Take(9);

            return Json(otherProds);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(CAddToCartViewModel AddToCartvModel)
        {
            CMemberAdminViewModel vm = null;

            int showID2 = 0;
            string logJson = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USE);

            if (logJson != null)
            {
                vm = JsonSerializer.Deserialize<CMemberAdminViewModel>(logJson);
                showID2 = vm.MemberId;
            }

            bool isSuccess = true;

            if(showID2==0)
                return Json(Url.Action("Login","Login"));


            if (AddToCartvModel.txtCount == 0)
                return RedirectToAction("ProductDetail");

            Product prod = _medicalContext.Products.FirstOrDefault(p => p.ProductId == AddToCartvModel.txtPId);
            if (prod == null)
                return RedirectToAction("productList");

            var IsSuccess = isSuccess;


            ShoppingCart hasCart = (_medicalContext.ShoppingCarts.Where(c => c.Product.ProductId == AddToCartvModel.txtPId && c.MemberId == showID2)).FirstOrDefault();
            if (hasCart != null)
            {
                int beforeAmount = hasCart.ProductAmount;
                int afterAmount = beforeAmount + AddToCartvModel.txtCount;

                if(afterAmount > prod.Stock)
                {
                    ModelState.AddModelError("","數量不可大於庫存");
                    isSuccess = false;
                    return Content("失敗");
                }
                else
                {
                    hasCart.ProductAmount = afterAmount;
                    _medicalContext.SaveChanges();
                    return Content("成功+"+showID2);
                }
            }
            else
            {
                ShoppingCart cart = new ShoppingCart()
                {
                    MemberId = showID2,
                    ProductId = AddToCartvModel.txtPId,
                    ProductAmount = AddToCartvModel.txtCount
                };

                _medicalContext.Add(cart);
                _medicalContext.SaveChanges();

                var a = Json(cart);

                return Content("成功");
            }
        }
     
        public IActionResult CartViewList(int? id)
        {
            CMemberAdminViewModel vm = null;

            int showID2 = 0;
            string logJson = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USE);

            if (logJson != null)
            {
                vm = JsonSerializer.Deserialize<CMemberAdminViewModel>(logJson);
                showID2 = vm.MemberId;
            }

            if (showID2 == 0)
                return RedirectToAction("Login", "Login");

            List<ShoppingCart> cartList = _medicalContext.ShoppingCarts.Where(c => c.MemberId == showID2).ToList();

            if (cartList.Count == 0)
            {
                return RedirectToAction("emptyCart");
            }

            List<Product> prodList = _medicalContext.Products.ToList();
            List<ProductSpecification> prodspecList = _medicalContext.ProductSpecifications.ToList();

            List<CShoppingCartItem> cartForShowList = new List<CShoppingCartItem>();

            Product p = new Product();

            foreach (ShoppingCart cart in cartList)
            {
                CShoppingCartItem item = new CShoppingCartItem();
                item.MemberId = showID2;
                item.cart = cart;
                item.prod = prodList.FirstOrDefault(p => p.ProductId == cart.ProductId);
                item.prodspec = prodspecList.FirstOrDefault(ps => ps.ProductId == cart.ProductId);
                cartForShowList.Add(item);
            }
            return View(cartForShowList);
        }

        [HttpPost]
        public IActionResult DeleteCartItem(int ShoppingCartId)
        {
            CMemberAdminViewModel vm = null;

            int showID2 = 0;
            string logJson = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USE);

            if (logJson != null)
            {
                vm = JsonSerializer.Deserialize<CMemberAdminViewModel>(logJson);
                showID2 = vm.MemberId;
            }

            ShoppingCart cart = _medicalContext.ShoppingCarts.FirstOrDefault(c => c.ShoppingCartId == ShoppingCartId);

            _medicalContext.Remove(cart);
            _medicalContext.SaveChanges();
            return Content("成功+" + showID2);
        }

        [HttpPost]
        public IActionResult ChangeCartItem(ShoppingCart cart)
        {
            CMemberAdminViewModel vm = null;

            int showID2 = 0;
            string logJson = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USE);

            if (logJson != null)
            {
                vm = JsonSerializer.Deserialize<CMemberAdminViewModel>(logJson);
                showID2 = vm.MemberId;
            }


            ShoppingCart mycart = _medicalContext.ShoppingCarts.FirstOrDefault(mc => mc.ShoppingCartId == cart.ShoppingCartId);
            mycart.ProductAmount = cart.ProductAmount;
            _medicalContext.SaveChanges();

            return Content("成功+"+showID2);
        }

        public IActionResult MainPageCart(int? id)
        {

            List<ShoppingCart> cartList = _medicalContext.ShoppingCarts.Where(c => c.MemberId ==id).ToList();


            List<Product> prodList = _medicalContext.Products.ToList();
            List<ProductSpecification> prodspecList = _medicalContext.ProductSpecifications.ToList();

            List<CMainPageCartViewModel> cartForShowList = new List<CMainPageCartViewModel>();

            Product p = new Product();

            foreach (ShoppingCart cart in cartList)
            {
                CMainPageCartViewModel item = new CMainPageCartViewModel();
                item.ShoppingCartId = cart.ShoppingCartId;
                item.ProductName = cart.Product.ProductName;
                item.UnitPrice = prodspecList.FirstOrDefault(ps => ps.Product.ProductName == cart.Product.ProductName).UnitPrice;
                item.ProductAmount = cart.ProductAmount;
                item.ProductId = cart.ProductId;
                cartForShowList.Add(item);
            }
            return Json(cartForShowList);
            
        }


        public IActionResult GetCoupon(int? id)
        {
            List<CGetUserCoupon>GetUserC = _medicalContext.CouponDetails.Include(cd=>cd.Coupon).Where(cd => cd.MemberId == id && cd.CouponUsed==false).Select(cd=>new CGetUserCoupon {
            
            CouponDetailId = cd.CouponDetailId,
            CouponDiscountNum =cd.Coupon.CouponDiscountNum,
            CouponId = cd.CouponId,
            CouponRequireNum =cd.Coupon.CouponRequireNum
            }).ToList();

            return Json(GetUserC);
        }

        public IActionResult CheckViewList(int? id)
        {
            CMemberAdminViewModel vm = null;

            int showID2 = 0;
            string logJson = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USE);

            if (logJson != null)
            {
                vm = JsonSerializer.Deserialize<CMemberAdminViewModel>(logJson);
                showID2 = vm.MemberId;
            }

            if (showID2 == 0)
                return RedirectToAction("Login", "Login");




            List<ShoppingCart> cartList = _medicalContext.ShoppingCarts.Where(c => c.MemberId == showID2).ToList();

            List<Product> prodList = _medicalContext.Products.ToList();



            List<ProductSpecification> prodspecList = _medicalContext.ProductSpecifications.ToList();


            List<CShoppingCartItem> checkForShowList = new List<CShoppingCartItem>();

            Product p = new Product();

            foreach (ShoppingCart cart in cartList)
            {
                CShoppingCartItem item = new CShoppingCartItem();
                item.cart = cart;
                item.prod = prodList.FirstOrDefault(p => p.ProductId == cart.ProductId);
                item.prodspec = prodspecList.FirstOrDefault(ps => ps.ProductId == cart.ProductId);
                checkForShowList.Add(item);
            }


            return View(checkForShowList);
        }


        public IActionResult QueryNotFinishOrder(int? id)
        {
            List<Order> orderList = _medicalContext.Orders.Where(o => o.MemberId ==19&& o.OrderStateId==1).OrderByDescending(o => o.OrderId).ToList();
            List<OrderDetail> orderDetailList = null;

            foreach (var o in orderList)
            {
                orderDetailList = _medicalContext.OrderDetails.Where(od => od.OrderId == o.OrderId).ToList();
                o.OrderDetails = orderDetailList;
            }


            List<Product> prodList = _medicalContext.Products.ToList();
            List<ProductSpecification> prodspecList = _medicalContext.ProductSpecifications.ToList();



            COrderforShowViewModel cOrderforShowViewModel = new COrderforShowViewModel()
            {

                orderDetailList = orderDetailList,
                orderList = orderList,
                productList = prodList,
                productSpecificationList = prodspecList
            };

            return View(cOrderforShowViewModel);
        }
        public IActionResult QueryFinishOrder(int? id)
        {
            List<Order> orderList = _medicalContext.Orders.Where(o => o.MemberId == 19 && o.OrderStateId == 2).OrderByDescending(o => o.OrderId).ToList();
            List<OrderDetail> orderDetailList = null;

            foreach (var o in orderList)
            {
                orderDetailList = _medicalContext.OrderDetails.Where(od => od.OrderId == o.OrderId).ToList();
                o.OrderDetails = orderDetailList;
            }


            List<Product> prodList = _medicalContext.Products.ToList();
            List<ProductSpecification> prodspecList = _medicalContext.ProductSpecifications.ToList();



            COrderforShowViewModel cOrderforShowViewModel = new COrderforShowViewModel()
            {

                orderDetailList = orderDetailList,
                orderList = orderList,
                productList = prodList,
                productSpecificationList = prodspecList
            };

            return View(cOrderforShowViewModel);
        }

        public IActionResult ReceiveCoupon(int? id)
        {
            if (id == null || id == 0)
                return RedirectToAction("Login", "Login");

            var cGet = _medicalContext.Coupons.Select(c => new CGetCouponViewModel
            {
                MemId = (int)id,
                coupon = c,
                couponDetail = c.CouponDetails.FirstOrDefault(cd => cd.MemberId == id && cd.CouponId == c.CouponId)
            });

            return View(cGet);
        }
        [HttpPost]
        public IActionResult ReceiveCoupon(int memberId,int couponId,bool couponUsed)
        {
            CouponDetail cd = new CouponDetail();
            cd.MemberId = memberId;
            cd.CouponId = couponId;
            cd.CouponUsed = couponUsed;
            _medicalContext.Add(cd);
            _medicalContext.SaveChanges();


            var cGet = _medicalContext.Coupons.Select(c => new CGetCouponViewModel
            {
                MemId = (int)memberId,
                coupon = c,
                couponDetail = c.CouponDetails.FirstOrDefault(cd => cd.MemberId == memberId && cd.CouponId == c.CouponId)
            });

            return View(cGet);
        }

        public IActionResult emptyCart()
        {
            return View();
        }


        //========================= 臨時用=========================

        public IActionResult tempList()
        {
            IEnumerable<MProductViewModel> datas = null;
            datas = _medicalContext.ProductSpecifications.Include(a => a.Product).Include(a => a.Product.ProductBrand)
               .Include(a => a.Product.ProductCategory).Select(a => new MProductViewModel
               {
                   product = a.Product,
                   productBrand = a.Product.ProductBrand,
                   productCate = a.Product.ProductCategory,
                   productSpec = a

               });
            return View(datas);
        }

        public ActionResult tempEdit(int? id)
        {
            IEnumerable<MProductViewModel> datas = _medicalContext.ProductSpecifications.Select(a => new MProductViewModel { product = a.Product, productSpec = a, productCate = a.Product.ProductCategory, productBrand = a.Product.ProductBrand });
            MProductViewModel mProduct = datas.FirstOrDefault(a => a.ProductId == id);
            if (mProduct == null)
                return RedirectToAction("tempList");

            else
            {



                IEnumerable<SelectListItem> objselectListItem = (from p in _medicalContext.ProductBrands
                                                                 where p.ProductBrandName != null
                                                                 select p).ToList().Select(p => new SelectListItem
                                                                 { Value = p.ProductBrandId.ToString(), Text = p.ProductBrandName });

                ViewBag.SelectListItem = objselectListItem;



                return View(mProduct);
            }
        }

        [HttpPost]
        public ActionResult tempEdit(MProductViewModel mp/*, int ProductBrandId*/)
        {


            Product mprod = _medicalContext.Products.FirstOrDefault(a => a.ProductId == mp.productSpec.ProductId);
            ProductSpecification mps = _medicalContext.ProductSpecifications.FirstOrDefault(m => m.ProductSpecificationId == mp.productSpec.ProductSpecificationId);

            if (mprod != null && mps != null)
            {
                if (mp.photo != null)
                {
                    string mpName = Guid.NewGuid().ToString() + ".jpg";
                    mp.photo.CopyTo(new FileStream(environment.WebRootPath + "/images/" + mpName, FileMode.Create));
                    mps.ProductImage = mpName;
                }
                //Product



                mprod.ProductBrandId = mp.ProductBrandId;
                mprod.ProductName = mp.ProductName;
                mprod.Shelfdate = mp.Shelfdate;
                mprod.Stock = mp.Stock;
                mprod.Discontinued = mp.Discontinued;

                // ProductSpec
                mps.ProductAppearance = mp.ProductAppearance;
                mps.ProductColor = mp.ProductColor;
                mps.ProductMaterial = mp.ProductMaterial;
                mps.UnitPrice = mp.UnitPrice;

            }

            try
            {
                _medicalContext.SaveChanges();
            }
            catch (DbUpdateException)
            {

            }
            return RedirectToAction("tempList");


        }


        public IActionResult tempOtherPic()
        {
            var q = _medicalContext.OtherProductImages.ToList();

            return View(q);
        }


        public IActionResult tempAddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult tempAddProduct(CProductViewModel cc)
        {

            Product p = new Product()
            {

                ProductBrandId = cc.ProductBrandId,
                ProductCategoryId = cc.ProductCategoryId,
                ProductName = cc.ProductName,
                Discontinued = cc.Discontinued,
                Shelfdate = cc.Shelfdate,
                Stock = cc.Stock


            };
            _medicalContext.Products.Add(p);
            _medicalContext.SaveChanges();

            ProductSpecification ps = new ProductSpecification()
            {


                ProductColor = cc.ProductColor,
                ProductAppearance = cc.ProductAppearance,
                ProductMaterial = cc.ProductMaterial,
                UnitPrice = cc.UnitPrice,
                ProductId = p.ProductId

            };

            if (cc.photo != null)
            {
                string mpName = Guid.NewGuid().ToString() + ".jpg";
                cc.photo.CopyTo(new FileStream(environment.WebRootPath + "/images/" + mpName, FileMode.Create));
                ps.ProductImage = mpName;
            }


            _medicalContext.ProductSpecifications.Add(ps);

            _medicalContext.SaveChanges();

            return RedirectToAction("tempAddProduct");
        }

        public IActionResult test001()
        {
            var q = _medicalContext.ProductBrands.ToList();

            return View(q);

        }
        [HttpPost]
        public IActionResult test001(int[] pbID)
        {
            var q = _medicalContext.ProductBrands.ToList();

            return View(q);

        }



        // ============ 柏鈞 End =================
    }
}
