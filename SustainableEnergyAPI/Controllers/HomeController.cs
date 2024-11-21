using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Content("Bem-vindo à API SustainableEnergyAPI! Acesse /swagger para a documentação.");
    }
}
