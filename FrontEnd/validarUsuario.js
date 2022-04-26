import PessoaService from "./pessoaService.js";

let email = document.querySelector("#email");
let senha = document.querySelector("#password");
let formulario = document.querySelector("#formulario");

formulario.addEventListener("submit", function (event) {
    event.preventDefault();

    let validacao = {
        email: email.value,
        senha: senha.value
    }

    PessoaService.ValidarUsuario(validacao).then(function (response) {
        if (response.ok) {
            response.json().then(usuario => {
                toastr.success("Usuário logado com sucesso!");
                const loginDados = btoa(`${email.value}:${senha.value}`)
                localStorage.setItem('data', JSON.stringify(`Basic ${loginDados}`));
                localStorage.removeItem("usuarioLogado");
                localStorage.setItem("usuarioLogado", JSON.stringify(usuario));
                window.location.href = 'dashboard.html';
            });
        } else {

            response.json().then(error => {
                toastr.error(error.Errors[0].Message);
            })
        }
    });
})