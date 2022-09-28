using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinerAPP.Application.Interfaces;

namespace MinerAPP.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsersServices _usersServices;

        public UserController(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }
        // GET: UserController
        public ActionResult Index()
        {
            List<string> names = _usersServices.GetUsernames();
            List<MinerAPP.Infrastructure.DTO.User> users = new List<Infrastructure.DTO.User>();
            foreach (var item in names)
            {
                users.Add(new Infrastructure.DTO.User { username = item });
            }
            return Ok(users);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
