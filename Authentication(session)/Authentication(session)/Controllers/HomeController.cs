using Authentication_session_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Authentication_session_.Controllers
{
    //Home Controller
    // Use username = Sameer0 password =ESW0
    public class HomeController : Controller
    {
        public List<User> userList = new List<Models.User>();
        
        //creating dummy Users
        public void UserInitialization()
        {
           for (int i = 0; i < 10; i++)
            {
                User user = new Models.User
                {
                    id = i,
                    userName = "Sameer" + i,
                    password = "ESW" + i
                };
                userList.Add(user);//list of dummy users
            }
           
        }


        public ActionResult Index()
        {
            UserInitialization();
            if (Session["user"] != null)
            {
                return View(userList); //if user is logged in then go to index view
            }
            else
            {
                return RedirectToAction("Login"); // not logged in then go to login
            }
        }
        public ActionResult Login()
        {
               UserInitialization();

            if (Session["user"] != null)
                return RedirectToAction("Index"); //if loggedin then go to index
            else
                return View(); //otherwise login page
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            UserInitialization();
            bool isExist = userList.Any(x => x.userName == user.userName && x.password == user.password);
            //checking the credentials of user i.e. authentication

            if (isExist)
            {
                Session["user"] = user.userName;
                return RedirectToAction("Index");//if valid set session var and go to index
            }

            else
            {
                TempData["incorrect"] = "Username or password incorrect"; //show user that credentials are incorrect
                return RedirectToAction("Login"); //otherwise login page
                
            }
        }
        public ActionResult Logout()
        {
            Session["user"] = null;// logout the user
            return RedirectToAction("Login");
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
    }
}