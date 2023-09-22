import { Injectable } from '@angular/core';
import FilterCommandModel from '../models/FilterCommandModel';
import { HttpClient } from '@angular/common/http';
import { AnaliseRiscoRelatorio } from '../models/Results/AnaliseRiscoRelatorio';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DashBoardService {
  urlBase = "https://localhost:5223/api/"

  constructor(private _http: HttpClient) { }

  buscarRelatorioGeral(filter: FilterCommandModel): Observable<AnaliseRiscoRelatorio[]> {

    var url = this.urlBase + "Relatorio?";
    if (filter.dataSolicitacaoDe !== null && filter.dataSolicitacaoDe != undefined) {
      url += `DataSolicitacaoDe=${filter.dataSolicitacaoDe}&`
    }

    if (filter.dataSolicitacaoAte !== null && filter.dataSolicitacaoAte != undefined) {
      url += `DataSolicitacaoAte=${filter.dataSolicitacaoAte}&`
    }

    if (filter.cpf != null || filter.cpf != undefined) {
      url += `cpf=${filter.cpf}&`
    }

    if (filter.status != null || filter.status != undefined) {
      url += `status=${filter.status}&`
    }
    return this._http.get<AnaliseRiscoRelatorio[]>(url);
  }
}
