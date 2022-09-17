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
      'Content-Type': 'application/json',
      'withCredentials': 'true'
    })
  };

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseurl = baseUrl;
    this.Obtener_Clientes();
  }

  async Obtener_Clientes() {
    var res = await this.http.get<string>("https://localhost:7143/GClientes/plantilla", {
      headers: this.httpOptions.headers,
      withCredentials: true
    }).subscribe(result => {
      this.respuesta = result;
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(this.respuesta);
  }

  async Add_Button() {
    const answer = {
      'Nombre': (<HTMLInputElement>document.getElementById("Nombre")).value,
      'Numero_Cedula': (<HTMLInputElement>document.getElementById("Numero de Cedula")).value,
      'Telefono1': (<HTMLInputElement>document.getElementById("Telefono 1")).value,
      'Telefono2': (<HTMLInputElement>document.getElementById("Telefono 2")).value,
      'Correo_e': (<HTMLInputElement>document.getElementById("Correo electronico")).value,
      'Direccion1': (<HTMLInputElement>document.getElementById("Direccion 1")).value,
      'Direccion2': (<HTMLInputElement>document.getElementById("Direccion 2")).value,
      'Usuario': (<HTMLInputElement>document.getElementById("Usuario")).value,
      'Password': (<HTMLInputElement>document.getElementById("Password")).value
    };

    console.log(this.respuesta);
    console.log(answer);
    let res = await this.http.post("https://localhost:7143/GClientes/post", JSON.stringify(answer), {
      headers: this.httpOptions.headers,
      withCredentials: true,
    })
    res.subscribe(result => {
      this.respuesta = result;
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(res)
  }

  async Delete_Button() {

  }
}

