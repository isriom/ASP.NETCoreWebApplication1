import {Component, Inject} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Router} from "@angular/router";

@Component({
  selector: 'app-Clientes',
  templateUrl: './Clientes.component.html',
  styleUrls: ['./Clientes.component.css']
})
export class ClientesComponent {
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
    var res = await this.http.get<string>("https://localhost:7143/Clientes/plantilla",).subscribe(result => {
      this.respuesta = result;
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(this.respuesta);
  }
  async Add_Button() {
    const answer = {
      'Nombre':(<HTMLInputElement>document.getElementById("Nombre")).value,
      'Numero_Cedula': (<HTMLInputElement>document.getElementById("Numero de Cedula")).value,
      'Telefono1': (<HTMLInputElement>document.getElementById("Numero de Cedula")).value,
      'Telefono2': (<HTMLInputElement>document.getElementById("Telefono 2")).value,
      'Correo_e':(<HTMLInputElement>document.getElementById("Correo electronico")).value,
      'Direccion1': (<HTMLInputElement>document.getElementById("Direccion 1")).value,
      'Direccion2': (<HTMLInputElement>document.getElementById("Direccion 2")).value,
      'Usuario': (<HTMLInputElement>document.getElementById("Usuario")).value
    };

    console.log(this.respuesta);
    console.log(answer);
    let res = await this.http.post("https://localhost:7143/Clientes/Clientes/post", JSON.stringify(answer), this.httpOptions)
    res.subscribe(result => {
      this.respuesta = result;
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(res)
  }

  async Delete_Button() {

  }
}

