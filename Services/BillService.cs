using Bill_Generate.Pages;
using System.Collections.Generic;
using System.Linq;

public class BillService
{
    public List<RateList.RateItem> SelectedItems { get; private set; } = new List<RateList.RateItem>();

    public void AddItem(RateList.RateItem item)
    {
        SelectedItems.Add(item);
    }

    public void RemoveItem(RateList.RateItem item)
    {
        SelectedItems.Remove(item);
    }

    public decimal TotalAmount => SelectedItems.Sum(item => item.Price);
}
