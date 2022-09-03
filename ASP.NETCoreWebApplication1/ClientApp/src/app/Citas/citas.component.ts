import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Title} from "@angular/platform-browser";
import {waitForAsync} from "@angular/core/testing";


@Component({
  selector: 'app-citas',
  templateUrl: './citas.component.html',
  styleUrls: ['./citas.component.css']
})

export class CitasComponent implements OnInit {
  saludo: any | undefined;
  http: HttpClient;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http=http;
    this.Obtener_Cita();
  }

  async Obtener_Cita(){
    var res = await this.http.get<string>("https://localhost:7143/Citas").subscribe(result => {
      this.saludo = result;
      console.log(this.saludo);

    }, error => console.error(error));

    console.log(this.saludo);
  }

  ngOnInit(): void {
  }

}
