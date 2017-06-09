using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using UserSignup.Models;
using UserSignup.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserSignup.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(AddUserViewModel user)
        {
            if (user == null) user = new AddUserViewModel();
            return View(user);
        }

        public IActionResult Add()
        {
            AddUserViewModel addUser = new AddUserViewModel();
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                AddUserViewModel user = new AddUserViewModel()
                {
                    Username = addUserViewModel.Username,
                    Email = addUserViewModel.Email,
                    Password = addUserViewModel.Password,
                    Verify = addUserViewModel.Verify
                };
                return RedirectToAction("Index", user);
            }

            return View(addUserViewModel);
        }
    }


}
