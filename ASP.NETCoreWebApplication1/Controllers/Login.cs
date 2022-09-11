﻿using System.Net;
using System.Security.Claims;
using System.Text.Json;
using ASP.NETCoreWebApplication1.Controllers.DB;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplication1.Controllers;

[ApiController]
[AllowAnonymous]
public class loginController : Controller
{
    public Data.loginUser template = new Data.loginUser();

    [HttpGet]
    [Route("login/plantilla")]
    public ActionResult plantilla(string? data)
    {
        this.template.contraseña = null;
        this.template.usuario = null;
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.loginUser>(template);
        return Content(jsonstring);
    }


    [HttpPut]
    [Route("/login")]
    public async Task<ActionResult> login(Data.loginUser data)
    {
        Console.Out.Write("data\n");
        var aut = await AuthenticateUser(data.usuario, data.usuario);
        Console.Out.Write(data);

        if (aut)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, data.usuario),
                new Claim(ClaimTypes.Role, "Trabajador"),
            };
            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimIdentity), new AuthenticationProperties());
            HttpContext.Response.Cookies.Append("dinero","500");
            Console.Out.Write( System.Text.Json.JsonSerializer.Serialize(
            HttpContext.Request.Cookies));
            return Ok(HttpContext.Response.Cookies);
        }

        return NotFound(data);
    }

    private async Task<Boolean> AuthenticateUser(string id, string password)
    {
        //Implementar codigo para revisar base de datos
        return true;
    }
}