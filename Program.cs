// See https://aka.ms/new-console-template for more information
List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Football",
        Color= "brown",
        Price = 15,
        Sold = false
    },
    new Product()
    {
        Name = "Hockey Stick",
        Color = "yellow",
        Price = 12,
        Sold = false
    },
    new Product()
    {
        Name = "Boomerang",
        Color = "red",
        Price = 10,
        Sold = false
    },
    new Product()
    {
        Name = "Basketball",
        Color = "orange",
        Price = 15,
        Sold = false
    },
    new Product()
    {
        Name = "Frisbee",
        Color = "maroon",
        Price = 10,
        Sold = false
    },
    new Product()
    {
        Name = "Golf Club",
        Color = "silver",
        Price = 20,
        Sold = false
    },
    new Product()
    {
        Name = "Hulahoop",
        Color = "multi-colored",
        Price = 8,
        Sold = false
    }
};

string greeting = @"Welcome to Thrown for a Loop!
Your one-stop shop for used sporting equipment";

Console.WriteLine(greeting);

Console.WriteLine("Products:");
for (int i = 0; i < products.Count; i++)
{
    Console.WriteLine($"{i + 1}. {products[i].Name}");
}

Console.WriteLine("Please enter a product number: ");

int response = int.Parse(Console.ReadLine().Trim());

while (response > products.Count || response < 1)
{
    Console.WriteLine("Choose a number between 1 and 5!");
    response = int.Parse(Console.ReadLine().Trim());
}

Product chosenProduct = products[response - 1];
Console.WriteLine($"You chose: A {chosenProduct.Color} {chosenProduct.Name}, which costs {chosenProduct.Price} dollars and is {(chosenProduct.Sold ? "" : "not ")}sold.");
