using Donators.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Donators.DAL
{
    public class DonatorContext : DbContext
    {
        public DonatorContext() : base("DonatorContext")
        {
        }

        public DbSet<Donator> Donators { get; set; }
    }
}