import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Guid } from "guid-typescript";
import ProprietarioCommandModel from 'src/app/models/ProprietarioCommandModel';
import { EnderecoResultModel } from 'src/app/models/Results/EnderecoResultModel';
import MotoristaResultModel from 'src/app/models/Results/MotoristaResultModel';
import SolicitarAnaliseCommandModel from 'src/app/models/SolicitarAnaliseCommandModel';
import VeiculoCommand from 'src/app/models/VeiculoCommandModel';
import { MotoristaService } from 'src/app/services/motorista.service';


@Component({
  selector: 'app-solicitar-analise',
  templateUrl: './solicitar-analise.component.html',
  styleUrls: ['./solicitar-analise.component.scss']
})
export class SolicitarAnaliseComponent {
  motoristaId: Guid;
  novoMotorista: boolean = true;
  nomeMotorista: string;
  motorista: MotoristaResultModel;
  proprietario: ProprietarioCommandModel = new ProprietarioCommandModel();
  solicitarAnaliseCommandModel: SolicitarAnaliseCommandModel = new SolicitarAnaliseCommandModel();

  veiculo: VeiculoCommand = new VeiculoCommand();
  veiculos: VeiculoCommand[] = [];
  constructor(
    private router: ActivatedRoute,
    private motoristaService: MotoristaService) {
    this.motorista = {} as MotoristaResultModel;

  }

  ngOnInit() {
    this.router.params.subscribe(params => {
      this.motoristaId = params['idmotorista'];
      this.novoMotorista = this.motoristaId.toString() == Guid.EMPTY;
      this.carregarForm();
    });
  }

  carregarForm(): void {
    this.solicitarAnaliseCommandModel.motoristaId = this.motoristaId;

    this.motoristaService.buscarMotorista(this.motoristaId)
      .subscribe((result: MotoristaResultModel) => {
        this.motorista = result;
      })
  }

  adicionarVeiculo(): void {
    this.veiculo.id = Guid.createEmpty();
    this.veiculos.push(this.veiculo);

    this.veiculo = new VeiculoCommand();
  }

  buscarEndereco(): void {
    this.motoristaService.BuscarEndereco(this.proprietario.cep)
      .subscribe({
        next: (result) => {
          this.proprietario.bairro = result.bairro;
          this.proprietario.cidade = result.localidade;
          this.proprietario.estado = result.uf;
          this.proprietario.rua = result.logradouro;
        }
      });
  }

}
