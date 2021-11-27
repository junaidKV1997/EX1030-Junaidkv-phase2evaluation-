using AssetManagmentSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagmentSystem.Repository
{
    public interface IUserModelRepository
    {
        //--- get all users and login details---//

        Task<List<UserModel>> GetAllDetails();
    }
}
