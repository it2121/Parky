﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Parky_API.Data;
using Parky_API.Models;
using Parky_API.Repository.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Parky_API.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _db;
        private readonly AppSettings _appSettings;
        private object encoding;

        public UserRepository(ApplicationDbContext db,IOptions<AppSettings> appSettings)
        {
            _db = db;
            _appSettings = appSettings.Value; 
        }

        public User Authenticate(string username, string password)
        {

            var user = _db.Users.SingleOrDefault(x => x.Username == username && x.Password == password);
            if(user == null)
            {

                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {

                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())


                }),

                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature

                )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = "";
            return user;

        }




        public bool IsUniqueUser(string username)
        {

            var user =  _db.Users.SingleOrDefault(x=>x.Username == username);
            
            if (user == null)
            {

                return true;   
            }

            return false;         }

        public User Register(string username, string password)
        {

            User userObj = new User()
            {
                Username = username,
                Password = password,
                Role = "Admin"

            };
            _db.Users.Add(userObj);

            _db.SaveChanges();
            userObj.Password = "";

            return userObj;
        }
    }
}
