using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StateManagment_Lab.Models;

namespace State_Managemet_Lab.Controllers
{
    public class HomeController : Controller
    {
        List<Item> ItemList = new List<Item>() {

            new Item("Hot Chocolate", "Milk, Cocoa, Sugar, Fat", 1.99),
            new Item("Latte",  "Milk, Coffee", 1.99),
            new Item("Coffee",  "Coffee, Water", 1.00),
            new Item("Tea", "Black Tea", 1.00),
            new Item("Frozen Lemonade",  "Lemon, Sugar, Ice", 1.99)
        };

        List<Item> ShoppingCart = new List<Item>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Register()
        {
            ViewBag.Message = "Register";
            return View();
        }
        public ActionResult Result(User r)
        {
            if (r.UserName != null)
            {
                Session["UserName"] = r.UserName;
                Session["Email"] = r.Email;
                Session["Password"] = r.Password;
                Session["Age"] = r.Age;
            }
            return View();
        }
        public ActionResult Logout()
        {

            ViewBag.name = Session["UserName"];
            Session["UserName"] = null;
            return View();
        }
        public ActionResult UserInfo(User r)
        {
            if (r.UserName != null)
            {
                Session["UserName"] = r.UserName;
                Session["Email"] = r.Email;
                Session["Passwrod"] = r.Password;
                Session["Age"] = r.Age;

            }
            return View();

        }
        public ActionResult ListItems()
        {
            ViewBag.ItemsList = ItemList;
            return View();
        }

        public ActionResult AddItem(string itemName)
        {
            if (Session["ShoppingCart"] != null)
            {
                ShoppingCart = (List<Item>)Session["ShoppingCart"];
            }

            foreach (Item item in ItemList)
            {
                if (item.ItemName == itemName)
                {
                    ShoppingCart.Add(item);
                }
            }

            Session["ShoppingCart"] = ShoppingCart;
            return RedirectToAction("ListItems");
        }

    }
}