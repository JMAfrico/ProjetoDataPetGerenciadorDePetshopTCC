-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 14-Jan-2021 às 16:48
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
(9, 'ELEN CONCEICAO FERREIRA AFRICO', 'ELEN@HOTMAIL.COM', 11966644774, 1122525252, 'RUA JOSÉ BORGES DO CANTO', 'SÃO PAULO', 'SP', 16, 'JARDIM CAMARGO NOVO', '08142010', 'CASA', 'EM FRENTE AO MERCADO', '40927503824'),
(14, 'JOAO MARCOS AFRICO DA SILVA', 'JOAO_MARCOSSILVA@HOTMAIL.COM', 11967757056, 1125612203, 'RUA JOSÉ BORGES DO CANTO', 'SÃO PAULO', 'SÃO PAULO', 16, 'JARDIM CAMARGO NOVO', '08142010', 'CASA B', 'EM FRENTE A ESCOLA EZEQUIEL', '39211358850'),
(15, 'BRENO KASHIMA', 'BRENOKASHIMA654@GMAIL.COM', 11967757056, 1125612203, 'ALAMEDA MANOEL TELLES BARRETO', 'CARAGUATATUBA', 'SP', 16, 'JARDIM BRASIL', '11667260', 'CASA B', 'C', '48636095824'),
(16, 'THIAGO DE AZEVEDO', 'THIAGO22ENG@GMAIL.COM', 11997021738, 1125612203, 'RUA NANCIB RACHID', 'CARAGUATATUBA', 'CARAGUATATUBA', 16, 'PONTAL DE SANTA MARINA', '11672141', 'CASA B', '', '08950320827'),
(17, 'ROBERTO AFRICO', 'ROBERTOAFRICO@GMAIL.COM', 19919191919, 1126616161, 'RUA SÃO MARCOS', 'CARAGUATATUBA', 'CARAGUATATUBA', 61, 'MORRO DO ALGODÃO', '11671450', 'CASA 61', 'CONDOMINIO VILA PORTO SEGURO', '04412805875');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_clienteanimais`
--

CREATE TABLE `tb_clienteanimais` (
  `cod_cadastro` int(10) NOT NULL,
  `cod_cliente` int(10) NOT NULL,
  `cod_tipo_animal` int(10) NOT NULL,
  `nome_raca_animal` varchar(50) NOT NULL,
  `nome_animal` varchar(50) DEFAULT '0',
  `pesoAnimal` varchar(10) DEFAULT '0',
  `alturaAnimal` varchar(10) DEFAULT '0',
  `corAnimal` varchar(20) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_clienteanimais`
--

INSERT INTO `tb_clienteanimais` (`cod_cadastro`, `cod_cliente`, `cod_tipo_animal`, `nome_raca_animal`, `nome_animal`, `pesoAnimal`, `alturaAnimal`, `corAnimal`) VALUES
(4, 9, 3, 'CANARIO', 'BILU', '20G', '12CM', 'AMARELO/VERDE'),
(9, 9, 1, 'SHIH TSU', 'THOR', '', '', ''),
(14, 14, 1, 'DALMATA', 'CARRERINHA', '3KG', '90CM', 'PRETO/BRANCO'),
(15, 9, 2, 'PERSA', 'IURI', '', '', ''),
(16, 15, 2, 'PERSA', 'THORRRRRRRRRRRR', '', '', ''),
(17, 16, 1, 'POODLE', 'PIT', '2KG', '20CM', 'BRANCO'),
(18, 15, 1, 'DALMATA', 'JOW', '50KG', '1,00', 'MARROM'),
(19, 17, 1, 'PITBULL', 'HUCK', '15KG', '', '');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_consulta`
--

CREATE TABLE `tb_consulta` (
  `codConsulta` int(4) NOT NULL,
  `CodCliente` int(4) NOT NULL,
  `cod_tipo_animal_consulta` int(10) NOT NULL,
  `cod_raca_animal_consulta` varchar(50) NOT NULL,
  `cod_veterinario` int(10) DEFAULT '0',
  `desc_servicos` longtext NOT NULL,
  `valortotal_consulta` varchar(10) NOT NULL DEFAULT '0',
  `dataConsulta` date NOT NULL,
  `horaConsulta` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_consulta`
--

