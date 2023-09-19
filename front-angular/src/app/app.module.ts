import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AddMotoristaComponent } from './motorista/add-motorista/add-motorista.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ModalComponent } from './componentes/modal/modal.component';
import { ListMotoristaComponent } from './motorista/list-motorista/list-motorista.component';
import { SolicitarAnaliseComponent } from './solicitar-analise/solicitar-analise.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AddMotoristaComponent,
    ModalComponent,
    ListMotoristaComponent,
    SolicitarAnaliseComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
