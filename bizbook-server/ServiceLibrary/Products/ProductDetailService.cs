using System.Linq;
using System.Threading.Tasks;
using RequestModel.Sales;
using ViewModel.Sales;
using BaseRepo = Model.BaseRepository<Model.Model.Products.ProductDetail>;
using Rm = RequestModel.Products.ProductDetailRequestModel;
using Vm = ViewModel.Products.ProductDetailViewModel;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Model;
using Model.Model.Products;
using Model.Model.Purchases;
using Model.Model.Sales;
using Model.Shops;
using Newtonsoft.Json;
using ViewModel.History;
using RequestModel.Purchases;
using ViewModel.Purchases;
using RequestModel.Products;
using ViewModel.Products;

namespace ServiceLibrary.Products
{
    using ServiceLibrary.Shops;

    public class ProductDetailService : BaseService<ProductDetail, Rm, Vm>, IWooCommerceService
    {
        public ProductDetailService(BaseRepo repository) : base(repository)
        {

        }

        public async Task<string> GetBarcode(string shopId)
        {
            var shops = await this.Repository.Db.Set<Shop>().OrderBy(x => x.Id).AsQueryable().Select(x => x.Id).ToListAsync();
            int index = shops.FindIndex(x => x == shopId);
            var queryable = this.GetQueryable(shopId);
            int count = queryable.Count() + 1;

            do
            {
                var barcode = index.ToString().PadLeft(3, '0') + count.ToString().PadLeft(6, '0');
                var prod = queryable.FirstOrDefault(x => x.BarCode == barcode) == null;
                if (prod)
                {
                    return barcode;
                }

                count = count + 1;
            } while (true);
        }

        public string GetBarcode2(string shopId)
        {
            var shopIds = this.Repository.Db.Set<Shop>().OrderBy(x => x.Id).Select(x => x.Id).ToList();
            int index = shopIds.FindIndex(x => x == shopId);
            var queryable = this.GetQueryable(shopId);
            int count = queryable.Count() + 1;

            do
            {
                var barcode = index.ToString().PadLeft(3, '0') + count.ToString().PadLeft(6, '0');
                var prod = queryable.FirstOrDefault(x => x.BarCode == barcode) == null;
                if (prod)
                {
                    return barcode;
                }

                count = count + 1;
            } while (true);
        }


        private IQueryable<ProductDetail> GetQueryable(string shopId)
        {
            IQueryable<ProductDetail> queryable = this.Repository.Get().Where(x => x.ShopId == shopId).OrderBy(x => x.Id);
            return queryable;
        }

        public async Task<Tuple<Vm, List<HistoryViewModel>, int>> GetHistory(Rm rm)
        {
            var productDetailService = new BaseService<ProductDetail, ProductDetailRequestModel, ProductDetailViewModel>(new BaseRepository<ProductDetail>(Repository.Db));
            var productDetail = productDetailService.GetById(rm.ParentId);

            var productDetailViewModel = new Vm(productDetail);


            var service1 = new BaseService<SaleDetail, SaleDetailRequestModel, SaleDetailViewModel>(new BaseRepository<SaleDetail>(Repository.Db));
            var saleDetailRequestModel = new SaleDetailRequestModel("")
            {
                ShopId = rm.ShopId,
                ProductDetailId = rm.ParentId,
                Page = rm.Page,
                IsIncludeParents = true,
                PerPageCount = rm.PerPageCount,
            };
            // this will pull all data

            Tuple<List<SaleDetailViewModel>, int> result = await service1.SearchAsync(saleDetailRequestModel);
            List<HistoryViewModel> viewModels = result.Item1.ConvertAll(x => new HistoryViewModel(x, productDetail.Name, productDetail.SalePrice)).ToList();

            var purchaseDetailService = new BaseService<PurchaseDetail, PurchaseDetailRequestModel, PurchaseDetailViewModel>(new BaseRepository<PurchaseDetail>(Repository.Db));
            var purchaseDetailRequestModel = new PurchaseDetailRequestModel("")
            {
                ShopId = rm.ShopId,
                ProductDetailId = rm.ParentId,
                Page = rm.Page,
                PerPageCount = rm.PerPageCount,
                IsIncludeParents = true,
                WarehouseId = rm.WarehouseId
            };

            Tuple<List<PurchaseDetailViewModel>, int> purchaseDetailResult = await purchaseDetailService.SearchAsync(purchaseDetailRequestModel);
            List<HistoryViewModel> models = purchaseDetailResult.Item1.ConvertAll(x => new HistoryViewModel(x, productDetail.Name, productDetail.CostPrice)).ToList();
            viewModels.AddRange(models);
            List<HistoryViewModel> merged = viewModels.OrderByDescending(x => x.Date).ToList();

            return new Tuple<Vm, List<HistoryViewModel>, int>(productDetailViewModel, merged, viewModels.Count);
        }

