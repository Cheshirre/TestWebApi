using System;
using System.Collections.Generic;
using System.Text;

namespace DataTestLibrary
{
    public class Filter
    {
        List<FilterParams> filterParams { get; set; }
    }

    public class FilterParams
    {
        public string PropertyName { get; set; }
        public string ParamValue { get; set; }
        public string ExpressionType { get; set; }
    }
}
