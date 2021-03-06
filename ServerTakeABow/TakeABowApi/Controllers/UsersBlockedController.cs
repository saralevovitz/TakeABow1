﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Web.Http;
using TakeABowApi.Common;



namespace TakeABowApi.Controllers
{
    public class UsersBlockedController : ApiController
    {
        // GET: UsersBlocked
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        [Route("api/UsersBlocked/TakeABowDB")]
        public bool Get()
        {
            return true;
        }

        int num_blocks =100;
        TakeABowApi.Logic.Logic logic = new TakeABowApi.Logic.Logic();

        /*עובד*/
        [HttpGet]
        [Route("api/UsersBlocked/BlockUser")]
        public bool Get(int userId, int blockedUserId)
        {
            UsersBlocked u = new UsersBlocked(num_blocks++, userId, blockedUserId , true, DateTime.Now);
            if(logic.Block(u))
               return true;
            return false;

        }



    }
}