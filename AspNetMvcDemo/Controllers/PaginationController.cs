using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetMvcDemo.Models;
using Lifepoem.Foundation.Utilities.DBHelpers;
using Lifepoem.Foundation.Utilities.Helpers;

namespace AspNetMvcDemo.Controllers
{
    public class PaginationController : Controller
    {
        // GET: Pagination
        public ActionResult Index(int page = 1)
        {
            PagingOption option = GetPagingOption(page, 10);
            EmployeeManager em = new EmployeeManager();
            var list = em.SelectEmployees(option);
            ViewBag.WebPagingOption = new WebPagingOption { CurrentPage = page, ItemsPerPage = 10, TotalItems = option.RecordCount };
            return View(list);
        }

        private PagingOption GetPagingOption(int page, int pageSize)
        {
            PagingOption option = new PagingOption();
            option.Start = (page - 1) * pageSize + 1;
            option.Length = pageSize;
            option.GetRecordCount = true;
            return option;
        }
    }
}