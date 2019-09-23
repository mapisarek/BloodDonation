using Donators.Models;
using LumenWorks.Framework.IO.Csv;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Donators.Services
{
    public interface ICsvReader
    {
        List<string[]> LoadFile(HttpPostedFileBase uploadedFile);

    }

    public class CsvReaderService : ICsvReader
    {

        private string[] delimiters = { ";", "," };
        private List<string[]> listOfDonators = new List<string[]>();

        public List<string[]> LoadFile(HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                if (upload.FileName.EndsWith(".csv"))
                {
                    Stream stream = upload.InputStream;
                    using (CsvReader csvReader =
                        new CsvReader(new StreamReader(stream), true))
                    {
                        listOfDonators = csvReader.ToList();
                    }
                    
                }
            }
            return listOfDonators;
        }

    }
}