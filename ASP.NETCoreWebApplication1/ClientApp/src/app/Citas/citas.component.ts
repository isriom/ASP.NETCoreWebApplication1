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
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Data':'*',
      'Accept':"json",
    })
  };

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
    const answer = {
      'cliente': (<HTMLInputElement>document.getElementById("Cliente")).value,
      'placa': (<HTMLInputElement>document.getElementById("placa")).value,
      "sucursal": (<HTMLInputElement>document.getElementById("sucursal")).value,
      "servicio": (<HTMLInputElement>document.getElementById("servicio")).value
    };
    console.log(this.respuesta);
    console.log(answer);
    const res = this.http.post<string>("https://localhost:7143/Citas", JSON.stringify(answer), this.httpOptions);
    res.subscribe(result => {
      console.log(answer);

      this.respuesta = result;
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(res)
    console.log(answer);

  }

  async Delete_Button() {

  }
}
