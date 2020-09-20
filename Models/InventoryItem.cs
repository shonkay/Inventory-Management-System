using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management_System.Models
{
    public class InventoryItem
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid WareHouseId { get; set; }
    }
}
