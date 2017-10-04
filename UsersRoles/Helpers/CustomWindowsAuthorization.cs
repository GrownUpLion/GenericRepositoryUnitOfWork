using Domain.Interfaces;
using Domain.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UsersAdmin.Helpers
{
    public class CustomWindowsAuthorization : AuthorizeAttribute
    {

        [Inject]
        public IRepository<IEntity> _repository { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //System.Security.Principal.IPrincipal user = httpContext.User;
            //System.Security.Principal.IIdentity identity = user.Identity;
            //var username = httpContext.User.Identity.Name.Substring(identity.Name.IndexOf(@"\") + 1);
            //var DBuser = _repository.GetByName<User>("UserName", username);
            //if (DBuser == null) return false;
            return true;
        }
    }
}