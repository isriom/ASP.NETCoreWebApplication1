using System.Net;
using System.Security.Claims;
using System.Text.Json;
using ASP.NETCoreWebApplication1.Controllers.DB;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplication1.Controllers;

[ApiController]
public class loginController : Controller
{
    public Data.loginUser template = new Data.loginUser();

    [AllowAnonymous]
    [HttpGet]
    [Route("login/plantilla")]
    public ActionResult plantilla(string? data)
    {
        this.template.Contraseña = null;
        this.template.Usuario = null;
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.loginUser>(template);
        return Content(jsonstring);
    }

    [AllowAnonymous]
    [HttpPut]
    [Route("/login/Singin")]
    public async Task<ActionResult> login(Data.loginUser data)
    {
        Console.Out.Write("data\n");
        var aut = await AuthenticateUser(data.Usuario, data.Usuario);
        Console.Out.Write(data);

        if (aut)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, data.Usuario),
                new Claim(ClaimTypes.Role, "Trabajador"),
            };
            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimIdentity), new AuthenticationProperties()
                {
                    IsPersistent = true,
                });
            Console.Out.Write(System.Text.Json.JsonSerializer.Serialize(
                HttpContext.Request.Cookies.ToString()));
            return Content(System.Text.Json.JsonSerializer.Serialize(
                claims[1].Value)
            );
        }

        return NotFound(data);
    }

    private async Task<Boolean> AuthenticateUser(string id, string password)
    {
        //Implementar codigo para revisar base de datos
        return true;
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("/logout")]
    public async Task<ActionResult> logout(Data.loginUser data)
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        Console.Out.Write("Log out");
        return Ok(data);
    }
}