import { Guid } from "guid-typescript";

export default class SolicitarAnaliseCommandModel {
  motoristaId: Guid
  proprietario: ProprietarioSolicitarAnaliseCommandModel = new ProprietarioSolicitarAnaliseCommandModel();
  veiculos: VeiculoSolicitarAnaliseCommandModel[] = []
}

export class ProprietarioSolicitarAnaliseCommandModel {
  cpfCnpj: string
  nome: string
  cep: string
  codigoCidade: string
  nomeCidade: string
  rua: string
  numero: string
  complemento: string
  bairro: string
  estado: string
  telefone: string
}

export class VeiculoSolicitarAnaliseCommandModel {
  tipo: string
  placa: string
  chassi: string
  renavam: string
  rntrc: string
  dataLicenciamento: string
  cor: string
  marca: string
  modelo: string
  anoFabricacao: number
  anoModelo: number
  estado: string
  codigoCidade: string
  imagemCrlv: string
}
