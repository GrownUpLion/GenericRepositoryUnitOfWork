using Domain.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MappingClasses
{
    class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(c => c.Id).GeneratedBy.Assigned(); ;
            Map(c => c.FirstName);
            Map(c => c.LastName);
            Map(c => c.UserName);
            Map(c => c.Active);
            Map(c => c.Email);

            HasManyToMany(x => x.Roles)
            .ParentKeyColumn("User_Id")
            .ChildKeyColumn("Role_Id")
            .Table("UserRoles")
            //.Inverse()            // this is essential
             .Cascade.All();
        }
    }
}
