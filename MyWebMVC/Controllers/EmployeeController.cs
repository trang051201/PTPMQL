using System;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace ptpmql2.Controllers 
{    
public class EmployeeController : Controller
{
    public IActionResult Index() { return View(); }
}
}
