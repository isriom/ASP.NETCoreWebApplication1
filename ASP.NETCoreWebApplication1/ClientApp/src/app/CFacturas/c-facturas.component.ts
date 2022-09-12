import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Title} from "@angular/platform-browser";
import {waitForAsync} from "@angular/core/testing";
import {HttpHeaders} from '@angular/common/http';
import {Router} from '@angular/router';
import {Template} from "@angular/compiler/src/render3/r3_ast";

@Component({
  selector: 'app-CFacturas',
  templateUrl: './c-facturas.component.html',
  styleUrls: ['./c-facturas.component.css']
})


export class CFacturasComponent {
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
    this.Consultar_Factura();
  }

  async Consultar_Factura() {
    var res = await this.http.get<string>("https://localhost:7143/CFacturas/plantilla",).subscribe(result => {
      this.respuesta = result;
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(this.respuesta);
  }



  async Consult_Button() {
    const answer = {
      'cliente': (<HTMLInputElement>document.getElementById("Cliente")).value,
      'n_factura': (<HTMLInputElement>document.getElementById("Numero de Placa")).value
    };

    console.log(this.respuesta);
    console.log(answer);
    let res = await this.http.post("https://localhost:7143/CFacturas/post", JSON.stringify(answer), this.httpOptions)
    res.subscribe(result => {
      this.respuesta = result;
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(res)
  }

  async Delete_Button() {

  }
}
