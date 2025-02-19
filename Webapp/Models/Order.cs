using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace homework_7_oscardavila09.Models;

public class Order
{
    public int OrderID{get;set;}
    [Display(Name = "Customer Name")]
    public string CustomerName {get;set;} = string.Empty;
    [Display(Name = "Order Date")]
    [DataType(DataType.Date)]
    public DateTime OrderDate{get;set;}
    [Display(Name = "Products in Order")]
    public List<ProductOrder>? ProductOrders {get;set;} = default!;//navigation property

}