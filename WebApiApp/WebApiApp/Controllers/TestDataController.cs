using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTestLibrary;
using DataTestLibrary.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiApp.Factory;
using WebApiApp.Models;
using System.Linq.Expressions;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDataController : ControllerBase
    {
        private readonly IDataTestRepository _dataTestRepository;
        private readonly IDataViewModelFactory _dataViewModelFactory;

        public TestDataController(IDataTestRepository dataTestRepository, IDataViewModelFactory dataViewModelFactory)
        {
            _dataTestRepository = dataTestRepository;
            _dataViewModelFactory = dataViewModelFactory;
        }


        class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        [HttpGet]
        public IEnumerable<DataViewModel> Get()
        {
            //to-do: получаем JSON filter с клиента
            //на клиенте динамическое формирование списка
            //like в фильтре пока не работает - не успла пока нормально реализовать

            //for test
            IFilter filter = new Filter() {
                filterParams = new List<FilterParams>()
            };

            filter.filterParams.Add(new FilterParams() { PropertyName = "Count", ParamValue = "3", ExpressionType = ">" });
            filter.filterParams.Add(new FilterParams() { PropertyName = "Count", ParamValue = "10", ExpressionType = "<" });
            //filter.filterParams.Add(new FilterParams() { PropertyName = "Name", ParamValue = "4", ExpressionType = "%like%" });
            filter.filterParams.Add(new FilterParams() { PropertyName = "Flag", ParamValue = "true", ExpressionType = "=" });

            var target = _dataTestRepository.Get(filter);

            return _dataViewModelFactory.Create();
        }
    }
}