using System;
using System.ComponentModel.DataAnnotations;
namespace ptpmql2.Models;

public class Person
{
    public int PersonId { get; set; } = 0;
    public string FullName { get; set; } = "";
    public string Address { get; set; } = "";
}
