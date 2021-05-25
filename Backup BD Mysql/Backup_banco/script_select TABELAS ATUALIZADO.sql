/*SELECT BUSCAR CLIENTE PARA CONSULTA*/ 
SELECT cliente.cpfCliente AS 'CPF',
cliente.nomeCliente AS 'CLIENTE',
tipo.nome_tipo_animal AS 'TIPO', 
raca.nome_raca_animal AS 'RACA', 
nome_animal AS 'NOME' from 
tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente 
join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal 
join tb_raca raca on raca.cod_raca = ClienteAnimal.cod_raca_animal;


SELECT CONSULTA.codConsulta AS 'CODIGO',
CLIENTE.nomeCliente AS 'CLIENTE',
TIPO.nome_tipo_animal AS 'TIPO',
RACA.nome_raca_animal AS 'RACA',
VETERINARIO.nomeVeterinario AS 'VETERINARIO',
SERVICOS.nome_servico AS 'SERVIÇOS',
valortotal_consulta AS'VALOR TOTAL',
dataConsulta AS 'DATA',
horaConsulta AS 'HORA'
from tb_consulta CONSULTA
JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente 
JOIN tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CONSULTA.cod_tipo_animal_consulta
JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta
JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario 
JOIN tb_servicos SERVICOS on SERVICOS.cod_servico = CONSULTA.codConsulta 
is not null ;

/*SELECT POR DATA DA CONSULTA*/
select 
CONSULTA.dataConsulta AS 'DATA', 
CLIENTE.nomeCliente AS 'NOME', 
SERVICO.nome_servico AS 'SERVICO', 
SERVICO.preco_servico AS 'PRECO' 
from tb_consulta CONSULTA 
JOIN tb_servicos SERVICO on SERVICO.cod_servico = CONSULTA.cod_servico 
JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente 
WHERE CLIENTE.nomeCliente = "JOÃO MARCOS AFRICO DA SILVA" AND CONSULTA.dataConsulta = "30-01-2021";

select * from tb_itens_cliente;

/*SELECIONA TODOS OS ITENS DO CLIENTE NUMERO "X" */
SELECT * FROM `tb_itens_cliente` WHERE `cod_cliente` = 18;

/*SELECIONA TODOS OS SERVICOS DO CLIENTE NUMERO "X" */
SELECT 
CLIENTE.nomeCliente AS 'NOME' ,
SERVICO.nome_servico AS 'SERVICO'
FROM tb_itens_cliente ITENS 
JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = ITENS.cod_cliente
JOIN tb_servicos SERVICO on SERVICO.cod_servico = ITENS.cod_servico 
WHERE ITENS.cod_cliente = 18;

/*SELECIONA TODOS OS PRODUTOS DO CLIENTE NUMERO "X" */
SELECT 
CLIENTE.nomeCliente AS 'NOME' ,
PRODUTO.nome_produto AS 'PRODUTO' 
FROM tb_itens_cliente ITENS 
JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = ITENS.cod_cliente
JOIN tb_produtos PRODUTO on PRODUTO.cod_produto = ITENS.cod_produto 
WHERE ITENS.cod_cliente = 15;



/*uniao de produtos e servicos "X" */
SELECT 
ITENS.cod_registro ,
CLIENTE.nomeCliente AS 'NOME' ,
SERVICO.nome_servico AS 'ITEM',
'SERVICO' AS TABELA
FROM tb_itens_cliente ITENS 
JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = ITENS.cod_cliente
JOIN tb_servicos SERVICO on SERVICO.cod_servico = ITENS.cod_servico 
WHERE ITENS.cod_cliente = 15
union all
SELECT 
ITENS.cod_registro,
CLIENTE.nomeCliente AS 'NOME' ,
PRODUTO.nome_produto ,
'PRODUTO' AS TABELA
FROM tb_itens_cliente ITENS 
JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = ITENS.cod_cliente
JOIN tb_produtos PRODUTO on PRODUTO.cod_produto = ITENS.cod_produto ORDER BY cod_registro;

