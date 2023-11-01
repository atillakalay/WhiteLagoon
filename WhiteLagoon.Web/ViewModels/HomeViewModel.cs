using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Villa>? VillaList { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly? CheckOutDate { get; set; }
        public int Nights { get; set; }

    }
}
