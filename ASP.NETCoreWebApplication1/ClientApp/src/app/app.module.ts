import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';

import {AppComponent} from './app.component';
import {NavMenuComponent} from './nav-menu/nav-menu.component';
import {HomeComponent} from './home/home.component';
import {CitasComponent} from "./Citas/citas.component";
import {ClientesComponent} from "./Clientes/Clientes.component";
import {trabajadoresComponent} from "./trabajadores/trabajadores.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    trabajadoresComponent,
    ClientesComponent,
    CitasComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent, pathMatch: 'full'},
      {path: 'trabajadores', component: trabajadoresComponent},
      {path: 'Clientes', component: ClientesComponent},
      {path: 'Citas', data: {title: "Citas"}, component: CitasComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
