using System;
using System.ComponentModel.DataAnnotations;
namespace WebExcelMVC.Models;

public class PersonModel
{
    public string PersonId { get; set; } = "";
    public string FullName { get; set; } = "";
    public string Address { get; set; } = "";
}
