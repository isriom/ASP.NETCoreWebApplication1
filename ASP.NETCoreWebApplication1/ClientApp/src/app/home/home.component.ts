import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Router} from "@angular/router";
import {Cookies, getCookie} from "typescript-cookie";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})


export class HomeComponent implements OnInit {
  token= sessionStorage.getItem("Token");
  user = sessionStorage.getItem("Usuario")
  headers = {};
  respuesta = {};
  http: HttpClient;
  router: Router | undefined;
  baseurl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'withCredentials':'true'
})
  };
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseurl = baseUrl;
    this.Obtener_plantilla();
    if (this.token===undefined){
      this.token="null";
    }
    if (this.user!==null) {
      (<HTMLParagraphElement>document.getElementById("NAME")).textContent = this.user.toString();
    }
    console.log(this.token)
    console.log(this.user)
  }

  async Obtener_plantilla() {

    var res = await this.http.get<string>("https://localhost:7143/login/plantilla",this.httpOptions).subscribe(result => {
      this.respuesta = result;
      console.log("login plantilla");
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(this.respuesta);
  }


  async Sig_In() {
    const answer = {
      'Usuario': (<HTMLInputElement>document.getElementById("Usuario")).value,
      'Contraseña': (<HTMLInputElement>document.getElementById("Contraseña")).value,
    };
    console.log(answer);
    const res = this.http.put<string>("https://localhost:7143/login/Singin", answer, {headers:this.httpOptions.headers, withCredentials:true});
    res.subscribe(result => {
      console.log(answer);

      this.respuesta = result;
      sessionStorage.setItem("Nombre", <string>answer.Usuario);
      localStorage.setItem("Nombre",<string>answer.Usuario);
      Cookies.set("nombre",answer.Usuario)
      Cookies.set("Token","True")
      sessionStorage.setItem("Token", "True");
      this.user = sessionStorage.getItem("Nombre")
      // window.location.reload()
      console.log(this.respuesta);

    }, error => console.error(error));
  }

  async Log_out() {
    const res = this.http.post<string>("https://localhost:7143/logout", {
      "Usuario": sessionStorage.getItem("Usuario"),
      "Contraseña": "0000"
    }, this.httpOptions);
    res.subscribe(result => {
      console.log(res);

      this.respuesta = result;
      document.cookie = "";
      console.log(this.respuesta);

    }, error => console.error(error));
  }

  ngOnInit() {

  }
}
