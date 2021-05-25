-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 02-Mar-2021 às 18:31
-- Versão do servidor: 10.1.30-MariaDB
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `petshop_2020`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_cliente`
--

CREATE TABLE `tb_cliente` (
  `CodCliente` int(4) NOT NULL,
  `nomeCliente` varchar(30) NOT NULL,
  `emailCliente` varchar(50) NOT NULL,
  `TelefoneCelularCli` bigint(11) NOT NULL,
  `TelefoneFixoCli` bigint(10) DEFAULT NULL,
  `enderecoCliente` varchar(50) NOT NULL,
  `cidadeCliente` varchar(50) NOT NULL,
  `estadoCliente` varchar(50) NOT NULL,
  `numeroResidenciaCliente` int(4) NOT NULL,
  `bairroCliente` varchar(30) NOT NULL,
  `cepCliente` varchar(8) NOT NULL,
  `complementoCliente` varchar(50) NOT NULL,
  `referencia_cliente` varchar(50) DEFAULT NULL,
  `cpfCliente` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_cliente`
--

INSERT INTO `tb_cliente` (`CodCliente`, `nomeCliente`, `emailCliente`, `TelefoneCelularCli`, `TelefoneFixoCli`, `enderecoCliente`, `cidadeCliente`, `estadoCliente`, `numeroResidenciaCliente`, `bairroCliente`, `cepCliente`, `complementoCliente`, `referencia_cliente`, `cpfCliente`) VALUES
(9, 'ELEN CONCEICAO FERREIRA AFRICO', 'ELEN_AFRICO@HOTMAIL.COM', 11966644774, 1122525252, 'RUA JOSÉ BORGES DO CANTO', 'SÃO PAULO', 'SP', 16, 'JARDIM CAMARGO NOVO', '08142010', 'CASA', 'EM FRENTE AO MERCADO', '40927503824'),
(14, 'JOAO MARCOS AFRICO DA SILVA', 'JOAO_MARCOSSILVA@HOTMAIL.COM', 11967757056, 1125612203, 'RUA JOSÉ BORGES DO CANTO', 'SÃO PAULO', 'SÃO PAULO', 16, 'JARDIM CAMARGO NOVO', '08142010', 'CASA B', 'EM FRENTE A ESCOLA EZEQUIEL', '39211358850'),
(15, 'BRENO KASHIMA', 'BRENOKASHIMA654@GMAIL.COM', 11967757056, 1125612203, 'ALAMEDA MANOEL TELLES BARRETO', 'CARAGUATATUBA', 'SP', 16, 'JARDIM BRASIL', '11667260', 'CASA B', 'C', '48636095824'),
(16, 'THIAGO DE AZEVEDO', 'THIAGO22ENG@GMAIL.COM', 11997021738, 1125612203, 'RUA NANCIB RACHID', 'CARAGUATATUBA', 'CARAGUATATUBA', 16, 'PONTAL DE SANTA MARINA', '11672141', 'CASA B', '', '08950320827'),
(19, 'COMPRA SEM CLIENTE', '0', 999999999, 99999999, '0', '0', '0', 0, '0', '0', '0', '0', '0'),
(20, 'ROBERTO AFRICO DA SILVA', 'ROBERTOAFRICO@GMAIL.COM', 12911415456, 1195564332, 'ALAMEDA MANOEL TELLES BARRETO', 'CARAGUATATUBA', 'CARAGUATATUBA', 54, 'JARDIM BRASIL', '11667260', 'CONDOMINIO VILA REAL', 'DE FRENTE AO PONTO DE ONIBUS', '04412805875');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_clienteanimais`
--

CREATE TABLE `tb_clienteanimais` (
  `cod_cadastro` int(10) NOT NULL,
  `cod_cliente` int(10) NOT NULL,
  `cod_tipo_animal` int(10) NOT NULL,
  `cod_raca_animal` int(11) NOT NULL,
  `nome_animal` varchar(50) DEFAULT '0',
  `pesoAnimal` varchar(10) DEFAULT '0',
  `alturaAnimal` varchar(10) DEFAULT '0',
  `corAnimal` varchar(20) DEFAULT '0',
  `idade_animal` varchar(2) DEFAULT NULL,
  `sexo_animal` varchar(20) NOT NULL,
  `historico_vacinas` longtext,
  `historico_medico` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_clienteanimais`
