using Domain.Interfaces;
using Domain.Models;
using Moq;
using UsersAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UsersAdmin.Controllers
{
    public class UsersAPIController : ApiController
    {

        public IUnitOfWork _unitOFWOrk { get; set; }

        public UsersAPIController(IUnitOfWork _unitOFWOrk)
        {
            this._unitOFWOrk = _unitOFWOrk;
        }

        // GET api/usersapi
        public IEnumerable<User> Get()
        {
            IEnumerable<User> users = _unitOFWOrk.GetRepository().GetAll<User>(0, 100);
            return users.ToList<User>();
        }

        // GET api/usersapi/id
        public User Get(int id)
        {
            User user = _unitOFWOrk.GetRepository().GetById<User>(id);
            return user;
        }

        // POST api/usersapi
        public void Post(User user)
        {
            _unitOFWOrk.GetRepository().Save(user);
            _unitOFWOrk.Commit();
        }

        // PUT api/usersapi/id
        public void Put(User user)
        {
            _unitOFWOrk.GetRepository().Update(user);
            _unitOFWOrk.Commit();
        }

        // DELETE api/usersapi/id
        public void Delete(int id)
        {
            User user = _unitOFWOrk.GetRepository().GetById<User>(id);
            _unitOFWOrk.GetRepository().Delete(user);
            _unitOFWOrk.Commit();
        }
    }
}