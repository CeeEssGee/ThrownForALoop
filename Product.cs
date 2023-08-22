public class Product
{
    public string Name { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
    // public bool Sold { get; set; } // changed per Explorer chapter
    public DateTime? SoldOnDate { get; set; } // Explorer - ? makes it nullable
    public DateTime StockDate { get; set; }
    public int ManufactureYear { get; set; }
    public double Condition { get; set; }

    // public TimeSpan TimeInStock
    // {
    //     get
    //     {
    //         DateTime lastDay;
    //         if (SoldOnDate != null)
    //         {
    //             lastDay = (DateTime)SoldOnDate; // convert SoldOnDate to DateTime because DateTime? is not the same type
    //         }
    //         else
    //         {
    //             lastDay = DateTime.Now;
    //         }
    //         return lastDay - StockDate;
    //     }
    // }

    public TimeSpan TimeInStock
    {
        get
        {
            DateTime lastDay = SoldOnDate != null ? (DateTime)SoldOnDate : DateTime.Now;
            return lastDay - StockDate;
        }
    }
}