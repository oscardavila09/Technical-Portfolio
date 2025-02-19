using System.Data;
using System.Data.Common;
using System.Formats.Asn1;
using Homework4.Models;
using Microsoft.Extensions.DependencyModel.Resolution;



using var db = new AppDbContext();

//making a list of products and adding them to the database
List<Product> listOfProducts = new List<Product>
{
new Product {Name = "MindSync", Description = "Neural Implant Device", Price = 1995.99},
new Product {Name = "Seraphine", Description = "AI Assistant", Price = 200.00},
new Product {Name = "SoulSear", Description = "Military Grade Death Ray", Price = 4300000000.00},
new Product {Name = "PhantomClaw", Description = "High Quality Gaming Mouse", Price = 99.95},
};
db.AddRange(listOfProducts);
db.SaveChanges();

//outputting what we have in our current database
foreach(Product p in listOfProducts)
{
    Console.WriteLine(p);
}


string? answer;
Console.WriteLine("(A)dd a product, (U)pdate a product, (R)emove a product, (L)ist all products");
answer= Console.ReadLine();
if(answer == "A" || answer =="a")
{
    Console.WriteLine("Enter a name for the new product:");
    string nameOfProduct = Console.ReadLine()!;
    Console.WriteLine("Enter a description:");
    string descriptionOfProduct = Console.ReadLine()!;
    Console.WriteLine("Enter price:");
    double priceOfProduct = Convert.ToDouble(Console.ReadLine());
    Product newProduct = new Product{Name = nameOfProduct,Description= descriptionOfProduct,Price = priceOfProduct};
    db.Add(newProduct);
    db.SaveChanges();
}
else if (answer == "L" || answer =="l")
{
    foreach (Product s in db.Products)
        {
            Console.WriteLine(s);
        }
}
else if(answer == "U" || answer == "u")
{
    Console.WriteLine("Enter the Product ID to update:");
    int updateId = Convert.ToInt32(Console.ReadLine())!;
    Console.WriteLine($"{db.Products.Find(updateId)}");
    
}
