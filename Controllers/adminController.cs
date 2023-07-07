using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Blog.Models;
using Blog.Repository.Interfaces;
using Blog.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blog.Controllers
{
  public class AdminController : Controller
  {
    private readonly ILogger<AdminController> _logger;
    private readonly IRepositoryBase<User> _userRepository;
  
    public  AdminController(ILogger<AdminController> logger, IRepositoryBase<User> userRepository)
    {
      _logger = logger;
      _userRepository = userRepository;
    }

    public IActionResult Index()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

    public IActionResult Error()
    {
      return View("Error!");
    }

    public async Task<IActionResult> Register(UserViewModel model)
    {
      var newUser = new User(Guid.NewGuid(), model.Name, model.Password, model.Email);

      await _userRepository.AddAsync(newUser);
      return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Logged(UserViewModel model)
    {
      var users = await _userRepository.GetAll();
      var userExist = users.Where(a => a.Password == model.Password && a.Email == model.Email).Count();

      if (userExist > 0)
        return View();

      return RedirectToAction("Index", "Home");
    }
  }
}