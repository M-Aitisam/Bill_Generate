using Bill_Generate.Pages;

public class BillService
{
    public List<RateList.RateItem> SelectedItems { get; private set; } = new List<RateList.RateItem>();

    // Calculate the total amount by summing up the prices of selected items
    public decimal TotalAmount => SelectedItems.Sum(item => item.Price);

    public event Action? OnChange;

    public void AddItem(RateList.RateItem item)
    {
        if (!SelectedItems.Any(i => i.Name == item.Name))
        {
            item.BasePrice = item.Price; // Store the original price as BasePrice
            item.Quantity = 1; // Set the initial quantity to 1
            SelectedItems.Add(item);
        }
        else
        {
            IncrementItemQuantity(item);
        }
        NotifyStateChanged();
    }

    public void IncrementItemQuantity(RateList.RateItem item)
    {
        var selectedItem = SelectedItems.FirstOrDefault(i => i.Name == item.Name);
        if (selectedItem != null)
        {
            selectedItem.Quantity++;
            selectedItem.Price = selectedItem.BasePrice * selectedItem.Quantity;
            NotifyStateChanged();
        }
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
