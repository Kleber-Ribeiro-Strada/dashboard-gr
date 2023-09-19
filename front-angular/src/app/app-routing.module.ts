import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AddMotoristaComponent } from './motorista/add-motorista/add-motorista.component';
import { ListMotoristaComponent } from './motorista/list-motorista/list-motorista.component';
import { SolicitarAnaliseComponent } from './solicitar-analise/solicitar-analise.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'add-motorista', component: AddMotoristaComponent },
  { path: 'list-motorista', component: ListMotoristaComponent },
  { path: ':idmotorista/solicitar-analise', component: SolicitarAnaliseComponent },

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
