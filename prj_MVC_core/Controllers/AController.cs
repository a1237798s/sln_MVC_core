using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using prj_MVC_core.Models;

namespace prj_MVC_core.Controllers
{
    public class AController : Controller
    {
        /* 序列化轉成JSON */        
        public string demoObjJson1() 
        {
            TCustomer customer = new TCustomer()
            {
                FName = "Json",
                FPhone = "1234567890",
                FEmail = "Json@gmail.com",
                FAddress = "123",
                FPassword = "12345"
            };
            string json = JsonSerializer.Serialize(customer);
            return json;
        }

        /* 序列化在轉回Object */
        public string demoObjJson2()
        {
            string json = demoObjJson1();
            TCustomer customer = JsonSerializer.Deserialize<TCustomer>(json);
            return "姓名:" + customer.FName + " 電話:"+customer.FPhone+ " Email:"+ customer.FEmail + customer;
        }


        public IActionResult Index()
        {
            return View();
        }

        public string SayHello() 
        {
            return "Hello world";
        }

        public IActionResult conutBySession() 
        {
            //int count = 0;
            //if (HttpContext.Session.Keys.Contains("COUNT")) 
            //{
            //    count = (int)HttpContext.Session.GetInt32("COUNT");
            //}
            //count++;
            //HttpContext.Session.SetInt32("COUNT", count);         
            //ViewBag.Count = count;

            //return View();

            // 從 Session 中取得 "COUNT" 值
            int count = HttpContext.Session.GetInt32("COUNT") ?? 0;

            // 增加計數
            count++;

            // 將更新後的值儲存回 Session
            HttpContext.Session.SetInt32("COUNT", count);

            // 將計數結果顯示在畫面
            ViewBag.Count = count;
            return View();
        }

        public string Lotto()
        {
            Random rnd = new Random();
            int[] arr = new int[6];
            int count = 0;
            string s = "";

            while (count < 6)
            {
                int x = rnd.Next(1, 50); // 產生 1 到 49 的隨機數
                                         // 檢查是否重複
                bool exists = false;
                for (int i = 0; i < count; i++)
                {
                    if (arr[i] == x)
                    {
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    arr[count] = x;
                    count++;
                }
            }

            // 排序 (可以用 Array.Sort 簡化)
            Array.Sort(arr);

            foreach (int i in arr)
            {
                s += $"{i} ";
            }
            return s;
        }
    }
}
