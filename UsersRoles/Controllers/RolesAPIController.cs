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
        public IUnitOfWork _unitOFWOrk { get; set; }

        public RolesAPIController(IUnitOfWork _unitOFWOrk)
        {
            this._unitOFWOrk = _unitOFWOrk;
        }

        // GET api/rolesapi
        public IEnumerable<Role> Get()
        {
            IEnumerable<Role> roles = _unitOFWOrk.GetRepository().GetAll<Role>(0, 100);
            return roles;
        }

        // GET api/rolesapi/5
        public Role Get(int id)
        {
            Role role = _unitOFWOrk.GetRepository().GetById<Role>(id);
            return role;
        }

        // POST api/rolesapi
        public void Post(Role role)
        {
            _unitOFWOrk.GetRepository().Save(role);
            _unitOFWOrk.Commit();
        }


        // PUT api/rolesapi/id
        public void Put(Role role)
        {
            _unitOFWOrk.GetRepository().Update(role);
            _unitOFWOrk.Commit();
        }


        // DELETE api/rolesapi/id
        public void Delete(int id)
        {
            Role role = _unitOFWOrk.GetRepository().GetById<Role>(id);
            _unitOFWOrk.GetRepository().Delete(role);
            _unitOFWOrk.Commit();
        }
    }
}