        //public async Task<Tuple<List<HistoryViewModel>, int>> GetProductHistoryByCustomer(Rm rm)
        //{
        //    BizBookInventoryContext db = this.Repository.Db as BizBookInventoryContext;
        //    List<SaleDetail> models = await db.SaleDetails.Include(x => x.Sale).Include(x => x.ProductDetail).Where(x => x.ShopId == rm.ShopId && x.Sale.CustomerId == rm.ParentId)
        //                                  .ToListAsync();
        //    List<SaleDetailViewModel> viewModels = models.ConvertAll(x => new SaleDetailViewModel(x)).ToList();
        //    List<HistoryViewModel> historyViewModels = viewModels.ConvertAll(x => new HistoryViewModel(x, x.ProductDetailName, x.SalePricePerUnit)).ToList();
        //    var list = historyViewModels.GroupBy(x => x.ProductDetailId).ToList();

        //    var histories = new List<HistoryViewModel>();
        //    foreach (var v in list)
        //    {
        //        HistoryViewModel m = new HistoryViewModel();
        //        string pid = v.Key;
        //        var pList = v.ToList();
        //        m.ProductName = pList.First().ProductName;
        //        m.ProductDetailId = pid;
        //        m.Quantity = pList.Sum(x => x.Quantity);
        //        m.Total = pList.Sum(x => x.Total);
        //        if (m.Quantity > 0)
        //        {
        //            m.UnitPrice = m.Total / m.Quantity;
        //        }

        //        m.Paid = pList.Sum(x => x.Paid);
        //        m.Due = pList.Sum(x => x.Due);
        //        histories.Add(m);
        //    }

        //    return new Tuple<List<HistoryViewModel>, int>(histories, histories.Count);
        //}




        //public async Task<int> PullWcData(string shopId, string username)
        //{
        //    int count = 0;
        //    BizBookInventoryContext db = Repository.Db as BizBookInventoryContext;
        //    Shop shop = await db.Shops.FindAsync(shopId);

        //    var parent = await db.ProductCategories.FirstOrDefaultAsync(x => x.ShopId == shopId && x.Name == "General");
        //    if (parent == null)
        //    {
        //        ProductGroup productGroup = await db.ProductGroups.FirstOrDefaultAsync(x => x.Name == "General" && x.ShopId == shopId);
        //        parent = new ProductCategory();
        //        parent.Id = Guid.NewGuid().ToString();
        //        parent.Created = DateTime.UtcNow;
        //        parent.Modified = DateTime.UtcNow;
        //        parent.CreatedBy = username;
        //        parent.ModifiedBy = username;
        //        parent.ShopId = shopId;
        //        parent.CreatedFrom = "Server";
        //        parent.Name = "General";
        //        parent.WcId = 0;
        //        parent.ProductGroupId = productGroup.Id;
        //        db.ProductCategories.Add(parent);
        //        await db.SaveChangesAsync();
        //    }

        //    var brand = await db.Brands.FirstOrDefaultAsync(x => x.ShopId == shopId && x.Name == "Unknown");
        //    if (brand == null)
        //    {
        //        brand = new Brand();
        //        brand.Id = Guid.NewGuid().ToString();
        //        brand.Created = DateTime.UtcNow;
        //        brand.Modified = DateTime.UtcNow;
        //        brand.CreatedBy = username;
        //        brand.ModifiedBy = username;
        //        brand.ShopId = shopId;
        //        brand.CreatedFrom = "Server";
        //        brand.Name = "Unknown";
        //        db.Brands.Add(brand);
        //        await db.SaveChangesAsync();
        //    }

