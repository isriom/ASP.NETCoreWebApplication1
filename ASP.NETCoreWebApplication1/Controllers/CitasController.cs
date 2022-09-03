using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASP.NETCoreWebApplication1.Controllers;

public class cita
{
    public string? Cliente { get; set; }
    public int? placa { get; set; }
    public string? sucursal { get; set; }
    public string? servicio { get; set; }
}

[ApiController]
[Route("[controller]")]
public class CitasController : Controller
{
    cita prueba = new cita();

    public CitasController()
    {
        this.prueba.Cliente = "Cliente de prueba";
        this.prueba.placa = 1115486;
        this.prueba.sucursal = "Sucursal de prueba";
        this.prueba.servicio = "Servicio de prueba";
    }

    [HttpGet]
    [Route("/{data}")]
    public ActionResult Register(string? data)
    {
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<cita>(prueba);
        return Content(jsonstring);
    }

    [HttpGet]
    [Route("/{id:int}")]
    public ActionResult Consult(int? id)
    {
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<cita>(prueba);
        return Content(jsonstring);
    }


    [HttpGet]
    [Route("")]
    public ActionResult See()
    {
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<cita>(prueba);
        return Content(jsonstring);
    }
}