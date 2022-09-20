import {Component, Inject} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Router} from '@angular/router';

/**
 * Componentes utilizados para el funcionamiento de la pagina
 */
@Component({
  selector: 'app-RCitas',
  templateUrl: './Rcitas.component.html',
  styleUrls: ['./Rcitas.component.css']
})

/**
 * Clase donde se desarrolla las funcionalidades de la pagina del Registro de Citas en la vista Cliente
 */
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
  /**
   * Constructor de la clase
   * @param http variable para la manipulacion del get y post
   * @param baseUrl variable para manejar la direccion de la pagina
   */
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseurl = baseUrl;
    this.Obtener_Cita();
  }
  /**
   * Metodo que crea la pagina en el momento que es solicitada en los componentes de la barra de menu
   * @constructor metodo donde se hace la llamada
   */
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

  /**
   * Metodo para definar la accion que debe realizar el boton obtener los datos ingresados en la pagina
   * @constructor metodo relacionado
   */
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
  /**
   * Metodo para definir la funcionalidad del boton de DELETE
   * @constructor metodo relacionado
   */
  async Delete_Button() {

  }
}