INSERT INTO `tb_consulta` (`codConsulta`, `CodCliente`, `cod_tipo_animal_consulta`, `cod_raca_animal_consulta`, `cod_veterinario`, `desc_servicos`, `valortotal_consulta`, `dataConsulta`, `horaConsulta`) VALUES
(84, 14, 1, 'DALMATA', 2, ' CONSULTA	-R$ 30,00.\n HIDRATAÇÃO	-R$ 30,00.\n', 'R$ 60', '2020-12-25', '16:00:00'),
(88, 9, 2, 'PERSA', 1, ' BANHO E TOSA ESPECIAL	-R$ 45,00.\n', 'R$ 45', '2020-12-16', '15:00:00'),
(97, 15, 1, 'DALMATA', 1, ' CONSULTA	-R$ 30,00.\n BANHO E TOSA PET GRANDE	-R$ 36,00.\n TAXI DOG	-R$ 10,00.\n', 'R$ 76', '2020-12-23', '13:00:00'),
(98, 14, 1, 'DALMATA', 2, ' TOSA GRANDE	-R$ 25,00.\n HIDRATAÇÃO	-R$ 30,00.\n', 'R$ 55', '2021-01-05', '18:00:00'),
(99, 17, 1, 'PITBULL', 2, ' CONSULTA	-R$ 30,00.\n BANHO E TOSA PET GRANDE	-R$ 36,00.\n', 'R$ 66', '2021-01-10', '12:00:00');

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
(9, 'X', 'TESTE', 'TESTE');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_produtos`
--

CREATE TABLE `tb_produtos` (
  `cod_produto` int(11) NOT NULL,
  `nome_produto` varchar(50) NOT NULL,
  `preco_produto` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_raca`
--

