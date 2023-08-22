// See https://aka.ms/new-console-template for more information
List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Football",
        Color= "brown",
        Price = 15.00M,
        StockDate = new DateTime(2022, 10, 20),
        ManufactureYear = 2010,
        Condition = 4.2
    },
    new Product()
    {
        Name = "Hockey Stick",
        Color = "yellow",
        Price = 12.50M,
        StockDate = new DateTime(2021, 05, 23),
        ManufactureYear = 2019,
        Condition = 3.2
    },
    new Product()
    {
        Name = "Boomerang",
        Color = "red",
        Price = 10.25M,
        StockDate = new DateTime(2023, 07, 26),
        SoldOnDate = new DateTime(2023, 08, 01),
        ManufactureYear = 2021,
        Condition = 3.7
    },
    new Product()
    {
        Name = "Basketball",
        Color = "orange",
        Price = 15.50M,
        StockDate = new DateTime(2023, 06, 01),
        ManufactureYear = 2022,
        Condition = 3.8
    },
    new Product()
    {
        Name = "Frisbee",
        Color = "maroon",
        Price = 10.25M,
        StockDate = new DateTime(2022, 08, 11),
        SoldOnDate = new DateTime(2023, 08, 02),
        ManufactureYear = 2022,
        Condition = 4.7
    },
    new Product()
    {
        Name = "Golf Club",
        Color = "silver",
        Price = 20.75M,
        StockDate = new DateTime(2020, 05, 10),
        ManufactureYear = 2019,
        Condition = 3.5
    },
    new Product()
    {
        Name = "Hulahoop",
        Color = "multi-colored",
        Price = 8.50M,
        StockDate = new DateTime(2021, 02, 25),
        ManufactureYear = 2020,
        Condition = 2.8
    }
};

string greeting = @"Welcome to Thrown for a Loop!
Your one-stop shop for used sporting equipment";

Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
    0. Exit
    1. View All Products
    2. View Product Details
    3. View Latest Products");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListProducts();
    }
    else if (choice == "2")
    {
        ViewProductDetails();
    }
    else if (choice == "3")
    {
        ViewLatestProducts();
    }
}

void ViewProductDetails()
{
    ListProducts();

    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }
    }

    DateTime now = DateTime.Now;

    TimeSpan timeInStock = now - chosenProduct.StockDate;

    Console.WriteLine(@$"You chose: {ProductDetails(chosenProduct)}");


    // A {chosenProduct.Color} {chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
    // It is {now.Year - chosenProduct.ManufactureYear} years old. 
    // It's condition is rated at {chosenProduct.Condition} out of 5. 
    // It {(chosenProduct.SoldOnDate != null ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}");
}

void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (product.SoldOnDate != null)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewLatestProducts()
{
    // create a new empty List to store the latest products
    List<Product> latestProducts = new List<Product>();
    // Calculate a DateTime 90 days in the past
    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
    // loop through the products
    foreach (Product product in products)
    {
        // add a product to latest products if it fits the criteria
        if (product.StockDate > threeMonthsAgo && product.SoldOnDate != null)
        {
            latestProducts.Add(product);
        }
    }
    // print out the latest products to console
    for (int i = 0; i < latestProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
    }
}

string ProductDetails(Product product)
{
    string productString = @$"A {product.Color} {product.Name}, which costs {product.Price} dollars. It's condition is rated at {product.Condition} out of 5. It {(product.SoldOnDate != null ? "sold" : "is available")} for ${product.Price}. It has spent {product.TimeInStock} days in stock.";

    return productString;
}

// void MonthlySalesReport() // Explorer - need help!!!!
// {
//     Console.WriteLine(@"Welcome to the Monthly Sales Report Builder
//     Please enter a 4-digit year");
//     int userYear = int.Parse(Console.ReadLine());
//     Console.WriteLine("Please enter a 2-digit month");
//     int userMonth = int.Parse(Console.ReadLine());

//     List<Product> userProducts = products.Where(p => p.SoldOnDate = new DateTime(2023, 08, 31) && < new DateTime(2023, 09, 01));
// }