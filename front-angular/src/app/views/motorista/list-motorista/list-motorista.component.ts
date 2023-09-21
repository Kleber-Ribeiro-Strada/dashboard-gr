import { Component } from '@angular/core';
import MotoristaResultModel from 'src/app/models/Results/MotoristaResultModel';
import { MotoristaService } from 'src/app/services/motorista.service';

@Component({
  selector: 'app-list-motorista',
  templateUrl: './list-motorista.component.html',
  styleUrls: ['./list-motorista.component.scss']
})
export class ListMotoristaComponent {

  motoristas: MotoristaResultModel[] = [];
  constructor(private service: MotoristaService) {
  }

  ngOnInit() {
    this.buscarMotoristas();
  }

  buscarMotoristas(): void {
    this.service.buscarMotoristas()
      .subscribe((result: MotoristaResultModel[]) => {
        this.motoristas = result;
      });
  }
}
