using System.Text.Json;
using ASP.NETCoreWebApplication1.Controllers.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplication1.Controllers;

[ApiController]
[Authorize]
[Authorize(Roles = "Cliente")]
public class CFacturasController : Controller
{
    private Data.Consulta_factura facturap;


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
    public ActionResult Insert(Data.Consulta_factura data)
    {
        var file = "";
        if (User.IsInRole("Trabajador"))
        {
            file = "./Facturas/F" + data.Numero_de_Factura + ".pdf";
            Console.Out.Write("Trabajador");
        }
        else
        {
            if (DBController.IsOwner(User.Identity.Name, data.Numero_de_Factura))
            {
                file = "./Facturas/F" + data.Numero_de_Factura + ".pdf";
                Console.Out.Write("Clientes");
                Console.Out.Write(User.Identity.Name);
            }
        }

        if (file == "") return NotFound();

        Response.ContentType = "application/pdfapplication/pdf";
        return File(System.IO.File.ReadAllBytes(file), "application/pdf");
    }
}