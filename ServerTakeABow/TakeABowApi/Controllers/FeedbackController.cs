﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TakeABowApi.Common;

namespace TakeABowApi.Controllers
{
    public class FeedbackController : ApiController
    {
         int num_feedback_id = 1000;

        TakeABowApi.Logic.Logic logic = new TakeABowApi.Logic.Logic();

        [HttpGet]
        [Route("api/feedback/test")]
        public bool Get()
        {
            return true;
        }

        /*עובד*/
        [HttpGet]
        [Route("api/feedback/createFeedback")]
        public bool Get(int fromUserId, int toUserId, string feedback, bool isAnonymous, bool isSeen ,bool isDeleted)
        {
            Feedbacks f = new Feedbacks(/*num_feedback_id++,*/ fromUserId, toUserId, feedback, isAnonymous, false, false);
            bool res = logic.saveNewFeedback(f);
            if(res)
               return true;
            return false;

        }



        [HttpGet]
        [Route("api/feedback/topFeedBack")]
        public IOrderedEnumerable<KeyValuePair<int, List<Feedbacks>>> GET()
        {
            return logic.getTopFeedbacks();
         
        }

        //[HttpGet]
        //[Route("api/feedback/deleteFeedback")]
        //public bool Get(int fId)
        //{
        //    Feedbacks f = logic.deleteFeedback(fId);
        //    if(f == true)
        //        return true;
        //    return false;

        //}




    }


}