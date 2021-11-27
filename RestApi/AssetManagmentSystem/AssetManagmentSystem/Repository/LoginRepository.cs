using AssetManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagmentSystem.Repository
{
    public class LoginRepository : ILoginRepository
    {

        AssetManagmentSystemContext db;
        //constructor dependency injection
        public LoginRepository(AssetManagmentSystemContext _db)
        {
            db = _db;
        }


        //get Login details by using username and password
        public Login validateUser(string username, string password)
        {

            if (db != null)
            {
                Login login = db.Login.FirstOrDefault(em => em.Username == username && em.Password == password);
                if (login != null)
                {
                    return login;
                }
            }
            return null;

        }

        public Login GetLoginById(int loginId)
        {
            if (db != null)
            {
                Login login = db.Login.FirstOrDefault(em => em.LId == loginId);
                if (login != null)
                {
                    return login;
                }
            }
            return null;
        }


        // add new login details and return added login id
        public async Task<int> AddLogin(Login login)
        {
            {
                //--- member function to add login ---//
                if (db != null)
                {
                    await db.Login.AddAsync(login);
                    await db.SaveChangesAsync();
                    return login.LId;
                }
                return 0;

            }


        }


        //update login details
        public async Task<Login> UpdateLogin(Login login)
        {
            if (db != null)
            {
                db.Login.Update(login);
                await db.SaveChangesAsync();
                return login;
            }
            return null;
        }


        //delete login dedtails
        public async Task<Login> DeleteLogin(int id)
        {
            if (db != null)
            {
                Login login = db.Login.Find(id);
                db.Login.Remove(login);
                db.SaveChanges();



                return (login);
            }
            return null;

        }

    }
}
