using Delivery.Api;
using DeliveryApi.Contexts;
using DeliveryApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeliveryApi.Controllers
{
    [ApiController]
    [Route("/basket")]

    public class BasketController : Controller
    {
        private BasketDbContext _baskets;
        private UserDbContext _users;
        private DishesDbContext _dishes;

        public BasketController(BasketDbContext baskets, UserDbContext users, DishesDbContext dishes)
        {
            _baskets = baskets;
            _users = users;
            _dishes = dishes;

        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]

        public IActionResult Get()
        {

            var email = User.FindFirstValue(ClaimTypes.Name);

            var userId = _users.Users.SingleOrDefault(x => x.email == email).id;

            var userBasket = GetBasketList(userId);

            return Ok(userBasket);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]

        public IActionResult Post(Guid dishId)
        {
            var email = User.FindFirstValue(ClaimTypes.Name);

            var userId = _users.Users.SingleOrDefault(x => x.email == email).id;

            var newDish = _dishes.Dishes.Find(dishId);

            var currentBasket = GetBasketList(userId);

            var dishInBasket = currentBasket.FirstOrDefault(x => x.name == newDish.name);

            if (dishInBasket == default(DishBasketDto))
            {
                var dishToBasket = new DishBasketDto()
                {
                    Id = Guid.NewGuid(),
                    name = newDish.name,
                    price = newDish.price,
                    amount = 1,
                    totalPrice = newDish.price,
                    image = newDish.image,
                };

                var dishInBasketModel = new DishInBasketModel()
                {
                    DishId = dishToBasket.Id,
                    UserId = userId
                };

                _baskets.DishInBasket.Add(dishInBasketModel);

                _baskets.SaveChanges();

                _baskets.Baskets.Add(dishToBasket);

                _baskets.SaveChanges();

                return Ok(dishToBasket);
            }
            else
            {
                dishInBasket.amount += 1;
                dishInBasket.totalPrice = dishInBasket.price*dishInBasket.amount;

                _baskets.SaveChanges();
            }


            return Ok(dishInBasket);
        }

        private IQueryable<DishBasketDto> GetBasketList(Guid userId)
        {
            var list = _baskets.DishInBasket.Where(x => x.UserId == userId);

            var dishIdList = new List<Guid>();

            for (int i = 0; i < list.Count(); i++)
            {
                dishIdList.Add(list.ToList()[i].DishId);
            }

            var userBasket = _baskets.Baskets.Where(x => dishIdList.Contains(x.Id));

            return (userBasket);
        }

    }
}
