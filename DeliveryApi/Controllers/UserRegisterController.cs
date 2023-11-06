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

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("1VEGxX0cJiGuTPOuvlQNsNbSh0XGs7CJStmL0QBKC19MMNUy8NHBYdGoOJlIW8Aj4RR729UTUMYTe5-qxKxi1g");

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "Delivery",
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, model.email)
                }),
                Audience = "1488"
            };

            var user = _users.Users.Find(model.email);
            if (user == null)
            {
                var token = tokenHandler.CreateToken(tokenDescriptor);


                _users.Add(model);
                _users.SaveChanges();

                var bearer = tokenHandler.WriteToken(token);

                var emailToTokenModel = new EmailToTokenModel()
                {
                    email = model.email,
                    token = bearer
                };
                _users.Add(emailToTokenModel);


                return Ok(bearer);
            }

            return Ok("kek");

        }

        [HttpPost]
        [Route("/login")]

        public IActionResult login([FromBody]LoginCredentials model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("1VEGxX0cJiGuTPOuvlQNsNbSh0XGs7CJStmL0QBKC19MMNUy8NHBYdGoOJlIW8Aj4RR729UTUMYTe5-qxKxi1g");

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "Delivery",
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, model.email)
                }),
                Audience = "1488"
            };



            var user = _users.Users.Find(model.email);
            if (user!=null)
            {
                var token = tokenHandler.CreateToken(tokenDescriptor);

                var bearer = tokenHandler.WriteToken(token);

                _users.EmailToTokens.Find(model.email)
                    .token = bearer;

                return Ok(bearer);
            }

            return Ok("kek");
        }

        [HttpPost]

        public IActionResult logout()
        {
            return Ok();
            // Токены изменяются в дб 
        }

        [HttpGet]
        [ActionName("profile")]

        public IActionResult get()
        {
            if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
            {
                return Ok(authToken);
            }
            return Ok();
            //По токену ведется поиск в бд и возвращает UserDto
        }

        [HttpPut]
        [ActionName("profile")]

        public IActionResult put([FromBody]UserEditModel model ) //Тут нужно получить токен, по нему найти юзера в бд
        {
            // после нахождения юзера создать изменить полученные данные
            return Ok();
        }



    }
}
