using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using CC.Core.Mapping;
using CellService;
using Domain.T2C;
using Microsoft.AspNet.Identity;
using T2C.Login;
using T2C.Models;

namespace T2C.Controllers
{

    public class UserController : Controller
    {
        private readonly IService _servicio;
        private readonly IMapper _mapper;

        public UserController(IService servicio, IMapper mapper)
        {
            _servicio = servicio;
            _mapper = mapper;
        }

     
        // GET: User

        public ActionResult Index()
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            return View(_mapper.Map<List<UserModel>>(_servicio.ListUsers()));
        }

     
        // GET: User/Details/5

        public ActionResult Details(Guid id)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            return View(_mapper.Map<UserModel>(_servicio.GetUser(id)));
        }

     
        // GET: User/Create

        public ActionResult Create()
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            return View();
        }

     
        // POST: User/Create
        [HttpPost]
      
        public ActionResult Create(UserModel user)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            if (ModelState.IsValid)
            {
                _servicio.AddUser(_mapper.Map<UserModel, UserCell>(user));
                return RedirectToAction("Index");
            }

            ViewBag.NombreAgencia = new SelectList(_servicio.ListUsers(), "Nombre", "Nombre", user.UserName);


            return View(user);
        }

     
        // GET: User/Edit/5

        public ActionResult Edit(Guid id)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            var user = _mapper.Map<UserModel>(_servicio.GetUser(id));
            // ViewBag.NombreCategoria = new SelectList(_servicio.ListUsers(), "Nombre", "Nombre", user.UserName);
            return View(user);
        }

     
        // POST: User/Edit/5
        [HttpPost]
      
        public ActionResult Edit(UserModel user)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            if (ModelState.IsValid)
            {
                _servicio.UpdateUser(_mapper.Map<UserCell>(user));
                return RedirectToAction("Index");
            }
            // ViewBag.NombreCategoria = new SelectList(_servicio.ListUsers(), "Nombre", "Nombre");

            return View(user);
        }


        // GET: User/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            return View(_mapper.Map<UserModel>(_servicio.GetUser(id)));
        }

     
        // POST: Anuncio/Delete/5

        [HttpPost]

        [ActionName("Delete")]

        public ActionResult DeleteConfirm(Guid id)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            _servicio.RemoveUser(_mapper.Map<UserCell>(_servicio.GetUser(id)));
            return RedirectToAction("Index");
        }


        public ActionResult LoginUser()
        {
            return View();
        }


        [HttpPost]

        public ActionResult LoginUser(string userName, string password)
        {
            if (ModelState.IsValid)
            {

                var user = _servicio.GetUser(userName, password);
                if (user != null)
                {
                    //  SessionUser.AddUserToSession(user.Id.ToString());
                   // FormsAuthentication.SetAuthCookie(userName, false);
                    Session["UserID"] = user.Id.ToString();
                    Session["Username"] = user.UserName;
                    return RedirectToAction("Index", "Cell");
                        //dirigir controlador home vista Index una vez se a autenticado en el sistema

                }
            }

            return View();
        }



        /// <summary>
        /// Cerrar sesion del usuario autenticado
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
         Session.Clear();
            return RedirectToAction("t2c", "Page");
        }


    }
}
