using AssetManagmentSystem.Models;
using AssetManagmentSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        private IConfiguration _config;
        IUserRepository UserRepository;

        public UserController(IConfiguration config, IUserRepository _IUserRepository)
        {
            _config = config;
            UserRepository = _IUserRepository;
        }




        #region Delete user Details

        //api for deleting user details by passing user id
        [HttpDelete]
        [Route("Deleteuser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var exp = await UserRepository.DeleteUser(id);
                if (exp == null)
                {
                    return NotFound();
                }
                return Ok(exp);
            }
            catch (Exception)
            {
                return BadRequest();
            }



        }
        #endregion


        #region Update User details
        [HttpPut]

        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserRegistration user)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await UserRepository.UpdateUser(user);
                    return Ok(user);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Add user

        // adding new user  details

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(UserRegistration user)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var UserId = await UserRepository.AddUser(user);
                    if (UserId != null)
                    {
                        return Ok(UserId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion

        #region  getuser details by id

        // api to fetch user details by passing id
        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user =  UserRepository.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion



        [HttpGet]
        [Route("GetAllUsers")]

        //api for getting all user details
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await UserRepository.GetAllUsers();
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


    }





}

