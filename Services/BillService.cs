using Bill_Generate.Pages;
using Bill_Generate.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bill_Generate.Services
{
    public class BillService
    {
        public List<RateItem> RateItems { get; set; } = new List<RateItem>();
        public List<RateItem> SelectedItems { get; private set; } = new List<RateItem>();

        public decimal TotalAmount => SelectedItems.Sum(item => item.Price);


        public void AddItem(RateItem item)
        {
            var existingItem = SelectedItems.FirstOrDefault(i => i.Name == item.Name);
            if (existingItem != null)
            {
                existingItem.Quantity++;
                existingItem.Price = existingItem.BasePrice * existingItem.Quantity;
            }
            else
            {
                item.Quantity = 1; // Set the initial quantity to 1
                SelectedItems.Add(item);
            }
            NotifyStateChanged();
        }

        public void RemoveItem(RateItem item)
        {
            SelectedItems.Remove(item);
            NotifyStateChanged();
        }
        public void AddRateItem(RateItem item)
        {
            RateItems.Add(item);
            NotifyStateChanged();
        }

        public void ClearAllItems()
        {
            SelectedItems.Clear();
            NotifyStateChanged();
        }

        public void ClearTotalAmount()
        {
            foreach (var item in SelectedItems)
            {
                item.Price = 0;
            }
            NotifyStateChanged();
        }

        public void UpdateItem(RateItem updatedItem)
        {
            var item = SelectedItems.FirstOrDefault(i => i.Name == updatedItem.Name);
            if (item != null)
            {
                item.Quantity = updatedItem.Quantity;
                item.Price = item.BasePrice * item.Quantity;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;
        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }
}