--

INSERT INTO `tb_clienteanimais` (`cod_cadastro`, `cod_cliente`, `cod_tipo_animal`, `cod_raca_animal`, `nome_animal`, `pesoAnimal`, `alturaAnimal`, `corAnimal`, `idade_animal`, `sexo_animal`, `historico_vacinas`, `historico_medico`) VALUES
(10, 15, 3, 20, 'LORO', '2KG', '0,50CM', 'PRETO', '', '0', NULL, NULL),
(15, 14, 1, 27, 'THOR', '6,5KG', '30CM', 'MARROM/BRANCO', '', '0', NULL, NULL),
(16, 20, 3, 2, 'CORINTIANO', '2KG', '20CM', 'BRANCO/PRETO', '', '0', NULL, NULL),
(17, 9, 1, 6, 'LOGO', '15KG', '0,50', 'PRETO', NULL, '', NULL, NULL),
(18, 9, 2, 28, 'THANOS', '25', '30', 'PRETO', '9', '', '', 'ALERGIA A DIPIRONA'),
(19, 9, 1, 6, 'DSSAD', '54', '25', 'ADSDS', '4', '', 'dsasad', 'dsasad'),
(20, 9, 1, 6, 'DF', '20', '5', 'FDSS', '5', 'MASCULINO', 'System.Windows.Forms.ListBox+ObjectCollection', 'doente / febre'),
(21, 16, 1, 6, 'MARIA', '5', '12', '', '2', 'FEMININO', '', 'cirurgia da coluna'),
(22, 15, 2, 29, 'CDCDCD', '12', '1', '', '6', 'MASCULINO', '', 'operou das amidalas');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_compra`
--

CREATE TABLE `tb_compra` (
  `cod_compra` int(11) NOT NULL,
  `cod_pagamento` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_compra`
--

INSERT INTO `tb_compra` (`cod_compra`, `cod_pagamento`) VALUES
(31, 1),
(32, 1),
(33, 1),
(35, 1),
(34, 2),
(36, 2),
(37, 2);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_consulta`
--

CREATE TABLE `tb_consulta` (
  `codConsulta` int(4) NOT NULL,
  `CodCliente` int(4) NOT NULL,
  `cod_tipo_animal_consulta` int(10) NOT NULL,
  `cod_raca_animal_consulta` int(10) NOT NULL,
  `cod_veterinario` int(10) DEFAULT '0',
  `cod_servico` int(10) DEFAULT NULL,
  `valortotal_consulta` varchar(10) DEFAULT '0',
  `dataConsulta` date NOT NULL,
  `horaConsulta` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_consulta`
--

