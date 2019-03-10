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

        public virtual Property1 Prop1 { get; set; }
        public Guid Prop1Id { get; set; }

        public virtual Property2 Prop2 { get; set; }
        public Guid Prop2Id { get; set; }

        public int Count { get; set; }

        public bool Flag { get; set; }

        public decimal Sum { get; set; }

        public virtual ICollection<SubData> SubData { get; set; }
    }
}
