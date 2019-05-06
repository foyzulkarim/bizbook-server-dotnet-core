using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model.Model;
using Model.Shops;

namespace Model.ModelBuilders
{
    public static class BizBookModelBuilder
    {
        public static void BuildModels(ModelBuilder modelBuilder)
        {
            AccountHead(modelBuilder);
            AccountInfo(modelBuilder);
            Address(modelBuilder);
            Brand(modelBuilder);
            Courier(modelBuilder);
            Customer(modelBuilder);
            Damage(modelBuilder);
            DealerProduct(modelBuilder);
            DealerProductTransaction(modelBuilder);
            Dealer(modelBuilder);
            District(modelBuilder);
            EmployeeInfo(modelBuilder);
            HookDetail(modelBuilder);
            InstallmentDetail(modelBuilder);
            Installment(modelBuilder);
            ProductCategorie(modelBuilder);
            ProductDetail(modelBuilder);
            ProductGroup(modelBuilder);
            ProductImage(modelBuilder);
            ProductSerial(modelBuilder);
            PurchaseDetail(modelBuilder);
            Purchase(modelBuilder);
            SaleDetail(modelBuilder);
            Sale(modelBuilder);
            SaleState(modelBuilder);
            Shop(modelBuilder);
            Sms(modelBuilder);
            SmsHistory(modelBuilder);
            SmsHook(modelBuilder);
            StockTransferDetail(modelBuilder);
            StockTransfer(modelBuilder);
            SupplierProduct(modelBuilder);
            SupplierProductTransaction(modelBuilder);
            Supplier(modelBuilder);
            Transaction(modelBuilder);
            WarehouseProduct(modelBuilder);
            Warehouse(modelBuilder);
            WarehouseZone(modelBuilder);
            Zone(modelBuilder);

        }

        private static void Customer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Email)
                    .HasName("IX_Email");

                entity.HasIndex(e => e.MembershipCardNo)
                    .HasName("IX_MembershipCardNo");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Name");

                entity.HasIndex(e => e.NationalId)
                    .HasName("IX_NationalId");

                entity.HasIndex(e => e.OrdersCount)
                    .HasName("IX_OrdersCount");

                entity.HasIndex(e => e.OtherAmount)
                    .HasName("IX_OtherAmount");

                entity.HasIndex(e => e.Phone)
                    .HasName("IX_Phone");

                entity.HasIndex(e => e.Point)
                    .HasName("IX_Point");

