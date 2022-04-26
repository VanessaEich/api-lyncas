import AtualizarPessoa from "./atualizarPessoa.js";
import PessoaService from "./pessoaService.js";

let nome = document.querySelector("#nome");
let sobrenome = document.querySelector("#sobrenome");
let telefone = document.querySelector("#phone");
let dataNascimento = document.querySelector("#dtnascimento");
let email = document.querySelector("#email3");
let senha = document.querySelector("#senha");
let repetirSenha = document.querySelector("#repetirsenha");
let ativo = document.getElementById("check2");
let cadastro = document.querySelector('#cadastro');
let id = location.href.split("id=")[1]

if (id != undefined) {
    AtualizarPessoa(id, nome, sobrenome, telefone, dataNascimento, email, ativo)
    document.getElementsByClassName("user")[0].innerHTML = "Usuários / Alterar"
    document.getElementsByClassName("cadastrar")[0].innerHTML = "Atualizar"
} else {
    document.getElementsByClassName("user")[0].innerHTML = "Usuários / Cadastrar"
    document.getElementsByClassName("cadastrar")[0].innerHTML = "Cadastrar"
}

cadastro.addEventListener("submit", function (event) {
    event.preventDefault();
    let dados = {
        nome: nome.value,
        sobrenome: sobrenome.value,
        telefone: telefone.value.replace(/\D/gm, ""),
        dataNascimento: dataNascimento.value,
        email: email.value,
        senha: senha.value,
        status: ativo.checked,
        id: id
    }
    if (id == undefined) {
        PessoaService.CadastrarPessoa(dados).then(function (response) {
            if (response.ok) {
                limpaCampos();
                toastr.success("Usuário cadastrado com sucesso!");
            } else {
                response.json().then(error => {
                    toastr.error(error.Errors[0].Message);
                })
            }
        });
    } else {
        PessoaService.AtualizarPessoa(dados).then(function (response) {
            if (response.ok) {
                redirecionaListagem();
            } else {
                response.json().then(error => {
                    toastr.error(error.Errors[0].Message);
                })
            }
            return response.json()
        })
    }
});

function limpaCampos() {
    nome.value = "";
    sobrenome.value = "";
    telefone.value = "";
    dataNascimento.value = ""
    email.value = "";
    senha.value = "";
    repetirSenha.value = "";
    ativo.checked = false;
}

function redirecionaListagem() {
    setTimeout(() => {
        window.location.href = `listagem.html`;
    }, 1500)
    toastr.success("Usuário alterado com sucesso!");
}