import {Component, Inject} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from "@angular/router";

@Component({
  selector: 'app-trabajadores',
  templateUrl: './trabajadores.component.html'
})
export class trabajadoresComponent {
  token = sessionStorage.getItem("tokenKey");
  headers = {};
  respuesta = {};
  http: HttpClient;
  router: Router | undefined;
  baseurl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseurl = baseUrl;
    this.Obtener_trabajadores();
  }

  async Obtener_trabajadores() {
    var res = await this.http.get<string>("https://localhost:7143/Trabajadores",).subscribe(result => {
      this.respuesta = result;
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(this.respuesta);
  }
}

