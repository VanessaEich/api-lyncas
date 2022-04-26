import PessoaService from "./pessoaService.js";

export default function AtualizarPessoa(id, nome, sobrenome, telefone, dataNascimento, email, ativo) {

    PessoaService.ObterPorId(id).then(usuario => {
        if (usuario == null) {
            toastr.error("Usuário não encontrado!");
            setTimeout(() => {
                window.location.href = 'listagem.html';
            }, 3000)
        } else {
            nome.value = usuario.nome
            sobrenome.value = usuario.sobrenome
            telefone.value = ConverterTelefone(usuario.telefone)
            dataNascimento.value = usuario.dataNascimento.split("T")[0]
            email.value = usuario.email
            ativo.checked = usuario.status
        }
    })

    function ConverterTelefone(telefone) {
        const novoTelefone = "(" + telefone.slice(0, 2) + ") " + (telefone.length == 11 ? telefone.slice(2, 7) : telefone.slice(2, 6)) + "-" + (telefone.length == 11 ? telefone.slice(7, 11) : telefone.slice(6, 10))
        return novoTelefone;
    }

}