                entity.HasIndex(e => e.ProductAmount)
                    .HasName("IX_ProductAmount");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.TotalAmount)
                    .HasName("IX_TotalAmount");

                entity.HasIndex(e => e.TotalDiscount)
                    .HasName("IX_TotalDiscount");

                entity.HasIndex(e => e.TotalDue)
                    .HasName("IX_TotalDue");

                entity.HasIndex(e => e.TotalPaid)
                    .HasName("IX_TotalPaid");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void Courier(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courier>(entity =>
            {
                entity.HasIndex(e => e.CourierShopId)
                    .HasName("IX_CourierShopId");

                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Couriers)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void Brand(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Name");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Brands)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void Address(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("IX_CustomerId");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Shop)
                    .WithMany(x => x.Addresses)
                    .HasForeignKey(x => x.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void AccountInfo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountInfo>(entity =>
            {   
                entity.HasIndex(e => e.AccountInfoType)
                    .HasName("IX_AccountInfoType");

                entity.HasIndex(e => e.AccountTitle)
                    .HasName("IX_AccountTitle");

                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.AccountInfoes)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void AccountHead(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountHead>(entity =>
            {
                entity.HasIndex(e => e.AccountHeadType)
                    .HasName("IX_AccountHeadType");

                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_AccountHeadName");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(x => x.Remarks).HasName("IX_AccountHeadRemarks");

                entity.HasOne(d => d.Shop).WithMany(p => p.AccountHeads)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void Damage(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Damage>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.ProductDetailId)
                    .HasName("IX_ProductDetailId");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.WarehouseId)
                    .HasName("IX_WarehouseId");

                entity.HasOne(d => d.ProductDetail)
                    .WithMany(p => p.Damages)
                    .HasForeignKey(d => d.ProductDetailId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Damages)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.Damages)
                    .HasForeignKey(d => d.WarehouseId);
            });
        }

        private static void DealerProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DealerProduct>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.DealerId)
                    .HasName("IX_DealerId");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.ProductDetailId)
                    .HasName("IX_ProductDetailId");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasOne(d => d.Dealer)
                    .WithMany(p => p.DealerProducts)
                    .HasForeignKey(d => d.DealerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.ProductDetail)
                    .WithMany(p => p.DealerProducts)
                    .HasForeignKey(d => d.ProductDetailId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.DealerProducts)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void DealerProductTransaction(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DealerProductTransaction>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.DealerProductId)
                                        .HasName("IX_DealerProductId");

                entity.HasIndex(e => e.Modified)
                                        .HasName("IX_Modified");

                entity.HasIndex(e => e.ShopId)
                                        .HasName("IX_ShopId");

                entity.HasIndex(e => e.TransactionId)
                                        .HasName("IX_TransactionId");

                entity.HasOne(d => d.DealerProduct)
                                        .WithMany(p => p.DealerProductTransactions)
                                        .HasForeignKey(d => d.DealerProductId)
                                        .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Shop)
                                        .WithMany(p => p.DealerProductTransactions)
                                        .HasForeignKey(d => d.ShopId)
                                        .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Transaction)
                                        .WithMany(p => p.DealerProductTransactions)
                                        .HasForeignKey(d => d.TransactionId)
                                        .OnDelete(DeleteBehavior.Restrict);
            });

        }

        private static void Dealer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dealer>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Name");

                entity.HasIndex(e => e.OrdersCount)
                    .HasName("IX_OrdersCount");

                entity.HasIndex(e => e.OtherAmount)
                    .HasName("IX_OtherAmount");

                entity.HasIndex(e => e.Phone)
                    .HasName("IX_Phone");

                entity.HasIndex(e => e.ProductAmount)
                    .HasName("IX_ProductAmount");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.TotalAmount)
                    .HasName("IX_TotalAmount");

                entity.HasIndex(e => e.TotalDiscount)
                    .HasName("IX_TotalDiscount");

                entity.HasIndex(e => e.TotalDue)
                    .HasName("IX_TotalDue");

                entity.HasIndex(e => e.TotalPaid)
                    .HasName("IX_TotalPaid");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Dealers)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }

        private static void District(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<District>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

            });

        }

        private static void EmployeeInfo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeInfo>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Email)
                    .HasName("IX_Email");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Name");

                entity.HasIndex(e => e.Phone)
                    .HasName("IX_Phone");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.WarehouseId)
                    .HasName("IX_WarehouseId");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.EmployeeInfoes)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.EmployeeInfoes)
                    .HasForeignKey(d => d.WarehouseId);
            });

        }

        private static void HookDetail(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HookDetail>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.HookName)
                    .HasName("IX_HookName");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.SmsHookId)
                    .HasName("IX_SmsHookId");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.HookDetails)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SmsHook)
                    .WithMany(p => p.HookDetails)
                    .HasForeignKey(d => d.SmsHookId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }

        private static void InstallmentDetail(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstallmentDetail>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.InstallmentId)
                    .HasName("IX_InstallmentId");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.SaleId)
                    .HasName("IX_SaleId");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.TansactionId)
                    .HasName("IX_TansactionId");

                entity.HasOne(d => d.Installment)
                    .WithMany(p => p.InstallmentDetails)
                    .HasForeignKey(d => d.InstallmentId);

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.InstallmentDetails)
                    .HasForeignKey(d => d.SaleId);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.InstallmentDetails)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Tansaction)
                    .WithMany(p => p.InstallmentDetails)
                    .HasForeignKey(d => d.TansactionId);
            });

        }

        private static void Installment(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Installment>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Installments)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }

        private static void ProductCategorie(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Name");

                entity.HasIndex(e => e.ProductGroupId)
                    .HasName("IX_ProductGroupId");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.WcId)
                    .HasName("IX_WcId");

                entity.HasOne(d => d.ProductGroup)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(d => d.ProductGroupId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }

        private static void ProductDetail(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.HasIndex(e => e.BarCode)
                    .HasName("IX_BarCode");

                entity.HasIndex(e => e.BrandId)
                    .HasName("IX_BrandId");

                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Name");

                entity.HasIndex(e => e.ProductCategoryId)
                    .HasName("IX_ProductCategoryId");

                entity.HasIndex(e => e.ProductCode)
                    .HasName("IX_ProductCode");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.WcCategoryId)
                    .HasName("IX_WcCategoryId");

                entity.HasIndex(e => e.WcId)
                    .HasName("IX_WcId");

                entity.HasIndex(e => e.WcVariationId)
                    .HasName("IX_WcVariationId");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }

        private static void ProductGroup(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Name");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.ProductGroups)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }

        private static void ProductImage(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.ProductDetailId)
                    .HasName("IX_ProductDetailId");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasOne(d => d.ProductDetail)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductDetailId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }

        private static void ProductSerial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSerial>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.ProductDetailId)
                    .HasName("IX_ProductDetailId");

                entity.HasIndex(e => e.PurchaseDetailId)
                    .HasName("IX_PurchaseDetailId");

                entity.HasIndex(e => e.SerialNumber)
                    .HasName("IX_SerialNumber");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasOne(d => d.ProductDetail)
                    .WithMany(p => p.ProductSerials)
                    .HasForeignKey(d => d.ProductDetailId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.PurchaseDetail)
                    .WithMany(p => p.ProductSerials)
                    .HasForeignKey(d => d.PurchaseDetailId);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.ProductSerials)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }

        private static void PurchaseDetail(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseDetail>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.ProductDetailId)
                    .HasName("IX_ProductDetailId");

                entity.HasIndex(e => e.PurchaseId)
                    .HasName("IX_PurchaseId");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.WarehouseId)
                    .HasName("IX_WarehouseId");

                entity.HasOne(d => d.ProductDetail)
                    .WithMany(p => p.PurchaseDetails)
                    .HasForeignKey(d => d.ProductDetailId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.PurchaseDetails)
                    .HasForeignKey(d => d.PurchaseId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.PurchaseDetails)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.PurchaseDetails)
                    .HasForeignKey(d => d.WarehouseId);
            });

        }

        private static void Purchase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.OrderNumber)
                    .HasName("IX_OrderNumber");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.SupplierId)
                    .HasName("IX_SupplierId");

                entity.HasIndex(e => e.WarehouseId)
                    .HasName("IX_WarehouseId");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.WarehouseId);
            });

        }


        private static void SaleDetail(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleDetail>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.ProductDetailId)
                    .HasName("IX_ProductDetailId");

                entity.HasIndex(e => e.SaleId)
                    .HasName("IX_SaleId");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.WarehouseId)
                    .HasName("IX_WarehouseId");

                entity.HasIndex(e => e.WcId)
                    .HasName("IX_WcId");

                entity.HasOne(d => d.ProductDetail)
                    .WithMany(p => p.SaleDetails)
                    .HasForeignKey(d => d.ProductDetailId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.SaleDetails)
                    .HasForeignKey(d => d.SaleId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.SaleDetails)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.SaleDetails)
                    .HasForeignKey(d => d.WarehouseId);
            });

        }

        private static void Sale(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasIndex(e => e.AddressId)
                    .HasName("IX_AddressId");

                entity.HasIndex(e => e.CourierShopId)
                    .HasName("IX_CourierShopId");

                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("IX_CustomerId");

                entity.HasIndex(e => e.DealerId)
                    .HasName("IX_DealerId");

                entity.HasIndex(e => e.EmployeeInfoId)
                    .HasName("IX_EmployeeInfoId");

                entity.HasIndex(e => e.InstallmentId)
                    .HasName("IX_InstallmentId");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.OrderNumber)
                    .HasName("IX_OrderNumber");

                entity.HasIndex(e => e.OrderState)
                    .HasName("IX_OrderState");

                entity.HasIndex(e => e.SaleChannel)
                    .HasName("IX_SaleChannel");

                entity.HasIndex(e => e.SaleFrom)
                    .HasName("IX_SaleFrom");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.WarehouseId)
                    .HasName("IX_WarehouseId");

                entity.HasIndex(e => e.WcCustomerId)
                    .HasName("IX_WcCustomerId");

                entity.HasIndex(e => e.WcId)
                    .HasName("IX_WcId");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.AddressId);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Dealer)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.DealerId);

                entity.HasOne(d => d.EmployeeInfo)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.EmployeeInfoId);

                entity.HasOne(d => d.Installment)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.InstallmentId);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.WarehouseId);
            });

        }

        private static void SaleState(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleState>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.SaleId)
                    .HasName("IX_SaleId");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.State)
                    .HasName("IX_State");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.SaleStates)
                    .HasForeignKey(d => d.SaleId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.SaleStates)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }

        private static void Shop(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>(entity =>
            {
                entity.HasIndex(e => e.ContactPersonDesignation)
                    .HasName("IX_ContactPersonDesignation");

                entity.HasIndex(e => e.ContactPersonName)
                    .HasName("IX_ContactPersonName");

                entity.HasIndex(e => e.ContactPersonPhone)
                    .HasName("IX_ContactPersonPhone");

                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Email)
                    .HasName("IX_Email");

                entity.HasIndex(e => e.Facebook)
                    .HasName("IX_Facebook");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_ShopName")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("IX_ShopPhone");

                entity.HasIndex(e => e.WcKey)
                    .HasName("IX_WcKey");

                entity.HasIndex(e => e.WcSecret)
                    .HasName("IX_WcSecret");

                entity.HasIndex(e => e.WcUrl)
                    .HasName("IX_WcUrl");

                entity.HasIndex(e => e.WcWebhookSource)
                    .HasName("IX_WcWebhookSource");

                entity.HasIndex(e => e.Website)
                    .HasName("IX_Website");
            });

        }

        private static void Sms(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sms>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.ReasonId)
                    .HasName("IX_ReasonId");

                entity.HasIndex(e => e.ReasonType)
                    .HasName("IX_ReasonType");

                entity.HasIndex(e => e.ReceiverId)
                    .HasName("IX_ReceiverId");

                entity.HasIndex(e => e.ReceiverNumber)
                    .HasName("IX_ReceiverNumber");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Sms)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }

        private static void SmsHistory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SmsHistory>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.SmsHistories)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }

        private static void SmsHook(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SmsHook>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.SmsHooks)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }

        private static void StockTransferDetail(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockTransferDetail>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.DestinationWarehouseId)
                    .HasName("IX_DestinationWarehouseId");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.ProductDetailId)
                    .HasName("IX_ProductDetailId");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.SourceWarehouseId)
                    .HasName("IX_SourceWarehouseId");

                entity.HasIndex(e => e.StockTransferId)
                    .HasName("IX_StockTransferId");

                entity.HasOne(d => d.DestinationWarehouse)
                    .WithMany(p => p.StockTransferDetailsDestinationWarehouse)
                    .HasForeignKey(d => d.DestinationWarehouseId);

                entity.HasOne(d => d.ProductDetail)
                    .WithMany(p => p.StockTransferDetails)
                    .HasForeignKey(d => d.ProductDetailId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.StockTransferDetails)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SourceWarehouse)
                    .WithMany(p => p.StockTransferDetailsSourceWarehouse)
                    .HasForeignKey(d => d.SourceWarehouseId);

                entity.HasOne(d => d.StockTransfer)
                    .WithMany(p => p.StockTransferDetails)
                    .HasForeignKey(d => d.StockTransferId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }

        private static void StockTransfer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockTransfer>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.DestinationWarehouseId)
                    .HasName("IX_DestinationWarehouseId");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.OrderNumber)
                    .HasName("IX_OrderNumber");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.SourceWarehouseId)
                    .HasName("IX_SourceWarehouseId");

                entity.HasOne(d => d.DestinationWarehouse)
                    .WithMany(p => p.StockTransfersDestinationWarehouse)
                    .HasForeignKey(d => d.DestinationWarehouseId);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.StockTransfers)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SourceWarehouse)
                    .WithMany(p => p.StockTransfersSourceWarehouse)
                    .HasForeignKey(d => d.SourceWarehouseId);
            });

        }

        private static void SupplierProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SupplierProduct>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.ProductDetailId)
                    .HasName("IX_ProductDetailId");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.SupplierId)
                    .HasName("IX_SupplierId");

                entity.HasOne(d => d.ProductDetail)
                    .WithMany(p => p.SupplierProducts)
                    .HasForeignKey(d => d.ProductDetailId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.SupplierProducts)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierProducts)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }

        private static void SupplierProductTransaction(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SupplierProductTransaction>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.SupplierProductId)
                    .HasName("IX_SupplierProductId");

                entity.HasIndex(e => e.TransactionId)
                    .HasName("IX_TransactionId");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.SupplierProductTransactions)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SupplierProduct)
                    .WithMany(p => p.SupplierProductTransactions)
                    .HasForeignKey(d => d.SupplierProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.SupplierProductTransactions)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }

        private static void Supplier(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Name");

                entity.HasIndex(e => e.OrdersCount)
                    .HasName("IX_OrdersCount");

                entity.HasIndex(e => e.OtherAmount)
                    .HasName("IX_OtherAmount");

                entity.HasIndex(e => e.Phone)
                    .HasName("IX_Phone");

                entity.HasIndex(e => e.ProductAmount)
                    .HasName("IX_ProductAmount");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.TotalAmount)
                    .HasName("IX_TotalAmount");

                entity.HasIndex(e => e.TotalDiscount)
                    .HasName("IX_TotalDiscount");

                entity.HasIndex(e => e.TotalDue)
                    .HasName("IX_TotalDue");

                entity.HasIndex(e => e.TotalPaid)
                    .HasName("IX_TotalPaid");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.SuppliersShop)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);                
            });


        }

        private static void Transaction(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasIndex(e => e.AccountHeadId)
                    .HasName("IX_AccountHeadId");

                entity.HasIndex(e => e.AccountHeadName)
                    .HasName("IX_AccountHeadName");

                entity.HasIndex(e => e.AccountInfoId)
                    .HasName("IX_AccountInfoId");

                entity.HasIndex(e => e.Amount)
                    .HasName("IX_Amount");

                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.OrderId)
                    .HasName("IX_OrderId");

                entity.HasIndex(e => e.OrderNumber)
                    .HasName("IX_OrderNumber");

                entity.HasIndex(e => e.ParentId)
                    .HasName("IX_ParentId");

                entity.HasIndex(e => e.ParentName)
                    .HasName("IX_ParentName");

                entity.HasIndex(e => e.PaymentGatewayService)
                    .HasName("IX_PaymentGatewayService");

                entity.HasIndex(e => e.PaymentGatewayServiceName)
                    .HasName("IX_PaymentGatewayServiceName");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.TransactionFlowType)
                    .HasName("IX_TransactionFlowType");

                entity.HasIndex(e => e.TransactionFor)
                    .HasName("IX_TransactionFor");

                entity.HasIndex(e => e.TransactionMedium)
                    .HasName("IX_TransactionMedium");

                entity.HasIndex(e => e.TransactionMediumName)
                    .HasName("IX_TransactionMediumName");

                entity.HasIndex(e => e.TransactionNumber)
                    .HasName("IX_TransactionNumber");

                entity.HasIndex(e => e.TransactionWith)
                    .HasName("IX_TransactionWith");

                entity.HasOne(d => d.AccountHead)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AccountHeadId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.AccountInfo)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AccountInfoId);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }

        private static void WarehouseProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WarehouseProduct>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.ProductDetailId)
                    .HasName("IX_ProductDetailId");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.WarehouseId)
                    .HasName("IX_WarehouseId");

                entity.HasOne(d => d.ProductDetail)
                    .WithMany(p => p.WarehouseProducts)
                    .HasForeignKey(d => d.ProductDetailId);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.WarehouseProducts)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.WarehouseProducts)
                    .HasForeignKey(d => d.WarehouseId);
            });

        }

        private static void Warehouse(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }

        private static void WarehouseZone(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WarehouseZone>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasIndex(e => e.ShopId)
                    .HasName("IX_ShopId");

                entity.HasIndex(e => e.WarehouseId)
                    .HasName("IX_WarehouseId");

                entity.HasIndex(e => e.ZoneId)
                    .HasName("IX_ZoneId");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.WarehouseZones)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.WarehouseZones)
                    .HasForeignKey(d => d.WarehouseId);

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.WarehouseZones)
                    .HasForeignKey(d => d.ZoneId);
            });

        }

        private static void Zone(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zone>(entity =>
            {
                entity.HasIndex(e => e.Created)
                    .HasName("IX_Created");

                entity.HasIndex(e => e.DistrictId)
                    .HasName("IX_DistrictId");

                entity.HasIndex(e => e.Modified)
                    .HasName("IX_Modified");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Zones)
                    .HasForeignKey(d => d.DistrictId);
            });

        }


    }
}
