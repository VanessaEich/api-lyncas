//validação nome
function validarNome() {
  let validacaoNome = "validacaoNome";
  let nome = cadastro.nome.value;

  if (nome.length < 3) {
    document.getElementsByClassName(validacaoNome)[0].innerHTML = "Preencha o campo nome"
    document.getElementById("btnCadastrar").disabled = true;
    return false;
  } else {
    document.getElementsByClassName(validacaoNome)[0].innerHTML = ""
    document.getElementById("btnCadastrar").disabled = false;
    return true;
  }
}

//validação sobrenome
function validarSobrenome() {
  let validacaoSobrenome = "validacaoSobrenome";
  let sobrenome = cadastro.sobrenome.value;

  if (sobrenome.length < 3) {
    document.getElementsByClassName(validacaoSobrenome)[0].innerHTML = "Preencha o campo sobrenome"
    document.getElementById("btnCadastrar").disabled = true;
    return false;
  } else {
    document.getElementsByClassName(validacaoSobrenome)[0].innerHTML = ""
    document.getElementById("btnCadastrar").disabled = false;
    return true;
  }
}

//mascara telefone
function mascaraTelefone(o, f) {
  setTimeout(function () {
    var v = mphone(o.value);
    if (v != o.value) {
      o.value = v;
    }
  }, 1);
}

function mphone(v) {
  var r = v.replace(/\D/g, "");
  r = r.replace(/^0/, "");
  if (r.length > 10) {
    r = r.replace(/^(\d\d)(\d{5})(\d{4}).*/, "($1) $2-$3");
  } else if (r.length > 5) {
    r = r.replace(/^(\d\d)(\d{4})(\d{0,4}).*/, "($1) $2-$3");
  } else if (r.length > 2) {
    r = r.replace(/^(\d\d)(\d{0,5})/, "($1) $2");
  } else {
    r = r.replace(/^(\d*)/, "($1");
  }
  return r;
}

//validação telefone
function validarTelefone() {
  let validacaoTelefone = "validacaoTelefone";
  let phone = cadastro.phone.value;

  if (phone.length < 14) {
    document.getElementsByClassName(validacaoTelefone)[0].innerHTML = "Telefone deve conter no mínimo 10 números"
    document.getElementById("btnCadastrar").disabled = true;
    return false;
  } else {
    document.getElementsByClassName(validacaoTelefone)[0].innerHTML = ""
    document.getElementById("btnCadastrar").disabled = false;
    return true;
  }
}

//validação data de nascimento
function validarData() {
  let validacaoData = "validacaoData";
  let data = cadastro.dtnascimento.value;

  if (data.length < 1) {
    document.getElementsByClassName(validacaoData)[0].innerHTML = "Preencha o campo data de nascimento"
    document.getElementById("btnCadastrar").disabled = true;
    return false;
  } else {
    document.getElementsByClassName(validacaoData)[0].innerHTML = ""
    document.getElementById("btnCadastrar").disabled = false;
    return true;
  }
}

//validação email
function validarEmail() {
  let validacaoEmail = "validacaoEmail"
  let email = cadastro.email.value;
  let regex = /^[\w+.]+@\w+\.\w{2,}(?:\.\w{2})?$/;

  if (regex.test(email)) {
    document.getElementsByClassName(validacaoEmail)[0].innerHTML = ""
    document.getElementById("btnCadastrar").disabled = false;
    return true;
  } else {
    document.getElementsByClassName(validacaoEmail)[0].innerHTML = "E-mail deve conter @ e . "
    document.getElementById("btnCadastrar").disabled = true;
    return false;
  }
}


//validação senha
function validarSenha() {
  let validacaoSenha = "validacaoSenha";
  let senha = cadastro.senha.value;
  let repetir = cadastro.repetirsenha.value;
  let id = location.href.split("id=")[1];
  if (id != undefined && senha.length == 0 && repetir.length == 0) {
    document.getElementsByClassName(validacaoSenha)[0].innerHTML = ""
    document.getElementById("btnCadastrar").disabled = false;
    return true;
  }
  let regex = /^(?=(?:.*?[A-Z]){0})(?=(?:.*?[0-9]){1})(?=(?:.*?[!@#$%*()_+^&}{:;?.]){0})(?!.*\s)[0-9a-zA-Z!@#$%;*(){}_+^&]*$/;

  if (senha.length < 6) {
    document.getElementsByClassName(validacaoSenha)[0].innerHTML = "Senha deve conter no minímo 6 dígitos e pelo menos um número"
    document.getElementById("btnCadastrar").disabled = true;
    return false;
  } else if (!regex.test(senha)) {
    document.getElementsByClassName(validacaoSenha)[0].innerHTML = "Senha deve conter no mínimo 1 número"
    document.getElementById("btnCadastrar").disabled = true;
    return false;
  } else {
    document.getElementsByClassName(validacaoSenha)[0].innerHTML = ""
    document.getElementById("btnCadastrar").disabled = false;
    return true;
  }
}

//validação confirmação da senha
function repetirSenha() {
  let senha = cadastro.senha.value;
  let validacaoSenha = "validacaoSenha";
  let repeticaoSenha = "repeticaoSenha";
  let id = location.href.split("id=")[1];
  let repetir = cadastro.repetirsenha.value;

  if (id != undefined && repetir.length == 0 && senha.length == 0) {
    document.getElementsByClassName(validacaoSenha)[0].innerHTML = ""
    document.getElementById("btnCadastrar").disabled = false;
    return true;
  }

  if (repetir != senha) {
    document.getElementsByClassName(repeticaoSenha)[0].innerHTML = "Senha é diferente da informada"
    document.getElementById("btnCadastrar").disabled = true;
    return false;
  } else if (repetir.length < 1) {
    document.getElementsByClassName(repeticaoSenha)[0].innerHTML = "Campo obrigatório"
    document.getElementById("btnCadastrar").disabled = true;
    return false;
  } else {
    document.getElementsByClassName(repeticaoSenha)[0].innerHTML = ""
    document.getElementById("btnCadastrar").disabled = false;
    return true;
  }
}

//validação todos os campos são obrigatórios
function validarFinal() {
  validarNome();
  validarSobrenome();
  validarTelefone();
  validarData();
  validarEmail();
  if (!validarSenha()) {
    return;
  }
  if (!repetirSenha()) {
    return;
  }
  let validarFinal = "validarFinal";
  let nome = cadastro.nome.value;
  let sobrenome = cadastro.sobrenome.value;
  let telefone = cadastro.phone.value;
  let data = cadastro.dtnascimento.value;
  let email = cadastro.email.value;
  let senha = cadastro.senha.value;
  let repetir = cadastro.repetirsenha.value;

  let id = location.href.split("id=")[1]
  if (id == undefined) {
    if (senha.length < 1 || repetir.length < 1) {
      document.getElementsByClassName(validarFinal)[0].innerHTML = "Atenção! Todos os campos são obrigatórios!"
      document.getElementById("btnCadastrar").disabled = true;
      return false;
    }
  }

  if (nome.length < 1 || sobrenome.length < 1 || telefone.length < 14 || data.length < 1 || email.length < 1) {
    document.getElementsByClassName(validarFinal)[0].innerHTML = "Atenção! Todos os campos são obrigatórios!"
    document.getElementById("btnCadastrar").disabled = true;
    return false;
  } else {
    document.getElementsByClassName(validarFinal)[0].innerHTML = ""
    document.getElementById("btnCadastrar").disabled = false;
    return true;
  }
}