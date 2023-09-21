import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Guid } from "guid-typescript";
import { EnderecoResultModel } from 'src/app/models/Results/EnderecoResultModel';
import MotoristaResultModel from 'src/app/models/Results/MotoristaResultModel';
import SolicitarAnaliseCommandModel, { VeiculoSolicitarAnaliseCommandModel } from 'src/app/models/SolicitarAnaliseCommandModel';
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
  solicitarAnaliseCommandModel: SolicitarAnaliseCommandModel = new SolicitarAnaliseCommandModel();

  veiculo: VeiculoSolicitarAnaliseCommandModel = new VeiculoSolicitarAnaliseCommandModel();
  veiculos: VeiculoSolicitarAnaliseCommandModel[] = [];
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
    this.veiculos.push(this.veiculo);

    this.veiculo = new VeiculoSolicitarAnaliseCommandModel();
  }

  buscarEndereco(): void {
    this.motoristaService.BuscarEndereco(this.solicitarAnaliseCommandModel.proprietario.cep)
      .subscribe({
        next: (result) => {
          this.solicitarAnaliseCommandModel.proprietario.bairro = result.bairro;
          this.solicitarAnaliseCommandModel.proprietario.nomeCidade = result.localidade;
          this.solicitarAnaliseCommandModel.proprietario.estado = result.uf;
          this.solicitarAnaliseCommandModel.proprietario.rua = result.logradouro;
        }
      });
  }

}
