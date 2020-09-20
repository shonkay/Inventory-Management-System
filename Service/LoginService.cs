using Inventory_Management_System.Context;
using Inventory_Management_System.Interface;
using Inventory_Management_System.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management_System.Service
{
    public class LoginService : ILoginService
    {
        private readonly DataContext _context;

        public LoginService(DataContext context)
        {
            _context = context;
        }


        public UserViewModel GetUser(string userName, string password)
        {
            var user = (from e in _context.Employees.Where(x => x.Name == userName && x.Password == password)
                       join r in _context.Roles on e.roleId equals r.Id
                       select new UserViewModel
                       {
                           UserName = e.Name,
                           UserRole = r.role
                       }).FirstOrDefault();
            if(user == null)
            {
                return null;
            }
            return user;
        }
    }
}
