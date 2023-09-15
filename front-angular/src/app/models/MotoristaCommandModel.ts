export class MotoristaCommandModel {
    nome: string | undefined
    genero: string | undefined
    dataNascimento: string | undefined
    cpf: string | undefined
    rg: string | undefined
    estadoEmissao: string | undefined
    dataEmissao: string | undefined
    nomeMae: string | undefined
    nomePai: string | undefined
    telefone: string | undefined
    email: string | undefined
    nomeReferencia: string | undefined
    telefoneReferencia: string | undefined
    cep: string | undefined
    numero: string | undefined
    complemento: string | undefined
    cnh: Cnh | undefined
}

export class Cnh {
    motoristaId: string | undefined
    numero: string | undefined
    estadoEmissao: string | undefined
    dataVencimento: string | undefined
    categoria: string | undefined
    codigoSeguranca: string | undefined
    dataPrimeiraHabilitacao: string | undefined
    imagem: string | undefined
}
