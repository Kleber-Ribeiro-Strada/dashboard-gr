import { Component } from '@angular/core';
import { EnderecoResultModel } from 'src/app/models/EnderecoResultModel';
import MotoristaCommandModel from 'src/app/models/MotoristaCommandModel';
import { MotoristaService } from 'src/app/services/motorista.service';

@Component({
  selector: 'app-add-motorista',
  templateUrl: './add-motorista.component.html',
  styleUrls: ['./add-motorista.component.scss']
})
export class AddMotoristaComponent {

  model: MotoristaCommandModel = new MotoristaCommandModel();
  endereco!: EnderecoResultModel;
  constructor(private _service: MotoristaService) {
    this.model.cep = '';
    this.endereco = {} as EnderecoResultModel
  }




  testarApi(event: Event) {
    event.preventDefault()

    this._service.teste().subscribe((result) => {

      console.log(result);
    });
  }

  buscarEndereco(): void {
    this._service.BuscarEndereco(this.model.cep)
      .subscribe((result: EnderecoResultModel) => {
        this.endereco = result;
      })
  }
}
