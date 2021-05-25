/*FILTRO DE COMPRA COM CLIENTE,CONSULTA E PRODUTO*/
SELECT CONSULTA.codConsulta AS 'CONSULTA',
CONSULTA.CodCliente AS 'CLIENTE',
CLIENTE.nomeCliente AS 'NOME',
SERVICO.nome_servico AS 'SERVICO',
PRODUTO.nome_produto AS 'PRODUTO'
from tb_ordem_servico_produto CS
JOIN tb_consulta CONSULTA on CONSULTA.codConsulta = CS.cod_consulta
JOIN tb_servicos SERVICO on SERVICO.cod_servico = CS.cod_servico
JOIN tb_produtos PRODUTO on PRODUTO.cod_produto = CS.cod_produto
JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente;

/*FILTRO DE COMPRA SEM CLIENTE ASSOCIADO,SOMENTE COMPRA DE PRODUTO*/
SELECT CS.cod_consulta = NULL AS 'TRANSAÇÃO',
PRODUTO.nome_produto AS 'PRODUTO'
from tb_ordem_servico_produto CS
JOIN tb_produtos PRODUTO on PRODUTO.cod_produto = CS.cod_produto;

/*INSERT*/
INSERT INTO tb_ordem_servico_produto(cod_consulta,cod_servico,cod_produto) values(12,25,1);
INSERT INTO tb_ordem_servico_produto(cod_consulta,cod_servico,cod_produto) values(12,null,1);



SELECT * FROM tb_consulta where tb_consulta.CodCliente = 14;

select
CONSULTA.dataConsulta AS 'DATA',
CLIENTE.nomeCliente AS 'NOME',
SERVICO.nome_servico AS 'SERVICO',
SERVICO.preco_servico AS 'PRECO'
from tb_consulta CONSULTA
JOIN tb_servicos SERVICO on SERVICO.cod_servico = CONSULTA.cod_servico
JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente where CLIENTE.nomeCliente = "ROBERTO AFRICO";