INSERT INTO `tb_consulta` (`codConsulta`, `CodCliente`, `cod_tipo_animal_consulta`, `cod_raca_animal_consulta`, `cod_veterinario`, `cod_servico`, `valortotal_consulta`, `dataConsulta`, `horaConsulta`) VALUES
(9, 14, 1, 27, 5, 33, 'R$ 31', '2021-02-26', '17:00:00'),
(10, 14, 1, 27, 4, 27, 'R$ 65', '2021-03-04', '15:00:00'),
(10, 14, 1, 27, 4, 42, 'R$ 65', '2021-03-04', '15:00:00'),
(11, 14, 1, 27, 5, 35, 'R$ 24', '2021-03-31', '12:00:00'),
(12, 20, 3, 2, 5, 27, 'R$ 50', '2021-02-27', '15:00:00'),
(13, 14, 1, 27, 5, 38, 'R$ 30', '2021-02-26', '19:50:00'),
(14, 15, 2, 29, 4, 27, 'R$ 50', '2021-03-02', '15:45:00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_consulta_cliente`
--

CREATE TABLE `tb_consulta_cliente` (
  `cod_consulta` int(11) NOT NULL,
  `status_pagamento` int(11) NOT NULL DEFAULT '1',
  `tipo_pagamento` int(11) NOT NULL DEFAULT '5'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_consulta_cliente`
--

INSERT INTO `tb_consulta_cliente` (`cod_consulta`, `status_pagamento`, `tipo_pagamento`) VALUES
(8, 2, 2),
(9, 2, 1),
(10, 2, 3),
(11, 2, 4),
(12, 2, 1),
(13, 2, 2),
(14, 2, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_especialidade_medica`
--

CREATE TABLE `tb_especialidade_medica` (
  `cod_especialidade` int(11) NOT NULL,
  `nome_especialidade` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_especialidade_medica`
--

INSERT INTO `tb_especialidade_medica` (`cod_especialidade`, `nome_especialidade`) VALUES
(1, 'ESCOLHA UMA ESPECIALIDADE'),
(2, 'CLINICO GERAL'),
(3, 'COMPORTAMENTO ANIMAL'),
(4, 'DERMATOLOGIA'),
(5, 'ENDOCRINOLOGIA'),
(6, 'FISIOTERAPIA'),
(7, 'HEMATOLOGIA '),
(8, 'HOMEOPATIA'),
(9, 'NEFROLOGIA'),
(10, 'NEUROLOGIA'),
(11, 'NUTROLOGIA'),
(12, 'ODONTOLOGIA'),
(13, 'OFTALMOLOGIA'),
(14, 'ORTOPEDISTA'),
(15, 'PEDIATRIA');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_funcionario`
--

CREATE TABLE `tb_funcionario` (
  `codFuncionario` int(4) NOT NULL,
  `nomeFuncionario` varchar(40) NOT NULL,
  `emailFuncionario` varchar(50) NOT NULL,
  `telefoneFixoFunc` bigint(10) DEFAULT NULL,
  `telefoneCelularFunc` bigint(11) NOT NULL,
  `enderecoFuncionario` varchar(50) NOT NULL,
  `cidadeFuncionario` varchar(50) NOT NULL,
  `estadoFuncionario` varchar(50) NOT NULL,
  `bairroFuncionario` varchar(30) NOT NULL,
  `cepFuncionario` varchar(8) NOT NULL,
  `numeroResidenciaFuncionario` int(4) NOT NULL,
  `complementoFuncionario` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_funcionario`
--

INSERT INTO `tb_funcionario` (`codFuncionario`, `nomeFuncionario`, `emailFuncionario`, `telefoneFixoFunc`, `telefoneCelularFunc`, `enderecoFuncionario`, `cidadeFuncionario`, `estadoFuncionario`, `bairroFuncionario`, `cepFuncionario`, `numeroResidenciaFuncionario`, `complementoFuncionario`) VALUES
(1, 'THIAGO DE AZEVEDO', 'THIAGO.SILVA@GMAIL.COM', 1154463984, 11974041222, 'RUA JOSÉ DE ANDRADE SANDIM', 'MOGI DAS CRUZES', 'SP', 'VILA RICA', '08810010', 22, 'CONJUNTO 3 - 5ºANDAR');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_login`
--

CREATE TABLE `tb_login` (
  `codUsuario` int(11) NOT NULL,
  `nomeUsuario` varchar(50) NOT NULL,
  `senhaUsuario` varchar(15) NOT NULL,
  `confirmarSenha` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_login`
--

INSERT INTO `tb_login` (`codUsuario`, `nomeUsuario`, `senhaUsuario`, `confirmarSenha`) VALUES
(3, 'JOAO', '123', '123'),
(4, 'ADMIN', 'ADMIN', 'ADMIN'),
(5, 'BRENO', '123456', '123456'),
(8, 'MARCOS', '159159', '159159'),
(9, 'X', 'TESTE', 'TESTE'),
(10, 'KRATOS', 'GOD', 'GOD');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_pagamento`
--

CREATE TABLE `tb_pagamento` (
  `cod_pagamento` int(11) NOT NULL,
  `nome_pagamento` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_pagamento`
--

INSERT INTO `tb_pagamento` (`cod_pagamento`, `nome_pagamento`) VALUES
(1, 'DINHEIRO'),
(2, 'DEBITO'),
(3, 'CREDITO A VISTA'),
(4, 'CREDITO 2X'),
(5, 'NAO PAGO');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_produtos`
--

CREATE TABLE `tb_produtos` (
  `cod_produto` int(11) NOT NULL,
  `nome_produto` varchar(50) NOT NULL,
  `preco_produto` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_produtos`
--

INSERT INTO `tb_produtos` (`cod_produto`, `nome_produto`, `preco_produto`) VALUES
(1, 'WHISKAS +1', '2,50'),
(3, 'RAÇÃO PEDIGREE PARA CACHORRO GRANDE 5KG', '70,00'),
(4, 'OSSO PARA CAES', '2,30'),
(5, 'CAMA PARA CACHORRO E GATO ', '39,99'),
(6, 'CAIXA SANITÁRIA PARA GATO 6,4 LITROS', '14,20'),
(7, 'BEBEDOURO PARA GATO/COR ROSA ', '7,40'),
(8, 'SHAMPOO PARA CÃES', '8,50'),
(9, 'ALPISTE PACOTE 5KG', '33,00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_produtos_cliente`
--

CREATE TABLE `tb_produtos_cliente` (
  `cod_compra` int(11) NOT NULL,
  `cod_cliente` int(11) DEFAULT NULL,
  `cod_produto` int(11) NOT NULL,
  `total_compra` varchar(10) NOT NULL,
  `data_compra` date NOT NULL,
  `hora_compra` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_produtos_cliente`
--

INSERT INTO `tb_produtos_cliente` (`cod_compra`, `cod_cliente`, `cod_produto`, `total_compra`, `data_compra`, `hora_compra`) VALUES
(32, 20, 9, '33', '2021-02-24', '15:04:08'),
(33, 19, 4, '72,3', '2021-02-24', '15:45:52'),
(33, 19, 3, '72,3', '2021-02-24', '15:45:52'),
(34, 19, 4, '49,5', '2021-02-25', '23:06:55'),
(34, 19, 6, '49,5', '2021-02-25', '23:06:55'),
(34, 19, 9, '49,5', '2021-02-25', '23:06:55'),
(35, 14, 8, '8,5', '2021-02-26', '19:21:49'),
(36, 16, 1, '117,29', '2021-02-26', '19:34:13'),
(36, 16, 3, '117,29', '2021-02-26', '19:34:13'),
(36, 16, 1, '117,29', '2021-02-26', '19:34:13'),
(36, 16, 4, '117,29', '2021-02-26', '19:34:13'),
(36, 16, 5, '117,29', '2021-02-26', '19:34:13'),
(37, 19, 1, '2,5', '2021-03-02', '13:12:43');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_raca`
--

CREATE TABLE `tb_raca` (
  `cod_raca` int(10) NOT NULL,
  `cod_tipo_animal` int(11) NOT NULL,
  `nome_raca_animal` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_raca`
--

INSERT INTO `tb_raca` (`cod_raca`, `cod_tipo_animal`, `nome_raca_animal`) VALUES
(2, 3, 'ARARA'),
(5, 3, 'BEIJA FLOR'),
(6, 1, 'BICHON FRISE'),
(7, 2, 'BRITISH SHORTHAIR'),
(8, 2, 'BURMESE'),
(9, 3, 'CALOPSITA'),
(10, 3, 'CANARIO'),
(12, 1, 'COCKER'),
(13, 3, 'COLEIRO'),
(14, 3, 'CURIO'),
(15, 1, 'DALMATA'),
(16, 1, 'FOX TERRIER'),
(17, 2, 'HIMALAIA'),
(18, 2, 'MAINE CONN'),
(19, 1, 'MALTES'),
(20, 3, 'PAPAGAIO'),
(22, 3, 'PINTASSILGO'),
(23, 1, 'PITBULL'),
(24, 1, 'POODLE'),
(25, 2, 'RAGDOLL'),
(26, 1, 'SCHNAUZER'),
(27, 1, 'SHIH TSU'),
(28, 2, 'SIAMES'),
(29, 2, 'SIBERIANO'),
(30, 2, 'SPHYNX'),
(31, 3, 'TRINCA-FERRO'),
(32, 3, 'TUCANO'),
(33, 1, 'WEST HIGHTLAND TERRIER'),
(34, 1, 'YORKSHIRE'),
(41, 2, 'ANGORA'),
(42, 2, 'XMEN');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_servicos`
--

CREATE TABLE `tb_servicos` (
  `cod_servico` int(10) NOT NULL,
  `nome_servico` varchar(50) NOT NULL,
  `preco_servico` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_servicos`
--

INSERT INTO `tb_servicos` (`cod_servico`, `nome_servico`, `preco_servico`) VALUES
(27, 'CONSULTA', '50,00'),
(28, 'BANHO E TOSA ESPECIAL', '45,00'),
(29, 'BANHO MEDICINAL GRANDE', '5,00'),
(30, 'BANHO MEDICINAL MEDIO', '4,50'),
(31, 'BANHO MEDICINAL PEQUENO', '3,50'),
(32, 'BANHO E TOSA PET GRANDE', '36,00'),
(33, 'BANHO E TOSA PET MEDIO', '31,00'),
(34, 'BANHO E TOSA PET PEQUENO', '28,00'),
(35, 'TOSA GRANDE', '24,00'),
(36, 'TOSA MEDIO', '22,00'),
(37, 'TOSA PEQUENO', '20,00'),
(38, 'HIDRATAÇÃO', '30,00'),
(39, 'MASSAGEM E BANHOS RELAXANTES', '50,00'),
(40, 'HOSPEDAGEM', '25,00'),
(41, 'TAXI DOG', '10,00'),
(42, 'DOG WALKER', '15,00'),
(43, 'DOAÇÃO DE PET', '0,00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_status_pagamento_consulta`
--

CREATE TABLE `tb_status_pagamento_consulta` (
  `cod_status` int(11) NOT NULL,
  `nome_status` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_status_pagamento_consulta`
--

INSERT INTO `tb_status_pagamento_consulta` (`cod_status`, `nome_status`) VALUES
(1, 'PENDENTE'),
(2, 'PAGO');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_tipo_animal`
--

CREATE TABLE `tb_tipo_animal` (
  `cod_tipo_animal` int(10) NOT NULL,
  `nome_tipo_animal` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_tipo_animal`
--

INSERT INTO `tb_tipo_animal` (`cod_tipo_animal`, `nome_tipo_animal`) VALUES
(1, 'CACHORRO'),
(2, 'GATO'),
(3, 'PASSARO');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_vacinas`
--

CREATE TABLE `tb_vacinas` (
  `cod_vacina` int(11) NOT NULL,
  `nome_vacina` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_vacinas`
--

INSERT INTO `tb_vacinas` (`cod_vacina`, `nome_vacina`) VALUES
(1, 'VACINA ANTIRRABICA'),
(5, 'VACINA CONTRA A LEISHMANIOSE'),
(3, 'VACINA CONTRA GIARDIASE'),
(4, 'VACINA CONTRA GRIPE CANINA'),
(2, 'VACINA MULTIPLA OU POLIVALENTE (V8 E V10)');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_veterinario`
--

CREATE TABLE `tb_veterinario` (
  `codVeterinario` int(10) NOT NULL,
  `nomeVeterinario` varchar(40) NOT NULL,
  `crmv` varchar(5) NOT NULL,
  `especializacao` int(11) NOT NULL,
  `enderecoVeterinario` varchar(50) NOT NULL,
  `cidadeVeterinario` varchar(50) NOT NULL,
  `estadoVeterinario` varchar(50) NOT NULL,
  `bairroVeterinario` varchar(30) NOT NULL,
  `cepVeterinario` varchar(8) NOT NULL,
  `numeroResidenciaVeterinario` int(4) NOT NULL,
  `complementoVeterinario` varchar(50) NOT NULL,
  `emailVeterinario` varchar(50) NOT NULL,
  `telefoneFixoVet` bigint(10) NOT NULL,
  `telefoneCelularVet` bigint(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_veterinario`
--

INSERT INTO `tb_veterinario` (`codVeterinario`, `nomeVeterinario`, `crmv`, `especializacao`, `enderecoVeterinario`, `cidadeVeterinario`, `estadoVeterinario`, `bairroVeterinario`, `cepVeterinario`, `numeroResidenciaVeterinario`, `complementoVeterinario`, `emailVeterinario`, `telefoneFixoVet`, `telefoneCelularVet`) VALUES
(4, 'WILSON DE AZEVEDO', '15415', 2, 'RUA JOSÉ BORGES DO CANTO', 'SÃO PAULO', 'SP', 'JARDIM CAMARGO NOVO', '08142010', 16, 'CASA', 'WILSON@HOTMAIL.COM', 2626262266, 26262626262),
(5, 'N/A', '00000', 1, '0', '0', '0', '0', '0', 0, '0', '0', 0, 0),
(6, 'ANTONIO FREITAS ', '15715', 14, 'RUA JOSÉ BORGES DO CANTO', 'SÃO PAULO', 'SP', 'JARDIM CAMARGO NOVO', '08142010', 16, 'CASA B', 'ANTONIO_FR@GMAIL.COM', 1166588070, 11968121159);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tb_cliente`
--
ALTER TABLE `tb_cliente`
  ADD PRIMARY KEY (`CodCliente`),
  ADD UNIQUE KEY `cpfCliente` (`cpfCliente`);

--
-- Indexes for table `tb_clienteanimais`
--
ALTER TABLE `tb_clienteanimais`
  ADD PRIMARY KEY (`cod_cadastro`),
  ADD KEY `fk_ClientetbClientes` (`cod_cliente`),
  ADD KEY `fkRacaAnimal` (`cod_raca_animal`),
  ADD KEY `fk_TipoAnimaltbAnimais` (`cod_tipo_animal`);

--
-- Indexes for table `tb_compra`
--
ALTER TABLE `tb_compra`
  ADD PRIMARY KEY (`cod_compra`),
  ADD KEY `fk_tipoPagamento` (`cod_pagamento`);

--
-- Indexes for table `tb_consulta`
--
ALTER TABLE `tb_consulta`
  ADD KEY `CodCliente_tb_animal` (`CodCliente`),
  ADD KEY `fk_VeterinariotbVeterinario_consulta` (`cod_veterinario`),
  ADD KEY `fk_TipoAnimaltbanimalCliente` (`cod_tipo_animal_consulta`),
  ADD KEY `fkRaca` (`cod_raca_animal_consulta`),
  ADD KEY `fk_ServicostbServicos` (`cod_servico`),
  ADD KEY `fk_cod_consulta` (`codConsulta`);

--
-- Indexes for table `tb_consulta_cliente`
--
ALTER TABLE `tb_consulta_cliente`
  ADD PRIMARY KEY (`cod_consulta`),
  ADD KEY `fk_status_pagamento` (`status_pagamento`),
  ADD KEY `fk` (`tipo_pagamento`);

--
-- Indexes for table `tb_especialidade_medica`
--
ALTER TABLE `tb_especialidade_medica`
  ADD PRIMARY KEY (`cod_especialidade`);

--
-- Indexes for table `tb_funcionario`
--
ALTER TABLE `tb_funcionario`
  ADD PRIMARY KEY (`codFuncionario`);

--
-- Indexes for table `tb_login`
--
ALTER TABLE `tb_login`
  ADD PRIMARY KEY (`codUsuario`),
  ADD UNIQUE KEY `nomeUsuario` (`nomeUsuario`);

--
-- Indexes for table `tb_pagamento`
--
ALTER TABLE `tb_pagamento`
  ADD PRIMARY KEY (`cod_pagamento`);

--
-- Indexes for table `tb_produtos`
--
ALTER TABLE `tb_produtos`
  ADD PRIMARY KEY (`cod_produto`);

--
-- Indexes for table `tb_produtos_cliente`
--
ALTER TABLE `tb_produtos_cliente`
  ADD KEY `fk_cliente` (`cod_cliente`),
  ADD KEY `fk_produto` (`cod_produto`),
  ADD KEY `fk_cod_compra` (`cod_compra`);

--
-- Indexes for table `tb_raca`
--
ALTER TABLE `tb_raca`
  ADD PRIMARY KEY (`cod_raca`),
  ADD KEY `cod_raca_animal` (`cod_tipo_animal`);

--
-- Indexes for table `tb_servicos`
--
ALTER TABLE `tb_servicos`
  ADD PRIMARY KEY (`cod_servico`),
  ADD UNIQUE KEY `nome_servico` (`nome_servico`);

--
-- Indexes for table `tb_status_pagamento_consulta`
--
ALTER TABLE `tb_status_pagamento_consulta`
  ADD PRIMARY KEY (`cod_status`);

--
-- Indexes for table `tb_tipo_animal`
--
ALTER TABLE `tb_tipo_animal`
  ADD PRIMARY KEY (`cod_tipo_animal`),
  ADD UNIQUE KEY `nome_tipo_animal` (`nome_tipo_animal`);

--
-- Indexes for table `tb_vacinas`
--
ALTER TABLE `tb_vacinas`
  ADD PRIMARY KEY (`cod_vacina`),
  ADD UNIQUE KEY `nome_vacina` (`nome_vacina`);

--
-- Indexes for table `tb_veterinario`
--
ALTER TABLE `tb_veterinario`
  ADD PRIMARY KEY (`codVeterinario`),
  ADD UNIQUE KEY `crmv` (`crmv`),
  ADD KEY `fk_especializacao_vet` (`especializacao`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tb_cliente`
--
ALTER TABLE `tb_cliente`
  MODIFY `CodCliente` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `tb_clienteanimais`
--
ALTER TABLE `tb_clienteanimais`
  MODIFY `cod_cadastro` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT for table `tb_compra`
--
ALTER TABLE `tb_compra`
  MODIFY `cod_compra` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=38;

--
-- AUTO_INCREMENT for table `tb_consulta_cliente`
--
ALTER TABLE `tb_consulta_cliente`
  MODIFY `cod_consulta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `tb_especialidade_medica`
--
ALTER TABLE `tb_especialidade_medica`
  MODIFY `cod_especialidade` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `tb_funcionario`
--
ALTER TABLE `tb_funcionario`
  MODIFY `codFuncionario` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tb_login`
--
ALTER TABLE `tb_login`
  MODIFY `codUsuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `tb_pagamento`
--
ALTER TABLE `tb_pagamento`
  MODIFY `cod_pagamento` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `tb_produtos`
--
ALTER TABLE `tb_produtos`
  MODIFY `cod_produto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `tb_raca`
--
ALTER TABLE `tb_raca`
  MODIFY `cod_raca` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=43;

--
-- AUTO_INCREMENT for table `tb_servicos`
--
ALTER TABLE `tb_servicos`
  MODIFY `cod_servico` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;

--
-- AUTO_INCREMENT for table `tb_status_pagamento_consulta`
--
ALTER TABLE `tb_status_pagamento_consulta`
  MODIFY `cod_status` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tb_tipo_animal`
--
ALTER TABLE `tb_tipo_animal`
  MODIFY `cod_tipo_animal` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `tb_vacinas`
--
ALTER TABLE `tb_vacinas`
  MODIFY `cod_vacina` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `tb_veterinario`
--
ALTER TABLE `tb_veterinario`
  MODIFY `codVeterinario` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `tb_clienteanimais`
--
ALTER TABLE `tb_clienteanimais`
  ADD CONSTRAINT `fkRacaAnimal` FOREIGN KEY (`cod_raca_animal`) REFERENCES `tb_raca` (`cod_raca`),
  ADD CONSTRAINT `fk_ClientetbClientes` FOREIGN KEY (`cod_cliente`) REFERENCES `tb_cliente` (`CodCliente`),
  ADD CONSTRAINT `fk_TipoAnimaltbAnimais` FOREIGN KEY (`cod_tipo_animal`) REFERENCES `tb_tipo_animal` (`cod_tipo_animal`);

--
-- Limitadores para a tabela `tb_compra`
--
ALTER TABLE `tb_compra`
  ADD CONSTRAINT `fk_tipoPagamento` FOREIGN KEY (`cod_pagamento`) REFERENCES `tb_pagamento` (`cod_pagamento`);

--
-- Limitadores para a tabela `tb_consulta`
--
ALTER TABLE `tb_consulta`
  ADD CONSTRAINT `fkRaca` FOREIGN KEY (`cod_raca_animal_consulta`) REFERENCES `tb_raca` (`cod_raca`),
  ADD CONSTRAINT `fk_ClientetbanimalCliente_consulta` FOREIGN KEY (`CodCliente`) REFERENCES `tb_cliente` (`CodCliente`),
  ADD CONSTRAINT `fk_ServicostbServicos` FOREIGN KEY (`cod_servico`) REFERENCES `tb_servicos` (`cod_servico`),
  ADD CONSTRAINT `fk_TipoAnimaltbanimalCliente` FOREIGN KEY (`cod_tipo_animal_consulta`) REFERENCES `tb_tipo_animal` (`cod_tipo_animal`),
  ADD CONSTRAINT `fk_VeterinariotbVeterinario_consulta` FOREIGN KEY (`cod_veterinario`) REFERENCES `tb_veterinario` (`codVeterinario`),
  ADD CONSTRAINT `fk_cod_consulta` FOREIGN KEY (`codConsulta`) REFERENCES `tb_consulta_cliente` (`cod_consulta`);

--
-- Limitadores para a tabela `tb_consulta_cliente`
--
ALTER TABLE `tb_consulta_cliente`
  ADD CONSTRAINT `fk` FOREIGN KEY (`tipo_pagamento`) REFERENCES `tb_pagamento` (`cod_pagamento`),
  ADD CONSTRAINT `fk_status_pagamento` FOREIGN KEY (`status_pagamento`) REFERENCES `tb_status_pagamento_consulta` (`cod_status`);

--
-- Limitadores para a tabela `tb_produtos_cliente`
--
ALTER TABLE `tb_produtos_cliente`
  ADD CONSTRAINT `fk_cliente` FOREIGN KEY (`cod_cliente`) REFERENCES `tb_cliente` (`CodCliente`),
  ADD CONSTRAINT `fk_cod_compra` FOREIGN KEY (`cod_compra`) REFERENCES `tb_compra` (`cod_compra`),
  ADD CONSTRAINT `fk_produto` FOREIGN KEY (`cod_produto`) REFERENCES `tb_produtos` (`cod_produto`);

--
-- Limitadores para a tabela `tb_raca`
--
ALTER TABLE `tb_raca`
  ADD CONSTRAINT `tb_raca_ibfk_1` FOREIGN KEY (`cod_tipo_animal`) REFERENCES `tb_tipo_animal` (`cod_tipo_animal`);

--
-- Limitadores para a tabela `tb_veterinario`
--
ALTER TABLE `tb_veterinario`
  ADD CONSTRAINT `fk_especializacao_vet` FOREIGN KEY (`especializacao`) REFERENCES `tb_especialidade_medica` (`cod_especialidade`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
