using System.Security.Claims;
using System.Text.Json;
using ASP.NETCoreWebApplication1.Controllers.DB;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplication1.Controllers;

[ApiController]

/*
 * Clase Controladora del componente del Login de la Pagina
 */
public class loginController : Controller
{
    // Variable de estructura
    public Data.loginUser template = new();

    /**
     * Metodo donde se define una plantilla de verificacion
     */
    [AllowAnonymous]
    [HttpGet]
    [Route("login/plantilla")]
    public ActionResult plantilla(string? data)
    {
        template.Contraseña = null;
        template.Usuario = null;
        var jsonstring = JsonSerializer.Serialize(template);
        return Content(jsonstring);
    }

    /**
     * Metodo donde se realiza la autorizacion de los usuarios cuando se presiona el boton de Sign In
     */
    [AllowAnonymous]
    [HttpPut]
    [Route("/login/Singin")]
    public async Task<ActionResult> login(Data.loginUser data)
    {
        Console.Out.Write("data\n");
        var rol = await AuthenticateUser(data.Usuario, data.Contraseña);
        Console.Out.Write(JsonSerializer.Serialize(data));
        var aut = false;
        if (rol == "No Found")
        {
            aut = false;
            Console.Out.Write("No found");
        }
        else
        {
            aut = true;
        }

        if (aut)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, data.Usuario),
                new(ClaimTypes.Role, rol)
            };
            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimIdentity), new AuthenticationProperties
                {
                    IsPersistent = false,
                    RedirectUri = "", AllowRefresh = false
                });

            Console.Out.Write(JsonSerializer.Serialize(
                HttpContext.Request.Cookies));
            return Content(JsonSerializer.Serialize(
                claims[1].Value)
            );
        }

        return NotFound(data);
    }

    /**
     * Metodo que realiza la autenticacion del usuario 
     */
    private async Task<string> AuthenticateUser(string id, string password)
    {
        //Implementar codigo para revisar base de datos
        var role = DBController.FoundUser(id, password);
        return role;
    }

    /**
     * Metodo que determina la accion al presionar el boton de Log Out 
     */
    [AllowAnonymous]
    [HttpPut]
    [Route("/logout")]
    public async Task<ActionResult> logout(Data.loginUser? data)
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if (HttpContext.Request.Cookies.ContainsKey(".AspNetCore.Cookies"))
            HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");

        Console.Out.Write("Log out");
        return Content(JsonSerializer.Serialize(
            template));
    }
}