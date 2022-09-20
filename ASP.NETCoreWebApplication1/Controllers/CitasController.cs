using System.Text.Json;
using ASP.NETCoreWebApplication1.Controllers.DB;
using ASP.NETCoreWebApplication1.Controllers.DB.Facturas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplication1.Controllers;

[ApiController]
[Authorize]
[Authorize(Roles = "Trabajador")]
public class CitasController : Controller
{
    private Data.cita prueba;


    [HttpGet]
    [Route("[controller]/{data}")]
    public ActionResult Register(string? data)
    {
        var jsonstring = JsonSerializer.Serialize(prueba);
        return Content(jsonstring);
    }

    [HttpGet]
    [Route("[controller]/{id:int}")]
    public ActionResult Consult(int? id)
    {
        var jsonstring = JsonSerializer.Serialize(prueba);
        return Content(jsonstring);
    }


    [HttpGet]
    [Route("[controller]/plantilla")]
    public ActionResult template()
    {
        prueba = new Data.cita();
        User.IsInRole("Administrators");
        prueba.Cliente = "Cliente de prueba";
        prueba.Placa_del_Vehiculo = 1115486;
        prueba.Sucursal = "Sucursal de prueba";
        prueba.Servicio_solicitado = "Servicio de prueba";


        var jsonstring = JsonSerializer.Serialize(prueba);

        return Content(jsonstring);
    }

    [HttpPost]
    [Route("[controller]/post")]
    public ActionResult Insert(Data.cita cita)
    {
        Console.Out.Write("Creando el pdf");
        var numeroF = PDFHandler.FacturaCita(cita);
        DBController.RegistrarCitayFactura(cita, Convert.ToDouble(numeroF));
        return CreatedAtAction(nameof(Insert), numeroF);
    }
}