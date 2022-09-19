import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {DomSanitizer, SafeHtml, SafeUrl} from "@angular/platform-browser";
import {Router} from '@angular/router';
import {Popup} from "../Popup/Popup.component";


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
  factura: any;

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
      'Cliente': (<HTMLInputElement>document.getElementById("Cliente")).value,
      'Numero_de_Factura': (<HTMLInputElement>document.getElementById("Numero_de_Factura")).value
    };

    console.log(this.respuesta);
    console.log(answer);
    let res = await this.http.post("https://localhost:7143/CFacturas/post", JSON.stringify(answer), {
      responseType: "blob",
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'withCredentials': 'true'
      },),
      withCredentials: true,
    })
    res.subscribe(result => {

      let blob = new Blob([result], {type: result.type})
      this.pdf = window.URL.createObjectURL(blob);
      this.respuesta = result;
      console.log(this.respuesta);

    }, error => {
      Popup.open("ERROR", "No Se encuentra una factura con este Numero a su nombre", "Recargar", function () {
        window.location.reload();
      })
      console.error(error);
    });
    console.log(res)

  }

  async Delete_Button() {
    this.pdf = "favicon.ico"
  }

  ngOnInit(): void {

  }

}
