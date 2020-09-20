using Inventory_Management_System.Context;
using Inventory_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management_System.Helpers
{
    public class InsertToDbOnStartUp
    {
        private readonly DataContext _context;

        public InsertToDbOnStartUp(DataContext context)
        {
            _context = context;
        }
        public void SeedAdmin()
        {

            var entity = _context.Roles.Where(x => x.role == "Admin").FirstOrDefault();
            if(entity == null)
            {
                var newEntity = new Employee
                {
                    Id = Guid.NewGuid(),
                    IsNew = true,
                    roleId = Guid.NewGuid(),
                    Name = "Admin",
                    Password = "Admin"
                };
                _context.Employees.Add(newEntity);
                _context.SaveChanges();

                var newEntityRole = new Role
                {
                    Id = newEntity.roleId,
                    role = "Admin"
                };

                _context.Roles.Add(newEntityRole);
                _context.SaveChanges();
            }
        }
    }
}
