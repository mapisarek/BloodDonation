using Donators.DAL;
using Donators.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Donators.Services
{
    public interface IDonatorService
    {
        void addDonatorToDb(Donator donator);
        bool validateDonator(Donator donator); 
    }

    
    public class DonatorService : IDonatorService
    {
        DonatorContext _context;
        public List<DataPoint> bloodAmountList;     

        public DonatorService(DonatorContext dbContext)
        {
            _context = dbContext;
            bloodAmountList = new List<DataPoint>();
        }

        List<string> BloodType = new List<string>
        {
            "A",
            "B",
            "AB",
            "0"
        };

        List<string> BloodFactor = new List<string>
        {
            "RH+",
            "RH-"
        };

        public bool validateDonator(Donator donator)
        {
            bool ValidationPassed = true;

            if (!Regex.IsMatch(donator.FirstName, @"^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ\s]*$"))
            {
                ValidationPassed = false;
                donator.FirstName = markWrongData(donator.FirstName);
            }
            if (!Regex.IsMatch(donator.LastName, @"^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ\s]*$"))
            {
                ValidationPassed = false;
                donator.LastName = markWrongData(donator.LastName);
            }
            if (!Regex.IsMatch(donator.Place, @"^[-A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ\s]*$"))
            {
                ValidationPassed = false;
                donator.Place = markWrongData(donator.Place);
            }
            if (donator.Pesel.Length != 11 || !Regex.IsMatch(donator.Pesel, @"^[0-9]*$"))
            {
                ValidationPassed = false; 
                donator.Pesel = markWrongData(donator.Pesel);
            }
            if (!BloodFactor.Where(x => x.Contains(donator.BloodFactor.ToUpper())).Any() || donator.BloodFactor.Length > 3 || donator.BloodFactor.Length < 0)
            {
                ValidationPassed = false;
                donator.BloodFactor = markWrongData(donator.BloodFactor);
            }
            if (!BloodType.Where(x => x.Contains(donator.BloodType.ToUpper())).Any() || donator.BloodType.Length > 2 || donator.BloodType.Length < 0)
            {
                ValidationPassed = false;
                donator.BloodType = markWrongData(donator.BloodType);
            }
            if (!Regex.IsMatch(donator.DonationDate, @"^[0-3]?[0-9]/[0-3]?[0-9]/(?:[0-9]{2})?[0-9]{2}$"))
            {
                ValidationPassed = false;
                donator.DonationDate = markWrongData(donator.DonationDate);
            }

            try
            {
                DateTime.Parse(donator.DonationDate).ToShortTimeString();
            }
            catch
            {
                ValidationPassed = false;
                donator.DonationDate = markWrongData(donator.DonationDate);
            }

            try
            {
                Int32.Parse(donator.BloodAmount);    
            }
            catch
            {
                ValidationPassed = false;
                donator.BloodAmount = markWrongData(donator.BloodAmount);
            }

            return ValidationPassed;
        }

        public string markWrongData(string data)
        {
            data = $"<font color=\"red\"><strong>" + data + $"</font></strong>";
            return data;
        }
        
        public void getDonatorInstantiate(List<string[]> listOfDonators)
        {
            Donator BloodDonator;

            foreach(var item in listOfDonators)
            {
                BloodDonator = new Donator
                {
                    FirstName = item[0],
                    LastName = item[1],
                    Pesel = item[2],
                    BloodType = item[3],
                    BloodFactor = item[4],
                    BloodAmount = item[5],
                    DonationDate = item[6],
                    Place = item[7]
                };

                if (validateDonator(BloodDonator))
                {
                    BloodDonator.IsDataValid = true;
                }
                else
                {
                    BloodDonator.IsDataValid = false;
                }

                addDonatorToDb(BloodDonator);
            }
            

        }

        public void addDonatorToDb(Donator donator)
        {
            _context.Donators.Add(donator);
            _context.SaveChanges();
        }

        public void clearDbDonators()
        {
            foreach (var entity in _context.Donators)
                _context.Donators.Remove(entity);
            _context.SaveChanges();
        }

        public List<Donator> getValidDonatorsDB()
        {
            return _context.Donators.Where(x => x.IsDataValid == true).ToList();
        }

        public List<Donator> getWrongDonatorsDB()
        {
            return _context.Donators.Where(x => x.IsDataValid == false).ToList();
        }

        public void sumBlood(string bloodType)
        {
            int Amount = 0;
            DataPoint dataPoint;

            var amountTypeList = (from items in _context.Donators
                          where items.BloodType == bloodType && items.IsDataValid == true
                          select items.BloodAmount).ToList();

            foreach (var item in amountTypeList)
            {
                Amount += Convert.ToInt32(item);
            }

            dataPoint = new DataPoint(
                bloodType,
                Amount
                );

            bloodAmountList.Add(dataPoint);
        }

        public void allTypesAmount()
        {
            sumBlood("A");
            sumBlood("B");
            sumBlood("AB");
            sumBlood("0");
        }

    }
}