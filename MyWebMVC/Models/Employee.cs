namespace ptpmql2.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class Employee : Person
{
    public int EmployeeId { get; set; } = 0;
    public int EmployeeAge { get; set;} = 0;
}
