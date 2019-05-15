using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCUI.Models;
using DataAccess;
namespace MVCUI.Controllers
{
    [Authorize]
    public class BlogsController : Controller
    {
        // GET: Blogs
        public ActionResult Index()
        {
            var repository = new TweetRepository();
            var objTweets = repository.GetAllTweets();
            var tweetModel = new List<TweetViewModel>();
            foreach (var item in objTweets)
            {
                tweetModel.Add(new TweetViewModel { userid = item.userid, TweetID = item.TweetID, message = item.message, created = item.created });
            }

            return View(tweetModel);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken,ValidateInput(false)]
            public ActionResult create(TweetViewModel objModel)
        {
            if (ModelState.IsValid)
            {
                var objTweet = new Tweet();
                objTweet.TweetID = objModel.TweetID;
                objTweet.message = objModel.message;
                objTweet.userid = User.Identity.Name;
                objTweet.created = DateTime.Now;

                //create repository
                var Repository = new TweetRepository ();
                Repository.AddTweet(objTweet);

                ViewBag.Message = "Tweets sent for Request";
            }
            return View(objModel);
        }
        public ActionResult MyProfile()
        {
            string userID = User.Identity.Name;
            var repository = new TweetRepository();
            var objTweets = repository.ViewTweetsByUsername(userID);
            var tweetModel = new List<TweetViewModel>();
            foreach (var item in objTweets)
            {
                tweetModel.Add(new TweetViewModel { userid = item.userid, TweetID = item.TweetID, message = item.message, created = item.created });
            }
            return View(tweetModel);
        }
        public ActionResult EditTweet(int id)
        {
            var repository = new TweetRepository();
            var tweetObj = repository.FindTweet(id);
            var tweetModel = new TweetViewModel { userid = tweetObj.userid, TweetID = tweetObj.TweetID, message = tweetObj.message, created = tweetObj.created };
            return View(tweetModel);
        }
        [HttpPost, ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult EditTweet(TweetViewModel objTweetModel)
        {
            if (ModelState.IsValid)
            {
                var objTweet = new Tweet();
                objTweet.message = objTweetModel.message;
                objTweet.created = DateTime.Now;
                objTweet.userid = User.Identity.Name;
                objTweet.TweetID = objTweetModel.TweetID;

                var tRep = new TweetRepository();
                tRep.EditTweet(objTweet);
                ViewBag.msg = "Editted Successfully";
            }
            else
            {
                ViewBag.msg = "Error Occured";

            }
            return View(objTweetModel);
        }


        public ActionResult DeleteTweet(int id)
        {

            var repository = new TweetRepository();
            repository.DeleteTweet(id);
            return RedirectToAction("MyProfile", "Twitter");
        }



    }
}