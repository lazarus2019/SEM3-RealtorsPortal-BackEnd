﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{
    [Route("api/adspackage")]
    public class AdsPackageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
