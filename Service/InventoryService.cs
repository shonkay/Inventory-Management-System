using Inventory_Management_System.Context;
using Inventory_Management_System.Interface;
using Inventory_Management_System.Models;
using Inventory_Management_System.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management_System.Service
{
    public class InventoryService : IInventoryService
    {
        private readonly DataContext _context;

        public InventoryService(DataContext context)
        {
            _context = context;
        }

        public List<InventoryViewModel> GetAllInventories()
        {
            var inventory = (from inv in _context.InventoryItems
                             join w in _context.WareHouses on inv.WareHouseId equals w.Id
                             join employee in _context.Employees on inv.EmployeeId equals employee.Id
                             select new InventoryViewModel
                             {
                                 Id = inv.Id.ToString(),
                                 InventoryItem= inv.ItemName,
                                 EmployeeName = employee.Name,
                                 WareHouse = w.WarehouseName
                             }).ToList();

            if(inventory.Count > 0)
            {
                return inventory;
            }
            else
            {
                return null;
            }
        }
    }
}
