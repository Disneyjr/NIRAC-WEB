﻿const divparcelas = document.getElementById('DivParcelas');
const table = document.getElementById('tabela');
const montanteEmprestimo = document.getElementById('Emprestimo.TotalEmprestimo');
const quantidadeParcelas = document.getElementById('Emprestimo.QuantidadeParcela');
const diaCobranca = document.getElementById('Emprestimo.DiaCobranca');
const juros = document.getElementById('Emprestimo.PorcentagemJuros');

function AparecerParcelas() {
    divparcelas.hidden = false;
    var existTable = document.getElementsByClassName('table');
    if (existTable.length == 0) {
        const tabela = document.createElement("table");
        tabela.classList.add('table');
        tabela.innerHTML = `<thead>
                        <tr>
                            <th scope="col">N° Parcelas</th>
                            <th scope="col">Valor</th>
                            <th scope="col">Dia do Pagamento</th>
                        </tr>
                    </thead>
                    <tbody id="tbody">
                    ${GetTds()}
                    </tbody>`;
        table.appendChild(tabela);
    } else {
        AtualizaBody()
    }
    
}
function GetTds() {
    const Parcelas = GetParcelaValores(quantidadeParcelas.value, juros.value, montanteEmprestimo.value);
    const trs = [];
    Parcelas.forEach(function (parcela) {
        trs.push(`<tr>
                            <td scope="row">${parcela.numero}</td>
                            <td>RS: ${parcela.valorParcela}</td>
                            <td>${parcela.DiaPagamento}</td>
                        </tr>`)
    })
    return trs;
}
function GetParcelaValores(numeroParcelas, juros, valorTotalParcela) {
    const Parcelas = [];
    let numeroParcela = 1;
    const valorAntigo = 0;
    const dataAntiga = new Date();
    const valorParcela = valorTotalParcela / numeroParcelas;
    const jurosReal = juros / 100;
    for (var i = 0; i < numeroParcelas; i++) {
        const valor = CalculaValorParcela(valorParcela, jurosReal, valorTotalParcela, valorAntigo);
        const DiadoPagamento = DiaPagamento(new Date(), dataAntiga, diaCobranca.value);
        console.log(valor);
        var parcela = new Object();
        if (i == 0) {
            parcela.valorParcela = valorParcela;
        } else {
            parcela.valorParcela = valor;
        }
        parcela.numero = numeroParcela;
        parcela.DiaPagamento = DiadoPagamento;
        Parcelas.push(parcela);
        numeroParcela++;
    }
    return Parcelas;
}
function CalculaValorParcela(valorParcela, juros, valorTotalParcela, valorAntigo) {
    if (valorTotalParcela == valorAntigo || valorAntigo > valorTotalParcela) {
        return (valorAntigo * juros) + valorAntigo;
    } else {
        return (valorParcela * juros) + valorParcela;
    }
}
function AtualizaBody() {
    const body = document.getElementById('tbody');
    body.innerHTML = GetTds();
}
function DiaPagamento(dataAtual, dataAntiga, diaCobranca) {
    let dataFormatada;
    if (ExisteSegundoMes(dataAtual, dataAntiga) === true) {
        dataFormatada = ((diaCobranca)) + "/" + ((dataAtual.getMonth() + 2)) + "/" + dataAtual.getFullYear();
    } else {
        dataFormatada = ((diaCobranca)) + "/" + ((dataAtual.getMonth() + 1)) + "/" + dataAtual.getFullYear();
    }
    dataAntiga = dataAtual;
    dataAntiga.setMonth(dataAntiga.getMonth() + "1");
    return dataFormatada;
}
function ExisteSegundoMes(dataAtual, dataAntiga) {
    if (dataAtual > dataAntiga) {
        return true;
    } else {
        return false;
    }
}
function EsconderParcelas() {
    divparcelas.hidden = true;
}