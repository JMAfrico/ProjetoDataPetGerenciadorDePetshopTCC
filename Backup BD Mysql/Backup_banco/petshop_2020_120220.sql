-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 13-Fev-2021 às 00:09
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
(18, 'ROBERTO AFRICO', 'ROBERTOAFRICO@GMAIL.COM', 99191919192, 1152618181, 'RUA SÃO MARCOS', 'CARAGUATATUBA', 'CARAGUATATUBA', 61, 'MORRO DO ALGODÃO', '11671450', 'CONDOMINIO', 'CONDOMINIO VILA PORTO SEGURO', '04412805875'),
(19, 'COMPRA SEM CLIENTE', '0', 999999999, 99999999, '0', '0', '0', 0, '0', '0', '0', '0', '0');

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
  `corAnimal` varchar(20) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_clienteanimais`
--

INSERT INTO `tb_clienteanimais` (`cod_cadastro`, `cod_cliente`, `cod_tipo_animal`, `cod_raca_animal`, `nome_animal`, `pesoAnimal`, `alturaAnimal`, `corAnimal`) VALUES
(1, 15, 1, 23, 'MARIA', '20', '2', 'AZUL'),
(2, 9, 2, 17, 'tody', '0', '0', '0'),
(10, 15, 3, 20, 'LORO', '2KG', '0,50CM', 'PRETO'),
(11, 14, 2, 25, 'XMEN', '', '', ''),
(12, 18, 2, 18, '', '', '', ''),
(13, 14, 3, 13, 'YUGI', '', '', ''),
(14, 9, 2, 28, 'IURI AFRICO', '5KG', '30CM', 'PRETO/MARROM');

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
(1, 'ACUPUNTURA'),
(2, 'CARDIOLOGIA'),
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
  `nomeFuncionario` varchar(20) NOT NULL,
  `sobrenomeFuncionario` varchar(30) NOT NULL,
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

INSERT INTO `tb_funcionario` (`codFuncionario`, `nomeFuncionario`, `sobrenomeFuncionario`, `emailFuncionario`, `telefoneFixoFunc`, `telefoneCelularFunc`, `enderecoFuncionario`, `cidadeFuncionario`, `estadoFuncionario`, `bairroFuncionario`, `cepFuncionario`, `numeroResidenciaFuncionario`, `complementoFuncionario`) VALUES
(1, 'THIAGO', 'AZEVEDO SILVA', 'THIAGO.SILVA@GMAIL.COM', 1154463984, 11974041224, 'RUA JOSÉ DE ANDRADE SANDIM', 'MOGI DAS CRUZES', 'SP', 'VILA RICA', '08810010', 22, 'CONJUNTO 3 - 5ºANDAR');

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
(43, 15, 9, '14', '2021-02-10', '10:00:00'),
(44, 15, 7, '20', '2021-02-10', '10:00:00'),
(46, 15, 7, '', '2021-02-11', '14:00:00'),
(47, 15, 6, '', '2021-02-11', '14:00:00'),
(48, 15, 3, '', '2021-02-10', '08:00:00'),
(49, 15, 8, '', '2021-02-10', '08:00:00'),
(59, 9, 5, '42,29', '2021-02-11', '19:39:38'),
(60, 14, 4, '49,69', '2021-02-11', '19:40:52'),
(61, 14, 5, '49,69', '2021-02-11', '19:40:52'),
(62, 14, 7, '49,69', '2021-02-11', '19:40:52'),
(63, 19, 5, '61,59', '2021-02-11', '20:21:28'),
(64, 19, 6, '61,59', '2021-02-11', '20:21:28'),
(65, 19, 7, '61,59', '2021-02-11', '20:21:28');

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
-- Estrutura da tabela `tb_veterinario`
--

CREATE TABLE `tb_veterinario` (
  `codVeterinario` int(10) NOT NULL,
  `nomeVeterinario` varchar(20) NOT NULL,
  `sobrenomeVeterinario` varchar(30) NOT NULL,
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

INSERT INTO `tb_veterinario` (`codVeterinario`, `nomeVeterinario`, `sobrenomeVeterinario`, `crmv`, `especializacao`, `enderecoVeterinario`, `cidadeVeterinario`, `estadoVeterinario`, `bairroVeterinario`, `cepVeterinario`, `numeroResidenciaVeterinario`, `complementoVeterinario`, `emailVeterinario`, `telefoneFixoVet`, `telefoneCelularVet`) VALUES
(4, 'WILSON', 'AZEVEDO', '15415', 6, 'RUA JOSÉ BORGES DO CANTO', 'SÃO PAULO', 'SP', 'JARDIM CAMARGO NOVO', '08142010', 16, 'CASA', 'WILSON@HOTMAIL.COM', 2626262266, 26262626262);

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
-- Indexes for table `tb_consulta`
--
ALTER TABLE `tb_consulta`
  ADD PRIMARY KEY (`codConsulta`),
  ADD KEY `CodCliente_tb_animal` (`CodCliente`),
  ADD KEY `fk_VeterinariotbVeterinario_consulta` (`cod_veterinario`),
  ADD KEY `fk_TipoAnimaltbanimalCliente` (`cod_tipo_animal_consulta`),
  ADD KEY `fkRaca` (`cod_raca_animal_consulta`),
  ADD KEY `fk_ServicostbServicos` (`cod_servico`);

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
-- Indexes for table `tb_produtos`
--
ALTER TABLE `tb_produtos`
  ADD PRIMARY KEY (`cod_produto`);

--
-- Indexes for table `tb_produtos_cliente`
--
ALTER TABLE `tb_produtos_cliente`
  ADD PRIMARY KEY (`cod_compra`),
  ADD KEY `fk_cliente` (`cod_cliente`),
  ADD KEY `fk_produto` (`cod_produto`);

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
-- Indexes for table `tb_tipo_animal`
--
ALTER TABLE `tb_tipo_animal`
  ADD PRIMARY KEY (`cod_tipo_animal`),
  ADD UNIQUE KEY `nome_tipo_animal` (`nome_tipo_animal`);

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
  MODIFY `CodCliente` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `tb_clienteanimais`
--
ALTER TABLE `tb_clienteanimais`
  MODIFY `cod_cadastro` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `tb_consulta`
--
ALTER TABLE `tb_consulta`
  MODIFY `codConsulta` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

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
-- AUTO_INCREMENT for table `tb_produtos`
--
ALTER TABLE `tb_produtos`
  MODIFY `cod_produto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `tb_produtos_cliente`
