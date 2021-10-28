
CREATE TABLE ENDERECO (
	ID INTEGER NOT NULL PRIMARY KEY,
	LOGRADOURO VARCHAR(256) NOT NULL,
	NUMERO INTEGER NOT NULL,
	CEP INTEGER NOT NULL,
	BAIRRO VARCHAR(50) NOT NULL,
	CIDADE VARCHAR(30) NOT NULL,
	ESTADO VARCHAR(20) NOT NULL
)

CREATE TABLE TELEFONE_TIPO (
	ID INTEGER NOT NULL PRIMARY KEY,
	TIPO VARCHAR(10) NOT NULL
)

CREATE TABLE TELEFONE (
	ID INTEGER NOT NULL PRIMARY KEY,
	NUMERO INTEGER NOT NULL,
	DDD INTEGER NOT NULL,
	TIPO INTEGER NOT NULL FOREIGN KEY REFERENCES TELEFONE_TIPO(ID)
)

CREATE TABLE PESSOA (
	ID INTEGER NOT NULL PRIMARY KEY,
	NOME VARCHAR(256) NOT NULL,
	CPF BIGINT NOT NULL,
	ENDERECO INTEGER NOT NULL FOREIGN KEY REFERENCES ENDERECO(ID)
)

CREATE TABLE PESSOA_TELEFONE (
	ID_PESSOA INTEGER NOT NULL,
	ID_TELEFONE INTEGER NOT NULL,
	CONSTRAINT PESSOA_TELEFONE_PK PRIMARY KEY (ID_PESSOA,ID_TELEFONE) ,
	CONSTRAINT PESSOA_TELEFONE_FK01 FOREIGN KEY (ID_PESSOA) REFERENCES PESSOA (ID),
	CONSTRAINT PESSOA_TELEFONE_FK02 FOREIGN KEY (ID_TELEFONE) REFERENCES TELEFONE (ID)
)

INSERT INTO TELEFONE_TIPO (ID,TIPO) VALUES (1,'Celular');
INSERT INTO TELEFONE_TIPO (ID,TIPO) VALUES (2,'Fixo');
INSERT INTO TELEFONE_TIPO (ID,TIPO) VALUES (3,'Trabalho');
INSERT INTO TELEFONE_TIPO (ID,TIPO) VALUES (4,'Familiar');

INSERT INTO TELEFONE (ID, NUMERO, DDD, TIPO) VALUES (1, 991679999, 19, 1);
INSERT INTO TELEFONE (ID, NUMERO, DDD, TIPO) VALUES (2, 32560978, 19, 2);

INSERT INTO ENDERECO (ID, LOGRADOURO, NUMERO, CEP, BAIRRO, CIDADE, ESTADO)
VALUES (1, 'Rua Girassol', 400, 13087420, 'Ch�cara Primavera', 'Campinas', 'SP')
INSERT INTO ENDERECO (ID, LOGRADOURO, NUMERO, CEP, BAIRRO, CIDADE, ESTADO)
VALUES (2, 'Rua das Hort�ncias', 300, 13087420, 'Ch�cara Primavera', 'Campinas', 'SP')
