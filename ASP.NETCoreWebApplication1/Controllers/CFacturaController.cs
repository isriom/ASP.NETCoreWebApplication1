
using ASP.NETCoreWebApplication1.Controllers.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplication1.Controllers;
[ApiController]
[AllowAnonymous]
[Route("[controller]")]
public class CFacturasController : Controller
{
    private static CFacturasController? _instance;
    Data.Consulta_factura facturap;
    private List<Data.Consulta_factura> Factura = new List<Data.Consulta_factura>();

    public CFacturasController()
    {
        facturap = new Data.Consulta_factura();
        // User.IsInRole("Administrators");
        this.facturap.Cliente = "Felix";
        this.facturap.Numero_de_Factura = 11;
        
    }


    [HttpGet]
    [Route("/{data}")]
    public ActionResult Register(string? data)
    {
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.Consulta_factura>(facturap);
        return Content(jsonstring);
    }

    [HttpGet]
    [Route("/{id:int}")]
    public ActionResult Consult(int? id)
    {
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.Consulta_factura>(facturap);
        return Content(jsonstring);
    }


    [HttpGet]
    [Route("")]
    public ActionResult template()
    {
        facturap = new Data.Consulta_factura();
        User.IsInRole("Administrators");
        this.facturap.Cliente = "Felix";
        this.facturap.Numero_de_Factura = 9;
        
        

        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.Consulta_factura>(facturap);

        return Content(jsonstring);
    }

    [HttpPost]
    [Route("")]
    public ActionResult Insert(string data)
    {
        Console.Out.Write("Prueba");
        Console.Out.Write(data);
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.Consulta_factura>(facturap);
        System.Console.Out.Write("jsonstring:\n");
        System.Console.Out.Write(jsonstring);
        return CreatedAtAction(nameof(Insert), new Data.Consulta_factura());
    }
}