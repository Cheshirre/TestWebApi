using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTestLibrary.Interface;
using Microsoft.EntityFrameworkCore;
using WebApiApp.Models;

namespace DataTestLibrary
{
    public class DataTestRepository : IDataTestRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DataTestRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
      
        public IEnumerable<IData> Get()
        {
            return _dbContext.Datas.Include(x => x.Prop1).Include(x => x.Prop2).Include(x => x.SubData).AsEnumerable();
        }

        public IEnumerable<ISubData> GetSubDatas()
        {
            return _dbContext.SubDatas.AsEnumerable();
        }

        public IEnumerable<IProperty1> GetProperty1s()
        {
            return _dbContext.Property1s.AsEnumerable();
        }

        public IEnumerable<IProperty2> GetProperty2s()
        {
            return _dbContext.Property2s.AsEnumerable();
        }

        public void AddData(Data target)
        {
            _dbContext.Datas.Add(target);
            _dbContext.SaveChanges();
        }

        public void AddProperty1(Property1 target)
        {
            _dbContext.Property1s.Add(target);
            _dbContext.SaveChanges();
        }

        public void AddProperty2(Property2 target)
        { 
            _dbContext.Property2s.Add(target);
            _dbContext.SaveChanges();
        }

        public void AddSubData(SubData target)
        {
            _dbContext.SubDatas.Add(target);
            _dbContext.SaveChanges();
        }
    }
}
