const divparcelas = document.getElementById('DivParcelas')
const table = document.getElementById('tabela')
montanteEmprestimo = document.getElementById('MontantePego')
quantidadeParcelas = document.getElementById('QuantidadeParcela')
const diaCobranca = document.getElementById('DiaCobranca')
juros = document.getElementById('Juros')
clienteSelecionado = document.getElementById('cliente')
valorParcela = document.getElementById('ValorParcela')
mensagemErro = document.getElementById('mensagemErro')
const jurosReal = juros.value / 100

function AparecerParcelas() {
    if (ValidaInputs()) {
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
function GetParcelaValores(numeroParcelas, jurosReal, valorTotalParcela) {
    const Parcelas = [];
    let numeroParcela = 1;
    const valorAntigo = 0;
    const dataAtual = new Date();
    const ParcelaUnitaria = valorTotalParcela / numeroParcelas;

    for (var i = 0; i < numeroParcelas; i++) {
        const valor = CalculaValorParcela(ParcelaUnitaria, jurosReal, valorTotalParcela, valorAntigo);
        const DiadoPagamento = DiaPagamento(dataAtual, i, diaCobranca.value);
        var parcela = new Object();
        if (i == 0) {
            parcela.valorParcela = valorParcela.value;
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
function CalculaValorParcela(valorParcela, jurosReal, valorTotalParcela, valorAntigo) {
    if (valorTotalParcela == valorAntigo || valorAntigo > valorTotalParcela) {
        return (valorAntigo * jurosReal) + valorAntigo;
    } else {
        return (valorParcela * jurosReal) + valorParcela;
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
function SimularEmprestimo() {
    if (ValidaInputs()) {
        if (juros.value != null && juros.value != ""
            && valorParcela.value != null && valorParcela.value != ""
            && montanteEmprestimo.value != null && montanteEmprestimo.value != "") {
            let valorTotalJuros = ValorTotalJuros(montanteEmprestimo.value, jurosReal)
            let sobraJuros = montanteEmprestimo.value * jurosReal
            quantidadeParcelas.value = valorTotalJuros / valorParcela.value
            mensagemErro.style.color = 'black';
            mensagemErro.innerHTML = `*** O total desse financiamento de ${quantidadeParcelas.value} parcelas de ${valorParcela.value} reais é ${valorTotalJuros} reais, sendo ${sobraJuros} de juros. ***`
        }
        else if (juros.value != null && juros.value != ""
            && quantidadeParcelas.value != null && quantidadeParcelas.value != ""
            && montanteEmprestimo.value != null && montanteEmprestimo.value != "") {
            valorParcela.value = ValorPrestacao(montanteEmprestimo.value, juros.value/100, quantidadeParcelas.value)
            let valorTotalJuros = valorParcela.value * quantidadeParcelas.value
            let sobraJuros = valorTotalJuros - montanteEmprestimo.value
            mensagemErro.style.color = 'black';
            mensagemErro.innerHTML = `*** O total desse financiamento de ${quantidadeParcelas.value} 
                                      parcelas de ${valorParcela.value} reais é ${valorTotalJuros} reais, 
                                      sendo ${sobraJuros} de juros. ***`
        }
/*
CASO 2
Nº de meses = 10
Valor da prestação = 86
Valor financiado = 750

Clique em 'Calcular' para obter a taxa de juros mensal.*/
/*
CASO 4
Nº de meses = 24
Taxa de juros mensal = 1,99
Valor da prestação = 935

Clique em 'Calcular' para obter o valor financiado.*/
        else if (juros.value != null && juros.value != ""
            && quantidadeParcelas.value != null && quantidadeParcelas.value != ""
            && valorParcela.value != null && valorParcela.value != "") {
            let valorTotalJuros = parseInt(valorParcela.value) * parseInt(quantidadeParcelas.value)
            montanteEmprestimo.value = 1
            sobraJuros = 1
            mensagemErro.style.color = 'black';
            mensagemErro.innerHTML = `*** O total desse financiamento de ${quantidadeParcelas.value} 
                                      parcelas de ${valorParcela.value} reais é ${valorTotalJuros} reais, 
                                      sendo ${sobraJuros} de juros. ***`
        }
        else {
            mensagemErro.style.color = 'red';
            mensagemErro.innerHTML = '*** Selecione no minimo 3 valores ***';
        }
    }


}
function ValidaInputs() {
    //VERIFICAR SE O CLIENTE FOI SELECIONADO
    if (clienteSelecionado.value == null || clienteSelecionado.value == 0 || clienteSelecionado.value == "") {
        mensagemErro.style.color = 'red';
        mensagemErro.innerHTML = '*** Selecione um cliente para simular um emprestimo ***';
    } else {
        return true
    }
}
function ValorTotalJuros(montanteEmprestimo, juros) {
    return (montanteEmprestimo * juros) + parseInt(montanteEmprestimo)
}
function ValorPrestacao(montanteEmprestimo, juros, quantidadeParcelas) {
    let cont = 1
    let E = 1
    for (let i = 0; i < quantidadeParcelas; i++) {
        cont = cont * (1 + juros)
        E = E + cont
    }
    E = E - cont
    montanteEmprestimo = montanteEmprestimo * cont
    return montanteEmprestimo / E
}
function ResetarEmprestimo() {
    juros.value = null
    quantidadeParcelas.value = null
    valorParcela.value = null
    montanteEmprestimo.value = null
    mensagemErro.hidden = true
}