SELECT 
ITENS.cod_registro ,
CLIENTE.nomeCliente AS 'NOME' ,
SERVICO.nome_servico AS 'ITEM',
'SERVICO' AS TABELA
FROM tb_itens_cliente ITENS 
JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = ITENS.cod_cliente
JOIN tb_servicos SERVICO on SERVICO.cod_servico = ITENS.cod_servico 
WHERE (CLIENTE.nomeCliente = "BRENO KASHIMA") 
union 
SELECT 
ITENS.cod_registro,
CLIENTE.nomeCliente AS 'NOME' ,
PRODUTO.nome_produto ,
'PRODUTO' AS TABELA
FROM tb_itens_cliente ITENS 
JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = ITENS.cod_cliente
JOIN tb_produtos PRODUTO on PRODUTO.cod_produto = ITENS.cod_produto ORDER BY 'TABELA';



SELECT desc_servicos FROM tb_consulta where CodCliente = 19;

/*select PARA MOSTRAR CODIGO DA CONSULTA, DO CLIENTE E FILTRAR PELA DATA*/
SELECT codConsulta,CodCliente,DATE_FORMAT(dataConsulta,"%d/%m/%Y") AS DATA FROM tb_consulta WHERE (CodCliente = 18 and dataConsulta = "2021-02-04");

/*SELECT PARA MOSTRAR CODIGO DA CONSULTA, DO CLIENTE E FILTRAR PELA DATA E EXCLUIR*/
DELETE FROM tb_consulta WHERE CodCliente = 18 and dataConsulta = "2021-02-04" ;

/*MOSTRA AS COMPRAS DO CLIENTE*/
SELECT 
PRODUTOS.cod_compra AS 'COMPRA',
CLIENTE.nomeCliente AS 'NOME',  
PRODUTOS.total_compra AS 'TOTAL',
PRODUTOS.data_compra AS 'DATA',
PRODUTOS.hora_compra AS 'HORA'
FROM tb_produtos_cliente PRODUTOS 
JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = PRODUTOS.cod_cliente GROUP by cod_cliente,data_compra;

/*MOSTRA O CLIENTE,DATA,HORA E OS ITENS DAS SUAS COMPRAS*/
select 
CLIENTE.nomeCliente AS 'NOME', 
PRODUTOS.nome_produto AS 'PRODUTO',
PRODUTOS.preco_produto AS 'PRECO',
CLIPRODUTOS.total_compra AS 'TOTAL',
DATE_FORMAT(CLIPRODUTOS.data_compra,'%d/%m/%Y') AS 'DATA', 
CLIPRODUTOS.hora_compra AS 'HORA'
from tb_produtos_cliente CLIPRODUTOS 
JOIN tb_produtos PRODUTOS on PRODUTOS.cod_produto = CLIPRODUTOS.cod_produto 
JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CLIPRODUTOS.cod_cliente 
WHERE CLIENTE.nomeCliente = "JOAO MARCOS AFRICO DA SILVA" AND CLIPRODUTOS.data_compra = "2021-02-08";

select * FROM tb_produtos_cliente;

/*SELECT PARA MOSTRAR O TOTAL DA COMPRA DO CLIENTE*/
SELECT PRODUTOS.cod_compra AS 'COMPRA',
CLIENTE.nomeCliente AS 'NOME',
PD.nome_produto AS 'PRODUTO',
REPLACE(FORMAT(sum(replace(PD.preco_produto,',','.')),2),'.',',') AS 'TOTAL',
PRODUTOS.data_compra AS 'DATA',
PRODUTOS.hora_compra AS 'HORA'
FROM tb_produtos_cliente PRODUTOS 
JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = PRODUTOS.cod_cliente 
JOIN tb_produtos PD on PRODUTOS.cod_produto = PD.cod_produto group by PRODUTOS.data_compra;


select ESP.nome_especialidade,
VET.nomeVeterinario 
from  tb_veterinario VET
JOIN tb_especialidade_medica ESP on VET.codVeterinario = ESP.cod_especialidade where ESP.cod_especialidade = 4;

SELECT nome_pagamento FROM tb_pagamento;

