using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using prj_MVC_core.Models;
using System.Text.Json;

namespace prj_MVC_core.Controllers
{
    public class PostController : Controller
    {
        public IActionResult List()
        {
            DbdemoContext db = new DbdemoContext();
            var customers= from c in db.TCustomers select c;
            
            db = new DbdemoContext();
            var datas = from t in db.TPhotos                   
                        select t;

            List<CPhotoWrap> list = new List<CPhotoWrap>();
            foreach (var data in datas) 
            {
                CPhotoWrap P =(new CPhotoWrap() { photo = data });
                TCustomer C = customers.FirstOrDefault(c=>c.Fid== data.FOwnerId);
                if (C != null) 
                {
                    P.postUser = C;                 
                }
                list.Add(P);
            }
            return View(list);
        }

        public IActionResult AddComment() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddComment(Tcomment C)
        {
            string json = HttpContext.Session.GetString(CDictionary.SK_LOGEDIN_USER);
            TCustomer user =JsonSerializer.Deserialize<TCustomer>(json);
            C.FPost = HttpContext.Session.GetInt32(CDictionary.SK_CURRENT_POSTID);
            C.FUserId = user.Fid;
            C.FDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            DbdemoContext db = new DbdemoContext();
            db.Tcomments.Add(C);
            db.SaveChanges();
            return RedirectToAction("Reply",new { id=C.FPost});

        }

        public IActionResult Reply(int id) 
        {
            HttpContext.Session.SetInt32(CDictionary.SK_CURRENT_POSTID,(int)id);
            TPhoto photo = (new DbdemoContext()).TPhotos.FirstOrDefault(p=>p.Fid ==id);
            if(photo == null) 
                return RedirectToAction("List");            
            ViewBag.PHOTO = photo.FImage;
            ViewBag.DESC = photo.FDescription;
            DbdemoContext db = new DbdemoContext();
            var post =(new DbdemoContext()).Tcomments.Where(c=>c.FPost==id);
            return View(post);
        }
    }
}
