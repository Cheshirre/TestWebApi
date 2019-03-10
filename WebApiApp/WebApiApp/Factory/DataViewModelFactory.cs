using DataTestLibrary;
using DataTestLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Models;

namespace WebApiApp.Factory
{
    public class DataViewModelFactory : IDataViewModelFactory
    {
        private readonly IDataTestRepository _dataTestRepository;

        public DataViewModelFactory(IDataTestRepository dataTestRepository)
        {
            _dataTestRepository = dataTestRepository;
        }

        public List<DataViewModel> Create()
        {
            List<DataViewModel> viewModelsList = new List<DataViewModel>();

            try
            {
                List<IData> dataTestList = _dataTestRepository.Get().ToList();

                dataTestList.ForEach(x => viewModelsList.Add(new DataViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Count = x.Count,
                    Flag = x.Flag,
                    Prop1Title = x.Prop1.Title,
                    Prop2Title = x.Prop2.Title,
                    Sum = x.Sum,
                    SumSubDataValues = x.SubData.Sum(t => t.Value)
                }));
            }
            catch (Exception)
            {

            }

            return viewModelsList;
        }
    }
}
