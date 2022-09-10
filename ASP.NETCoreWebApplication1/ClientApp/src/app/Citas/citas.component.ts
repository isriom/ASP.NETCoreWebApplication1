import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Title} from "@angular/platform-browser";
import {waitForAsync} from "@angular/core/testing";
import {HttpHeaders} from '@angular/common/http';
import {Router} from '@angular/router';
import {Template} from "@angular/compiler/src/render3/r3_ast";

@Component({
  selector: 'app-citas',
  templateUrl: './citas.component.html',
  styleUrls: ['./citas.component.css']
})

export class CitasComponent implements OnInit {
  respuesta: any | undefined;
  http: HttpClient;
  router: Router | undefined;
  baseurl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseurl = baseUrl;
    this.Obtener_Cita();
  }

  async Obtener_Cita() {
    var res = await this.http.get<string>("https://localhost:7143/Citas",).subscribe(result => {
      this.respuesta = result;
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(this.respuesta);
  }

  ngOnInit(): void {
    if (localStorage.getItem("token") == null) {
      this.router?.navigateByUrl("");
    }
  }

  async Add_Button() {
    let template = {cliente:"",placa:"",sucursal:"",servicio:""};
    template.cliente = (<HTMLInputElement>document.getElementById("Cliente")).value;
    template.placa = (<HTMLInputElement>document.getElementById("placa")).value;
    template.sucursal = (<HTMLInputElement>document.getElementById("sucursal")).value;
    template.servicio = (<HTMLInputElement>document.getElementById("servicio")).value;
    console.log(this.respuesta);
    console.log(template);
    let res = await this.http.post("https://localhost:7143/Citas", template)
    console.log(res)
  }

  async Delete_Button() {

  }
}
