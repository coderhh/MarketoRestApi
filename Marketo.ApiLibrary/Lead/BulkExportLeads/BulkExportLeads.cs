﻿using Marketo.ApiLibrary.Common.DI;
using Marketo.ApiLibrary.Lead.BulkExportLeads.Request;
using Marketo.ApiLibrary.Lead.BulkExportLeads.Response;
using System.Collections.Generic;

namespace Marketo.ApiLibrary.Lead.BulkExportLeads
{
    public class BulkExportLeads
    {
        private static IBulkExportLeadsController _bulkExportLeadsController;

        public static IBulkExportLeadsController BulkExportLeadsController
        {
            get
            {
                if (_bulkExportLeadsController == null)
                {
                    Initialize();
                }

                return _bulkExportLeadsController;
            }
        }

        static BulkExportLeads()
        {
            Initialize();
        }

        private static void Initialize()
        {
            _bulkExportLeadsController = MarketoApiContainer.Resolve<IBulkExportLeadsController>();
        }
        /// <summary>
        /// POST /bulk/v1/leads/export/create.json
        /// </summary>
        /// <returns></returns>
        public static CreateExportLeadJobResponse CreateExportLeadJob(List<string> fields, ExportLeadFilter filters, List<ColumnHeaderName> columnHeaderNames, string format = "csv")
        {
            return BulkExportLeadsController.CreateExportLeadJob(fields, filters, columnHeaderNames, format);
        }
    }
}