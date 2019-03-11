using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApiApp.Models;

namespace DataTestLibrary.Sample
{
    public class SampleData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            IDataTestRepository dataTestRepository = new DataTestRepository(context);

            if (!dataTestRepository.GetProperty1s().Any())
            {
                dataTestRepository.AddProperty1(new Property1() {
                    Id = Guid.NewGuid(),
                    Title = "some property first type"
                });
                dataTestRepository.AddProperty1(new Property1()
                {
                    Id = Guid.NewGuid(),
                    Title = "another property first type"
                });
            }

            if (!dataTestRepository.GetProperty2s().Any())
            {
                dataTestRepository.AddProperty2(new Property2()
                {
                    Id = Guid.NewGuid(),
                    Title = "some property second type"
                });
                dataTestRepository.AddProperty2(new Property2()
                {
                    Id = Guid.NewGuid(),
                    Title = "another property second type"
                });
            }


            if (!dataTestRepository.Get().Any())
            {
                dataTestRepository.AddData(new Data() {
                    Id = Guid.NewGuid(),
                    Sum = 10000,
                    Count = 2,
                    Flag = true,
                    Name = "sample data 1",
                    Prop1 = (Property1)dataTestRepository.GetProperty1s().FirstOrDefault(),
                    Prop2 = (Property2)dataTestRepository.GetProperty2s().FirstOrDefault(),
                    SubData = null
                });
                dataTestRepository.AddData(new Data()
                {
                    Id = Guid.NewGuid(),
                    Sum = 200000,
                    Count = 4,
                    Flag = false,
                    Name = "sample data 2",
                    Prop1 = (Property1)dataTestRepository.GetProperty1s().LastOrDefault(),
                    Prop2 = (Property2)dataTestRepository.GetProperty2s().LastOrDefault(),
                    SubData = null
                });
                dataTestRepository.AddData(new Data()
                {
                    Id = Guid.NewGuid(),
                    Sum = 10,
                    Count = 10,
                    Flag = true,
                    Name = "sample data 3",
                    Prop1 = (Property1)dataTestRepository.GetProperty1s().FirstOrDefault(),
                    Prop2 = (Property2)dataTestRepository.GetProperty2s().FirstOrDefault(),
                    SubData = null
                });
                dataTestRepository.AddData(new Data()
                {
                    Id = Guid.NewGuid(),
                    Sum = 200000,
                    Count = 4,
                    Flag = false,
                    Name = "sample data 4",
                    Prop1 = (Property1)dataTestRepository.GetProperty1s().LastOrDefault(),
                    Prop2 = (Property2)dataTestRepository.GetProperty2s().LastOrDefault(),
                    SubData = null
                });
            }



            if (!dataTestRepository.GetSubDatas().Any())
            {
                dataTestRepository.AddSubData(new SubData() {
                    Id = Guid.NewGuid(),
                    Data = (Data)dataTestRepository.Get().FirstOrDefault(),
                    Value = 50
                });
                dataTestRepository.AddSubData(new SubData()
                {
                    Id = Guid.NewGuid(),
                    Data = (Data)dataTestRepository.Get().FirstOrDefault(),
                    Value = 130
                });
                dataTestRepository.AddSubData(new SubData()
                {
                    Id = Guid.NewGuid(),
                    Data = (Data)dataTestRepository.Get().LastOrDefault(),
                    Value = 75
                });
                dataTestRepository.AddSubData(new SubData()
                {
                    Id = Guid.NewGuid(),
                    Data = (Data)dataTestRepository.Get().LastOrDefault(),
                    Value = 256
                });
            }

        }
    }
}
