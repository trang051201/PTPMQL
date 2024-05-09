using System;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace ptpmql2.Controllers 
{    
public class HelloWorldController : Controller
{
    public string Index() { return "This action"; }
    public string Welcome() {return "This action method"; }
}
}

