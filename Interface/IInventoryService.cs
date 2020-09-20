using Inventory_Management_System.Models;
using Inventory_Management_System.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management_System.Interface
{
   public interface IInventoryService
    {
        List<InventoryViewModel> GetAllInventories();
    }
}
