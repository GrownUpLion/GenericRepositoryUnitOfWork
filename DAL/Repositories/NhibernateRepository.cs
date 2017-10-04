using DAL.Helper;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using NHibernate.Linq;
using System.Linq;

namespace DAL.Repositories
{
    public class NhibernateRepository : IRepository<IEntity>
    {
        private NHibernateConection _connection;
        public ISession _session { get { return _connection.Session; } }

        public NhibernateRepository(NHibernateConection connection)
        {
            _connection = connection;
        }

        public void Delete(IEntity obj)
        {
            _session.Delete(obj);
        }

        public void Dispose()
        {
            if (_session != null)
            {
                //_session.Flush();
                CloseSession();
            }
        }
        private void CloseSession()
        {
            _session.Close();
            _session.Dispose();
        }


        public IEntity GetById<IEntity>(int objId)
        {
            return _session.Load<IEntity>(objId);
        }

        public void Save(IEntity obj)
        {
            _session.Save(obj);
            _session.Flush();
            _session.Clear();
        }


        public void Update(IEntity obj)
        {
            _session.Update(obj);
        }

        public IEnumerable<IEntity> GetAll<IEntity>(int startIndex, int count)
        {
            return (_session.Query<IEntity>().Skip(startIndex).Take(count));
        }

        public IEntity GetByName<IEntity>(string property, string name)
        {
            var par = System.Linq.Expressions.Expression.Parameter(typeof(IEntity), "x");
            var eq = System.Linq.Expressions.Expression.Equal(System.Linq.Expressions.Expression.Property(par, property), System.Linq.Expressions.Expression.Constant(name));
            var lambda = System.Linq.Expressions.Expression.Lambda<Func<IEntity, bool>>(eq, par);
            return _session.Query<IEntity>().Where(lambda).SingleOrDefault();
        }
    }
}
