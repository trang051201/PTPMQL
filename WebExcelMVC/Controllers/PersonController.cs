using System;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using WebExcelMVC.Models;

namespace WebExcelMVC.Controllers 
{    
public class PersonController : Controller
{
    public IActionResult Index() { return View(); }
    [HttpPost]
    public IActionResult Index( PersonModel ps){
        string strOutput = "xin chao" + ps.PersonId + "-" + ps.FullName + "-" + ps.Address;
        ViewBag.infoPerson = strOutput;
        return View();
    }
}
}


