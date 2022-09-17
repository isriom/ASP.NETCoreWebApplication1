import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Router} from "@angular/router";
import {Cookies, getCookie} from "typescript-cookie";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})


export class HomeComponent implements OnInit {
  token = sessionStorage.getItem("Token");
  user = sessionStorage.getItem("Nombre")
  headers = {};
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

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseurl = baseUrl;
    this.Obtener_plantilla();
    if (this.token === undefined) {
      this.token = "null";
    }
    console.log(this.token)
    console.log(this.user)
  }

  async Obtener_plantilla() {

    var res = await this.http.get<string>("https://localhost:7143/login/plantilla", this.httpOptions).subscribe(result => {
      this.respuesta = result;
      console.log("login plantilla");
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(this.respuesta);
  }


  async Sig_In() {
    const answer = {
      'Usuario': (<HTMLInputElement>document.getElementById("Usuario")).value,
      'Contrasena': (<HTMLInputElement>document.getElementById("Contraseña")).value,
    };
    console.log(answer);
    const res = this.http.put<string>("https://localhost:7143/login/Singin", answer, {
      headers: this.httpOptions.headers,
      withCredentials: true,
    });
    res.subscribe(result => {
      console.log(answer);

      this.respuesta = result;
      sessionStorage.setItem("Nombre", <string>answer.Usuario);
      sessionStorage.setItem("Token", "True");
      this.user = answer.Usuario
      sessionStorage.setItem("Rol",result)
      window.location.reload()
      console.log(this.respuesta);

    }, error => console.error(error));
  }



  async logout(){
    let res = await this.http.put("https://localhost:7143/logout", JSON.stringify({}), {
      headers: this.httpOptions.headers,
      withCredentials: true,
      observe:"response"
    })
    res.subscribe(result => {
      console.log(result);
      sessionStorage.clear();
      window.location.reload()
    }, error => console.error(error));
  }

  ngOnInit() {

  }
}
