import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './views/home/home.component';
import { AddMotoristaComponent } from './views/motorista/add-motorista/add-motorista.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ModalComponent } from './componentes/modal/modal.component';
import { ListMotoristaComponent } from './views/motorista/list-motorista/list-motorista.component';
import { SolicitarAnaliseComponent } from './views/analise/solicitar-analise/solicitar-analise.component';
import { ListAnaliseComponent } from './views/analise/list-analise/list-analise.component';
import { DashboardComponent } from './views/analise/dashboard/dashboard.component';
import { NgChartsModule } from 'ng2-charts';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AddMotoristaComponent,
    ModalComponent,
    ListMotoristaComponent,
    SolicitarAnaliseComponent,
    ListAnaliseComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgChartsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
