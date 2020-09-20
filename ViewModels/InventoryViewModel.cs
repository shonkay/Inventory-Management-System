using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management_System.ViewModels
{
    public class InventoryViewModel
    {
        public string Id { get; set; }
        public string InventoryItem { get; set; }
        public string EmployeeName { get; set; }
        public string WareHouse { get; set; }
        public string EmployeeRole { get; set; }
    }
}
