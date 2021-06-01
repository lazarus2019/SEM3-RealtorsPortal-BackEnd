using NETAPI_SEM3.Models;
using NETAPI_SEM3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public interface InvoiceService
    {
        public Invoice CreateInvoice(Invoice invoice);
        public bool CheckPackage(int memberId);

        public List<InvoiceViewModel> getAllInvoice(int page); 
        public int getAllInvoiceCount(); 
        public List<InvoiceViewModel> searchInvoice(string keyword , int page); 
        public int searchInvoiceCount(string keyword); 

    }
}
