using System.Text.Json;
using ASP.NETCoreWebApplication1.Controllers.DB;
using ASP.NETCoreWebApplication1.Controllers.DB.Facturas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplication1.Controllers;
/**
 * Permisos del api para el tema de autorizaciones
 */
[ApiController]
[Authorize]
[Authorize(Roles = "Cliente")]

/*
 * Clase Controladora del componente de las Citas para la vista del Cliente
 */
public class RCitasController : Controller
{
    //Variable de estructura
    private Data.cita prueba;


    /**
     * Metodo que define una accion resultante
     */
    [HttpGet]
    [Route("[controller]/{data}")]
    public ActionResult Register(string? data)
    {
        var jsonstring = JsonSerializer.Serialize(prueba);
        return Content(jsonstring);
    }

    /**
     * Metodo que define una accion resultante
     */
    [HttpGet]
    [Route("[controller]/{id:int}")]
    public ActionResult Consult(int? id)
    {
        var jsonstring = JsonSerializer.Serialize(prueba);
        return Content(jsonstring);
    }


    /**
     * Metodo que define una accion resultante que define y comprueba la estructura que se debe ingresar siendo una platilla
     */
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

    /**
     * Metodo donde se define la logica de la accion que realiza el boton de Add para poder crear el PDF y registrar la cita
     */
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