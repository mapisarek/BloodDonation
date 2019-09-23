using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Donators.Models
{
    public class Donator
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="Imię")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        public string Pesel { get; set; }
        [Display(Name = "Miejsce")]
        public string Place { get; set; }
        [Display(Name = "Data")]
        public string DonationDate { get; set; }
        [Display(Name = "Typ krwii")]
        public string BloodType { get; set; }
        [Display(Name = "Ilość")]
        public string BloodAmount { get; set; }
        [Display(Name = "Czynnik")]
        public string BloodFactor { get; set; }
        public bool IsDataValid { get; set; }
    }
}