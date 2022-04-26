import ApiUrl from "./apiUrl.js";

export default class PessoaService {
    static url = `${ApiUrl.baseString}Pessoas/`;
    static url2 = `${ApiUrl.baseString}Login/`;

    static async DeletarPessoa(id) {
        fetch(`${this.url}${id}`, {
                method: 'DELETE',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                    'Authorization': JSON.parse(localStorage.getItem('data')),
                }
            })
            .then(Resposta => {
                if (Resposta.ok) {
                    return null;
                }
                return Resposta.json()
            });
    }

    static async ObterPorId(id) {
        return fetch(`${this.url}${id}`, {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                    'Authorization': JSON.parse(localStorage.getItem('data')),
                }
            })
            .then(resposta => {
                if (!resposta.ok) {
                    return null;
                }
                return resposta.json()
            })
    }

    static async CadastrarPessoa(dados) {
        return fetch(`${this.url}cadastro`, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'Authorization': JSON.parse(localStorage.getItem('data')),
            },
            body: JSON.stringify(dados)
        });
    }

    static async AtualizarPessoa(dados) {
        return fetch(`${this.url}${dados.id}`, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'Authorization': JSON.parse(localStorage.getItem('data')),
            },
            body: JSON.stringify(dados)
        });
    }

    static async BuscarPessoas() {
        return fetch(`${this.url}todos`, {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'Authorization': JSON.parse(localStorage.getItem('data'))
            }
        });
    }

    static async ValidarUsuario(validacao) {
        return fetch(`${this.url2}login`, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(validacao)
        })
    }

}