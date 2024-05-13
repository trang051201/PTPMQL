using System;
using System.ComponentModel.DataAnnotations;
namespace ptpmql2.Models;

public class Person
{
    public string PersonId { get; set; } = "";
    public string FullName { get; set; } = "";
    public string Address { get; set; } = "";
}
