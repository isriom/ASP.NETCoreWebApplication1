import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';
import {AppComponent, SafePipe} from './app.component';
import {NavMenuComponent} from './nav-menu/nav-menu.component';
import {HomeComponent} from './home/home.component';
import {CitasComponent} from "./Citas/citas.component";
import {ClientesComponent} from "./Clientes/Clientes.component";
import {trabajadoresComponent} from "./trabajadores/trabajadores.component";
import {CFacturasComponent} from "./CFacturas/c-facturas.component";
import {GClientesComponent} from "./GClientes/GClientes.component";
import {RCitasComponent} from "./RCitas/Rcitas.component";
import {Popup} from "./Popup/Popup.component";

/**
 * Declaraciones donde se agregan los componentes que va a tener la barra de menu
 */
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    trabajadoresComponent,
    ClientesComponent,
    CitasComponent,
    CFacturasComponent,
    GClientesComponent,
    RCitasComponent,
    Popup,
    SafePipe,
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,

    RouterModule.forRoot([
      {path: '', component: HomeComponent, pathMatch: 'full'},
      {path: 'trabajadores', data: {title: "Gestion Trabajadores"}, component: trabajadoresComponent},
      {path: 'Clientes', data: {title: "Clientes"}, component: ClientesComponent},
      {path: 'Citas', data: {title: "Citas"}, component: CitasComponent},
      {path: 'CFactura', data: {title: "Consulta Facturas"}, component: CFacturasComponent},
      {path: 'RCitas', data: {title: "Citas"}, component: RCitasComponent},
      {path: 'GClientes', data: {title: "Gestion de Clientes"}, component: GClientesComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
