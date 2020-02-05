Funcionalidade: Cadastro de cliente
	Como um vendedor
	Eu quero cadastrar as informações do meu cliente
	Para poder entrar em contato com ele no futuro

@mytag
Cenário: Cadastro de cliente com dados válidos
	Dado que o vendedor informe um nome válido
	E informe um e-mail válido
	E informe uma data de nascimento maior ou igual a 18 anos
	Quando for solicitado o cadastro
	Então o cliente deve ser criado

@mytag
Cenário: Cadastro de cliente com nome vazio
	Dado que o vendedor informe um nome vazio
	E informe um e-mail válido
	E informe uma data de nascimento maior ou igual a 18 anos
	Quando for solicitado o cadastro
	Então deve ser solicitado informar o nome

@mytag
Cenário: Cadastro de cliente com e-mail vazio
	Dado que o vendedor informe um nome válido
	E informe um e-mail vazio
	E informe uma data de nascimento maior ou igual a 18 anos
	Quando for solicitado o cadastro
	Então deve ser solicitado informar o e-mail

@mytag
Cenário: Cadastro de cliente com e-mail inválido
	Dado que o vendedor informe um nome válido
	E informe um e-mail inválido
	E informe uma data de nascimento maior ou igual a 18 anos
	Quando for solicitado o cadastro
	Então deve retornar que o e-mail esta inválido

@mytag
Cenário: Cadastro de cliente menor de 18 anos
	Dado que o vendedor informe um nome válido
	E informe um e-mail válido
	E informe uma data de nascimento menor que 18 anos
	Quando for solicitado o cadastro
	Então deve retornar que o cliente precisa ter 18 anos ou mais