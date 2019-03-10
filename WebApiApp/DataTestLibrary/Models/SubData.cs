using DataTestLibrary.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApp.Models
{
    public class SubData : ISubData
    {
        public Guid Id { get; set; }

        public decimal Value { get; set; }

        public virtual Data Data { get; set; }

    }
}
