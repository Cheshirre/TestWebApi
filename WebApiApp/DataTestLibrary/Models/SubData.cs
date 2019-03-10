using DataTestLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApp.Models
{
    public class SubData : ISubData
    {
        public Guid Id { get; set; }

        public Data Parent { get; set; }

        public decimal Value { get; set; }

    }
}
