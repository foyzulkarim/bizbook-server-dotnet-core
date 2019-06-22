using Model;
using Model.Model;
using Model.Model.Products;
using RequestModel.Products;
using ViewModel.Products;

namespace ServiceLibrary.Products
{
    public interface IWooCommerceService
    {
        //Task<int> PullWcData(string shopId, string username);
    }

    public class ProductCategoryService : BaseService<ProductCategory, ProductCategoryRequestModel, ProductCategoryViewModel>, IWooCommerceService
    {
        public ProductCategoryService(BaseRepository<ProductCategory> repository) : base(repository)
        {
        }

        //public async Task<int> PullWcData(string shopId, string username)
        //{
        //    int count = 0;
        //    BizBookInventoryContext db = Repository.Db as BizBookInventoryContext;
        //    Shop shop = db.Shops.Find(shopId);
        //    var parent = db.ProductGroups.FirstOrDefault(x => x.ShopId == shopId && x.Name == "General");
        //    if (parent == null)
        //    {
        //        parent = new ProductGroup();
        //        parent.Id = Guid.NewGuid().ToString();
        //        parent.Created = DateTime.UtcNow;
        //        parent.Modified = DateTime.UtcNow;
        //        parent.CreatedBy = username;
        //        parent.ModifiedBy = username;
        //        parent.ShopId = shopId;
        //        parent.CreatedFrom = "Server";
        //        parent.Name = "General";
        //        db.ProductGroups.Add(parent);
        //        db.SaveChanges();
        //    }
            
        //    WcRepository wcRepository = new WcRepository(shop.WcUrl, shop.Key, shop.Secret);
        //    bool hasData = true;
        //    int start = 1;
        //    while (hasData)
        //    {
        //        var list = await wcRepository.GetCategories(start);
        //        if (list.Count == 0)
        //        {
        //            hasData = false;
        //        }
        //        foreach (var item in list)
        //        {
        //            bool found = db.ProductCategories.Any(x => x.WcId == item.WcId && x.ShopId == shop.Id);
        //            if (!found)
        //            {
        //                item.Id = Guid.NewGuid().ToString();
        //                item.Created = DateTime.UtcNow;
        //                item.Modified = DateTime.UtcNow;
        //                item.CreatedBy = username;
        //                item.ModifiedBy = username;
        //                item.ShopId = shopId;
        //                item.CreatedFrom = "Website";
        //                item.ProductGroupId = parent.Id;
        //                try
        //                {
        //                    Add(item);
        //                }
        //                catch (Exception exception)
        //                {
        //                    throw;
        //                }
        //                count++;
        //            }
        //        }

        //        start++;
        //    }
            
        //    return count;
        //}
    }
}
