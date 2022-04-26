function ValidarLogin() {
    let usuarioLogado = JSON.parse(localStorage.getItem("usuarioLogado"));
    if (usuarioLogado) {

        document.getElementsByClassName("nome")[0].innerHTML = usuarioLogado.nome + " " + usuarioLogado.sobrenome;
    } else {
        Sair();
    }
}

function RetornaUsuarioLogado() {
    let usuarioLogado = JSON.parse(localStorage.getItem("usuarioLogado"));
    return usuarioLogado;
}

ValidarLogin();

function Sair() {
    localStorage.removeItem("usuarioLogado");
    localStorage.removeItem("data");
    window.location.href = "login.html"
}