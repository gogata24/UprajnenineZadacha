using Microsoft.AspNetCore.Mvc;
using UprajnenineZadacha.Db;
using UprajnenineZadacha.Models;
using UprajnenineZadacha.ViewModels;

namespace UprajnenineZadacha.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserViewModel model)
        {
            using (var db = new ZadachaDbContext())
            {
                User user = new User();
                user.Id = model.Id;
                user.Email = model.Email;
                user.Username = model.Username;
                user.Password = model.Password;
                user.Phone = model.Phone;
                db.Users.Add(user);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Read()
        {
            using (var db = new ZadachaDbContext())
            {
                var data = db.Users.ToList();
                return View(data);
            }
        }

        public IActionResult Edit(int id)
        {
            using (var db = new ZadachaDbContext())
            {
                var user = db.Users.SingleOrDefault(x => x.Id == id);
                return View(user);
            }
        }
        [HttpPost]
        public IActionResult Edit(int id, User model)
        {
            using (var db = new ZadachaDbContext())
            {
                var user = db.Users.FirstOrDefault(x => x.Id == id);
                if(user!=null)
                {
                    user.Email = model.Email;
                    user.Username = model.Username;
                    user.Password = model.Password;
                    user.Phone = model.Phone;
                    db.SaveChanges();
                    return RedirectToAction("Read");   
                }
                else { return View(); }

            }
        }


        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id) 
        {
            using (var db = new ZadachaDbContext())
            {
                var user = db.Users.FirstOrDefault(x => x.Id == id);
                if(user!=null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    return RedirectToAction("Read");
                }
                else return View();
            }
        }

    }
}
