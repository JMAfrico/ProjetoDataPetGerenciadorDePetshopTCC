-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 17-Nov-2020 às 18:33
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

INSERT INTO `tb_cliente` (`CodCliente`, `nomeCliente`, `emailCliente`, `TelefoneCelularCli`, `TelefoneFixoCli`, `enderecoCliente`, `numeroResidenciaCliente`, `bairroCliente`, `cepCliente`, `complementoCliente`, `referencia_cliente`, `cpfCliente`) VALUES
(6, 'JOAO MARCOS AFRICO DA SILVA', 'JOAO_MARCOSSILVA@HOTMAIL.CO', 11982650333, 1125612203, 'AVENIDA JOSE BORGES DO CANTO', 16, 'ITAIM PAULISTA', '08142010', 'CASA B', 'EM FRENTE ESCOLA ', '39211358850'),
(7, 'BRENO KASHIMA', 'BRENO@HOTMAIL.COM', 11978488488, 1126262626, 'MANOEL TELLES BARRETO', 85, 'PORTO NOVO', '11667260', 'CASA B', 'CASA FEIA', '48636095824'),
(9, 'ELEN CONCEICAO FERREIRA AFRICO', 'ELEN@HOTMAIL.COM', 11966644774, 1122525252, 'JOSÉ BORGES DO CANTO', 16, 'JARDIM CAMARGO NOVO', '08142010', 'CASA', 'EM FRENTE AO MERCADO', '40927503824'),
(10, 'LINDINALVA ELIZA', 'LINDINALVAELIZA@HOTMAIL.COM', 11944515151, 1199987754, 'JOSÉ BORGES DO CANTO', 16, 'JARDIM CAMARGO NOVO', '08142010', 'CASA B', 'PAREDE AZUL', '08950320827');

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
(1, 7, 2, 'RAGDOLL', 'KJ', 'JJK', 'KJ', 'J'),
(2, 9, 2, 'BURMESE', 'O', 'O', 'O', 'O'),
(3, 10, 2, 'SPHYNX', 'TREI', 'F', 'D', 'S'),
(4, 9, 3, 'CANARIO', 'BILU', '20G', '12CM', 'AMARELO/VERDE'),
(5, 10, 3, 'CANARIO', 'PIPI', '25G', '15CM', 'AMARELO/VERDE'),
(6, 10, 3, 'CANARIO', 'PUPU', '3G', '5CM', 'VERDE'),
(8, 7, 1, 'POODLE', 'LEVADO', 'F', 'D', 'S');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_clienteanimal`
--

CREATE TABLE `tb_clienteanimal` (
  `cod_cadastro` int(10) NOT NULL,
  `cod_cliente` int(10) NOT NULL,
  `cod_tipo_animal` int(10) NOT NULL,
  `cod_raca_animal` int(10) NOT NULL,
  `nome_animal` varchar(50) NOT NULL,
  `pesoAnimal` varchar(10) DEFAULT '0',
  `alturaAnimal` varchar(10) DEFAULT '0',
  `corAnimal` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_clienteanimal`
--

INSERT INTO `tb_clienteanimal` (`cod_cadastro`, `cod_cliente`, `cod_tipo_animal`, `cod_raca_animal`, `nome_animal`, `pesoAnimal`, `alturaAnimal`, `corAnimal`) VALUES
(1, 7, 2, 2, 'DS', 'D', 'S', 'S'),
(3, 6, 3, 3, 'JJ', 'J', 'JJ', 'JJ');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_consulta`
--

CREATE TABLE `tb_consulta` (
  `codConsulta` int(4) NOT NULL,
  `CodCliente` int(4) NOT NULL,
  `cod_tipo_animal_consulta` int(10) NOT NULL,
  `cod_raca_animal_consulta` int(10) NOT NULL,
  `cod_veterinario` int(10) NOT NULL,
  `cod_servico` int(10) NOT NULL,
  `valortotal_consulta` varchar(10) NOT NULL DEFAULT '0',
  `dataConsulta` date NOT NULL,
  `horaConsulta` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
  `bairroFuncionario` varchar(30) NOT NULL,
  `cepFuncionario` varchar(8) NOT NULL,
  `numeroResidenciaFuncionario` int(4) NOT NULL,
  `complementoFuncionario` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_funcionario`
--

INSERT INTO `tb_funcionario` (`codFuncionario`, `nomeFuncionario`, `sobrenomeFuncionario`, `emailFuncionario`, `telefoneFixoFunc`, `telefoneCelularFunc`, `enderecoFuncionario`, `bairroFuncionario`, `cepFuncionario`, `numeroResidenciaFuncionario`, `complementoFuncionario`) VALUES
(2, 'EDUARDO ', 'DOS SANTOS', 'EDUARDO_DUDU@GMAIL.COM', 1166587748, 11966562539, 'RUA TIBÚRCIO DE SOUSA', 'ITAIM PAULISTA', '08140000', 877, 'CASA');

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
(4, 'ADMIN', 'ADMIN', 'ADMIN');

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
(34, 1, 'YORKSHIRE');

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
(15, 'TOSA GRANDE', '25,00'),
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
-- Estrutura da tabela `tb_veterinario`
--

