using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{
    [Route("api/report")]
    public class ReportController : Controller
    {

        private ReportService reportService;

        public ReportController(ReportService _reportService)
        {
            reportService = _reportService;
        }

        [Produces("application/json")]
        [HttpGet("getReport")]
        public IActionResult GetReport()
        {
            try
            {
                var report = reportService.getReport();
                return Ok(report); 
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }
        [Produces("application/json")]
        [HttpGet("getpayment")]
        public IActionResult GetPayment()
        {
            try
            {
                var invoices = reportService.getPayment();
                return Ok(invoices); 
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }

        [Produces("application/json")]
        [HttpGet("searchReportByDate/{fromMonth}/{fromDay}/{fromYear}/{toMonth}/{toDay}/{toYear}")]
        public IActionResult SearchReportByDate(int fromMonth , int fromDay , int fromYear ,int toMonth , int toDay ,  int toYear )
        {
            try
            {
                var fromDate = new DateTime(fromYear, fromMonth, fromDay); 
                var toDate = new DateTime(toYear, toMonth, toDay); 

                var reports = reportService.searchReportByDate(fromDate ,toDate);
                return Ok(reports);
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }

        [Produces("application/json")]
        [HttpGet("searchPaymentByDate/{fromMonth}/{fromDay}/{fromYear}/{toMonth}/{toDay}/{toYear}")]
        public IActionResult SearchPaymentByDate(int fromMonth,int fromDay,  int fromYear, int toMonth,int toDay,  int toYear)
        {
            try
            {
                var fromDate = new DateTime(fromYear, fromMonth, fromDay);
                var toDate = new DateTime(toYear, toMonth, toDay);

                var invoices = reportService.searchPaymentByDate(fromDate, toDate);
                return Ok(invoices);
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }
        
        [Produces("application/json")]
        [HttpGet("searchReportByDuration/{duration}")]
        public IActionResult SearchReportByDuration(string duration)
        {
            try
            {
                var reports = reportService.searchReportByDuration(duration);
                return Ok(reports);
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }

        [Produces("application/json")]
        [HttpGet("searchPaymentByDuration/{duration}")]
        public IActionResult SearchPaymentByDuration(string duration)
        {
            try
            {
                var invoices = reportService.searchPaymentByDuration(duration);
                return Ok(invoices);
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }


    }
}
