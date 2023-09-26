import { Component, ElementRef, Renderer2, ViewChild } from '@angular/core';
import { EnderecoResultModel } from 'src/app/models/Results/EnderecoResultModel';
import { ErrorResultModel } from 'src/app/models/Results/ErrorResultModel';
import MotoristaCommandModel, { CnhCommandModel } from 'src/app/models/MotoristaCommandModel';
import { MotoristaService } from 'src/app/services/motorista.service';

@Component({
  selector: 'app-add-motorista',
  templateUrl: './add-motorista.component.html',
  styleUrls: ['./add-motorista.component.scss']
})
export class AddMotoristaComponent {

  model: MotoristaCommandModel = new MotoristaCommandModel();
  endereco!: EnderecoResultModel;
  error: ErrorResultModel;

  @ViewChild('staticBackdrop')
  private meuModal: ElementRef;

  constructor(private _service: MotoristaService, private renderer: Renderer2) {

    this.endereco = {} as EnderecoResultModel
    this.error = {} as ErrorResultModel;
    console.log(this.meuModal);
  }

  abrirModal() {
    this.renderer.addClass(this.meuModal.nativeElement, 'show');
  }

  fecharModal() {
    this.renderer.removeClass(this.meuModal.nativeElement, 'show');
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
        this.model.bairro = result.bairro;
        this.model.codigoCidade = result.gia;
        this.model.nomeCidade = result.localidade;
        this.model.estado = result.uf;
        this.model.rua = result.logradouro;
      })
  }

  add(): void {
    console.log(this.model);
    this.error = null;
    this._service.adicionar(this.model).subscribe({
      next: (result) => {
        console.log('result', result);

      },
      error: (e) => {
        console.log('error', e.error);
        this.error = e.error;
        this.abrirModal();
      },
      complete: () => console.log('done'),
    });
  }
}
