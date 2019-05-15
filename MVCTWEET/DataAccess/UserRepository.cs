using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public  class UserRepository
    {
        public void AddUser(Person objUser)
        {
            try
            {
                using (var objcontext=new MVCSBAEntities() )
                {
                    objcontext.Persons.Add(objUser);
                    objcontext.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool VerifyUser(string Username,string Password)
        {
            bool IsvalidUser = false;
            try
            {
                using (var objcontext = new MVCSBAEntities())
                {
                    var NoOfusers = (from obj in objcontext.Persons
                                where obj.userid == Username && obj.password == Password
                                select obj).Count();
                    IsvalidUser = NoOfusers > 0;
                    
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return IsvalidUser;
        }
    }
}
