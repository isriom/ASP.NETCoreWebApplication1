using System.Text.Json;
using ASP.NETCoreWebApplication1.Controllers.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplication1.Controllers;

[ApiController]
[Authorize]
public class trabajadoresController : Controller
{
    private static trabajadoresController? _instance;
    private Data.G_trabajadores ejemplo;
    private List<Data.G_trabajadores> Trabajadores = new();

    public trabajadoresController()
    {
        ejemplo = new Data.G_trabajadores();
        // User.IsInRole("Administrators");
        ejemplo.Nombre = "Armando";
        ejemplo.Apellidos = "Perez Mora";
        ejemplo.Numero_Cedula = 258741028;
        ejemplo.Fecha_Ingreso = "25/08/2014";
        ejemplo.Fecha_Nacimiento = "7/3/1987";
        ejemplo.Edad = 35;
        ejemplo.Password = "hdbsajnojds";
        ejemplo.Rol = "Mecanico";
    }


    [HttpGet]
    [Route("[controller]/{data}")]
    public ActionResult Register(string? data)
    {
        var jsonstring = JsonSerializer.Serialize(ejemplo);
        return Content(jsonstring);
    }

    [HttpGet]
    [Route("[controller]/{id:int}")]
    public ActionResult Consult(int? id)
    {
        var jsonstring = JsonSerializer.Serialize(ejemplo);
        return Content(jsonstring);
    }


    [HttpGet]
    [Route("[controller]/plantilla")]
    public ActionResult template()
    {
        ejemplo = new Data.G_trabajadores();
        User.IsInRole("Administrators");
        ejemplo.Nombre = "Arnoldo";
        ejemplo.Apellidos = "Perez Mora";
        ejemplo.Numero_Cedula = 258741028;
        ejemplo.Fecha_Ingreso = "25/08/2014";
        ejemplo.Fecha_Nacimiento = "7/3/1987";
        ejemplo.Edad = 35;
        ejemplo.Password = "hdbsajnojds";
        ejemplo.Rol = "Mecanico";


        var jsonstring = JsonSerializer.Serialize(ejemplo);

        return Content(jsonstring);
    }

    [HttpPost]
    [Route("[controller]/post")]
    public ActionResult Insert(string data)
    {
        Console.Out.Write("Prueba");
        Console.Out.Write(data);
        var jsonstring = JsonSerializer.Serialize(ejemplo);
        Console.Out.Write("jsonstring:\n");
        Console.Out.Write(jsonstring);
        return CreatedAtAction(nameof(Insert), new Data.G_trabajadores());
    }
}