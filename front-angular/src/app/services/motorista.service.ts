import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { EnderecoResultModel } from '../models/EnderecoResultModel';


@Injectable({
  providedIn: 'root'
})
export class MotoristaService {

  urlBase = "https://localhost:5223/api/"
  constructor(private _http: HttpClient) {
  }

  teste():Observable<string> {
    return this._http.get<string>(`/api/`);
  }

  BuscarEndereco(cep:string):Observable<EnderecoResultModel>{
    return this._http.get<EnderecoResultModel>(`${this.urlBase}Endereco/${cep}/buscar-endereco`);
  }
}
