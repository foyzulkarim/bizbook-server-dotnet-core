using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Model.Constants
{
    public enum AccountType
    {
        Income,
        Expense
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccountInfoType
    {
        Cash,
        Bank,
        Mobile,
        Other
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransactionFlowType
    {
        Income = 1,
        Expense = 2,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransactionFor
    {
        All = 0,
        Sale = 1,
        Purchase = 2,
        Office = 3,
        Other = 4
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransactionWith
    {
        All = 0,
        Customer = 1,
        Supplier = 2,
        Employee = 3,
        Dealer = 4,
        Partner = 5,
        Other = 6
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransactionMedium
    {
        All = 0,
        Cash = 1,
        Card = 2,
        Cheque = 3,
        Mobile = 4,
        Other = 5,
        Bank = 6
    }


    public enum ReportTimeType
    {
        Daily,
        Weekly,
        Monthly,
        Yearly
    }

    public enum SaleChannel
    {
        All,
        InHouse,
        CashOnDelivery,
        Courier,
        Condition,
        Other
    }

    public enum SaleFrom
    {
        All,
        BizBook365,
        Facebook,
        Website,
        PhoneCall,
        MobileApp,
        Referral,
        Other,
    }

    public enum OrderState
    {
        //All, //0
        Pending = 1,
        Created, //2
        ReadyToDeparture, //3
        OnTheWay, // 4
        Delivered, //5
        Completed, //6
        Cancel // 7
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SmsReceiverType
    {
        Unknown = 0,
        Customer,
        Dealer,
        User,
        Supplier
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SmsReasonType
    {
        Unknown = 0,
        Sale,
        Purchase,
        Transaction
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BizSmsHook
    {
        OrderPending = 1,
        OrderCreated,
        OrderReadyToDepurture
    }


    public enum StockTransferState
    {
        Pending = 0,
        Approved = 1
    }
}
