using System.Text.Json;
using ASP.NETCoreWebApplication1.Controllers.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplication1.Controllers;

[ApiController]
[Authorize]
public class CFacturasController : Controller
{
    private static CFacturasController? _instance;
    private List<Data.Consulta_factura> Factura = new();
    private Data.Consulta_factura facturap;

    public CFacturasController()
    {
        facturap = new Data.Consulta_factura();
        // User.IsInRole("Administrators");
        facturap.Cliente = "Felix";
        facturap.Numero_de_Factura = 11;
    }


    [HttpGet]
    [Route("[controller]/{data}")]
    public ActionResult Register(string? data)
    {
        var jsonstring = JsonSerializer.Serialize(facturap);
        return Content(jsonstring);
    }

    [HttpGet]
    [Route("[controller]/{id:int}")]
    public ActionResult Consult(int? id)
    {
        var jsonstring = JsonSerializer.Serialize(facturap);
        return Content(jsonstring);
    }


    [HttpGet]
    [Route("[controller]/plantilla")]
    public ActionResult template()
    {
        facturap = new Data.Consulta_factura();
        // User.IsInRole("Administrators");
        facturap.Cliente = "Felix";
        facturap.Numero_de_Factura = 9;


        var jsonstring = JsonSerializer.Serialize(facturap);

        return Content(jsonstring);
    }

    [HttpPost]
    [Route("[controller]/post")]
    public ActionResult Insert(string data)
    {
        Console.Out.Write("Prueba");
        Console.Out.Write(data);
        var jsonstring = JsonSerializer.Serialize(facturap);
        Console.Out.Write("jsonstring:\n");
        Console.Out.Write(jsonstring);
        return CreatedAtAction(nameof(Insert), new Data.Consulta_factura());
    }
}