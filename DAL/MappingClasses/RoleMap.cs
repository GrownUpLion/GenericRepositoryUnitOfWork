using Domain.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MappingClasses
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Id(c => c.Id).GeneratedBy.Assigned();
            Map(c => c.Name);

           //// HasManyToMany(x => x.Users)
           //// .ParentKeyColumn("Role_Id")
           //// .ChildKeyColumn("User_Id")
           //// .Table("UserRoles")
           ////.Cascade.All();


        }
    }
}
