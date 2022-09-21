using System.Text.Json;
using ASP.NETCoreWebApplication1.Controllers.DB;
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
 * Clase Controladora del componente de los Clientes desde la parte del Cliente
 */
public class GClientesController : Controller
{
    //Variarible de estructura
    private Data.G_ClientesVC ejemplo;


    /**
     * Metodo que define una accion resultante
     */
    [HttpGet]
    [Route("[controller]/{data}")]
    public ActionResult Register(string? data)
    {
        var jsonstring = JsonSerializer.Serialize(ejemplo);
        return Content(jsonstring);
    }

    /**
     * Metodo que define una accion resultante
     */
    [HttpGet]
    [Route("[controller]/{id:int}")]
    public ActionResult Consult(int? id)
    {
        var jsonstring = JsonSerializer.Serialize(ejemplo);
        return Content(jsonstring);
    }


    /**
     * Metodo que define una accion resultante que define y comprueba la estructura que se debe ingresar siendo una platilla
     */
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

    /**
     * Metodo donde se define la logica de la accion que realiza el boton de Add para poder registrar el cliente
     */
    [HttpPost]
    [Route("[controller]/post")]
    public ActionResult Insert(Data.G_ClientesVC cliente)
    {
        Console.Out.Write("Cliente Registrado");
        DBController.RegistrarCC(cliente);
        return CreatedAtAction(nameof(Insert), new Data.G_ClientesVC());
    }
}