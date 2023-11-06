using System.Drawing;

namespace Delivery.Api
{
    public class PageInfoModel
    {
        public int size { get; set; }
        
        public int count { get; set; }

        public int current { get; set; }
    }
}
