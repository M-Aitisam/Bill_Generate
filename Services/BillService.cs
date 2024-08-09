using Bill_Generate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;

public class BillService
{
    public List<RateList.RateItem> SelectedItems { get; private set; } = new List<RateList.RateItem>();
    public decimal TotalAmount => SelectedItems.Sum(item => item.Price);

    public event Action? OnChange;

    public void AddItem(RateList.RateItem item)
    {
        if (!SelectedItems.Any(i => i.Name == item.Name)) // Check if item already exists
        {
            item.BasePrice = item.Price; // Store the original price as BasePrice
            SelectedItems.Add(item);
            NotifyStateChanged();
        }
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

    public void UpdateItem(RateList.RateItem updatedItem)
    {
        var item = SelectedItems.FirstOrDefault(i => i.Name == updatedItem.Name);
        if (item != null)
        {
            item.Quantity = updatedItem.Quantity;
            item.Price = updatedItem.BasePrice * updatedItem.Quantity; // Calculate price as BasePrice * Quantity
            NotifyStateChanged();
        }
    }

    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}