CREATE TABLE `tb_veterinario` (
  `codVeterinario` int(10) NOT NULL,
  `nomeVeterinario` varchar(20) NOT NULL,
  `sobrenomeVeterinario` varchar(30) NOT NULL,
  `crmv` varchar(4) NOT NULL,
  `especializacao` varchar(20) NOT NULL,
  `enderecoVeterinario` varchar(50) NOT NULL,
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

INSERT INTO `tb_veterinario` (`codVeterinario`, `nomeVeterinario`, `sobrenomeVeterinario`, `crmv`, `especializacao`, `enderecoVeterinario`, `bairroVeterinario`, `cepVeterinario`, `numeroResidenciaVeterinario`, `complementoVeterinario`, `emailVeterinario`, `telefoneFixoVet`, `telefoneCelularVet`) VALUES
(4, 'ANTONIO', 'CARLOS', '1557', 'CIRURGIÃO', 'LORENA', 'JARDIM PAULISTA', '01424002', 54, 'APTO 53 E 54', 'DDR@HOTMAIL.COM', 1125645525, 15554884444);

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
-- Indexes for table `tb_clienteanimal`
--
ALTER TABLE `tb_clienteanimal`
  ADD PRIMARY KEY (`cod_cadastro`),
  ADD UNIQUE KEY `fk_RacaAnimaltbA` (`cod_raca_animal`) USING BTREE,
  ADD KEY `fk_ClientetbCliente` (`cod_cliente`),
  ADD KEY `fk_TipoAnimaltbAnimal` (`cod_tipo_animal`);

--
-- Indexes for table `tb_consulta`
--
ALTER TABLE `tb_consulta`
  ADD PRIMARY KEY (`codConsulta`),
  ADD KEY `CodCliente_tb_animal` (`CodCliente`),
  ADD KEY `fk_TipoAnimaltbanimalCliente` (`cod_tipo_animal_consulta`),
  ADD KEY `fk_RacaAnimaltbanimalCliente_consulta` (`cod_raca_animal_consulta`),
  ADD KEY `fk_VeterinariotbVeterinario_consulta` (`cod_veterinario`),
  ADD KEY `fk_ServicostbServicos_consulta` (`cod_servico`);

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
-- Indexes for table `tb_raca`
--
ALTER TABLE `tb_raca`
  ADD PRIMARY KEY (`codigo_index_raca`),
  ADD UNIQUE KEY `nome_raca_animal` (`nome_raca_animal`),
  ADD KEY `cod_raca_animal` (`cod_raca_animal`);

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
  ADD UNIQUE KEY `crmv` (`crmv`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tb_cliente`
--
ALTER TABLE `tb_cliente`
  MODIFY `CodCliente` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `tb_clienteanimais`
--
ALTER TABLE `tb_clienteanimais`
  MODIFY `cod_cadastro` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `tb_clienteanimal`
--
ALTER TABLE `tb_clienteanimal`
  MODIFY `cod_cadastro` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `tb_consulta`
--
ALTER TABLE `tb_consulta`
  MODIFY `codConsulta` int(4) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tb_funcionario`
--
ALTER TABLE `tb_funcionario`
  MODIFY `codFuncionario` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tb_login`
--
ALTER TABLE `tb_login`
  MODIFY `codUsuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `tb_raca`
--
ALTER TABLE `tb_raca`
  MODIFY `codigo_index_raca` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

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
  ADD CONSTRAINT `fk_ClientetbClientes` FOREIGN KEY (`cod_cliente`) REFERENCES `tb_cliente` (`CodCliente`),
  ADD CONSTRAINT `fk_TipoAnimaltbAnimais` FOREIGN KEY (`cod_tipo_animal`) REFERENCES `tb_tipo_animal` (`cod_tipo_animal`);

--
-- Limitadores para a tabela `tb_clienteanimal`
--
ALTER TABLE `tb_clienteanimal`
  ADD CONSTRAINT `fk_ClientetbCliente` FOREIGN KEY (`cod_cliente`) REFERENCES `tb_cliente` (`CodCliente`),
  ADD CONSTRAINT `fk_TipoAnimaltbAnimal` FOREIGN KEY (`cod_tipo_animal`) REFERENCES `tb_tipo_animal` (`cod_tipo_animal`);

--
-- Limitadores para a tabela `tb_consulta`
--
ALTER TABLE `tb_consulta`
  ADD CONSTRAINT `fk_ClientetbanimalCliente_consulta` FOREIGN KEY (`CodCliente`) REFERENCES `tb_clienteanimal` (`cod_cliente`),
  ADD CONSTRAINT `fk_RacaAnimaltbanimalCliente_consulta` FOREIGN KEY (`cod_raca_animal_consulta`) REFERENCES `tb_clienteanimal` (`cod_raca_animal`),
  ADD CONSTRAINT `fk_ServicostbServicos_consulta` FOREIGN KEY (`cod_servico`) REFERENCES `tb_servicos` (`cod_servico`),
  ADD CONSTRAINT `fk_TipoAnimaltbanimalCliente` FOREIGN KEY (`cod_tipo_animal_consulta`) REFERENCES `tb_clienteanimal` (`cod_tipo_animal`),
  ADD CONSTRAINT `fk_VeterinariotbVeterinario_consulta` FOREIGN KEY (`cod_veterinario`) REFERENCES `tb_veterinario` (`codVeterinario`);

--
-- Limitadores para a tabela `tb_raca`
--
ALTER TABLE `tb_raca`
  ADD CONSTRAINT `tb_raca_ibfk_1` FOREIGN KEY (`cod_raca_animal`) REFERENCES `tb_tipo_animal` (`cod_tipo_animal`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
