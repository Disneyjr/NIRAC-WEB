const divparcelas = document.getElementById('DivParcelas');
const simulacaoparcelas = document.getElementById('SimulacaoParcelas');

function AparecerParcelas() {
    divparcelas.hidden = false;
    SimularParcelas();
}
function EsconderParcelas() {
    divparcelas.hidden = true;
}

function SimularParcelas() {
    const montanteEmprestimo = document.getElementById('Emprestimo.TotalEmprestimo');
    const quantidadeParcelas = document.getElementById('Emprestimo.QuantidadeParcela');
    const juros = document.getElementById('Emprestimo.PorcentagemJuros');
    console.log(montanteEmprestimo.value);
    console.log(quantidadeParcelas.value);
    console.log(juros.value);
}