using NETAPI_SEM3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public interface ReportService 
    {
        public ReportViewModel getReport();
        public List<InvoiceViewModel> getPayment();
        /// <summary>
        /// //
        /// </summary>
        public ReportViewModel searchReportByDate(DateTime fromDate , DateTime toDate);
        public List<InvoiceViewModel> searchPaymentByDate(DateTime fromDate , DateTime toDate);
        ///
        public ReportViewModel searchReportByDuration(string duration);
        public List<InvoiceViewModel> searchPaymentByDuration(string duration ) ;

    }
}
