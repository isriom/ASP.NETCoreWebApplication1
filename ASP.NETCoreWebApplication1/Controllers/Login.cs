﻿using System.Text.Json;
using ASP.NETCoreWebApplication1.Controllers.DB;
using Microsoft.AspNetCore.Authorization;
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
        this.template.Contraseña = null;
        this.template.Usuario = null;
        string jsonstring = System.Text.Json.JsonSerializer.Serialize<Data.loginUser>(template);
        return Content(jsonstring);
    }


    [HttpPut]
    [Route("/login")]
    public ActionResult login(string data)
    {
        Data.loginUser login = JsonSerializer.Deserialize<Data.loginUser>(data);

        return NotFound(login);
    }
}