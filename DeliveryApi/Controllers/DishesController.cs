using Delivery.Api;
using DeliveryApi.Contexts;
using DeliveryApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace DeliveryApi.Controllers
{

    [ApiController]
    [Route("/dish")]
    public class DishesController : Controller
    {
        private DishesDbContext _dishes;

        public DishesController(DishesDbContext dishes)
        {
            _dishes = dishes;
        }

        [HttpGet]

        public IActionResult Get([FromQuery]DishCategory[] categories, bool vegeterian, DishSorting sorting, int page=1) {

            var dishes = CreateList(categories, vegeterian, sorting, page);

            return Ok(dishes);

        }

        [HttpGet]
        [Route("/dish/{id}")]

        public IActionResult Get(Guid id)
        {
            return Ok(_dishes.Dishes.Find(id));
        }


        private DishPagedListDto CreateList(DishCategory[] categories, bool vegeterian, DishSorting sorting, int page)
        {

            var currentDishList = _dishes.Dishes;

            var dishlistinfo = new DishPagedListDto();

            var pagination = new PageInfoModel();
            pagination.size = 5;
            pagination.current = 1;

            if (categories.Length == 0)
            {
                categories = (DishCategory[])Enum.GetValues(typeof(DishCategory));
            }
            if (vegeterian == true)
            {
                pagination.count = currentDishList
                            .Where(x => categories.Contains(x.category) && (x.vegeterian == true))
                            .Count()/pagination.size;
                switch (sorting)
                {
                    case DishSorting.NameAsc:
                        dishlistinfo.dishes = currentDishList
                            .Where(x => categories.Contains(x.category) && (x.vegeterian == true))
                            .OrderBy(x => x.name)
                            .Skip(pagination.size * (page - 1)).Take(pagination.size);
                        dishlistinfo.pagination = pagination;
                        return dishlistinfo;

                    case DishSorting.NameDesc:
                        dishlistinfo.dishes = currentDishList
                            .Where(x => categories.Contains(x.category) && x.vegeterian == true)
                            .OrderByDescending(x => x.name)
                            .Skip(pagination.size * (page - 1)).Take(pagination.size);
                        dishlistinfo.pagination = pagination;
                        return dishlistinfo;

                    case DishSorting.PriceAsc:
                        dishlistinfo.dishes = currentDishList
                            .Where(x => categories.Contains(x.category) && x.vegeterian == true)
                            .OrderBy(x => x.price)
                            .Skip(pagination.size * (page - 1)).Take(pagination.size);
                        dishlistinfo.pagination = pagination;
                        return dishlistinfo;

                    case DishSorting.PriceDesc:
                        dishlistinfo.dishes = currentDishList
                            .Where(x => categories.Contains(x.category) && x.vegeterian == true)
                            .OrderByDescending(x => x.price)
                            .Skip(pagination.size * (page - 1)).Take(pagination.size);
                        dishlistinfo.pagination = pagination;
                        return dishlistinfo;

                    case DishSorting.RatingAsc:
                        dishlistinfo.dishes = currentDishList
                            .Where(x => categories.Contains(x.category) && x.vegeterian == true)
                            .OrderBy(x => x.rating)
                            .Skip(pagination.size * (page - 1)).Take(pagination.size);
                        dishlistinfo.pagination = pagination;
                        return dishlistinfo;

                    case DishSorting.RatingDesc:
                        dishlistinfo.dishes = currentDishList
                            .Where(x => categories.Contains(x.category) && x.vegeterian == true)
                            .OrderByDescending(x => x.rating)
                            .Skip(pagination.size * (page - 1)).Take(pagination.size);
                        dishlistinfo.pagination = pagination;
                        return dishlistinfo;

                    default:
                        dishlistinfo.dishes = currentDishList
                            .Where(x => categories.Contains(x.category) && x.vegeterian == true)
                            .OrderBy(x => x.name)
                            .Skip(pagination.size * (page - 1)).Take(pagination.size);
                        dishlistinfo.pagination = pagination;
                        return dishlistinfo;


                }
            }
            else
            {
                pagination.count = currentDishList
                            .Where(x => categories.Contains(x.category))
                            .Count()/pagination.size;
                switch (sorting)
                {
                    case DishSorting.NameAsc:
                        dishlistinfo.dishes = currentDishList
                            .Where(x => categories.Contains(x.category))
                            .OrderBy(x => x.name)
                            .Skip(pagination.size * (page - 1)).Take(pagination.size);
                        dishlistinfo.pagination= pagination;
                        return dishlistinfo;

                    case DishSorting.NameDesc:
                        dishlistinfo.dishes = currentDishList
                            .Where(x => categories.Contains(x.category))
                            .OrderByDescending(x => x.name)
                            .Skip(pagination.size * (page - 1)).Take(pagination.size);
                        dishlistinfo.pagination = pagination;
                        return dishlistinfo;

                    case DishSorting.PriceAsc:
                        dishlistinfo.dishes = currentDishList
                            .Where(x => categories.Contains(x.category))
                            .OrderBy(x => x.price)
                            .Skip(pagination.size * (page - 1)).Take(pagination.size);
                        dishlistinfo.pagination = pagination;
                        return dishlistinfo;

                    case DishSorting.PriceDesc:
                        dishlistinfo.dishes = currentDishList
                            .Where(x => categories.Contains(x.category))
                            .OrderByDescending(x => x.price)
                            .Skip(pagination.size * (page - 1)).Take(pagination.size);
                        dishlistinfo.pagination = pagination;
                        return dishlistinfo;

                    case DishSorting.RatingAsc:
                        dishlistinfo.dishes = currentDishList
                            .Where(x => categories.Contains(x.category))
                            .OrderBy(x => x.rating)
                            .Skip(pagination.size * (page - 1)).Take(pagination.size);
                        dishlistinfo.pagination = pagination;
                        return dishlistinfo;

                    case DishSorting.RatingDesc:
                        dishlistinfo.dishes = currentDishList
                            .Where(x => categories.Contains(x.category))
                            .OrderByDescending(x => x.rating)
                            .Skip(pagination.size * (page - 1)).Take(pagination.size);
                        dishlistinfo.pagination = pagination;
                        return dishlistinfo;

                    default:
                        dishlistinfo.dishes = currentDishList
                            .Where(x => categories.Contains(x.category))
                            .OrderBy(x => x.name)
                            .Skip(pagination.size * (page - 1)).Take(pagination.size);
                        dishlistinfo.pagination = pagination;
                        return dishlistinfo;


                }
            }
        }

    }
}
