using System;
using ChatRoom.Entity;
using ChatRoom.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChatRoom.controller
{
    public class RoomController : Controller
    {
        private IUserService _userService;

        private IRoomService _roomService;

        public RoomController(IUserService userService, IRoomService roomService)
        {
            _userService = userService;
            _roomService = roomService;
        }


        [HttpGet]
        [Route("/room")]
        public ActionResult ToRoomCreation()
        {
            return View("~/Views/RoomCreation.cshtml");
        }

        [HttpGet]
        [Route("/privateTalk")]
        public ActionResult ToPrivateChat()
        {
            return View("~/Views/PrivateTalk.cshtml");
        }

        [HttpPost]
        [Route("/privateTalk")]
        public void CreatePrivateTalk(String name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                User guest = _userService.FindUserByNickname(name);
                if (guest != null)
                {
                    string userStr = HttpContext.Session.GetString("user");
                    if (userStr != null)
                    {
                        Room room = new Room();
                        room.Owner = JsonConvert.DeserializeObject<User>(userStr).Uid;
                        room.Type = "private";
                        room.Name = name;
                        room.Guest = guest.Uid;
                        _roomService.AddRoom(room);
                    }
                    Response.Redirect("/chatRoom", false);
                }
            }
        }

        [HttpPost]
        [Route("/room")]
        public ActionResult CreateRoom(Room room)
        {
            if (room != null)
            {
                string userStr = HttpContext.Session.GetString("user");
                if (userStr != null)
                {
                    room.Owner = JsonConvert.DeserializeObject<User>(userStr).Uid;
                    room.Type = "public";

                    _roomService.AddRoom(room);
                }
            }

            return RedirectToAction("ToChatRoom", "User");
        }

        [HttpGet]
        [Route("/roomName")]
        public JsonResult CheckRoomName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return _roomService.CheckRoomName(name) ? Json(new {msg = "indispo"}) : Json(new {msg = "dispo"});
            }

            return Json(new {msg = "indispo"});
        }
    }
}