﻿using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public interface InvoiceService
    {
        public Invoice CreateInvoice(Invoice invoice);

    }
}
