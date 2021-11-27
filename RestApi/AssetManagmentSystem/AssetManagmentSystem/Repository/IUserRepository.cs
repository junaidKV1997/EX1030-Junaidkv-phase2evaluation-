using AssetManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagmentSystem.Repository
{
   public interface IUserRepository
    {
        #region User Details

        // get  all user details 
        Task<List<UserRegistration>> GetAllUsers();


        //get user by Id

        public UserRegistration GetUserById(int userId);


        //--- add User details ---//
        Task<int> AddUser(UserRegistration user);




        //--- update User details ---//
        Task<UserRegistration> UpdateUser(UserRegistration user);

        //delete User
        Task<UserRegistration> DeleteUser(int id);


        #endregion
    }
}
