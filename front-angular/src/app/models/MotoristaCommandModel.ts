export default class MotoristaCommandModel {
    nome!: string
    genero!: string
    dataNascimento!: Date
    cpf!: string
    rg!: string
    estadoEmissao!: string
    dataEmissao!: Date
    nomeMae!: string
    nomePai!: string
    telefone!: string
    email!: string
    nomeReferencia!: string
    telefoneReferencia!: string
    cep!: string
    codigoCidade:string
    nomeCidade:string
    rua:string
    bairro:string
    estado:string
    numero!: string
    complemento!: string
    cnh: CnhCommandModel = new CnhCommandModel()
}

export class CnhCommandModel {
    motoristaId!: string
    numero!: string
    estadoEmissao!: string
    dataVencimento!: Date
    categoria!: string
    codigoSeguranca!: string
    dataPrimeiraHabilitacao!: Date
    imagem!: string
}
