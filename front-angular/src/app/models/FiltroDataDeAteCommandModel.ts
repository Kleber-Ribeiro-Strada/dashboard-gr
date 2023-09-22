export default class FiltroDataDeAteCommandModel {

  constructor(de:Date, ate:Date) {
    this.dataSolicitacaoDe = de;
    this.dataSolicitacaoAte = ate;
  }
  dataSolicitacaoDe: Date
  dataSolicitacaoAte: Date
}
