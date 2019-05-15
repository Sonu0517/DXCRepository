using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TweetRepository
    {
        public void AddTweet(Tweet objTweet)
        {
            try
            {
                using (var objcontext = new MVCSBAEntities())
                {
                    objcontext.Tweets.Add(objTweet);
                    objcontext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            public  IEnumerable<Tweet> ViewTweetsByUsername(string username)
            {
                List<Tweet> objTweets = new List<Tweet>();
                try
                {
                    using (MVCSBAEntities objcontext = new MVCSBAEntities())
                    {
                        var Query = from obj in objcontext.Tweets
                                    where obj.userid == username
                                    select new
                                    {
                                        obj.message
                                    };
                        foreach (var item in Query)
                        {
                            objTweets.Add(new Tweet { message = item.message });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return objTweets;
            }
        public IEnumerable<Tweet> GetAllTweets()
        {
            List<Tweet> objTweets = new List<Tweet>();
            try
            {
                using (MVCSBAEntities objcontext = new MVCSBAEntities())
                {
                    var tweets = from obj in objcontext.Tweets

                                 select obj;

                    foreach (var item in tweets)
                    {
                        objTweets.Add(new Tweet { userid = item.userid, TweetID = item.TweetID, message = item.message, created = item.created });
                    }
                }
                return objTweets;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            public void EditTweet(Tweet objTweet)
            {
                try
                {
                    using(MVCSBAEntities objcontext=new MVCSBAEntities())
                    {
                        objcontext.Tweets.Attach(objTweet);
                        objcontext.Entry(objTweet).State = System.Data.Entity.EntityState.Modified;
                        objcontext.SaveChanges();
                    }
                }
                  catch(Exception ex)
                {
                    throw ex;
                }
            }
            public  void DeleteTweet(int id)
        {
            try
            {
                using (MVCSBAEntities objcontext = new MVCSBAEntities())
                {
                    var Query = (from obj in objcontext.Tweets
                                 where obj.TweetID == id
                                 select obj).FirstOrDefault();
                    objcontext.Tweets.Remove(Query);
                    objcontext.SaveChanges();
                }
            }
             catch(Exception ex)
            {
                throw ex;
            }
        }
          public Tweet FindTweet(int id)
        {
            try
            {
                using (MVCSBAEntities objcontext = new MVCSBAEntities())
                {
                    var Query = (from obj in objcontext.Tweets
                                 where obj.TweetID == id
                                 select obj).FirstOrDefault();
                    return Query;
                }
            }
             catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
       
       
    

