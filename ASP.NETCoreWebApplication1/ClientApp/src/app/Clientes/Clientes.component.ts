import {Component, Inject} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Popup} from "../Popup/Popup.component";

@Component({
  selector: 'app-Clientes',
  templateUrl: './Clientes.component.html',
  styleUrls: ['./Clientes.component.css']
})
export class ClientesComponent {
  token = sessionStorage.getItem("tokenKey");
  respuesta = {};
  http: HttpClient;
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
    var res = await this.http.get<string>("https://localhost:7143/Clientes/plantilla", {
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
      'Nombre_Completo': (<HTMLInputElement>document.getElementById("Nombre_Completo")).value,
      'Cedula': (<HTMLInputElement>document.getElementById("Cedula")).value,
      'Telefono_1': (<HTMLInputElement>document.getElementById("Telefono_1")).value,
      'Telefono_2': (<HTMLInputElement>document.getElementById("Telefono_2")).value,
      'Correo_electronico': (<HTMLInputElement>document.getElementById("Correo_electronico")).value,
      'Direccion_1': (<HTMLInputElement>document.getElementById("Direccion_1")).value,
      'Direccion_2': (<HTMLInputElement>document.getElementById("Direccion_2")).value,
      'Usuario': (<HTMLInputElement>document.getElementById("Usuario")).value
    };

    console.log(this.respuesta);
    console.log(answer);
    let res = await this.http.post("https://localhost:7143/Clientes/post", JSON.stringify(answer), {
      headers: this.httpOptions.headers,
      withCredentials: true,
    })
    res.subscribe(result => {
      this.respuesta = result;
      Popup.open("REGISTRO EXITOSO", "Se ha registrado la informacion. Revisar correo para acceder a su contraseña ", "Inicio", function () {
      window.location.assign("");
      });

      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(res)
  }

  async Delete_Button() {

  }
}

