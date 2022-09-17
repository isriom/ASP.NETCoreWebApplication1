import {Component, Inject} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Router} from "@angular/router";

@Component({
  selector: 'app-trabajadores',
  templateUrl: './trabajadores.component.html',
  styleUrls: ['./trabajadores.component.css']
})
export class trabajadoresComponent {
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
  elseBlock: any;


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseurl = baseUrl;
    this.Obtener_trabajadores();
  }

  async Obtener_trabajadores() {
    var res = await this.http.get<string>("https://localhost:7143/trabajadores/plantilla", {
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
      Nombre: (<HTMLInputElement>document.getElementById("Nombre")).value,
      Apellidos: (<HTMLInputElement>document.getElementById("Apellidos")).value,
      Numero_Cedula: (<HTMLInputElement>document.getElementById("Numero de Cedula")).value,
      Fecha_ingreso: (<HTMLInputElement>document.getElementById("Fecha de ingreso")).value,
      Fecha_nacimiento: (<HTMLInputElement>document.getElementById("Fecha de nacimiento")).value,
      Edad: (<HTMLInputElement>document.getElementById("Edad")).value,
      Password: (<HTMLInputElement>document.getElementById("Password")).value,
      Rol: (<HTMLInputElement>document.getElementById("Rol que desempeña")).value
    };

    console.log(this.respuesta);
    console.log(answer);
    let res = await this.http.post("https://localhost:7143/trabajadores/post", JSON.stringify(answer), this.httpOptions)
    res.subscribe(result => {
      this.respuesta = result;
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(res)
  }

  async Delete_Button() {

  }
}

