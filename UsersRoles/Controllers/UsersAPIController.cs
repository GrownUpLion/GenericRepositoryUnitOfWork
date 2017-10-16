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
using Domain.Validators;

namespace UsersAdmin.Controllers
{
    public class UsersAPIController : ApiController
    {

        public IUnitOfWork _unitOFWOrk { get; set; }


        public UsersAPIController(IUnitOfWork _unitOFWOrk)
        {
            this._unitOFWOrk = _unitOFWOrk;
        }

        // GET api/usersapi/pageno/pagesize
        public IEnumerable<User> Get([FromUri]int pageNo, [FromUri]int pageSize)
        {
            IEnumerable<User> users = _unitOFWOrk.GetRepository().GetAll<User>(pageNo, pageSize);
            return users.ToList<User>();
        }

        // GET api/usersapi/id
        public User Get([FromUri] int id)
        {
            User user = _unitOFWOrk.GetRepository().GetById<User>(id);
            return user;
        }

        // POST api/usersapi
        public IHttpActionResult Post(User user)
        {
            if (ModelState.IsValid)
            {
                _unitOFWOrk.GetRepository().Save(user);
                _unitOFWOrk.Commit();
            }
            else return BadRequest(ModelState);
            return Ok();
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