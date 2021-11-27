using AssetManagmentSystem.Models;
using AssetManagmentSystem.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {


        private IConfiguration _config;
        ILoginRepository loginRepository;

        public LoginController(IConfiguration config, ILoginRepository _l)
        {
            _config = config;
            loginRepository = _l;
        }






        // Api for gentering token and login details
        [AllowAnonymous]
        [HttpGet("{userName}/{password}")]

        public IActionResult LoginValidation(string userName, string password)
        {
            IActionResult response = Unauthorized();

            Login login = null;

            //Authenticate the user by passing username and password
            login = AuthenticateUser(userName, password);



            if (login != null)
            {
                var tokenString = GenerateJSONWebToken(login);
                response = Ok(new
                {
                    token = tokenString,
                    LId = login.LId,
                    Username = login.Username,
                    Password = login.Password,
                    UserType = login.UserType

                });
            }
            return response;
        }


        //GenerateJsonWebToken()
        private string GenerateJSONWebToken(Login login)
        {
            //security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));



            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);



            //generate token
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(20), signingCredentials: credentials);



            return new JwtSecurityTokenHandler().WriteToken(token);
        }





        //AuthenticateUSer()
        private Login AuthenticateUser(string userName, string password)
        {

            //validate the user credentials
            //Retrieve data from the database


            Login login = loginRepository.validateUser(userName, password);//checking validity of user by username and password

            if (login != null)
            {

                return login;

            }
            return null;
        }




        #region Delete Login Details

        //api for deleting login details by passing login id
        [HttpDelete]
        [Route("DeleteLogin")]
        public async Task<IActionResult> DeleteLogin(int id)
        {
            try
            {
                var exp = await loginRepository.DeleteLogin(id);
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


        #region Update login details
        [HttpPut]
        
        [Route("UpdateLogin")]
        public async Task<IActionResult> UpdateLogin(Login login)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await loginRepository.UpdateLogin(login);
                    return Ok(login);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Add Login

        // adding new user login details

        [HttpPost]
        [Route("AddLogin")]
        public async Task<IActionResult> AddLogin(Login login)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var loginId = await loginRepository.AddLogin(login);
                    if (loginId != null)
                    {
                        return Ok(loginId);
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



    }



}

