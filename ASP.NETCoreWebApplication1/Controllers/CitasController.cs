using ASP.NETCoreWebApplication1.Controllers.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplication1.Controllers;

[ApiController]
[AllowAnonymous]
[Route("[controller]")]
public class CitasController : Controller
{
    private static CitasController? _instance;
    Data.cita prueba;
    private List<Data.cita> Citas = new List<Data.cita>();

    public CitasController()
    {
        prueba = new Data.cita();
        // User.IsInRole("Administrators");
        this.prueba.Cliente = "Cliente de prueba";
        this.prueba.Placa_del_Vehiculo = 1115486;
        this.prueba.Sucursal = "Sucursal de prueba";
        this.prueba.Servicio_solicitado = "Servicio de prueba";
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
    public ActionResult template()
    {
        prueba = new Data.cita();
        User.IsInRole("Administrators");
        this.prueba.Cliente = "Cliente de prueba";
        this.prueba.Placa_del_Vehiculo = 1115486;
        this.prueba.Sucursal = "Sucursal de prueba";
        this.prueba.Servicio_solicitado = "Servicio de prueba";
        

        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.cita>(prueba);

        return Content(jsonstring);
    }

    [HttpPost]
    [Route("")]
    public ActionResult Insert(Data.cita cita)
    {
        Console.Out.Write("Prueba");
        Console.Out.Write(cita+"\n");
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.cita>(cita);
        return CreatedAtAction(nameof(Insert), cita);
    }
}