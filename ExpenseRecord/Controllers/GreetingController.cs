using Microsoft.AspNetCore.Mvc;

namespace Expense.Controllers;

[ApiController]
[Route("[controller]")]
public class GreetingController : ControllerBase
{
    [HttpGet]
    public string greet(string name)
    {
        Console.Out.WriteLine(name);
        return "Hello, " + name;
    }
}