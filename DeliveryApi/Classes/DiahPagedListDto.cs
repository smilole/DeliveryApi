namespace Delivery.Api
{
    public class DiahPagedListDto
    {
        public DishDto? dishes {  get; set; }

        public PageInfoModel pagination { get; set; }
    }
}
