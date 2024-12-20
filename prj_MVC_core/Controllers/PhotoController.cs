using Microsoft.AspNetCore.Mvc;
using prj_MVC_core.Models;
using prj_MVC_core.ViewModels;
using System.Text.Json;

namespace prj_MVC_core.Controllers
{
    public class PhotoController : Controller
    {
        IWebHostEnvironment _env = null;
        public PhotoController(IWebHostEnvironment IHE) 
        {
           _env= IHE;
        }



        public IActionResult List(CKeywordViewModel vm)
        {
            if(!HttpContext.Session.Keys.Contains(CDictionary.SK_LOGEDIN_USER))
                return RedirectToAction("Login","Home");

            string json = HttpContext.Session.GetString(CDictionary.SK_LOGEDIN_USER);
            TCustomer customer = JsonSerializer.Deserialize<TCustomer>(json);

            DbdemoContext db = new DbdemoContext();
            //新版不提供Request回傳資料，所以透過ViewModel將資料儲存後回傳
            string keyword = vm.txtKeyword;
            IEnumerable<TPhoto> datas = null;
            if (string.IsNullOrEmpty(keyword))
                datas = from t in db.TPhotos 
                        where t.FOwnerId == customer.Fid
                        select t;
            else
                datas = db.TPhotos.Where(c => c.FDescription.Contains(keyword) && c.FOwnerId==customer.Fid); 

            List<CPhotoWrap> list = new List<CPhotoWrap>();
            foreach (var item in datas)
            {
                list.Add(new CPhotoWrap() { photo = item });
            }

            return View(list);            
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CPhotoWrap photo)
        {
            if (!HttpContext.Session.Keys.Contains(CDictionary.SK_LOGEDIN_USER))
                return RedirectToAction("List");
            string json = HttpContext.Session.GetString(CDictionary.SK_LOGEDIN_USER);
            TCustomer customer = JsonSerializer.Deserialize<TCustomer>(json);
            if (photo.photoPath != null)
            {
                string photoName = Guid.NewGuid().ToString() + ".jpg";
                photo.FImage = photoName;
                photo.photoPath.CopyTo(new FileStream(_env.WebRootPath+"/imgs/" + photoName,FileMode.Create));
            }
            DbdemoContext db = new DbdemoContext();
            photo.FDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            photo.FOwnerId = customer.Fid;
            db.TPhotos.Add(photo.photo);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                DbdemoContext db = new DbdemoContext();
                TPhoto photo = db.TPhotos.FirstOrDefault(t => t.Fid == id);
                if (photo != null)
                {
                    db.TPhotos.Remove(photo);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            DbdemoContext db = new DbdemoContext();
            TPhoto photo = db.TPhotos.FirstOrDefault(p => p.Fid == id);
            if (photo == null)
                return RedirectToAction("List");

            return View(new CPhotoWrap() { photo=photo});
        }

        [HttpPost]
        public ActionResult Edit(CPhotoWrap p)
        {
            DbdemoContext db = new DbdemoContext();
            TPhoto photo = db.TPhotos.FirstOrDefault(c => c.Fid == p.Fid);
            if (photo != null)
            {
                photo.FDescription = photo.FDescription;              
                photo.FImage = photo.FImage;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