CREATE TABLE `tb_raca` (
  `codigo_index_raca` int(11) NOT NULL,
  `cod_raca_animal` int(11) NOT NULL,
  `nome_raca_animal` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_raca`
--

INSERT INTO `tb_raca` (`codigo_index_raca`, `cod_raca_animal`, `nome_raca_animal`) VALUES
(1, 2, 'ANGORA'),
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
(21, 2, 'PERSA'),
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
(36, 2, 'DRAGÃOS');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_racatipo`
--

CREATE TABLE `tb_racatipo` (
  `cod_RacaTipo` int(10) NOT NULL,
  `Raca` int(10) NOT NULL,
  `Tipo` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_racatipo`
--

INSERT INTO `tb_racatipo` (`cod_RacaTipo`, `Raca`, `Tipo`) VALUES
(1, 1, 1),
(2, 4, 2),
(3, 2, 1),
(4, 3, 2);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_raca_novo`
--

CREATE TABLE `tb_raca_novo` (
  `cod_raca_animal` int(10) NOT NULL,
  `nome_raca_animal` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_raca_novo`
--

INSERT INTO `tb_raca_novo` (`cod_raca_animal`, `nome_raca_animal`) VALUES
(1, 'Dalmata'),
(2, 'Pitbull'),
(3, 'Siames'),
(4, 'Persa');

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
(8, 'BANHO E TOSA ESPECIAL', '45,00'),
(9, 'BANHO MEDICINAL GRANDE', '5,00'),
(10, 'BANHO MEDICINAL MEDIO', '4,50'),
(11, 'BANHO MEDICINAL PEQUENO', '3,50'),
(12, 'BANHO E TOSA PET GRANDE', '36,00'),
(13, 'BANHO E TOSA PET MEDIO', '31,00'),
(14, 'BANHO E TOSA PET PEQUENO', '28,00'),
(15, 'TOSA GRANDE', '24,00'),
(16, 'TOSA MEDIO', '22,00'),
(17, 'TOSA PEQUENO', '20,00'),
(18, 'HIDRATAÇÃO', '30,00'),
(19, 'MASSAGEM E BANHOS RELAXANTES', '50,00'),
(20, 'HOSPEDAGEM', '25,00'),
(21, 'TAXI DOG', '10,00'),
(22, 'DOG WALKER', '15,00'),
(23, 'DOAÇÃO DE PET', '0,00'),
(24, 'CONSULTA', '30,00');

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
-- Estrutura da tabela `tb_tipo_animal_novo`
--

CREATE TABLE `tb_tipo_animal_novo` (
  `cod_tipo_animal` int(10) NOT NULL,
  `nome_tipo_animal` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_tipo_animal_novo`
--

INSERT INTO `tb_tipo_animal_novo` (`cod_tipo_animal`, `nome_tipo_animal`) VALUES
(1, 'Dog'),
(2, 'Cat');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_veterinario`
--

CREATE TABLE `tb_veterinario` (
  `codVeterinario` int(10) NOT NULL,
  `nomeVeterinario` varchar(20) NOT NULL,
  `sobrenomeVeterinario` varchar(30) NOT NULL,
  `crmv` varchar(4) NOT NULL,
  `especializacao` varchar(20) NOT NULL,
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
(1, 'NENHUM', 'NENHUM', '0000', 'NENHUM', 'ENDERECO', '', '', 'BAIRRO', '00000000', 0, '0', '0', 0, 0),
(2, 'ANTONIO', 'CARLOS CAMEROTE', '5574', 'CIRURGIA', 'RUA DOMINGOS DOS REIS QUITA', 'SÃO PAULO', 'SP', 'USINA PIRATININGA', '04444010', 16, 'CASA B', 'ANTONIO.CARLOS@MEDICAL.COM', 1125612203, 11967757056),
(3, 'BRUNO', 'SILVA', '1148', 'GASTRO', 'TRAVESSA SONHO DO ASTRÓLOGO', 'SÃO PAULO', 'SP', 'AMERICANÓPOLIS', '04411010', 566, 'CASA', 'BRUNO@TREINAMENTOS.COM', 1116644656, 15188844444);

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
  ADD KEY `fk_TipoAnimaltbAnimais` (`cod_tipo_animal`);

--
-- Indexes for table `tb_consulta`
--
ALTER TABLE `tb_consulta`
  ADD PRIMARY KEY (`codConsulta`),
  ADD KEY `CodCliente_tb_animal` (`CodCliente`),
  ADD KEY `fk_VeterinariotbVeterinario_consulta` (`cod_veterinario`),
  ADD KEY `fk_TipoAnimaltbanimalCliente` (`cod_tipo_animal_consulta`);

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
-- Indexes for table `tb_raca`
--
ALTER TABLE `tb_raca`
  ADD PRIMARY KEY (`codigo_index_raca`),
  ADD UNIQUE KEY `nome_raca_animal` (`nome_raca_animal`),
  ADD KEY `cod_raca_animal` (`cod_raca_animal`);

--
-- Indexes for table `tb_racatipo`
--
ALTER TABLE `tb_racatipo`
  ADD PRIMARY KEY (`cod_RacaTipo`),
  ADD KEY `fkraca` (`Raca`),
  ADD KEY `fktipo` (`Tipo`);

--
-- Indexes for table `tb_raca_novo`
--
ALTER TABLE `tb_raca_novo`
  ADD PRIMARY KEY (`cod_raca_animal`);

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
-- Indexes for table `tb_tipo_animal_novo`
--
ALTER TABLE `tb_tipo_animal_novo`
  ADD PRIMARY KEY (`cod_tipo_animal`);

--
-- Indexes for table `tb_veterinario`
--
ALTER TABLE `tb_veterinario`
  ADD PRIMARY KEY (`codVeterinario`),
  ADD UNIQUE KEY `crmv` (`crmv`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tb_cliente`
--
ALTER TABLE `tb_cliente`
  MODIFY `CodCliente` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `tb_clienteanimais`
--
ALTER TABLE `tb_clienteanimais`
  MODIFY `cod_cadastro` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `tb_consulta`
--
ALTER TABLE `tb_consulta`
  MODIFY `codConsulta` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=100;

--
-- AUTO_INCREMENT for table `tb_funcionario`
--
ALTER TABLE `tb_funcionario`
  MODIFY `codFuncionario` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tb_login`
--
ALTER TABLE `tb_login`
  MODIFY `codUsuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `tb_raca`
--
ALTER TABLE `tb_raca`
  MODIFY `codigo_index_raca` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT for table `tb_racatipo`
--
ALTER TABLE `tb_racatipo`
  MODIFY `cod_RacaTipo` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `tb_raca_novo`
--
ALTER TABLE `tb_raca_novo`
  MODIFY `cod_raca_animal` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `tb_servicos`
--
ALTER TABLE `tb_servicos`
  MODIFY `cod_servico` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT for table `tb_tipo_animal`
--
ALTER TABLE `tb_tipo_animal`
  MODIFY `cod_tipo_animal` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `tb_tipo_animal_novo`
--
ALTER TABLE `tb_tipo_animal_novo`
  MODIFY `cod_tipo_animal` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tb_veterinario`
--
ALTER TABLE `tb_veterinario`
  MODIFY `codVeterinario` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `tb_clienteanimais`
--
ALTER TABLE `tb_clienteanimais`
  ADD CONSTRAINT `fk_ClientetbClientes` FOREIGN KEY (`cod_cliente`) REFERENCES `tb_cliente` (`CodCliente`),
  ADD CONSTRAINT `fk_TipoAnimaltbAnimais` FOREIGN KEY (`cod_tipo_animal`) REFERENCES `tb_tipo_animal` (`cod_tipo_animal`);

--
-- Limitadores para a tabela `tb_consulta`
--
ALTER TABLE `tb_consulta`
  ADD CONSTRAINT `fk_ClientetbanimalCliente_consulta` FOREIGN KEY (`CodCliente`) REFERENCES `tb_cliente` (`CodCliente`),
  ADD CONSTRAINT `fk_TipoAnimaltbanimalCliente` FOREIGN KEY (`cod_tipo_animal_consulta`) REFERENCES `tb_tipo_animal` (`cod_tipo_animal`),
  ADD CONSTRAINT `fk_VeterinariotbVeterinario_consulta` FOREIGN KEY (`cod_veterinario`) REFERENCES `tb_veterinario` (`codVeterinario`);

--
-- Limitadores para a tabela `tb_raca`
--
ALTER TABLE `tb_raca`
  ADD CONSTRAINT `tb_raca_ibfk_1` FOREIGN KEY (`cod_raca_animal`) REFERENCES `tb_tipo_animal` (`cod_tipo_animal`);

--
-- Limitadores para a tabela `tb_racatipo`
--
ALTER TABLE `tb_racatipo`
  ADD CONSTRAINT `fkraca` FOREIGN KEY (`Raca`) REFERENCES `tb_raca_novo` (`cod_raca_animal`),
  ADD CONSTRAINT `fktipo` FOREIGN KEY (`Tipo`) REFERENCES `tb_tipo_animal_novo` (`cod_tipo_animal`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
