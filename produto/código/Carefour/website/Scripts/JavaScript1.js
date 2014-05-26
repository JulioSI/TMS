
function removerProduto(link) {

    var result = confirm("Deseja excluir esse produto?");
    if (result) {
        var row = link.parentNode.parentNode;
        row.parentNode.removeChild(row);
        return true;
    } else {
        return false;
    }
}

function verificarDadosCliente() {

    var mensagemErro = "";

    if (document.getElementById("nome").value == "")
        mensagemErro = "Informe o nome do cliente";

    else if (document.getElementById("email").value == "")
        mensagemErro = "Informe o email";

    else if (document.getElementById("senha").value == "")
        mensagemErro = "Informe a senha";

    else if (document.getElementById("dataNascimento").value == "")
        mensagemErro = "Informe a data de nascimento";

    else if (document.getElementById("sexo").value == "")
        mensagemErro = "Informe o sexo";

    else if (document.getElementById("endereco").value == "")
        mensagemErro = "Informe o endereco";

    else if (document.getElementById("telefone").value == "")
        mensagemErro = "Informe o telefone";

    else if (document.getElementById("telefone").value.length > 11)
        mensagemErro = "É permitido no maximo 11 digitos numericos para o telefone!";

    else if (document.getElementById("senha").value.length > 6)
        mensagemErro = "É permitido no maximo 6 digitos para senha!";

    if (mensagemErro == "") {
        return true;
    }
    else {
        alert(mensagemErro);
        return false;
    }



}

function verificaNumero(e) {
    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        return false;
    }
}





