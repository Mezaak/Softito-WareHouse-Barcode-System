using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Business.Concreate;
using Data.Abstarct;
using Data.EntityFramework;
using Entity.Concreate;


namespace UI.Controllers
{
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EFProductDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        OrderManager om = new OrderManager(new EFOrderDal());

        public ActionResult Index()
        {
            var sonuc = pm.ProductListe();
            return View(sonuc);
        }

        [HttpPost]

        public ActionResult Productadd(Product product)
        {
            SetCategoryViewBag(); 

            // Aynı isim veya barkod var mı kontrol edelim
            if (pm.ProductListe().Any(p => p.ProductName == product.ProductName))
            {
                ViewBag.ErrorMessage = "❌ Bu ürün adı zaten mevcut!";
                SetCategoryViewBag(); // Kategoriler hata sonrası tekrar yüklenmeli!
                return View();
            }

            if (pm.ProductListe().Any(p => p.Barcode == product.Barcode))
            {
                ViewBag.ErrorMessage = "❌ Bu barkod zaten başka bir ürüne ait!";
                SetCategoryViewBag(); // Kategoriler hata sonrası tekrar yüklenmeli!
                return View();
            }

            // Ürün ekleme işlemi
            pm.ProductInsert(product);
            ViewBag.SuccessMessage = "✔ Ürün başarıyla eklendi!";
            SetCategoryViewBag(); // Kategoriler başarı durumunda da tekrar yüklensin!
            return View();
        }

        // 📌 Sipariş Verme Ekranı (GET)
        public ActionResult CreateOrder()
        {
            ViewBag.Products = pm.ProductListe()
                .Select(p => new SelectListItem
                {
                    Text = p.ProductName + " - Stok: " + p.Quantity,
                    Value = p.ProductId.ToString()
                }).ToList();

            return View();
        }

        // 📌 Sipariş Verme İşlemi (POST)
        [HttpPost]
        public ActionResult CreateOrder(int productId, int quantity)
        {
            var product = pm.ProductGetById(productId);
            if (product == null)
            {
                ViewBag.ErrorMessage = "Ürün bulunamadı!";
                return View();
            }

            if (product.Quantity < quantity)
            {
                ViewBag.ErrorMessage = "Yeterli stok yok!";
                return View();
            }

            // Stoktan düş
            product.Quantity -= quantity;
            pm.Productupdate(product);

            // Siparişi kaydet
            Orders newOrder = new Orders
            {
                ProductId = productId,
                Quantity = quantity,
                OrderDate = DateTime.Now
            };
            om.Orderinsert(newOrder);

            ViewBag.SuccessMessage = "Sipariş başarıyla oluşturuldu!";
            return RedirectToAction("CreateOrder");
        }

        [HttpGet]
        public ActionResult Productadd()
        {
            EnsureCategoriesExist(); // ✅ Kategorileri kontrol eden metot

            SetCategoryViewBag(); // ✅ ViewBag.Category ayarlanıyor

            return View();
        }


        // 📌 Barkod Okuma Sayfası
        public ActionResult BarcodeScanner()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BarcodeScanner(string barcode)
        {
            var product = pm.ProductListe().FirstOrDefault(p => p.Barcode == barcode);

            if (product != null)
            {
                product.Quantity += 1;
                pm.Productupdate(product); 
                ViewBag.Message = $"✔ {product.ProductName} stoğu artırıldı!";
            }
            else
            {
                ViewBag.NoProduct = true; 
            }

            return View();
        }

        public ActionResult Reports()
        {
            var products = pm.ProductListe();
            return View(products);
        }

        // ✅ Kategorilerin olup olmadığını kontrol eden metot
        private void EnsureCategoriesExist()
        {
            if (!cm.GetAll().Any()) // Eğer hiç kategori yoksa
            {
                cm.CategoryInsert(new Category { CategoryName = "Elektronik" });
                cm.CategoryInsert(new Category { CategoryName = "Giyim" });
                cm.CategoryInsert(new Category { CategoryName = "Ev Eşyaları" });
            }
        }

        // ✅ Kategorileri `ViewBag` içine yükleyen metod
        private void SetCategoryViewBag()
        {
            List<SelectListItem> categoryList = cm.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.CategoryName,
                    Value = c.CategoryId.ToString()
                }).ToList();

            ViewBag.Category = categoryList;
        }
    }
}
