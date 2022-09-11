import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Title} from "@angular/platform-browser";
import {waitForAsync} from "@angular/core/testing";
import {HttpHeaders} from '@angular/common/http';
import {Router} from '@angular/router';
import {Template} from "@angular/compiler/src/render3/r3_ast";

@Component({
  selector: 'app-RCitas',
  templateUrl: './Rcitas.component.html',
  styleUrls: ['./Rcitas.component.css']
})


export class RCitasComponent {
  respuesta: any | undefined;
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
    this.Obtener_Cita();
  }

  async Obtener_Cita() {
    var res = await this.http.get<string>("https://localhost:7143/RCitas",).subscribe(result => {
      this.respuesta = result;
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(this.respuesta);
  }



  async Add_Button() {
    let template = {cliente: "", placa: "", sucursal: "", servicio: ""};
    template.cliente = (<HTMLInputElement>document.getElementById("Cliente")).value;
    template.placa = (<HTMLInputElement>document.getElementById("Placa")).value;
    template.sucursal = (<HTMLInputElement>document.getElementById("Sucursal")).value;
    template.servicio = (<HTMLInputElement>document.getElementById("Servicio")).value;
    console.log(this.respuesta);
    console.log(template);
    let res = await this.http.post("https://localhost:7143/RCitas", template)
    res.subscribe(result => {
      this.respuesta = result;
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(res)
  }

  async Delete_Button() {

  }
}
