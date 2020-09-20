using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management_System.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsNew { get; set; }
        public Guid roleId { get; set; }
    }
}
