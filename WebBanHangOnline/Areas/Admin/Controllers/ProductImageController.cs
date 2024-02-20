using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class ProductImageController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProductImage
        public ActionResult Index(int id)
        {
            ViewBag.ProductId = id;
            var items = db.ProductImages.Where(x => x.ProductId == id).ToList();
            return View(items);
        }

        [HttpPost]
        public ActionResult AddImage(int productId,string url)
        {
            db.ProductImages.Add(new ProductImage { 
                ProductId=productId,
                Image=url,
                IsDefault=false
            });
            db.SaveChanges();
            return Json(new { Success=true});
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.ProductImages.Find(id);
            db.ProductImages.Remove(item);
            db.SaveChanges();
            return Json(new { success = true });
        }
        [HttpPost]
        public ActionResult IsDefault(int id)
        {
            var item = db.ProductImages.Find(id);
            if (item != null)
            {
                // Cập nhật tất cả các ProductImages có ProductId = 1 thành IsDefault = false
                var productImagesToUpdate = db.ProductImages.Where(i => i.ProductId == item.ProductId);
                productImagesToUpdate.ToList().ForEach(i => i.IsDefault = false);
                db.SaveChanges();

                // Cập nhật item.IsDefault = true
                item.IsDefault = true;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return Json(new { success = true, isDefault = item.IsDefault });
            }

            return Json(new { success = false });
        }
    }
}