using System.Text.Json;
using ASP.NETCoreWebApplication1.Controllers.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplication1.Controllers;

[ApiController]
[Authorize]
public class GClientesController : Controller
{
    private static GClientesController? _instance;
    private List<Data.G_ClientesVC> ClientesVC = new();
    private Data.G_ClientesVC ejemplo;

    public GClientesController()
    {
        ejemplo = new Data.G_ClientesVC();
        // User.IsInRole("Administrators");
        ejemplo.Nombre_Completo = "Armando";
        ejemplo.Correo_electronico = "vcevvbceo@bbgx.com";
        ejemplo.Cedula = 321547841;
        ejemplo.Direccion_1 = "chbljdblkxnl";
        ejemplo.Direccion_2 = "xasbkjc vjbd";
        ejemplo.Telefono_1 = 87452145;
        ejemplo.Telefono_2 = 25548782;
        ejemplo.Usuario = "armadillo";
        ejemplo.Password = "gtndobc852";
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
        ejemplo = new Data.G_ClientesVC();
        User.IsInRole("Administrators");
        ejemplo.Nombre_Completo = "Armando";
        ejemplo.Correo_electronico = "vcevvbceo@bbgx.com";
        ejemplo.Cedula = 321547841;
        ejemplo.Direccion_1 = "chbljdblkxnl";
        ejemplo.Direccion_2 = "xasbkjc vjbd";
        ejemplo.Telefono_1 = 87452145;
        ejemplo.Telefono_2 = 25548782;
        ejemplo.Usuario = "armadillo";
        ejemplo.Password = "gtndobc852";


        var jsonstring = JsonSerializer.Serialize(ejemplo);

        return Content(jsonstring);
    }

    [HttpPost]
    [Route("[controller]/post")]
    public ActionResult Insert(Data.G_ClientesVC data)
    {
        Console.Out.Write("Prueba");
        Console.Out.Write(data);
        var jsonstring = JsonSerializer.Serialize(ejemplo);
        Console.Out.Write("jsonstring:\n");
        Console.Out.Write(jsonstring);
        return CreatedAtAction(nameof(Insert), new Data.G_ClientesVC());
    }
}