/*SELECT PARA MOSTRAR TODAS AS CONSULTAS*/
SELECT codConsulta AS 'CODIGO',
CLIENTE.nomeCliente AS 'CLIENTE',
TIPO.nome_tipo_animal AS 'TIPO',
RACA.nome_raca_animal AS 'RACA',
VETERINARIO.nomeVeterinario AS 'VETERINARIO',
dataConsulta AS 'DATA',
horaConsulta AS 'HORA',
valortotal_consulta AS 'TOTAL', 
CLIENTE.emailCliente AS 'EMAIL' 
FROM tb_consulta CONSULTA 
JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente 
JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario 
JOIN tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CONSULTA.cod_tipo_animal_consulta 
JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta 
GROUP BY CLIENTE.codCliente,dataConsulta ORDER BY dataConsulta,horaConsulta;

/*SELECT PARA MOSTRAR TODAS AS CONSULTAS*/
SELECT codConsulta AS 'CODIGO',
VETERINARIO.nomeVeterinario AS 'VETERINARIO',
CLIENTE.nomeCliente AS 'CLIENTE',
RACA.nome_raca_animal AS 'RACA',
dataConsulta AS 'DATA',
horaConsulta AS 'HORA'
FROM tb_consulta CONSULTA
JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente 
JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario 
JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta
where VETERINARIO.nomeVeterinario = "WILSON DE AZEVEDO" /*ou VETERINARIO.codVeterinario = ?*/
GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;

/*MOSTRA CONSULTAS DE HOJE*/
SELECT codConsulta FROM tb_consulta WHERE dataConsulta = CURRENT_DATE()
GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;  

/*MOSTRA CONSULTAS DE HOJE E DE ATÉ 3 DIAS PRA FRENTE*/
SELECT codConsulta,dataConsulta FROM tb_consulta WHERE (dataConsulta = CURRENT_DATE())
or(dataConsulta BETWEEN CURRENT_DATE() AND CURRENT_DATE()+3)  or (dataConsulta)
GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;  

SELECT 
CONSULTA.codConsulta AS 'CODIGO',
CLIENTE.nomeCliente AS 'CLIENTE',
TIPO.nome_tipo_animal AS 'TIPO',
RACA.nome_raca_animal AS 'RACA',
VETERINARIO.nomeVeterinario AS 'VETERINARIO',
dataConsulta AS 'DATA',
horaConsulta AS 'HORA',
valortotal_consulta AS 'TOTAL',
STU.nome_status AS 'PAGAMENTO',
CLIENTE.emailCliente AS 'EMAIL' 
FROM tb_consulta CONSULTA 
JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente 
JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario 
JOIN tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CONSULTA.cod_tipo_animal_consulta 
JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta 
JOIN tb_status_pagamento_consulta STU on STU.cod_status = CONSULTA.status_pagamento
GROUP BY CLIENTE.codCliente,dataConsulta ORDER BY dataConsulta,horaConsulta;

/*SELECIONA A CONSULTA E O STATUS*/
SELECT 
CONSULTA.codConsulta AS 'CODIGO',
CLIENTE.nomeCliente AS 'CLIENTE',
TIPO.nome_tipo_animal AS 'TIPO',
RACA.nome_raca_animal AS 'RACA',
VETERINARIO.nomeVeterinario AS 'VETERINARIO',
dataConsulta AS 'DATA',
horaConsulta AS 'HORA',
valortotal_consulta AS 'TOTAL',
STU.nome_status AS 'PAGAMENTO',
CLIENTE.emailCliente AS 'EMAIL' 
FROM tb_consulta CONSULTA 
JOIN tb_consulta_cliente CONCLIENTE on CONCLIENTE.cod_consulta = CONSULTA.codConsulta
JOIN tb_status_pagamento_consulta STU on STU.cod_status = CONCLIENTE.status_pagamento
JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente 
JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario 
JOIN tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CONSULTA.cod_tipo_animal_consulta 
JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta 
GROUP BY CLIENTE.codCliente,dataConsulta,horaConsulta; /*ORDER BY dataConsulta,horaConsulta;*/


select 
Rel.cod_cadastro AS 'CADASTRO',
Cliente.nomeCliente AS 'CLIENTE',
Cliente.cpfCliente AS 'CPF',
TIPO.nome_tipo_animal AS 'TIPO',
RACA.nome_raca_animal AS 'RAÇA ',
Rel.nome_animal AS 'NOME PET',
Rel.pesoAnimal as 'PESO',
Rel.alturaAnimal AS 'ALTURA',
Rel.idade_animal AS 'IDADE',
Rel.sexo_animal AS 'SEXO',
Rel.historico_vacinas AS 'VACINAS',
Rel.historico_medico AS 'HISTÓRICO MÉDICO'
from tb_clienteanimais Rel
inner join tb_cliente Cliente on Rel.cod_cliente = Cliente.CodCliente 
inner join tb_raca RACA on RACA.cod_raca = Rel.cod_raca_animal
inner join tb_tipo_animal TIPO on TIPO.cod_tipo_animal = Rel.cod_tipo_animal;

