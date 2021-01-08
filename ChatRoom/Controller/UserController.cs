
using System;
using System.Collections.Generic;
using ChatRoom.Dto;
using ChatRoom.Entity;
using ChatRoom.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChatRoom.controller
{
    public class UserController : Controller
    {
        private IUserService _userService;

        private IRoomService _roomService;

        public UserController(IUserService userService, IRoomService roomService)
        {
            _userService = userService;
            _roomService = roomService;
        }

        [Route("/")]
        [Route("/login")]
        public ActionResult ToLogin()
        {
            return View("~/Views/Login.cshtml");
        }
        
        [HttpPost]
        [Route("/login")]
        public ActionResult Login(string username, string password)
        {
            
            if (username != null && password != null)
            {
                User user = _userService.GetLoginUser(username, password);
                if (user != null)
                {
                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
                    return RedirectToAction("ToChatRoom");
                }
                return RedirectToAction("ToLogin");
            }
            return RedirectToAction("ToLogin");
        }

        [HttpGet]
        [Route("/register")]
        public ActionResult ToRegistration()
        {
            return View("~/Views/registration.cshtml");
        }
        
        [HttpPost]
        [Route("/register")]
        public ActionResult Register(User user)
        {
            Boolean res = false;
            
            if (user != null)
            {
                 res = _userService.AddUser(user);
            }

            if (res)
            {
                return RedirectToAction("ToLogin");
            }

            ViewBag.warnning = "Registration failed, Please try again";
            
            return View("~/Views/Registration.cshtml");
        }
        

        [HttpGet]
        [Route("/chatRoom")]
        public ActionResult ToChatRoom()
        {
            string userStr = HttpContext.Session.GetString("user");
            if (userStr != null)
            {
               User user = JsonConvert.DeserializeObject<User>(userStr);
                IEnumerable<Room> privateRooms = _roomService.GetAllRoomsPrivate(user.Uid);
                IEnumerable<Room> publicRooms = _roomService.GetAllRoomsPublic();
                ChatRoomInitModel chatRoomInitModel = new ChatRoomInitModel();
                chatRoomInitModel.PrivateRooms = privateRooms;
                chatRoomInitModel.PublicRooms = publicRooms;
                
                return View("~/Views/ChatRoom.cshtml", chatRoomInitModel);
            }

            return RedirectToAction("ToLogin");

        }
        
        [HttpGet]
        [Route("/logout")]
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("ToLogin");
        }

        [HttpGet]
        [Route("/userName")]
        public ActionResult findUserByNickName(String name)
        {
            if (name != null && name.Length > 0)
            {
                return _userService.CheckUserNickname(name) ? Json(new {msg = "exist"}) : Json(new {msg = "not exist"});
            }
            return Json(new {msg = "not exist"});
        }
        
        [HttpGet]
        [Route("/registrationCheck")]
        public ActionResult registrationCheck(String username,String nickname)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(nickname))
            {
                if (_userService.FindUserByNickname(nickname) != null)
                {
                    return Json(new {msg = "nickname indispo"});
                }

                if (_userService.FindUserByUsername(username) != null)
                {
                    return Json(new {msg = "username indispo"});
                }
                
                return Json(new {msg = "dispo" });
            }

            return Json(new {msg = "null parameter"});
        }
    }
}