using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class ProductQuantityController : Controller
    {
        // GET: Admin/ProductQuaniti
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int id)
        {
            ViewBag.ProductId = id;
            ViewBag.Sizes = db.Sizes.ToList();
            ViewBag.Colors = db.Colors.ToList();
            ViewBag.ProductId = id;
            var items = db.ProductQuanlities.Where(x => x.ProductId == id).ToList();
            return View(items);
        }

        [HttpPost]
        public ActionResult Add(int productId, int sizeId,int colorId, int quantity )
        {
            var item = db.ProductQuanlities.FirstOrDefault(x => x.SizeId == sizeId && x.ColorId == colorId);
            if(item == null)
            {
                db.ProductQuanlities.Add(new ProductQuanlity
                {
                    ProductId = productId,
                    SizeId = sizeId,
                    ColorId = colorId,
                    Quantity = quantity
                });
                db.SaveChanges();
                
            }
            return Json(new { Success = true });

        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.ProductQuanlities.Find(id);
            db.ProductQuanlities.Remove(item);
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
}