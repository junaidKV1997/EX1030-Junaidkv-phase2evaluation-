using AssetManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagmentSystem.Repository
{
    public interface ILoginRepository
    {
        #region Login

        // get Login details by using username and password
        public Login validateUser(string username, string password);

        //get Logindetails by Id

        public Login GetLoginById(int loginId);


        //--- add Login details ---//
        Task<int> AddLogin(Login login);




        //--- update Login details ---//
        Task<Login> UpdateLogin(Login login);

        //delete Login
        Task<Login> DeleteLogin(int id);


        #endregion
    }
}
