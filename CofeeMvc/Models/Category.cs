
using System.ComponentModel.DataAnnotations;
using CofeeMvc.Models.Base;

namespace CofeeMvc.Models;

public class Category:BaseEntity
{
    [Microsoft.Build.Framework.Required,StringLength(10,ErrorMessage = "category namein uzunluqu en cox 10 ola biler"),
    MinLength( 3,ErrorMessage = "category namein uzunlugu en az 3 ola biler")]
    public string Name { get; set; }
    public List<Product>? Products { get; set; }
}