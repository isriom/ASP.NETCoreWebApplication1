import {Component, Inject} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Router} from "@angular/router";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  token = sessionStorage.getItem("Token");
  rol = sessionStorage.getItem("Rol");
  http: HttpClient;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'withCredentials':'true'
    })
  };

  constructor(http: HttpClient) {
    this.http = http;
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  async logout(){
    let res = await this.http.post("https://localhost:7143/logout", JSON.stringify({}), this.httpOptions)
    res.subscribe(result => {
      console.log(result);
      sessionStorage.clear();
      window.location.reload()
    }, error => console.error(error));
  }
}
