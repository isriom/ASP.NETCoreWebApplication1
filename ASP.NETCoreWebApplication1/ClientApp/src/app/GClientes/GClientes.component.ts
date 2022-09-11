import {Component, Inject} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Router} from "@angular/router";

@Component({
  selector: 'app-GClientes',
  templateUrl: './GClientes.component.html',
  styleUrls: ['./GClientes.component.css']
})
export class GClientesComponent {
  token = sessionStorage.getItem("tokenKey");
  respuesta = {};
  http: HttpClient;
  router: Router | undefined;
  baseurl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseurl = baseUrl;
    this.Obtener_Clientes();
  }

  async Obtener_Clientes() {
    var res = await this.http.get<string>("https://localhost:7143/GClientes",).subscribe(result => {
      this.respuesta = result;
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(this.respuesta);
  }

  async Add_Button() {
    let template = {
      Nombre: "",
      Numero_Cedula: "",
      Telefono1: "",
      Telefono2: "",
      Correo_e: "",
      Direccion1: "",
      Direccion2: "",
      Usuario: "",
      Password: ""
    };
    template.Nombre = (<HTMLInputElement>document.getElementById("Nombre")).value;
    template.Numero_Cedula = (<HTMLInputElement>document.getElementById("Numero de Cedula")).value;
    template.Telefono1 = (<HTMLInputElement>document.getElementById("Telefono 1")).value;
    template.Telefono2 = (<HTMLInputElement>document.getElementById("Telefono 2")).value;
    template.Correo_e = (<HTMLInputElement>document.getElementById("Correo electronico")).value;
    template.Direccion1 = (<HTMLInputElement>document.getElementById("Direccion 1")).value;
    template.Direccion2 = (<HTMLInputElement>document.getElementById("Direccion 2")).value;
    template.Usuario = (<HTMLInputElement>document.getElementById("Usuario")).value;
    template.Password = (<HTMLInputElement>document.getElementById("Password")).value;
    console.log(this.respuesta);
    console.log(template);
    let res = await this.http.post("https://localhost:7143/GClientes", template)
    res.subscribe(result => {
      this.respuesta = result;
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(res)
  }

  async Delete_Button() {

  }
}

