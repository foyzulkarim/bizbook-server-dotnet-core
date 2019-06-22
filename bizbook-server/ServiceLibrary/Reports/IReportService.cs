﻿using System;
using System.Collections.Generic;
using Model.Constants;
using Model.Model;

namespace ServiceLibrary.Reports
{
    public interface IReportService<T, M> where T : ShopChild where M : BaseReport
    {
        void ShopClose(string shopId, DateTime start, DateTime end, ReportTimeType reportTimeType);
        IEnumerable<M> CreateReportModels(List<T> models, ReportParameterBase p);
        M CreateReportModel(List<T> models, ReportParameterBase reportParameter);
        void SaveReports(List<M> reports);
    }

    public interface IReportService2
    {
        string QuickUpdate(string shopId, string itemId, DateTime date);
    }
}
