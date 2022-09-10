import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})


export class HomeComponent implements OnInit {
  token = sessionStorage.getItem("tokenKey");
  headers = {};
  respuesta = {};
  http: HttpClient;
  router: Router | undefined;
  baseurl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseurl = baseUrl;
    this.Obtener_plantilla();
  }

  async Obtener_plantilla() {

    var res = await this.http.get<string>("https://localhost:7143/login/plantilla",).subscribe(result => {
      this.respuesta = result;
      console.log("login plantilla");
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(this.respuesta);
  }

  ngOnInit() {

  }
}
