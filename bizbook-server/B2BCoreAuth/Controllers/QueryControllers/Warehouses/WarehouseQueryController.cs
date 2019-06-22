using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ServiceLibrary.Products;

namespace B2BCoreApi.Controllers.QueryControllers.Warehouses
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Model;
    using Model.Model;
    

    using RequestModel.Transactions;
    using RequestModel.Warehouses;

    using ViewModel.Transactions;
    using ViewModel.Warehouses;

    [Route("api/WarehouseQuery")]
    public class WarehouseQueryController : BaseQueryController<Warehouse, WarehouseRequestModel, WarehouseViewModel>
    {
        public WarehouseQueryController(BizBookInventoryContext db, ILogger<WarehouseQueryController> logger) : base(new ServiceLibrary.BaseService<Warehouse, WarehouseRequestModel, WarehouseViewModel>(new BaseRepository<Warehouse>(db)), logger)
        {

        }

        //[Route("ProductHistory/{warehouseId}")]
        //[ActionName("ProductHistory")]
        //[HttpGet]
        //public async Task<IHttpActionResult> ProductHistory(string warehouseId)
        //{

        //    var response = new Dictionary<string, WarehouseProductHistoryViewModel>();

        //    var db = new BusinessDbContext();

        //    //var saleResults = from sale in db.Sales
        //    //                  join saleDetail in db.SaleDetails on sale.Id equals saleDetail.SaleId
        //    //                  join productDetail in db.ProductDetails on saleDetail.ProductDetailId equals productDetail.Id
        //    //                  where sale.WarehouseId == warehouseId
        //    //                  select new
        //    //                  {
        //    //                      productDetail.Name,
        //    //                      saleDetail.Quantity
        //    //                  };

        //    //foreach (var item in saleResults)
        //    //{
        //    //    if (!response.ContainsKey(item.Name))
        //    //    {
        //    //        response[item.Name] = new WarehouseProductHistoryViewModel
        //    //        {
        //    //            ProductName = item.Name,
        //    //            SaleQuantity = item.Quantity
        //    //        };
        //    //    }
        //    //    else
        //    //    {
        //    //        response[item.Name].SaleQuantity += item.Quantity;
        //    //    }
        //    //}

        //    //var purchaseResults = from purchase in db.Purchases
        //    //                      join purchaseDetail in db.PurchaseDetails on purchase.Id equals purchaseDetail.PurchaseId
        //    //                      join productDetail in db.ProductDetails on purchaseDetail.ProductDetailId equals productDetail.Id
        //    //                      where purchase.WarehouseId == warehouseId
        //    //                      select new
        //    //                      {
        //    //                          productDetail.Name,
        //    //                          purchaseDetail.Quantity
        //    //                      };

        //    //foreach (var item in purchaseResults)
        //    //{
        //    //    if (!response.ContainsKey(item.Name))
        //    //    {
        //    //        response[item.Name] = new WarehouseProductHistoryViewModel
        //    //        {
        //    //            ProductName = item.Name,
        //    //            PurchaseQuantity = item.Quantity
        //    //        };
        //    //    }
        //    //    else
        //    //    {
        //    //        response[item.Name].PurchaseQuantity += item.Quantity;
        //    //    }
        //    //}

        //    //var result = new List<WarehouseProductHistoryViewModel>();
        //    //foreach (var res in response)
        //    //{
        //    //    var data = new WarehouseProductHistoryViewModel();
        //    //    data.ProductName = res.Value.ProductName;
        //    //    data.SaleQuantity = res.Value.SaleQuantity;
        //    //    data.PurchaseQuantity = res.Value.PurchaseQuantity;
        //    //    result.Add(data);
        //    //}

        //    var result = db.WarehouseProducts.Where(x => x.WarehouseId == warehouseId).Include(x => x.ProductDetail)                
        //        //.Select(x => new
        //        //{
        //        //    ProductName = x.ProductDetail.Name,
        //        //    PurchaseQuantity = x.Purchased,
        //        //    SaleQuantity = x.Sold,
        //        //    x.TransferredIn,
        //        //    x.TransferredOut,
        //        //    x.OnHand
        //        //})
        //        .ToList();

        //    return Ok(result);
        //}

        //[Route("History")]
        //[ActionName("History")]
        //[HttpPost]
        //public async Task<IHttpActionResult> History(WarehouseRequestModel request)
        //{
        //    try
        //    {
        //        //WarehouseService service = Service as WarehouseService;
        //        //var content = await service.GetHistory(request);
        //        //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, content);
        //        //response.Headers.Add("Count", content.Item2.ToString());
        //        //return ResponseMessage(response);
        //        //  var response = new Dictionary<string, WarehouseProductHistoryViewModel>();

        //        var db = new BusinessDbContext();

        //        var saleResults = from sale in db.Sales
        //            join saleDetail in db.SaleDetails on sale.Id equals saleDetail.SaleId
        //            join productDetail in db.ProductDetails on saleDetail.ProductDetailId equals productDetail.Id
        //            where sale.WarehouseId == request.ParentId
        //            select new
        //            {
        //                Id = sale.Id,
        //                OrderNumber = sale.OrderNumber,
        //                ProductName = productDetail.Name,
        //                Quantity = saleDetail.Quantity,
        //                Type = "Sale",
        //                sale.Modified
        //            };

        //        var purchaseResults = from purchase in db.Purchases
        //            join purchaseDetail in db.PurchaseDetails on purchase.Id equals purchaseDetail.PurchaseId
        //            join productDetail in db.ProductDetails on purchaseDetail.ProductDetailId equals productDetail.Id
        //            where purchase.WarehouseId == request.ParentId
        //            select new
        //            {
        //                Id = purchase.Id,
        //                OrderNumber = purchase.OrderNumber,
        //                ProductName = productDetail.Name,
        //                Quantity = purchaseDetail.Quantity,
        //                Type = "Purchase",
        //                purchase.Modified
        //            };

        //        var stockTransfersSource = from transfer in db.StockTransfers
        //            join detail in db.StockTransferDetails on transfer.Id equals detail.StockTransferId
        //            join productDetail in db.ProductDetails on detail.ProductDetailId equals productDetail.Id
        //            where transfer.SourceWarehouseId == request.ParentId                      
        //            select new
        //            {
        //                transfer.Id, transfer.OrderNumber, productDetail.Name, detail.Quantity, Type="Transferred to "+transfer.DestinationWarehouse.Name, transfer.Modified
        //            };

        //        var stockTransfersDestination = from transfer in db.StockTransfers
        //            join detail in db.StockTransferDetails on transfer.Id equals detail.StockTransferId
        //            join productDetail in db.ProductDetails on detail.ProductDetailId equals productDetail.Id
        //            where transfer.DestinationWarehouseId == request.ParentId
        //            select new
        //            {
        //                transfer.Id,
        //                transfer.OrderNumber,
        //                productDetail.Name,
        //                detail.Quantity,
        //                Type = "Transferred from "+transfer.SourceWarehouse.Name,
        //                transfer.Modified
        //            };

        //        const int take = 100;
        //        int skip = (request.Page - 1) * take;
        //        var sales = saleResults.OrderByDescending(x => x.Modified).Skip(skip).Take(take).ToList();
        //        var warehouseSalesHistoryViewModels = sales.ConvertAll(item => new WarehouseHistoryViewModel
        //        {
        //            Id = item.Id,
        //            ProductName = item.ProductName,
        //            OrderNumber = item.OrderNumber,
        //            Quantity = item.Quantity,
        //            Type = item.Type,
        //            Date = item.Modified
        //        }).ToList();

        //        var warehousePurchasesHistoryViewModels = purchaseResults.OrderByDescending(x => x.Modified).Skip(skip).Take(take).ToList().ConvertAll(item =>
        //            new WarehouseHistoryViewModel
        //            {
        //                Id = item.Id,
        //                ProductName = item.ProductName,
        //                OrderNumber = item.OrderNumber,
        //                Quantity = item.Quantity,
        //                Type = item.Type,
        //                Date = item.Modified
        //            }).ToList();

        //        var warehouseTransferSourceViewModels = stockTransfersSource.OrderByDescending(x => x.Modified)
        //            .Skip(skip).Take(take).ToList().ConvertAll(item => new WarehouseHistoryViewModel()
        //            {
        //                Id = item.Id, ProductName = item.Name, OrderNumber = item.OrderNumber, Quantity = item.Quantity, Type = item.Type, Date = item.Modified
        //            }).ToList();

        //        var warehouseTransferDestinationViewModels = stockTransfersDestination.OrderByDescending(x => x.Modified)
        //            .Skip(skip).Take(take).ToList().ConvertAll(item => new WarehouseHistoryViewModel()
        //            {
        //                Id = item.Id,
        //                ProductName = item.Name,
        //                OrderNumber = item.OrderNumber,
        //                Quantity = item.Quantity,
        //                Type = item.Type,
        //                Date = item.Modified
        //            }).ToList();

        //        warehouseSalesHistoryViewModels.AddRange(warehousePurchasesHistoryViewModels);
        //        warehouseSalesHistoryViewModels.AddRange(warehouseTransferSourceViewModels);
        //        warehouseSalesHistoryViewModels.AddRange(warehouseTransferDestinationViewModels);
        //        warehouseSalesHistoryViewModels = warehouseSalesHistoryViewModels.OrderByDescending(x => x.Date).ToList();
        //        var content = warehouseSalesHistoryViewModels;
        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, content);
        //        response.Headers.Add("Count", "X");
        //        return ResponseMessage(response);

        //    }
        //    catch (Exception exception)
        //    {

        //        Logger.Fatal(exception, "Exception occurred while Searching {TypeName} with Request {Request}", typeName, request);
        //        return InternalServerError(exception);
        //    }

        //}


    }
}
