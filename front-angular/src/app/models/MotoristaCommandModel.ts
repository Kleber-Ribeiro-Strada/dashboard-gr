export default class MotoristaCommandModel {
    nome!: string 
    genero!: string 
    dataNascimento!: string 
    cpf!: string 
    rg!: string 
    estadoEmissao!: string 
    dataEmissao!: string 
    nomeMae!: string 
    nomePai!: string 
    telefone!: string 
    email!: string 
    nomeReferencia!: string 
    telefoneReferencia!: string 
    cep!: string
    numero!: string 
    complemento!: string 
    cnh!: Cnh 
}

export class Cnh {
    motoristaId!: string 
    numero!: string 
    estadoEmissao!: string 
    dataVencimento!: string 
    categoria!: string 
    codigoSeguranca!: string 
    dataPrimeiraHabilitacao!: string 
    imagem!: string 
}
