using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTestLibrary;
using DataTestLibrary.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDataController : ControllerBase
    {
        private readonly IDataTestRepository _dataTestRepository;

        public TestDataController(IDataTestRepository dataTestRepository)
        {
            _dataTestRepository = dataTestRepository;
        }

        [HttpGet]
        public IEnumerable<IData> Get()
        {
            return _dataTestRepository.Get();
        }
    }
}