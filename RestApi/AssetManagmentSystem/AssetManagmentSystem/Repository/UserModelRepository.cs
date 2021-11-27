using AssetManagmentSystem.Models;
using AssetManagmentSystem.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagmentSystem.Repository
{
    public class UserModelRepository : IUserModelRepository
    {
        AssetManagmentSystemContext _db;
        //constructor dependency injection
        public UserModelRepository(AssetManagmentSystemContext db)
        {
            _db = db;
        }
        public async Task<List<UserModel>> GetAllDetails()
        {
           
            if (_db != null)
                {
                    return await (from l in _db.Login
                                  from u in _db.UserRegistration
                                 
                                  where l.LId == u.LId 
                                  select new UserModel
                                  {
                                      LId =l.LId,
                                       Username =l.Username,
                                        Password=l.Password,
                                         UserType =l.UserType,
                                        UId=u.UId, 
                                        FirstName=u.FirstName, 
                                         LastName=u.LastName,
                                        Age =u.Age,
                                        Gender =u.Gender,
                                        Address=u.Address,
                                        PhoneNumber=u.PhoneNumber 
                                    
                                    }).ToListAsync();

                                     }
                                return null;
            
        }
    }
}
