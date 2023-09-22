import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './views/home/home.component';
import { AddMotoristaComponent } from './views/motorista/add-motorista/add-motorista.component';
import { ListMotoristaComponent } from './views/motorista/list-motorista/list-motorista.component';
import { SolicitarAnaliseComponent } from './views/analise/solicitar-analise/solicitar-analise.component';
import { ListAnaliseComponent } from './views/analise/list-analise/list-analise.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'add-motorista', component: AddMotoristaComponent },
  { path: 'list-motorista', component: ListMotoristaComponent },
  { path: ':idmotorista/solicitar-analise', component: SolicitarAnaliseComponent },
  { path: 'list-analise', component: ListAnaliseComponent },


];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
