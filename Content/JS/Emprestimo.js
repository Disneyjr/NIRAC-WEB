const divparcelas = document.getElementById('DivParcelas')
const table = document.getElementById('tabela')
montanteEmprestimo = document.getElementById('MontantePego')
quantidadeParcelas = document.getElementById('QuantidadeParcela')
diaCobranca = document.getElementById('DiaCobranca')
juros = document.getElementById('Juros')
clienteSelecionado = document.getElementById('cliente')
valorParcela = document.getElementById('ValorParcela')
mensagemErro = document.getElementById('mensagemErro')
TotalJuros = document.getElementById('valorTotalJuros')
const url = 'https://www.api.nirac.com.br/api/Emprestimo/CalculaParcela/' + montanteEmprestimo.value + '/' + quantidadeParcelas.value + '/' + juros.value;
parcelaValor = 0;
function getData(ajaxUrl) {
    return $.ajax({
        url: ajaxUrl,
        contentType: "application/json",
        dataType: 'json',
        success: function (result) {
            console.log(result)
        },
        done: function (resp) {
            console.log(resp)
        }
    })
}
async function AparecerParcelas() {
    if (ValidaInputs()) {
        try {
            const res = await getData(url)
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
                    ${GetTds(res)}
                    </tbody>`;
                table.appendChild(tabela);
            } else {
                AtualizaBody()
            }
        } catch (err) {
            console.log("ERROR: " + err);
        }
    }
}
function GetTds(res) {
    const Parcelas = GetParcelaValores(quantidadeParcelas.value, res);
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
function GetParcelaValores(numeroParcelas, res) {
    const Parcelas = [];
    let numeroParcela = 1;
    const dataAtual = new Date();

    for (var i = 0; i < numeroParcelas; i++) {
        const DiadoPagamento = DiaPagamento(dataAtual, i, diaCobranca.value);
        var parcela = new Object();
        parcela.valorParcela = res;
        parcela.numeroParcela = numeroParcela;
        parcela.DiaPagamento = DiadoPagamento;
        Parcelas.push(parcela);
        numeroParcela++;
    }
    return Parcelas;
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
function ResetarEmprestimo() {
    juros.value = null
    quantidadeParcelas.value = null
    valorParcela.value = null
    montanteEmprestimo.value = null
    mensagemErro.hidden = true
}
function ValidaInputs() {
    //VERIFICAR SE O CLIENTE FOI SELECIONADO
    if (clienteSelecionado.value == null || clienteSelecionado.value == 0 || clienteSelecionado.value == "") {
        mensagemErro.style.color = 'red';
        mensagemErro.innerHTML = '*** Selecione um cliente para simular um emprestimo ***';
    } else if (diaCobranca.value == null || diaCobranca.value == 0 || diaCobranca.value == "") {
        mensagemErro.style.color = 'red';
        mensagemErro.innerHTML = '*** Informe o dia da cobrança para simular um emprestimo ***';
    } else if (montanteEmprestimo.value == null || montanteEmprestimo.value == 0 || montanteEmprestimo.value == "") {
        mensagemErro.style.color = 'red';
        mensagemErro.innerHTML = '*** Informe o montante pego para simular um emprestimo ***';
    } else if (quantidadeParcelas.value == null || quantidadeParcelas.value == 0 || quantidadeParcelas.value == "") {
        mensagemErro.style.color = 'red';
        mensagemErro.innerHTML = '*** Informe o dia da cobrança para simular um emprestimo ***';
    } else if (juros.value == null || juros.value == 0 || juros.value == "") {
        mensagemErro.style.color = 'red';
        mensagemErro.innerHTML = '*** Informe o juros para simular um emprestimo ***';
    } else {
        return true;
    }
}