        //    WcRepository wcRepository = new WcRepository(shop.WcUrl, shop.Key, shop.Secret);
        //    bool hasData = true;
        //    int start = 1;
        //    while (hasData)
        //    {
        //        var list = await wcRepository.GetProducts(start);
        //        if (list.Count == 0)
        //        {
        //            hasData = false;
        //        }
        //        foreach (ProductDetail item in list)
        //        {
        //            bool found = db.ProductDetails.Any(x => x.WcId == item.WcId && x.ShopId == shop.Id);
        //            if (!found)
        //            {
        //                item.Id = Guid.NewGuid().ToString();
        //                item.CreatedBy = username;
        //                item.ModifiedBy = username;
        //                item.ShopId = shopId;
        //                item.CreatedFrom = "Website";
        //                var category = db.ProductCategories.FirstOrDefault(x => x.ShopId == shopId && x.WcId == item.WcCategoryId);
        //                item.ProductCategoryId = category == null ? parent.Id : category.Id;
        //                item.BarCode = await GetBarcode(shopId);
        //                item.BrandId = brand.Id;
        //                item.OnHand = 0;

        //                var productName = item.Name;
        //                if (item.Variations.Count > 0)
        //                {
        //                    List<ProductVariation> variations = item.Variations.ToList();
        //                    ProductVariation defaultVariation = new ProductVariation();
        //                    defaultVariation.WcVariationId = 0;
        //                    defaultVariation.Option = " (Default)";
        //                    defaultVariation.Permalink = item.Permalink;
        //                    defaultVariation.SalePrice = 0;
        //                    variations.Add(defaultVariation);

        //                    for (int i = 0; i < variations.Count; i++)
        //                    {
        //                        var variation = variations[i];
        //                        foreach (var image in item.Images)
        //                        {
        //                            image.Id = Guid.NewGuid().ToString();
        //                            image.CreatedBy = username;
        //                            image.ModifiedBy = username;
        //                            image.ShopId = shopId;
        //                            image.CreatedFrom = OrderFrom.Website.ToString();
        //                        }

        //                        item.Name = productName + " " + variation.Option;
        //                        item.Id = Guid.NewGuid().ToString();
        //                        item.BarCode = await GetBarcode(shopId);
        //                        item.WcVariationId = variation.WcVariationId;
        //                        item.WcVariationOption = variation.Option;
        //                        item.WcVariationPermalink = variation.Permalink;
        //                        item.SalePrice = variation.SalePrice;
        //                        try
        //                        {
        //                            bool add = await ProductAdd(item);
        //                        }
        //                        catch (Exception exception)
        //                        {
        //                            throw;
        //                        }
        //                        count++;
        //                    }
        //                }
        //                else
        //                {
        //                    foreach (var image in item.Images)
        //                    {
        //                        image.Id = Guid.NewGuid().ToString();
        //                        image.CreatedBy = username;
        //                        image.ModifiedBy = username;
        //                        image.ShopId = shopId;
        //                        image.CreatedFrom = OrderFrom.Website.ToString();
        //                    }

        //                    try
        //                    {
        //                        bool b = await ProductAdd(item);
        //                        count++;
        //                    }
        //                    catch (Exception exception)
        //                    {
        //                        throw;
        //                    }
        //                }
        //            }
        //        }

        //        start++;
        //    }

        //    return count;
        //}

        private async Task<bool> ProductAdd(ProductDetail productDetail)
        {
            string s = JsonConvert.SerializeObject(productDetail);
            ProductDetail detail = JsonConvert.DeserializeObject<ProductDetail>(s);
            bool add = Add(detail);
            return add;
        }

        public string GetProductCode(string detailName)
        {
            string[] separator = new[] { " ", "-" };
            string[] strings = detailName.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string c = "";
            foreach (string s in strings)
            {
                c += s[0].ToString();
            }

            return c;
        }

        //public bool AddWcProductDetail(ProductDetail detail, BizBookInventoryContext db)
        //{
        //    ProductDetail dbProductDetail = db.ProductDetails.FirstOrDefault(x => x.ShopId == detail.ShopId && x.WcId == detail.WcId && x.WcVariationId == detail.WcVariationId);

        //    if (dbProductDetail == null)
        //    {
        //        db.ProductDetails.Add(detail);
        //        db.SaveChanges();
        //    }
        //    else
        //    {
        //        dbProductDetail.SalePrice = detail.SalePrice;
        //        dbProductDetail.Modified = DateTime.Now;
        //        db.SaveChanges();
        //    }

        //    return true;
        //}

        //public ProductDetail GetProductDetailFromWcProductDetail(ProductDetail detail, BizBookInventoryContext db)
        //{
        //    string shopId = detail.ShopId;
        //    ProductDetail productDetail = db.ProductDetails.FirstOrDefault(
        //        x => x.ShopId == shopId && x.WcId == detail.WcId && x.WcVariationId == detail.WcVariationId);
        //    if (productDetail != null)
        //    {
        //        return null;
        //    }

