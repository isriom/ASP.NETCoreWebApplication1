using System.Text.Json;
using ASP.NETCoreWebApplication1.Controllers.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplication1.Controllers;

[ApiController]
[Authorize]
[Authorize (Roles = "Trabajador")]
public class ClientesController : Controller
{
    
    private Data.G_clientes ejemplo;
    

    public ClientesController()
    {
        
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
        ejemplo = new Data.G_clientes();
        // User.IsInRole("Administrators");
        ejemplo.Nombre_Completo = "Armando";
        ejemplo.Correo_electronico = "vcevvbceo@bbgx.com";
        ejemplo.Cedula = 321547841;
        ejemplo.Direccion_1 = "chbljdblkxnl";
        ejemplo.Direccion_2 = "xasbkjc vjbd";
        ejemplo.Telefono_1 = 87452145;
        ejemplo.Telefono_2 = 25548782;
        ejemplo.Usuario = "armadillo";


        var jsonstring = JsonSerializer.Serialize(ejemplo);

        return Content(jsonstring);
    }

    [HttpPost]
    [Route("[controller]/post")]
    public ActionResult Insert(Data.G_clientes cliente)
    {
        
        DBController.RegistrarTC(cliente);
        Console.Out.Write("Cliente Registrado");
        var jsonstring = JsonSerializer.Serialize(cliente);
        Console.Out.Write(jsonstring + "\n");
        return CreatedAtAction(nameof(Insert), new Data.G_clientes());
    }
}