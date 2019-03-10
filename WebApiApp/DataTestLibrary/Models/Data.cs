using DataTestLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApp.Models
{
    public class Data : IData
    { 
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Property1 Prop1 { get; set; }

        public Property2 Prop2 { get; set; }

        public ICollection<SubData> SubData { get; set; }

        public int Count { get; set; }

        public bool Flag { get; set; }

        public decimal Sum { get; set; }
    }
}
