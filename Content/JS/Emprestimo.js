const divparcelas = document.getElementById('DivParcelas');
const table = document.getElementById('tabela');
const montanteEmprestimo = document.getElementById('TotalEmprestimo');
const quantidadeParcelas = document.getElementById('QuantidadeParcela');
const diaCobranca = document.getElementById('DiaCobranca');
const juros = document.getElementById('PorcentagemJuros');

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
                            <td><input style="border:none; color:black;" disabled name="numeroParcela" value="${parcela.numeroParcela}"/></td>
                            <td><input style="border:none; color:black;" disabled name="valorParcela" value="RS: ${parcela.valorParcela}"/></td>
                            <td><input style="border:none; color:black;" disabled name="DiaPagamento" value="${parcela.DiaPagamento}"/></td>
                        </tr>`)
    })
    return trs;
}
function GetParcelaValores(numeroParcelas, juros, valorTotalParcela) {
    const Parcelas = [];
    let numeroParcela = 1;
    const valorAntigo = 0;
    const dataAtual = new Date();
    const valorParcela = valorTotalParcela / numeroParcelas;
    const jurosReal = juros / 100;
    for (var i = 0; i < numeroParcelas; i++) {
        const valor = CalculaValorParcela(valorParcela, jurosReal, valorTotalParcela, valorAntigo);
        const DiadoPagamento = DiaPagamento(dataAtual, i, diaCobranca.value);
        var parcela = new Object();
        if (i == 0) {
            parcela.valorParcela = valorParcela;
        } else {
            parcela.valorParcela = valor;
        }
        parcela.numeroParcela = numeroParcela;
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
function DiaPagamento(dataAtual, iteracao, diaCobranca) {
    let dataFormatada;
    if (iteracao > 0) {
        dataFormatada = ((diaCobranca)) + "/" + ((dataAtual.getMonth() + iteracao + 1)) + "/" + dataAtual.getFullYear();
    } else {
        dataFormatada = ((diaCobranca)) + "/" + ((dataAtual.getMonth() + 1)) + "/" + dataAtual.getFullYear();
    }
    return dataFormatada;
}
function AtualizaBody() {
    const body = document.getElementById('tbody');
    body.innerHTML = GetTds();
}
function EsconderParcelas() {
    divparcelas.hidden = true;
}