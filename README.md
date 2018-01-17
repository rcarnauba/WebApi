# FCamaraWebapi

Este projeto foi desenvolvido utilizando WebApi Core 

Os pre-requisitos para executar esse projeto são o Visual studio e sqlexpress

1 - ) Abrir o sql express
2 - ) Executar o script scriptDataBase.txt, será criado o banco de dados com o nome de Fcamara
3 - ) Executar o script scriptTables.txt, será criadas as tabelas e inseridos os dados de produtos e um usuário para fazer o login na aplicação.
4 - ) No projeto FCamara.DAl na classe banco de dados , linha 11, por favor altere o nome do datasource para a sua instancia do sqlexpress.

5 - ) Compile o projeto. Deve levar algum tempo pois nesse momente estão sendo baixadas e instaladas as dependencias.

6 - Execute o projeto FCamara.API. Pode ser em mode debug mesmo. Botão direito, debug, start new instance.

7 - ) Após isso a api está pronta para ser consumida pelo projeto SPA .
