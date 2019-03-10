using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Models;

namespace WebApiApp.Factory
{
    public interface IDataViewModelFactory
    {
        List<DataViewModel> Create();
    }
}
