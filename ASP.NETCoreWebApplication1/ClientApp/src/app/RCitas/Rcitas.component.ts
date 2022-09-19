import {Component, Inject} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Router} from '@angular/router';

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
      'Content-Type': 'application/json',
      'withCredentials': 'true'
    })
  };

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseurl = baseUrl;
    this.Obtener_Cita();
  }

  async Obtener_Cita() {
    var res = await this.http.get<string>("https://localhost:7143/RCitas/plantilla", {
      headers: this.httpOptions.headers,
      withCredentials: true
    }).subscribe(result => {
      this.respuesta = result;
      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(this.respuesta);
  }


  async Add_Button() {
    const answer = {
      'Cliente': (<HTMLInputElement>document.getElementById("Cliente")).value,
      'Placa_del_Vehiculo': (<HTMLInputElement>document.getElementById("Placa_del_Vehiculo")).value,
      "Sucursal": (<HTMLInputElement>document.getElementById("Sucursal")).value,
      "Servicio_solicitado": (<HTMLInputElement>document.getElementById("Servicio_solicitado")).value
    };

    console.log(this.respuesta);
    console.log(answer);
    let res = await this.http.post("https://localhost:7143/RCitas/post", JSON.stringify(answer), {
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

  }
}
