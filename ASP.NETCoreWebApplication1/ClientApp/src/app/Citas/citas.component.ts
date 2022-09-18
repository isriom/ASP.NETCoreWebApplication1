import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Router} from '@angular/router';
import {Popup} from "../Popup/Popup.component";

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
      'withCredentials': 'true'
    })
  };

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseurl = baseUrl;
    this.Obtener_Cita();
  }

  async Obtener_Cita() {
    var res = await this.http.get<string>("https://localhost:7143/Citas/plantilla", {
      headers: this.httpOptions.headers,
      withCredentials: true
    }).subscribe(result => {
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
      'Cliente': (<HTMLInputElement>document.getElementById("Cliente")).value,
      'Placa_del_Vehiculo': (<HTMLInputElement>document.getElementById("Placa_del_Vehiculo")).value,
      "Sucursal": (<HTMLInputElement>document.getElementById("Sucursal")).value,
      "Servicio_solicitado": (<HTMLInputElement>document.getElementById("Servicio_solicitado")).value
    };
    console.log(this.respuesta);
    console.log(answer);
    const res = this.http.post<string>("https://localhost:7143/Citas/post", JSON.stringify(answer), {
      headers: this.httpOptions.headers,
      withCredentials: true,
    });
    res.subscribe(result => {
      console.log(answer);

      this.Obtener_Cita();
      Popup.open("CITA REGISTRADA", "Se ha registrado la cita bajo la factura #" + result, "Imprimir");

      console.log(this.respuesta);

    }, error => console.error(error));
    console.log(res)
    console.log(answer);

  }

  async Delete_Button() {

  }
}
