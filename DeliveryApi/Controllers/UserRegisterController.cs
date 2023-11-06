using Delivery.Api;
using Delivery.Api.Classes;
using DeliveryApi.Contexts;
using DeliveryApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace DeliveryApi.Controllers
{
    [ApiController]
    [Route("/account/[action]")]
    public class UserRegisterController : ControllerBase
    {

        private UserDbContext _users;

        public UserRegisterController(UserDbContext users)
        {
            _users = users;
        }

        [HttpPost]
        [Route("/register")]
        
        public IActionResult register([FromBody]UserRegisterModel model)
        {

            var user = _users.Users.Find(model.email);

            if (user == null)
            {

                var bearer = CreateToken();

                var emailToTokenModel = new EmailToTokenModel()
                {
                    email = model.email,
                    token = bearer
                };

                _users.Add(model);
                _users.Add(emailToTokenModel);
                _users.SaveChanges();


                return Ok(bearer);
            }

            return Ok("kek");

        }

        [HttpPost]
        [Route("/login")]

        public IActionResult login([FromBody]LoginCredentials model)
        {

            var user = _users.Users.Find(model.email);

            if (user!=null && user.password == model.password)
            {
                var bearer = CreateToken();

                _users.EmailToTokens.Find(model.email)
                    .token = bearer;

                _users.SaveChanges();

                return Ok(bearer);
            }

            return Ok("kek");
        }

        [HttpPost]

        public IActionResult logout()
        {
            if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
            {
                var token = authToken.ToString()
                    .Substring(7);

                if (CheckToken(token))
                {
                    _users.EmailToTokens
                        .SingleOrDefault(model => model.token == token)
                        .token = CreateToken();

                    _users.SaveChanges();

                    return Ok();
                }
             
            }
            return Ok("nonono");
            // Токены изменяются в дб 
        }

        [HttpGet]
        [ActionName("profile")]

        public IActionResult get()
        {
            if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
            {
                var token = authToken.ToString()
                    .Substring(7);

                

                if (CheckToken(token))
                {
                    string userEmail = _users.EmailToTokens
                        .SingleOrDefault(model => model.token == token)
                        .email;
                    var usermodel = _users.Users.Find(userEmail);
                    var user = new UserDto
                    {
                        fullName = usermodel.fullName,
                        email = usermodel.email,
                        gender = usermodel.gender,
                        birthDate = usermodel.birthDate,
                        phoneNumber = usermodel.phoneNumber
                    };
                    return Ok(user);
                }

            }
            return Ok("nonono");
            //По токену ведется поиск в бд и возвращает UserDto
        }

        [HttpPut]
        [ActionName("profile")]

        public IActionResult put([FromBody]UserEditModel model ) //Тут нужно получить токен, по нему найти юзера в бд
        {

            if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
            {
                var token = authToken.ToString()
                    .Substring(7);

                if (CheckToken(token))
                {
                    string userEmail = _users.EmailToTokens
                        .SingleOrDefault(model => model.token == token)
                        .email;

                    _users.Users.Find(userEmail).fullName = model.fullName;
                    _users.Users.Find(userEmail).birthDate = model.birthDate;
                    _users.Users.Find(userEmail).gender = model.gender;
                    _users.Users.Find(userEmail).addressId = model.addressId;
                    _users.Users.Find(userEmail).phoneNumber = model.phoneNumber;

                    _users.SaveChanges();

                    return Ok();
                }

            }
                // после нахождения юзера создать изменить полученные данные
                return Ok();
        }

        private string? CreateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("1VEGxX0cJiGuTPOuvlQNsNbSh0XGs7CJStmL0QBKC19MMNUy8NHBYdGoOJlIW8Aj4RR729UTUMYTe5-qxKxi1g");

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "Delivery",
                Subject = new ClaimsIdentity(new Claim[]{}),
                Audience = "1488"
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var bearer = tokenHandler.WriteToken(token);

            return bearer;
        }
        private bool CheckToken(string token)
        {
            if (_users.EmailToTokens.SingleOrDefault(model => model.token == token) != default(EmailToTokenModel))
            {
                return true;
            }
            return false;
        }

    }
}
