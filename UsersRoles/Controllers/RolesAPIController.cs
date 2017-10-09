using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UsersAdmin.Controllers
{
    public class RolesAPIController : ApiController
    {
        public IRepository<IEntity> _repository { get; set; }

        public RolesAPIController(IRepository<IEntity> _repository)
        {
            this._repository = _repository;
        }

        // GET api/rolesapi
        public IEnumerable<Role> Get()
        {
            IEnumerable<Role> roles = _repository.GetAll<Role>(0, 100);
            return roles;
        }

        // GET api/rolesapi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}