import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {DomSanitizer, SafeHtml, SafeUrl} from "@angular/platform-browser";
import {Router} from '@angular/router';


@Component({
  selector: 'app-Popup',
  templateUrl: './Popup.component.html',
  styleUrls: ['./Popup.component.css']
})


export class Popup implements OnInit {

  http: HttpClient;
  router: Router | undefined;
  baseurl: string;

  div = document.getElementById("popup");
  Title: any = "Titulo";
  actionF: Function = () => this.close();
  Text: string = "TEXTO";
  actionText: string = "ACTION";
  static pop: Popup;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseurl = baseUrl;
    this.setactionF(this.close);
    this.div = document.getElementById("popup");
    Popup.pop = this;
    this.close()
  }


  ngOnInit(): void {
    this.close()
  }

  static open(TITLE: string, TEXT: string, ACTIONTEXT: string, FUNC?: Function) {
    Popup.pop.setactionF(FUNC);
    Popup.pop.Title = TITLE;
    Popup.pop.Text = TEXT;
    Popup.pop.actionText = ACTIONTEXT;
    (<HTMLDivElement>Popup.pop.div).hidden = false;
  }

  close() {
    if (this === undefined) {
      var div = document.getElementById("popup")
      if (div !== null) {
        (<HTMLDivElement>div).hidden = true;
        console.log("this und")
      }
      return
    }

    console.log(this)
    console.log(this.div)
    this.div = document.getElementById("popup");
    if (this.div !== null) {
      (<HTMLDivElement>this.div).hidden = true;
      // (<HTMLDivElement>this.div). = "none";
      console.log(<HTMLDivElement>this.div)
    }
  }

  /*
  When assign a new function the context is empty, So use a static/found objetct to use.
  Dont assign new
   */
  setactionF(value?: Function, parameters?: object) {
    if (value === undefined) {
      return;
    }
    if (parameters === null) {
      this.actionF = () => value();
    } else {
      this.actionF = () => value(parameters);
    }
  }
}
