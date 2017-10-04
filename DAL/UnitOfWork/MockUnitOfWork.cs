using DAL.Repositories;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class MockUnitOfWork : IUnitOfWork
    {

        public MockRepository _repository { get; private set; }

        public MockUnitOfWork(MockRepository repository)
        {
            _repository = repository;
        }



        public void Commit()
        {
           
        }

        public void Dispose()
        {
        }

        public IRepository<IEntity> GetRepository()
        {
            return _repository;
        }

        public void Rollback()
        {
           
        }
    }
}
