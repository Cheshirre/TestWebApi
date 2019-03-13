using System;
using System.Collections.Generic;
using System.Text;

namespace DataTestLibrary
{
    public interface IFilter
    {
        List<FilterParams> filterParams { get; set; }
    }
}
