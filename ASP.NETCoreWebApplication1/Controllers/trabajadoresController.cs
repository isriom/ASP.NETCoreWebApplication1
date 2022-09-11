using ASP.NETCoreWebApplication1.Controllers.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplication1.Controllers;
[ApiController]
[AllowAnonymous]
[Route("[controller]")]


public class trabajadoresController : Controller
{
    private static trabajadoresController? _instance;
    Data.G_trabajadores ejemplo;
    private List<Data.G_trabajadores> Trabajadores = new List<Data.G_trabajadores>();

    public trabajadoresController()
    {
        ejemplo = new Data.G_trabajadores();
        // User.IsInRole("Administrators");
        this.ejemplo.Nombre = "Armando";
        this.ejemplo.Apellidos = "Perez Mora";
        this.ejemplo.Numero_Cedula = 258741028;
        this.ejemplo.Fecha_Ingreso = "25/08/2014";
        this.ejemplo.Fecha_Nacimiento = "7/3/1987";
        this.ejemplo.Edad = 35;
        this.ejemplo.Password = "hdbsajnojds";
        this.ejemplo.Rol = "Mecanico";
    }


    [HttpGet]
    [Route("/{data}")]
    public ActionResult Register(string? data)
    {
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.G_trabajadores>(ejemplo);
        return Content(jsonstring);
    }

    [HttpGet]
    [Route("/{id:int}")]
    public ActionResult Consult(int? id)
    {
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.G_trabajadores>(ejemplo);
        return Content(jsonstring);
    }


    [HttpGet]
    [Route("")]
    public ActionResult template()
    {
        ejemplo = new Data.G_trabajadores();
        User.IsInRole("Administrators");
        this.ejemplo.Nombre = "Arnoldo";
        this.ejemplo.Apellidos = "Perez Mora";
        this.ejemplo.Numero_Cedula = 258741028;
        this.ejemplo.Fecha_Ingreso = "25/08/2014";
        this.ejemplo.Fecha_Nacimiento = "7/3/1987";
        this.ejemplo.Edad = 35;
        this.ejemplo.Password = "hdbsajnojds";
        this.ejemplo.Rol = "Mecanico";
        

        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.G_trabajadores>(ejemplo);

        return Content(jsonstring);
    }

    [HttpPost]
    [Route("")]
    public ActionResult Insert(string data)
    {
        Console.Out.Write("Prueba");
        Console.Out.Write(data);
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.G_trabajadores>(ejemplo);
        System.Console.Out.Write("jsonstring:\n");
        System.Console.Out.Write(jsonstring);
        return CreatedAtAction(nameof(Insert), new Data.G_trabajadores());
    }
}
