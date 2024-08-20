using Bill_Generate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bill_Generate.Services
{
    public class BillService
    {
        public List<RateList.RateItem> SelectedItems { get; private set; } = new List<RateList.RateItem>();

        public decimal TotalAmount => SelectedItems.Sum(item => item.Price);

        public event Action? OnChange;

        public void AddItem(RateList.RateItem item)
        {
            var existingItem = SelectedItems.FirstOrDefault(i => i.Name == item.Name);
            if (existingItem != null)
            {
                existingItem.Quantity++;
                existingItem.Price = existingItem.BasePrice * existingItem.Quantity;
            }
            else
            {
                item.BasePrice = item.Price; // Store the original price as BasePrice
                item.Quantity = 1; // Set the initial quantity to 1
                SelectedItems.Add(item);
            }
            NotifyStateChanged();
        }

        public void RemoveItem(RateList.RateItem item)
        {
            SelectedItems.Remove(item);
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

        public void UpdateItem(RateList.RateItem updatedItem)
        {
            var item = SelectedItems.FirstOrDefault(i => i.Name == updatedItem.Name);
            if (item != null)
            {
                item.Quantity = updatedItem.Quantity;
                item.Price = item.BasePrice * item.Quantity;
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }
}
