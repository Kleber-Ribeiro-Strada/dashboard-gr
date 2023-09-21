import { Guid } from "guid-typescript";

export default class ProprietarioCommandModel {
  id: Guid
  nome: string
  cpfCnpj: string
  telefone: string
  cep:string
  numero:string
  rua:string
  bairro:string
  cidade:string
  estado:string
  complemento:string

}
