using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Donators.DAL;
using Donators.Models;
using Donators.Services;
using Donators.ViewModels;
using Newtonsoft.Json;
using PagedList;

namespace Donators.Controllers
{
    public class DonatorsController : Controller
    {
        private DonatorContext db = new DonatorContext();
        private readonly DonatorService _donatorService;
        private readonly CsvReaderService _csvReaderService;
        private DonatorViewModel viewModel;
        public IPagedList<Donator> PagedDonors { get; set; }


        public DonatorsController()
        { 
            _donatorService = new DonatorService(db);
            _csvReaderService = new CsvReaderService();
            viewModel = new DonatorViewModel(db);
        }
        
        public ActionResult Index(int? page)
       {
            int pageSize = 20;
            int pageNumber = (page ?? 1);

            viewModel.PagedDonors = viewModel.Donators.ToPagedList(pageNumber, pageSize);
            ViewBag.DataPoints = JsonConvert.SerializeObject(viewModel.DataPoints);
            ViewBag.PageNumber = pageNumber;
            return View(viewModel);
        }
        
        public ActionResult Management(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            viewModel.setListToWrongData();
            viewModel.PagedWrongDonors = viewModel.Donators.ToPagedList(pageNumber, pageSize);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Management(HttpPostedFileBase uploadedFile)
        {
            _donatorService.getDonatorInstantiate(_csvReaderService.LoadFile(uploadedFile));
            return RedirectToAction("Index");
        }
        
        
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
