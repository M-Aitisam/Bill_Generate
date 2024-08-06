using Bill_Generate.Pages;

public class BillService
{
    private List<RateList.RateItem> _selectedItems = new List<RateList.RateItem>();

    public IReadOnlyList<RateList.RateItem> SelectedItems => _selectedItems.AsReadOnly();

    public void AddItem(RateList.RateItem item)
    {
        var existingItem = _selectedItems.FirstOrDefault(i => i.Name == item.Name);
        if (existingItem == null)
        {
            _selectedItems.Add(item);
        }
        else
        {
            existingItem.Price = item.Price; // Optionally update the price
        }
    }

    public void RemoveItem(RateList.RateItem item)
    {
        _selectedItems.Remove(item);
    }

    public decimal TotalAmount => _selectedItems.Sum(item => item.Price);

    public void LoadItems(List<RateList.RateItem> items)
    {
        _selectedItems = items ?? new List<RateList.RateItem>();
    }

    public void ClearItems()
    {
        _selectedItems.Clear();
    }
}
