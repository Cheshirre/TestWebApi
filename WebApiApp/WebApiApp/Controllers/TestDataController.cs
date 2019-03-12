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
        public IEnumerable<DataViewModel> Get(string filter = null)
        {
            var target = _dataTestRepository.Get("dfdf");

            return _dataViewModelFactory.Create();
        }
    }
}