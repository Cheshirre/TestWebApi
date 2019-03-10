using System;
using System.Collections.Generic;
using System.Text;

namespace DataTestLibrary.Interface
{
    public interface IProperty1
    {
        Guid Id { get; set; }

        string Title { get; set; }
    }
}
