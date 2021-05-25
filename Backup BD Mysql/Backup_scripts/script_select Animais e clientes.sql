select ClienteAnimal.cod_cadastro,cliente.nomeCliente,tipo.nome_tipo_animal,pesoAnimal,corAnimal
from tb_clienteanimal ClienteAnimal
inner join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente
inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal order by cliente.nomeCliente;

select ClienteAnimal.cod_cadastro,cliente.nomeCliente,tipo.nome_tipo_animal,raca.nome_raca_animal,pesoAnimal,corAnimal
from tb_clienteanimal ClienteAnimal
inner join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente
inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal
inner join tb_raca raca on raca.cod_raca_animal = ClienteAnimal.cod_raca_animal group by raca.cod_raca_animal;

select ClienteAnimal.cod_cadastro,cliente.nomeCliente,tipo.nome_tipo_animal,raca.nome_raca_animal,pesoAnimal,corAnimal
from tb_clienteanimal ClienteAnimal
inner join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente
inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal
inner join tb_raca raca on raca.cod_raca_animal = ClienteAnimal.cod_raca_animal group by cliente.nomeCliente;

/*PESQUISA DE ANIMAIS X CLIENTES DA TABELA RELACIONAMENTO ANIMALXCLIENTE*/
SELECT cliente.cpfCliente AS 'CPF',cliente.nomeCliente AS 'CLIENTE',
tipo.nome_tipo_animal AS 'TIPO',
raca.nome_raca_animal AS 'RACA',
 nome_animal AS 'NOME' from tb_clienteanimal
 ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente inner join tb_tipo_animal tipo
 on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal inner join tb_raca raca 
 on raca.cod_raca_animal = ClienteAnimal.cod_raca_animal WHERE cliente.nomeCliente LIKE "%J%" group by ClienteAnimal.cod_cadastro ;
 
 SELECT cliente.cpfCliente AS 'CPF',
 cliente.nomeCliente AS 'CLIENTE',
 tipo.nome_tipo_animal AS 'TIPO', 
 nome_raca_animal AS 'RACA', 
 nome_animal AS 'NOME' from 
 tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente 
 inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal 
 group by ClienteAnimal.cod_cadastro order by cliente.nomeCliente;
 

/*PESQUISA DE ANIMAIS X CLIENTES DA TABELA CONSULTA*/ 
SELECT cliente.cpfCliente AS 'CPF',
cliente.nomeCliente AS 'CLIENTE',
tipo.nome_tipo_animal AS 'TIPO', 
raca.nome_raca_animal AS 'RACA', 
nome_animal AS 'NOME' from 
tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente 
join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal 
join tb_raca raca on raca.cod_raca = ClienteAnimal.cod_raca_animal
group by ClienteAnimal.cod_cadastro order by cliente.nomeCliente;