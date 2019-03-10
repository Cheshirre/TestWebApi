using DataTestLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApp.Models
{
    public class Property1 : IProperty1
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}
