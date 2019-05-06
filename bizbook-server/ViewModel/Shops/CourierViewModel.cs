using Model.Model;

namespace ViewModel.Shops
{
    public class CourierViewModel : BaseViewModel<Courier>
    {
        public CourierViewModel(Courier x) : base(x)
        {
            ShopId = x.ShopId;
            ContactPersonName = x.ContactPersonName;
            CourierShopId = x.CourierShopId;
            CourierShopName = x.CourierShopName;
            CourierShopPhone = x.CourierShopPhone;
        }

        public string CourierShopPhone { get; set; }

        public string CourierShopName { get; set; }

        public string ShopId { get; set; }

        [IsViewable] public string ContactPersonName { get; set; }

        [IsViewable] public string CourierShopId { get; set; }
    }
}