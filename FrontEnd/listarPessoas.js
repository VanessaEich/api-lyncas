import PessoaService from "./pessoaService.js";

const tabela = document.querySelector("tbody");

function ListarPessoas(Pessoas) {
    Pessoas.forEach(pessoa => {
        const contador = tabela.rows.length;
        const linha = tabela.insertRow(contador);

        const colunaNome = linha.insertCell(0);
        const colunaTelefone = linha.insertCell(1);
        const colunaEmail = linha.insertCell(2);
        const colunaDataNascimento = linha.insertCell(3);
        const colunaStatus = linha.insertCell(4);
        const colunaAcoes = linha.insertCell(5);

        let id = pessoa.idPessoa;
        colunaNome.innerHTML = `<div class="dnome">
        <div class="usuario"><img src="img/usuario.jpg" alt="usuario" id='usuario'></div>                
        <h6 class="nometb">${pessoa.nome} ${pessoa.sobrenome} </h6>
          </div>`;


        pessoa.telefone = ConverterTelefone(pessoa.telefone)
        colunaTelefone.innerHTML = pessoa.telefone;
        colunaEmail.innerHTML = pessoa.email;
        let dataNascimento = new Date(pessoa.dataNascimento);
        colunaDataNascimento.innerHTML = new Intl.DateTimeFormat('pt-Br').format(dataNascimento);

        if (pessoa.status) {
            colunaStatus.innerHTML = `<p class="btnativo">Ativo</p>`;
        } else {
            colunaStatus.innerHTML = `<p class="btInativo">Inativo</p>`
        }

        colunaAcoes.innerHTML = ` <div class="dacoes">
        <i class='bx bx-edit' id="${id}"></i>
        <i class='bx bxs-trash-alt' id="${id}"></i>
        </div>`

        function ConverterTelefone(telefone) {
            const novoTelefone = "(" + telefone.slice(0, 2) + ") " + (telefone.length == 11 ? telefone.slice(2, 7) : telefone.slice(2, 6)) + "-" + (telefone.length == 11 ? telefone.slice(7, 11) : telefone.slice(6, 10))
            return novoTelefone;
        }

    })
    const botaoEditar = document.querySelectorAll(".bx-edit");
    botaoEditar.forEach(botao => {
        botao.addEventListener("click", () => {
            window.location.href = `cadastro.html?id=${botao.id}`
        })
    })

    const botaoDeletar = document.querySelectorAll(".bxs-trash-alt");
    botaoDeletar.forEach(botao => {
        botao.addEventListener("click", () => {
            Swal.fire({
                    title: 'Deseja excluir esse usuário?',
                    showCancelButton: true,
                    confirmButtonText: 'Deletar',
                    cancelButtonText: 'Cancelar',
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                })
                .then((result) => {
                    if (result.isConfirmed) {
                        PessoaService.DeletarPessoa(botao.id).then(Resposta => {
                            if (Resposta == null) {
                                var usuarioLogado = RetornaUsuarioLogado();
                                if (usuarioLogado == null) {
                                    Sair();
                                } else if (botao.id == usuarioLogado.idPessoa) {
                                    Sair();
                                }
                                toastr.success("Usuário deletado com sucesso");
                                for (let i = 0; i <= tabela.rows.length - 1; i++) {
                                    let row = tabela.rows[i];
                                    if (row.cells[5].innerHTML.includes(botao.id)) {
                                        tabela.deleteRow(row.rowIndex - 1);
                                    }
                                }
                            } else {
                                toastr.error(Resposta.detail);
                            }
                        });
                    } else {

                    }
                })
        })
    })

}

PessoaService.BuscarPessoas().then(Resposta => {
        if (Resposta.ok) {
            return Resposta.json();
        }
        Resposta.json().then(error => {
            if (error.Errors[0].Logref == 401) {
                Sair();
            }
            toastr.error(error.Errors[0].Message);

        })
        return null;
    })
    .then(Pessoas => {
        if (Pessoas != null) {
            ListarPessoas(Pessoas)
        }
    })