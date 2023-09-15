import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AddMotoristaComponent } from './motorista/add-motorista/add-motorista.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'add-motorista', component: AddMotoristaComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
