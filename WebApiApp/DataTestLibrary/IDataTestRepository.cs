using DataTestLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApiApp.Models;

namespace DataTestLibrary
{
    public interface IDataTestRepository
    {
        IEnumerable<IData> Get(IFilter filter = null);
        IEnumerable<Data> SimpleGet();
        IEnumerable<ISubData> GetSubDatas();
        IEnumerable<IProperty1> GetProperty1s();
        IEnumerable<IProperty2> GetProperty2s();

        void AddData(Data target);
        void AddProperty1(Property1 target);
        void AddProperty2(Property2 target);
        void AddSubData(SubData target);
    }
}
