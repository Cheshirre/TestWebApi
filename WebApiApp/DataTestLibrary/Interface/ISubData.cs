using System;
using System.Collections.Generic;
using System.Text;
using WebApiApp.Models;

namespace DataTestLibrary.Interface
{
    public interface ISubData
    {
        Guid Id { get; set; }

        Data Parent { get; set; }

        decimal Value { get; set; }
    }
}
