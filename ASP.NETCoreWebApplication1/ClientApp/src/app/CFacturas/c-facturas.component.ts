import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {DomSanitizer, SafeHtml, SafeUrl} from "@angular/platform-browser";
import {Router} from '@angular/router';


@Component({
  selector: 'app-CFacturas',
  templateUrl: './c-facturas.component.html',
  styleUrls: ['./c-facturas.component.css']
})


export class CFacturasComponent implements OnInit {
  respuesta: any | undefined;
  http: HttpClient;
  router: Router | undefined;
  baseurl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'withCredentials': 'true'
    })
  };
  cliente: any;
  pdf: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseurl = baseUrl;
    this.Consultar_Factura();
    if (sessionStorage.getItem("Rol") !== "Trabajador") {
      this.cliente = sessionStorage.getItem("Nombre");
    }
    this.pdf = "";
  }

  async Consultar_Factura() {
    var res = await this.http.get<string>("https://localhost:7143/CFacturas/plantilla", {
      headers: this.httpOptions.headers,
      withCredentials: true
    }).subscribe(result => {
      this.respuesta = result;
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(this.respuesta);

  }


  async Consult_Button() {
    this.pdf = ""
    const answer = {
      'cliente': (<HTMLInputElement>document.getElementById("Cliente")).value,
      'n_factura': (<HTMLInputElement>document.getElementById("Numero de Placa")).value
    };

    console.log(this.respuesta);
    console.log(answer);
    let res = await this.http.post("https://localhost:7143/CFacturas/post", JSON.stringify(answer), {
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
    this.pdf = "favicon.ico"
  }

  ngOnInit(): void {

  }

}
