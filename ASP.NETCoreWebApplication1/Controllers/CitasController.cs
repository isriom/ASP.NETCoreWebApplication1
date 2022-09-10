using ASP.NETCoreWebApplication1.Controllers.DB;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASP.NETCoreWebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class CitasController : Controller
{
    private static CitasController instance = null;
    Data.cita prueba = new Data.cita();
    private Data.cita[] Citas = null;

    public CitasController()
    {
        if (CitasController.instance != null)
        {
            this.prueba = CitasController.instance.prueba;
        }
        else
        {
            this.prueba.Cliente = "Cliente de prueba";
            this.prueba.placa = 1115486;
            this.prueba.sucursal = "Sucursal de prueba";
            this.prueba.servicio = "Servicio de prueba";
        }
    }


    [HttpGet]
    [Route("/{data}")]
    public ActionResult Register(string? data)
    {
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.cita>(prueba);
        return Content(jsonstring);
    }

    [HttpGet]
    [Route("/{id:int}")]
    public ActionResult Consult(int? id)
    {
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.cita>(prueba);
        return Content(jsonstring);
    }


    [HttpGet]
    [Route("")]
    public ActionResult See()
    {
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.cita>(prueba);
        return Content(jsonstring);
    }
    
    [HttpPost]
    [Route("")]
    public ActionResult Insert(Data.cita data)
    {
        Console.Out.Write("Prueba");
        Console.Out.Write(data);
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.cita>(prueba);
        return CreatedAtAction(nameof(Insert),new Data.cita());
    }
}