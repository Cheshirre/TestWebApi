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
            }

            if (!dataTestRepository.GetSubDatas().Any())
            {
                dataTestRepository.AddSubData(new SubData() {
                    Id = Guid.NewGuid(),
                    Parent = (Data)dataTestRepository.Get().FirstOrDefault()
                });

                dataTestRepository.Get().FirstOrDefault().SubData.Add((SubData)dataTestRepository.GetSubDatas().FirstOrDefault());
            }

        }
    }
}
