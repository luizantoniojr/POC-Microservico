Funcionalidade: Cliente
	Como um vendedor
	Eu quero cadastrar as informações do meu cliente
	Para poder entrar em contato com ele no futuro

@mytag
Cenário: Cadastrar cliente com dados corretos
	Dado que deseja	cadastrar o senhor Samuel
	E informe Nome
	E informe Email
	E informe Data de Nascimento
	Quando entrar estas informacoes no cadastro 
	Então o cliente deve ser criado