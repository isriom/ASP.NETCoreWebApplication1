using System.Text.Json;
using ASP.NETCoreWebApplication1.Controllers.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplication1.Controllers;

[ApiController]
[Authorize]
public class RCitasController : Controller
{
    private static RCitasController? _instance;
    private List<Data.cita> Citas = new();
    private Data.cita prueba;

    public RCitasController()
    {
        prueba = new Data.cita();
        // User.IsInRole("Administrators");
        prueba.Cliente = "Cliente de prueba";
        prueba.Placa_del_Vehiculo = 1115486;
        prueba.Sucursal = "Sucursal de prueba";
        prueba.Servicio_solicitado = "Servicio de prueba";
    }


    [HttpGet]
    [Route("[controller]/{data}")]
    public ActionResult Register(string? data)
    {
        var jsonstring = JsonSerializer.Serialize(prueba);
        return Content(jsonstring);
    }

    [HttpGet]
    [Route("[controller]/{id:int}")]
    public ActionResult Consult(int? id)
    {
        var jsonstring = JsonSerializer.Serialize(prueba);
        return Content(jsonstring);
    }


    [HttpGet]
    [Route("[controller]/plantilla")]
    public ActionResult template()
    {
        prueba = new Data.cita();
        User.IsInRole("Administrators");
        prueba.Cliente = "Cliente de prueba";
        prueba.Placa_del_Vehiculo = 1115486;
        prueba.Sucursal = "Sucursal de prueba";
        prueba.Servicio_solicitado = "Servicio de prueba";


        var jsonstring = JsonSerializer.Serialize(prueba);

        return Content(jsonstring);
    }

    [HttpPost]
    [Route("[controller]/post")]
    public ActionResult Insert(string data)
    {
        Console.Out.Write("Prueba");
        Console.Out.Write(data);
        var jsonstring = JsonSerializer.Serialize(prueba);
        Console.Out.Write("jsonstring:\n");
        Console.Out.Write(jsonstring);
        return CreatedAtAction(nameof(Insert), new Data.cita());
    }
}