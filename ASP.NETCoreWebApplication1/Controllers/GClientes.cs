using ASP.NETCoreWebApplication1.Controllers.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplication1.Controllers;
[ApiController]
[Authorize]
public class GClientesController : Controller
{
    private static GClientesController? _instance;
    Data.G_ClientesVC ejemplo;
    private List<Data.G_ClientesVC> ClientesVC = new List<Data.G_ClientesVC>();

    public GClientesController()
    {
        ejemplo = new Data.G_ClientesVC();
        // User.IsInRole("Administrators");
        this.ejemplo.Nombre_Completo = "Armando";
        this.ejemplo.Correo_electronico = "vcevvbceo@bbgx.com";
        this.ejemplo.Cedula = 321547841;
        this.ejemplo.Direccion1 = "chbljdblkxnl";
        this.ejemplo.Direccion2 = "xasbkjc vjbd";
        this.ejemplo.Telefono_1 = 87452145;
        this.ejemplo.Telefono_2 = 25548782;
        this.ejemplo.Usuario = "armadillo";
        this.ejemplo.Password = "gtndobc852";

    }


    [HttpGet]
    [Route("[controller]/{data}")]
    public ActionResult Register(string? data)
    {
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.G_ClientesVC>(ejemplo);
        return Content(jsonstring);
    }

    [HttpGet]
    [Route("[controller]/{id:int}")]
    public ActionResult Consult(int? id)
    {
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.G_ClientesVC>(ejemplo);
        return Content(jsonstring);
    }


    [HttpGet]
    [Route("[controller]/plantilla")]
    public ActionResult template()
    {
        ejemplo = new Data.G_ClientesVC();
        User.IsInRole("Administrators");
        this.ejemplo.Nombre_Completo = "Armando";
        this.ejemplo.Correo_electronico = "vcevvbceo@bbgx.com";
        this.ejemplo.Cedula = 321547841;
        this.ejemplo.Direccion1 = "chbljdblkxnl";
        this.ejemplo.Direccion2 = "xasbkjc vjbd";
        this.ejemplo.Telefono_1 = 87452145;
        this.ejemplo.Telefono_2 = 25548782;
        this.ejemplo.Usuario = "armadillo";
        this.ejemplo.Password = "gtndobc852";
        

        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.G_ClientesVC>(ejemplo);

        return Content(jsonstring);
    }

    [HttpPost]
    [Route("[controller]/post")]
    public ActionResult Insert(string data)
    {
        Console.Out.Write("Prueba");
        Console.Out.Write(data);
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.G_ClientesVC>(ejemplo);
        System.Console.Out.Write("jsonstring:\n");
        System.Console.Out.Write(jsonstring);
        return CreatedAtAction(nameof(Insert), new Data.G_ClientesVC());
    }
}