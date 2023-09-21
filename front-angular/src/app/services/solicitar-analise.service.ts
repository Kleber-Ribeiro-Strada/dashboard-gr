import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import SolicitarAnaliseCommandModel from '../models/SolicitarAnaliseCommandModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SolicitarAnaliseService {
  urlBase = "https://localhost:5223/api/"

  constructor(private _http: HttpClient) { }

  adicionar(model: SolicitarAnaliseCommandModel): Observable<Object> {
    return this._http.post(`${this.urlBase}analise/solicitar-analise`, model);
  }

}
