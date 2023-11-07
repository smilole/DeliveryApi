namespace Delivery.Api
{
    public class DishPagedListDto
    {
        public IQueryable? dishes {  get; set; }

        public PageInfoModel pagination { get; set; }
    }
}
