﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace demo_web_api_3._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]LoginModel login)
        {
            if (login == null) return Unauthorized();
            string tokenString = string.Empty;
            bool validUser = Authenticate(login);
            if (validUser)
            {
                tokenString = BuildToken();
            }
            else
            {
                return Unauthorized();
            }
            return Ok(new { Token = tokenString });
        }

        private string BuildToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtToken:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["JwtToken:Issuer"],
              _config["JwtToken:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool Authenticate(LoginModel login)
        {
            bool validUser = false;

            if (login.Username == "thecodebuzz" && login.Password == "dont-tell-anyone")
            {
                validUser = true;
            }
            return validUser;
        }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }


    }
}