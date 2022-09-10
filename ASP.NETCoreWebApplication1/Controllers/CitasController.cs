using ASP.NETCoreWebApplication1.Controllers.DB;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class CitasController : Controller
{
    private static CitasController? _instance;
    Data.cita prueba = new Data.cita();
    private List<Data.cita> Citas = new List<Data.cita>();

    public CitasController()
    {
        User.IsInRole("Administrators");
        if (CitasController._instance != null)
        {
            this.prueba = CitasController._instance.prueba;
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
        System.Console.Out.Write("jsonstring:");
        System.Console.Out.Write(jsonstring);

        return Content(jsonstring);
    }

    [HttpPost]
    [Route("")]
    public ActionResult Insert(Data.cita data)
    {
        Console.Out.Write("Prueba");
        Console.Out.Write(data);
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.cita>(prueba);
        return CreatedAtAction(nameof(Insert), new Data.cita());
    }
}