using System;
using System.ComponentModel.DataAnnotations;
namespace ptpmql2.Models;

public class Movie
{
    public int Id { get; set; }
    public String? Title { get; set; }
    [DataType(DataType.Date)]
    
    public DateTime? ReleaseDate { get; set;}
    public string? Genre { get; set; }
    public decimal Plice { get; set; }
}
