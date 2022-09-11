import {Component, Inject} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from "@angular/router";
import {HttpHeaders} from '@angular/common/http';

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
      'Content-Type': 'application/json'
    })
  };
  elseBlock: any;


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseurl = baseUrl;
    this.Obtener_trabajadores();
  }

  async Obtener_trabajadores() {
    var res = await this.http.get<string>("https://localhost:7143/trabajadores",).subscribe(result => {
      this.respuesta = result;
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(this.respuesta);
  }

  async Add_Button() {
    let template = {Nombre: "", Apellidos: "", Numero_Cedula: "", Fecha_ingreso: "", Fecha_nacimiento: "", Edad:"", Password: "", Rol: ""};
    template.Nombre = (<HTMLInputElement>document.getElementById("Nombre")).value;
    template.Apellidos = (<HTMLInputElement>document.getElementById("Apellidos")).value;
    template.Numero_Cedula = (<HTMLInputElement>document.getElementById("Numero de Cedula")).value;
    template.Fecha_ingreso = (<HTMLInputElement>document.getElementById("Fecha de ingreso")).value;
    template.Fecha_nacimiento = (<HTMLInputElement>document.getElementById("Fecha de nacimiento")).value;
    template.Edad = (<HTMLInputElement>document.getElementById("Edad")).value;
    template.Password = (<HTMLInputElement>document.getElementById("Password")).value;
    template.Rol = (<HTMLInputElement>document.getElementById("Rol que desempeña")).value;
    console.log(this.respuesta);
    console.log(template);
    let res = await this.http.post("https://localhost:7143/trabajadores", template)
    res.subscribe(result => {
      this.respuesta = result;
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(res)
  }

  async Delete_Button() {

  }
}