/* SELECT PARA CONSULTAS DE CLIENTES PARA MOSTRAR AO VETERINÁRIO*/
select
Consulta.codConsulta AS 'CONSULTA', 
cliente.nomeCliente AS 'CLIENTE',
cliente.cpfCliente AS 'CPF',
TIPO.nome_tipo_animal AS 'TIPO',
RACA.nome_raca_animal AS 'RAÇA ',
Rel.nome_animal AS 'NOME PET',
Rel.pesoAnimal as 'PESO',
Rel.alturaAnimal AS 'ALTURA',
Rel.idade_animal as 'IDADE',
Rel.sexo_animal AS 'SEXO',
Rel.historico_vacinas AS 'VACINAS TOMADAS',
Rel.historico_medico AS 'HISTORICO MÉDICO'
from tb_consulta_cliente CLICONSULTA 
inner JOIN tb_consulta Consulta ON CLICONSULTA.cod_consulta = Consulta.codConsulta
inner join tb_cliente cliente on Consulta.CodCliente = cliente.CodCliente 
inner join tb_raca RACA on RACA.cod_raca = Consulta.cod_raca_animal_consulta
inner join tb_tipo_animal TIPO on TIPO.cod_tipo_animal = Consulta.cod_tipo_animal_consulta
inner join tb_clienteanimais Rel on Rel.cod_raca_animal = RACA.cod_raca
group by cod_consulta;

/*
create table tb_diagnostico(
cod_diagnostico int auto_increment,
cod_consulta int not null,
cod_cliente varchar(50) not null,
cod_tipo_pet int not null,
cod_raca_pet int not null,
nome_pet varchar(50)not null,


);*/

/*select da tabela diagnostico, para verificar os diagnósticos já efetuados pelo veterinario*/
select 
DIAG.cod_diagnostico AS 'DIAGNOSTICO',
CONSULTA.codConsulta AS 'CONSULTA Nº',
CLIENTE.nomeCliente AS 'NOMEcLIE',
TIPO.nome_tipo_animal AS 'NOME_TIPO',
RACA.nome_raca_animal AS 'NOME_RACA',
CLIANI.nome_animal AS 'NOME_PET',
DIAG.descricao_diagnostico AS 'DIAGNOSTICO',
DIAG.medicacao_diagnostico AS 'MEDICACAO',
DIAG.exames_diagnostico AS 'exames',
DIAG.data_diagnostico AS 'DATA',
DIAG.hora_diagnostico AS 'HORA'
from tb_diagnostico DIAG
 join tb_consulta CONSULTA on DIAG.cod_consulta = CONSULTA.codConsulta
 JOIN tb_cliente CLIENTE on CONSULTA.codConsulta = CLIENTE.CodCliente
JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta
JOIN tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CONSULTA.cod_tipo_animal_consulta
 JOIN tb_clienteanimais CLIANI on CLIANI.cod_cadastro = DIAG.cod_cadastro;
 
