using AssetManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagmentSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        AssetManagmentSystemContext db;
        //constructor dependency injection
        public UserRepository(AssetManagmentSystemContext _db)
        {
            db = _db;
        }
        public async Task<int> AddUser(UserRegistration user)
        {
            {
                //--- member function to add user ---//
                if (db != null)
                {
                    await db.UserRegistration.AddAsync(user);
                    await db.SaveChangesAsync();
                    return user.UId;
                }
                return 0;

            }
        }


        // delete user by id
        public async Task<UserRegistration> DeleteUser(int id)
        {
            if (db != null)
            {
                UserRegistration user = db.UserRegistration.Find(id);
                db.UserRegistration.Remove(user);
                db.SaveChanges();



                return (user);
            }
            return null;
        }


        //get all user details
        public async Task<List<UserRegistration>> GetAllUsers()
        {
            if (db != null)
            {
                return  db.UserRegistration.ToList();

            }
            return null;
        }



        // get user details by user id
       public  UserRegistration GetUserById(int userId)
        {
            if (db != null)
            {
                UserRegistration user = db.UserRegistration.FirstOrDefault(em => em.UId == userId);
                return user;

            }
            return null;
        }



        //upadte user details 
        public async Task<UserRegistration> UpdateUser(UserRegistration user)
        {
            if (db != null)
            {
                db.UserRegistration.Update(user);
                await db.SaveChangesAsync();
                return user;
            }
            return null;
        }
    }
}
