import { Guid } from "guid-typescript"

export default class VeiculoCommand {
  id: Guid
  tipo: string
  placa: string
  chassi: string
  renavam: string
  dataLicenciamento: Date
  cor: string
  marca: string
  modelo: string
  anoFabricacao: Number
  anoModelo: number
  estado: string
}