--
ALTER TABLE `tb_produtos_cliente`
  MODIFY `cod_compra` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=66;

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
-- AUTO_INCREMENT for table `tb_tipo_animal`
--
ALTER TABLE `tb_tipo_animal`
  MODIFY `cod_tipo_animal` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `tb_veterinario`
--
ALTER TABLE `tb_veterinario`
  MODIFY `codVeterinario` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

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
-- Limitadores para a tabela `tb_consulta`
--
ALTER TABLE `tb_consulta`
  ADD CONSTRAINT `fkRaca` FOREIGN KEY (`cod_raca_animal_consulta`) REFERENCES `tb_raca` (`cod_raca`),
  ADD CONSTRAINT `fk_ClientetbanimalCliente_consulta` FOREIGN KEY (`CodCliente`) REFERENCES `tb_cliente` (`CodCliente`),
  ADD CONSTRAINT `fk_ServicostbServicos` FOREIGN KEY (`cod_servico`) REFERENCES `tb_servicos` (`cod_servico`),
  ADD CONSTRAINT `fk_TipoAnimaltbanimalCliente` FOREIGN KEY (`cod_tipo_animal_consulta`) REFERENCES `tb_tipo_animal` (`cod_tipo_animal`),
  ADD CONSTRAINT `fk_VeterinariotbVeterinario_consulta` FOREIGN KEY (`cod_veterinario`) REFERENCES `tb_veterinario` (`codVeterinario`);

--
-- Limitadores para a tabela `tb_produtos_cliente`
--
ALTER TABLE `tb_produtos_cliente`
  ADD CONSTRAINT `fk_cliente` FOREIGN KEY (`cod_cliente`) REFERENCES `tb_cliente` (`CodCliente`),
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
