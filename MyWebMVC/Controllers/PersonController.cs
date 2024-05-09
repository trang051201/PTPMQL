using System;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using ptpmql2.Models;

namespace ptpmql2.Controllers 
{    
public class PersonController : Controller
{
    public IActionResult Index() { return View(); }
    [HttpPost]
    public IActionResult Index( Person ps){
        string strOutput = "xin chao" + ps.PersonId + "-" + ps.FullName + "-" + ps.Address;
        ViewBag.infoPerson = strOutput;
        return View();
    }
}
}


