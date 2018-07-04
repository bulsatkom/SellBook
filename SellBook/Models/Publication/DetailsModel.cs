using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellBook.Models.Publication
{
    public class DetailsModel
    {
        public string Condition { get; set; }

        public string Delivery { get; set; }

        public int Number { get; set; }

        public int SalaryFrom { get; set; }

        public int SalaryTo { get; set; }

        public string Kind { get; set; }

        public string Bussiness { get; set; }

        public bool ForInvalids { get; set; }

        public bool IsContracting { get; set; }

        public string SuitableFor { get; set; }
    }
}