/*tabela select diagnosticos(já finalizados pelos veterinários)*/
select 
DIAG.cod_diagnostico AS 'Nº DIAG',
CONSULTA.codConsulta AS 'Nº CONSULTA',
CLIANI.cod_cadastro AS 'Nº CADASTRO',
CLIENTE.nomeCliente AS 'CLIENTE',
RACA.nome_raca_animal AS 'RACA',
TIPO.nome_tipo_animal AS 'TIPO',
CLIANI.nome_animal AS 'NOME',
CLIANI.idade_animal AS 'IDADE',
CLIANI.pesoAnimal AS 'PESO',
CLIANI.corAnimal AS 'COR',
CLIANI.sexo_animal AS 'SEXO',
CLIANI.historico_vacinas AS 'VACINAS',
CLIANI.historico_medico AS 'HISTÓRICO',
DIAG.descricao_diagnostico AS 'DIAGNOSTICO',
DIAG.medicacao_diagnostico AS 'MEDICACAO',
DIAG.exames_diagnostico AS 'EXAMES',
DIAG.data_diagnostico AS 'DATA',DIAG.hora_diagnostico AS 'HORA'
from tb_diagnostico as DIAG
inner JOIN tb_clienteanimais CLIANI on  CLIANI.cod_cadastro = DIAG.cod_cadastro
inner join tb_servicos_cliente CONSULTA on DIAG.cod_consulta = CONSULTA.codConsulta
inner join tb_cliente CLIENTE on CLIENTE.CodCliente = CLIANI.cod_cliente
inner join tb_raca RACA on RACA.cod_raca = CLIANI.cod_raca_animal
inner join tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CLIANI.cod_tipo_animal;


SELECT
cod_consulta AS 'CODIGO',
CLIANI.cod_cadastro AS 'CADASTRO',
VETERINARIO.nomeVeterinario AS 'VETERINARIO',
CLIENTE.nomeCliente AS 'CLIENTE',
RACA.nome_raca_animal AS 'RACA',
TIPO.nome_tipo_animal AS 'TIPO',
CLIANI.nome_animal AS 'NOME',
CLIANI.idade_animal AS 'IDADE',
CLIANI.pesoAnimal AS 'PESO',
CLIANI.corAnimal AS 'COR',
CLIANI.sexo_animal AS 'SEXO',
CLIANI.alturaAnimal AS 'TAMANHO',
CLIANI.historico_vacinas AS 'VACINAS',
CLIANI.historico_medico AS 'HISTÓRICO',
dataConsulta AS 'DATA',horaConsulta AS 'HORA' 
FROM tb_consulta_cliente CONSULTA 
join tb_servicos_cliente SERV on CONSULTA.cod_consulta = SERV.codConsulta
JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = SERV.CodCliente 
JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = SERV.cod_veterinario 
JOIN tb_raca RACA on RACA.cod_raca = SERV.cod_raca_animal_consulta 
JOIN tb_clienteanimais CLIANI on CLIANI.cod_raca_animal = RACA.cod_raca
join tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CLIANI.cod_tipo_animal
where VETERINARIO.nomeVeterinario = "WILSON DE AZEVEDO"
GROUP BY dataConsulta,horaConsulta
order BY dataConsulta,horaConsulta;

/**/
select distinct
DIAG.cod_diagnostico AS 'N DIAGNOSTICO',
CONSULTA.codConsulta AS 'CONSULTA',
CLIANI.cod_cadastro AS 'CADASTRO',
VET.nomeVeterinario AS 'VETERINARIO',
CLIENTE.nomeCliente AS 'CLIENTE',
RACA.nome_raca_animal AS 'RACA',
TIPO.nome_tipo_animal AS 'TIPO',
CLIANI.nome_animal AS 'NOME',
CLIANI.idade_animal AS 'IDADE',
CLIANI.pesoAnimal AS 'PESO',
CLIANI.alturaAnimal AS 'ALTURA',
CLIANI.corAnimal AS 'COR',
CLIANI.sexo_animal AS 'SEXO',
CLIANI.historico_vacinas AS 'VACINAS',
CLIANI.historico_medico AS 'HISTORICO',
DIAG.descricao_diagnostico AS 'DIAGNOSTICO',
DIAG.medicacao_diagnostico AS 'MEDICACAO',
DIAG.exames_diagnostico AS 'EXAMES',
DIAG.data_diagnostico AS 'DATA',
DIAG.hora_diagnostico AS 'HORA'
from tb_diagnostico as DIAG 
inner JOIN tb_clienteanimais CLIANI on CLIANI.cod_cadastro = DIAG.cod_cadastro 
inner join tb_servicos_cliente CONSULTA on DIAG.cod_consulta = CONSULTA.codConsulta 
inner join tb_cliente CLIENTE on CLIENTE.CodCliente = CLIANI.cod_cliente 
inner join tb_raca RACA on RACA.cod_raca = CLIANI.cod_raca_animal 
inner join tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CLIANI.cod_tipo_animal
inner join tb_veterinario VET on VET.codVeterinario = CONSULTA.cod_veterinario;


