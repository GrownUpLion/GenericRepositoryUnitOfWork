﻿using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MockRepository : IRepository<IEntity>
    {
        public static List<User> _users = new List<User>();
        public static List<Role> _roles = new List<Role>();

        static MockRepository()
        {
            User user = new User
            {
                Id = 1,
                UserName = "JosePelayo",
                FirstName = "Jose",
                LastName = "Pelayo",
                Email = "jmpelayot@gmail.com",
                Active = true,
                Roles = new List<Role>()
            };

            Role role = new Role
            {
                Id = 1,
                Name = "Admin"
            };
            user.Roles.Add(role);
            Role role2 = new Role
            {
                Id = 2,
                Name = "User"
            };

            _roles.Add(role);
            _roles.Add(role2);
            _users.Add(user);
        }

        public void Save(IEntity obj)
        {
            if (obj.GetType() == typeof(User))
            {
                User last = _users.LastOrDefault<User>();
                if (last == null) obj.Id = 1;
                else obj.Id = last.Id + 1;
                _users.Add((User)obj);
            }
            else
            {
                Role last = _roles.LastOrDefault<Role>();
                if (last == null) obj.Id = 1;
                else obj.Id = last.Id + 1;
                _roles.Add((Role)obj);
            }
        }

        public void Update(IEntity obj)
        {
            if (obj.GetType() == typeof(User))
            {
                int index = _users.FindIndex(x => x.Id == obj.Id);
                _users[index]= (User)obj;
            }
            else
            {
                int index = _roles.FindIndex(x => x.Id == obj.Id);
                _roles[index] = (Role)obj;
            }
        }

        public void Delete(IEntity obj)
        {
            if (obj.GetType() == typeof(User))
            {
                _users.Remove((User)obj);
            }
            else
            {
                _roles.Remove((Role)obj);
            }
        }

        public T GetById<T>(int objId)
        {
            if (typeof(T) == typeof(User))
            {
                return (T)Convert.ChangeType(_users.FirstOrDefault(x => x.Id == objId), typeof(T));
            }
            else
            {
                return (T)Convert.ChangeType(_roles.FirstOrDefault<Role>(x => x.Id == objId), typeof(T));
            }
        }

        public T GetByName<T>(string property, string name)
        {
            System.Reflection.PropertyInfo prop;
            if (typeof(T) == typeof(User))
            {
                prop = typeof(User).GetProperty(property);
                return (T)Convert.ChangeType(_users.FirstOrDefault(x => (string)prop.GetValue(x) == name), typeof(T));
            }
            else
            {
                prop = typeof(Role).GetProperty(property);
                return (T)Convert.ChangeType(_roles.FirstOrDefault(x => (string)prop.GetValue(x) == name), typeof(T));
            }
        }

        public IEnumerable<T> GetAll<T>(int startIndex, int count)
        {
            if (typeof(T) == typeof(User))
            {
                return (List<T>)Convert.ChangeType(_users.Skip(startIndex).Take(count).ToList(), typeof(List<T>));
            }
            else
            {
                return (List<T>)Convert.ChangeType(_roles.Skip(startIndex).Take(count).ToList(), typeof(List<T>));
            }
        }
    }
}
