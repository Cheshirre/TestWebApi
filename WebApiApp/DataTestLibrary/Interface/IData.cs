using System;
using System.Collections.Generic;
using System.Text;
using WebApiApp.Models;

namespace DataTestLibrary.Interface
{
    public interface IData
    {
        Guid Id { get; set; }

        string Name { get; set; }

        Property1 Prop1 { get; set; }
        Guid Prop1Id { get; set; }

        Property2 Prop2 { get; set; }
        Guid Prop2Id { get; set; }

        int Count { get; set; }

        bool Flag { get; set; }

        decimal Sum { get; set; }

        ICollection<SubData> SubData { get; set; }
    }
}
