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
        SelectedItems.Add(item);
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

    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}
