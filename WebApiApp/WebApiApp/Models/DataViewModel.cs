using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApp.Models
{
    public class DataViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Prop1Title { get; set; }
        public string Prop2Title { get; set; }

        public int Count { get; set; }

        public bool Flag { get; set; }

        public decimal Sum { get; set; }
        public decimal SumSubDataValues { get; set; }
    }
}
