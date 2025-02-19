using System.ComponentModel.DataAnnotations;

namespace homework_7_oscardavila09.Models;

public class Product
{
    public int ProductID{get;set;}
    public string Name {get;set;}= string.Empty;
    public string Description{get;set;} = string.Empty;
    [DataType(DataType.Currency)]
    public decimal Price{get;set;}
    public List<ProductOrder>? ProductOrders {get;set;} = default!;//navigation property
}

public class ProductOrder
{
    public int OrderID {get;set;}
    public int ProductID{get;set;}
    public Order Order{get;set;} = default!;
    public Product Product{get;set;} = default!;
}

