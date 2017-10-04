using DAL.Repositories;
using Domain.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NHUnitOfWork
{
    public class NHUnitOfWork : IUnitOfWork
    {
       
        private readonly ITransaction _transaction;

        public NhibernateRepository _repository { get; private set; }

        public NHUnitOfWork(NhibernateRepository repository)
        {
            _repository = repository;
            
            _transaction = _repository._session.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void Dispose()
        {
            if (_repository._session.IsOpen)
            {
                _transaction.Dispose();
                _repository.Dispose();
            }
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            if (_transaction.IsActive)
            {
                _transaction.Rollback();
            }
        }

        public IRepository<IEntity> GetRepository()
        {
            return _repository;
        }
    }
}