using ASP.NETCoreWebApplication1.Controllers.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplication1.Controllers;
[ApiController]
[Authorize]
public class ClientesController : Controller
{
    private static ClientesController? _instance;
    Data.G_clientes ejemplo;
    private List<Data.G_clientes> Clientes = new List<Data.G_clientes>();

    public ClientesController()
    {
        ejemplo = new Data.G_clientes();
        // User.IsInRole("Administrators");
        this.ejemplo.Nombre_Completo = "Armando";
        this.ejemplo.Correo_electronico = "vcevvbceo@bbgx.com";
        this.ejemplo.Cedula = 321547841;
        this.ejemplo.Direccion1 = "chbljdblkxnl";
        this.ejemplo.Direccion2 = "xasbkjc vjbd";
        this.ejemplo.Telefono_1 = 87452145;
        this.ejemplo.Telefono_2 = 25548782;
        this.ejemplo.Usuario = "armadillo";
        
    }


    [HttpGet]
    [Route("[controller]/{data}")]
    public ActionResult Register(string? data)
    {
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.G_clientes>(ejemplo);
        return Content(jsonstring);
    }

    [HttpGet]
    [Route("[controller]/{id:int}")]
    public ActionResult Consult(int? id)
    {
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.G_clientes>(ejemplo);
        return Content(jsonstring);
    }


    [HttpGet]
    [Route("[controller]/plantilla")]
    public ActionResult template()
    {
        ejemplo = new Data.G_clientes();
        // User.IsInRole("Administrators");
        this.ejemplo.Nombre_Completo = "Armando";
        this.ejemplo.Correo_electronico = "vcevvbceo@bbgx.com";
        this.ejemplo.Cedula = 321547841;
        this.ejemplo.Direccion1 = "chbljdblkxnl";
        this.ejemplo.Direccion2 = "xasbkjc vjbd";
        this.ejemplo.Telefono_1 = 87452145;
        this.ejemplo.Telefono_2 = 25548782;
        this.ejemplo.Usuario = "armadillo";
        

        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.G_clientes>(ejemplo);

        return Content(jsonstring);
    }

    [HttpPost]
    [Route("[controller]/post")]
    public ActionResult Insert(string data)
    {
        Console.Out.Write("Prueba");
        Console.Out.Write(data);
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.G_clientes>(ejemplo);
        System.Console.Out.Write("jsonstring:\n");
        System.Console.Out.Write(jsonstring);
        return CreatedAtAction(nameof(Insert), new Data.G_clientes());
    }
}