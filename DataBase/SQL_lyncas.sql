CREATE DATABASE lyncas;

CREATE TABLE pessoa
(
	idPessoa int IDENTITY (1,1) PRIMARY KEY NOT NULL,
	nome varchar(100) NOT NULL,
	sobrenome varchar (100) NOT NULL,
	email varchar(50) NOT NULL,
	telefone varchar(14) NOT NULL,
	dataNascimento date NOT NULL,
);

CREATE TABLE autenticacao
(
	id int IDENTITY (1,1) PRIMARY KEY NOT NULL,
	idPessoa int NOT NULL,
	senha varchar(50) NOT NULL,
	status bit NOT NULL,
);

ALTER TABLE autenticacao
   ADD CONSTRAINT FK_pessoa_autenticacao FOREIGN KEY (idPessoa)
      REFERENCES pessoa (idPessoa)
      ON DELETE CASCADE
      ON UPDATE CASCADE;

INSERT INTO pessoa (nome, sobrenome, email, telefone, dataNascimento) 
VALUES ('João', 'Silva', 'joaosilva@gmail.com', '(47)98765-4449', '12/03/1989');
INSERT INTO autenticacao ( idPessoa, senha, status )
VALUES (SCOPE_IDENTITY(), 'senhaboa12', '1');

INSERT INTO pessoa (nome, sobrenome, email, telefone, dataNascimento) 
VALUES ('Maria', 'Souza', 'maria.souza@hotmail.com', '(41)3425-7645', '30/07/1993')
INSERT INTO autenticacao ( idPessoa, senha, status )
VALUES (SCOPE_IDENTITY(), 'senhaforte1', '1');

INSERT INTO pessoa (nome, sobrenome, email, telefone, dataNascimento) 
VALUES ('Renata', 'Almeida', 'renata.almeida@gmail.com', '(47)9995436275', '02/05/1985')
INSERT INTO autenticacao ( idPessoa, senha, status )
VALUES (SCOPE_IDENTITY(), '25senhaforte', '0');

INSERT INTO pessoa (nome, sobrenome, email, telefone, dataNascimento) 
VALUES ('José', 'Rocha', 'joserocha@hotmail.com', '(54)99123-4567', '15/12/2000')
INSERT INTO autenticacao ( idPessoa, senha, status )
VALUES (SCOPE_IDENTITY(), '654senha', '0');

SELECT*FROM pessoa;
SELECT*FROM autenticacao;

UPDATE pessoa
SET telefone = '(47)99909-4563'
WHERE idPessoa = 3;

UPDATE autenticacao
SET senha = 'mudeiasenha234'
WHERE idPessoa = 2;

DELETE FROM pessoa WHERE idPessoa='1';

SELECT pessoa.idPessoa, pessoa.nome, pessoa.sobrenome FROM pessoa 
INNER JOIN autenticacao 
ON pessoa.idPessoa = autenticacao.idPessoa
WHERE status = '1';


