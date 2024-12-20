using Microsoft.AspNetCore.Mvc;
using prj_MVC_core.Models;
using prj_MVC_core.ViewModels;
using System.Collections.Generic;

namespace prj_MVC_core.Controllers
{
    public class CustomerController : Controller
    {

        public IActionResult test03()
        {

            TCustomer x = new TCustomer();
            x.FName = "Test03";
            x.FPhone = "Test03";
            CMyClass CC = new CMyClass(x);
            CC.customer1 = x;
            CC.insert3();
            return View();
        }

        public IActionResult test() 
        {
            
            TCustomer x = new TCustomer();
            x.FName= "Test";
            x.FPhone = "09xxxxx";           
            CMyClass CC = new CMyClass(x);
            CC.customer1 = x;
            CC.insert3();
            return View();
        }
        public IActionResult List(CKeywordViewModel vm)
        {
            DbdemoContext db = new DbdemoContext();
            //新版不提供Request回傳資料，所以透過ViewModel將資料儲存後回傳
            string keyword = vm.txtKeyword;
            IEnumerable<TCustomer> datas = null;
            if (string.IsNullOrEmpty(keyword))
                datas = from t in db.TCustomers select t;
            else
                datas = db.TCustomers.Where(c => c.FName.Contains(keyword) || c.FPhone.Contains(keyword) || c.FEmail.Contains(keyword) || c.FAddress.Contains(keyword));

            List<CCustomerWrap> list = new List<CCustomerWrap>();
            foreach (var item in datas)
            { 
                list.Add(new CCustomerWrap() { customer = item });
            }
               
            return View(list);            
        }

        public IActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult Create(TCustomer customer)
        {
            DbdemoContext db = new DbdemoContext();
            db.TCustomers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("List");
        }

     
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                DbdemoContext db = new DbdemoContext();
                TCustomer customer = db.TCustomers.FirstOrDefault(c => c.Fid == id);
                if (customer != null)
                {
                    db.TCustomers.Remove(customer);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");

            DbdemoContext db = new DbdemoContext();
            IEnumerable<TCustomer> datas = null;
            TCustomer customer = db.TCustomers.FirstOrDefault(c => c.Fid == id);
            if (customer == null)
                return RedirectToAction("List");                 

           
          

            return View(new CCustomerWrap() { customer = customer });
        }


        [HttpPost]
        public IActionResult Edit(CCustomerWrap C)
        {
            DbdemoContext db = new DbdemoContext();
            TCustomer customer = db.TCustomers.FirstOrDefault(cs => cs.Fid == C.Fid);
            if (customer != null)
            {
                customer.FName = C.FName;
                customer.FPhone = C.FPhone;
                customer.FEmail = C.FEmail;
                customer.FAddress = C.FAddress;
                customer.FPassword = C.FPassword;
                
                db.SaveChanges();
            }

            return RedirectToAction("List");
        }
       
      

    }
}
