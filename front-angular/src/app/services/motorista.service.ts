import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { EnderecoResultModel } from '../models/Results/EnderecoResultModel';
import MotoristaCommandModel from '../models/MotoristaCommandModel';
import MotoristaResultModel from '../models/Results/MotoristaResultModel';
import { Guid } from "guid-typescript";



@Injectable({
  providedIn: 'root'
})
export class MotoristaService {

  urlBase = "https://localhost:5223/api/"
  constructor(private _http: HttpClient) {
  }

  teste(): Observable<string> {
    return this._http.get<string>(`/api/`);
  }

  BuscarEndereco(cep: string): Observable<EnderecoResultModel> {
    return this._http.get<EnderecoResultModel>(`${this.urlBase}Endereco/${cep}/buscar-endereco`);
  }

  adicionar(model: MotoristaCommandModel): Observable<Object> {
    return this._http.post(`${this.urlBase}motorista/adicionar`, model);
  }

  buscarMotoristas(): Observable<MotoristaResultModel[]> {
    return this._http.get<MotoristaResultModel[]>(`${this.urlBase}motorista/`);
  }

  buscarMotorista(id: Guid):Observable<MotoristaResultModel>{
    return this._http.get<MotoristaResultModel>(`${this.urlBase}motorista/buscar-motorista/${id}`);

  }
}
