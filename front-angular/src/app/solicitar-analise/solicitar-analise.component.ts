import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Guid } from "guid-typescript";


@Component({
  selector: 'app-solicitar-analise',
  templateUrl: './solicitar-analise.component.html',
  styleUrls: ['./solicitar-analise.component.scss']
})
export class SolicitarAnaliseComponent {
  idMotorista: Guid;
  novoMotorista:boolean = true;
  motorista:string;
  constructor(private router: ActivatedRoute) {

  }

  ngOnInit() {
    this.router.params.subscribe(params => {
      this.idMotorista = params['idmotorista'];
      this.novoMotorista = this.idMotorista.toString() == Guid.EMPTY;
      this.carregarForm();
    });
  }

  carregarForm(): void {
    console.log(this.novoMotorista);
    console.log(this.idMotorista);
  }

}