        //    ProductCategory productCategory = this.GetWcProductCategory(detail, db, shopId);
        //    BrandService brandService = new BrandService(new BaseRepository<Brand>(db));
        //    Brand brand = brandService.GetDefaultBrand(detail.ShopId, detail.CreatedBy);

        //    string barCode = GetBarcode2(shopId);

        //    productDetail = new ProductDetail()
        //    {
        //        CreatedBy = detail.CreatedBy,
        //        ModifiedBy = detail.ModifiedBy,
        //        CreatedFrom = "System",
        //        ShopId = shopId,
        //        IsActive = true,
        //        Id = Guid.NewGuid().ToString(),
        //        Created = DateTime.Now,
        //        Modified = DateTime.Now,
        //        Name = detail.Name.Cut(128),
        //        ProductCode = this.GetProductCode(detail.Name),
        //        BarCode = barCode,
        //        BrandId = brand.Id,
        //        CostPrice = 0,
        //        DealerPrice = 0,
        //        OnHand = 0,
        //        ProductCategoryId = productCategory.Id,
        //        SalePrice = detail.SalePrice,
        //        WcId = (int)detail.WcId,
        //        WcVariationId = (int)detail.WcVariationId,
        //        HasUniqueSerial = false,
        //    };

        //    return productDetail;
        //}

        //private ProductCategory GetWcProductCategory(ProductDetail detail, BizBookInventoryContext db, string shopId)
        //{
        //    ProductCategory category =
        //        db.ProductCategories.FirstOrDefault(x => x.ShopId == shopId && x.WcId == detail.WcCategoryId);

        //    if (category == null)
        //    {
        //        ProductGroup productGroup = this.GetDefaultProductGroup(db, shopId, detail.CreatedBy);
        //        category = new ProductCategory();
        //        category.Id = Guid.NewGuid().ToString();
        //        category.Created = DateTime.Now;
        //        category.Modified = DateTime.Now;
        //        category.CreatedBy = detail.CreatedBy;
        //        category.ModifiedBy = detail.ModifiedBy;
        //        category.ShopId = shopId;
        //        category.CreatedFrom = "Server";
        //        category.Name = detail.ProductCategory.Name;
        //        category.WcId = detail.ProductCategory.WcId;
        //        category.ProductGroupId = productGroup.Id;
        //        db.ProductCategories.Add(category);
        //        db.SaveChanges();
        //    }

        //    return category;
        //}

        public ProductGroup GetDefaultProductGroup(BizBookInventoryContext db, string shopId, string username)
        {
            ProductGroup productGroup = db.ProductGroups.FirstOrDefault(x => x.Name == "General" && x.ShopId == shopId);
            if (productGroup == null)
            {
                productGroup = new ProductGroup
                {
                    Id = Guid.NewGuid().ToString(),
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow,
                    CreatedBy = username,
                    ModifiedBy = username,
                    ShopId = shopId,
                    CreatedFrom = "Server",
                    Name = "General",
                };
                db.ProductGroups.Add(productGroup);
                db.SaveChanges();
            }

            return productGroup;
        }

        public async Task<Tuple<List<ProductDetailViewModel>, int>> SearchByWarehouseAsync(ProductDetailRequestModel request)
        {
            //BizBookInventoryContext db = base.Repository.Db as BizBookInventoryContext;
            //var tuple = await base.SearchAsync(request);
            //var whProducts = db.WarehouseProducts.Where(x => x.ShopId == request.ShopId && x.WarehouseId == request.WarehouseId);
            //var enumerable = from m in tuple.Item1
            //                 join wh in whProducts on m.Id equals wh.ProductDetailId into ps
            //                 from wh in ps.DefaultIfEmpty()
            //                 select new { ProductDetail = m, Quantity = wh?.OnHand ?? 0 };
            //foreach (var v in enumerable)
            //{
            //    v.ProductDetail.OnHand = v.Quantity;
            //}

            //var list = enumerable.Select(x => x.ProductDetail).ToList();
            //var tuple1 = new Tuple<List<ProductDetailViewModel>, int>(list, tuple.Item2);
            //return tuple1;
            return new Tuple<List<ProductDetailViewModel>, int>(new List<ProductDetailViewModel>(), 0);
        }
    }
}