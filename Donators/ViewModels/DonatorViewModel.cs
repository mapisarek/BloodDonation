using Donators.DAL;
using Donators.Models;
using Donators.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace Donators.ViewModels
{
    public class DonatorViewModel
    {
        public List<DataPoint> DataPoints = new List<DataPoint>();
        public IPagedList<Donator> PagedDonors { get; set; }
        public IPagedList<Donator> PagedWrongDonors { get; set; }
        public List<Donator> Donators = new List<Donator>();
        public Donator donatorModel;
        private readonly DonatorService donatorService;


        public DonatorViewModel(DonatorContext context)
        {
            donatorService = new DonatorService(context);
            Donators = donatorService.getValidDonatorsDB();
            setDataPoints();

        }

        public void setListToWrongData()
        {
            Donators = donatorService.getWrongDonatorsDB();
        }

       public void setDataPoints()
        {
            donatorService.allTypesAmount();
            DataPoints = donatorService.bloodAmountList;
        }
    }
}