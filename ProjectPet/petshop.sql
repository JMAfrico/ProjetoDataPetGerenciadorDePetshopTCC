-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 01-Nov-2019 às 03:32
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
-- Database: `petshop`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_animal`
--

CREATE TABLE `tb_animal` (
  `codAnimal` int(4) NOT NULL,
  `sexoAnimal` varchar(1) NOT NULL,
  `descricaoAnimal` varchar(50) DEFAULT NULL,
  `nomeAnimal` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tb_animal`
--

INSERT INTO `tb_animal` (`codAnimal`, `sexoAnimal`, `descricaoAnimal`, `nomeAnimal`) VALUES
(1, 'M', 'Poodle', 'Levado'),
(2, 'M', 'Poodle', 'Levado'),
(3, 'M', 'Poodle', 'Levado'),
(4, 'M', 'dsds', 'ffff'),
(5, 'F', 'PITBULL', 'MARIA'),
(6, 'M', 'PITBULL', 'MARIA');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_atendimento`
--

CREATE TABLE `tb_atendimento` (
  `codAnimal` int(4) NOT NULL,
  `codVeterinario` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_cliente`
--

CREATE TABLE `tb_cliente` (
  `CodCliente` int(4) NOT NULL,
  `CodAnimal` int(4) NOT NULL,
  `nomeCliente` varchar(30) NOT NULL,
  `emailCliente` varchar(50) NOT NULL,
  `TelefoneCelularCli` int(11) NOT NULL,
  `TelefoneFixoCli` int(10) DEFAULT NULL,
  `enderecoCliente` varchar(50) NOT NULL,
  `numeroResidenciaCliente` int(4) NOT NULL,
  `bairroCliente` varchar(30) NOT NULL,
  `cepCliente` int(8) NOT NULL,
  `complementoCliente` varchar(50) NOT NULL,
  `cpfCliente` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_consulta`
--

CREATE TABLE `tb_consulta` (
  `codConsulta` int(4) NOT NULL,
  `relatoConsulta` varchar(50) NOT NULL,
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
  `telefoneFixoFunc` int(10) DEFAULT NULL,
  `telefoneCelularFunc` int(11) NOT NULL,
  `enderecoFuncionario` varchar(50) NOT NULL,
  `bairroFuncionario` varchar(30) NOT NULL,
  `cepFuncionario` int(8) NOT NULL,
  `numeroResidenciaFuncionario` int(4) NOT NULL,
  `complementoFuncionario` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_marca`
--

CREATE TABLE `tb_marca` (
  `codFuncionario` int(4) NOT NULL,
  `codConsulta` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_tem`
--

CREATE TABLE `tb_tem` (
  `codAnimal` int(4) NOT NULL,
  `codConsulta` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_veterinario`
--

CREATE TABLE `tb_veterinario` (
  `codVeterinario` int(4) NOT NULL,
  `nomeVeterinario` varchar(20) NOT NULL,
  `sobrenomeVeterinario` varchar(30) NOT NULL,
  `crmv` int(4) NOT NULL,
  `especializacao` varchar(20) NOT NULL,
  `enderecoVeterinario` varchar(50) NOT NULL,
  `bairroVeterinario` varchar(30) NOT NULL,
  `cepVeterinario` int(8) NOT NULL,
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
(1, 'joao', 'marcos', 1111, 'ortopedista', 'av jose borges', 'itaim', 8142010, 16, 'casa', 'joaomarcos@hotmail.com', 1125612203, 11960164015),
(2, 'joao', 'africo', 7789, 'ortopedista', 'av jose dos campo', 'itaqua', 8142010, 16, 'casa', 'joazeras', 1125612203, 11960164015),
(3, 'eu', 'mesmo', 1112, 'outro', 'avenida', 'itaimiim0', 8142010, 16, 'predio', 'joaozeras', 1125612203, 11960164015),
(4, 'joao', 'joao', 1591, 'kkkk', 'rua 2', 'itaim', 8142010, 11, 'apto', 'joao@123', 1125612203, 11960164015);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tb_animal`
--
ALTER TABLE `tb_animal`
  ADD PRIMARY KEY (`codAnimal`);

--
-- Indexes for table `tb_atendimento`
--
ALTER TABLE `tb_atendimento`
  ADD KEY `codAnimal_fk_atend` (`codAnimal`),
  ADD KEY `codVeterinario_fk_atend` (`codVeterinario`);

--
-- Indexes for table `tb_cliente`
--
ALTER TABLE `tb_cliente`
  ADD PRIMARY KEY (`CodCliente`),
  ADD KEY `codAnimal_fk` (`CodAnimal`);

--
-- Indexes for table `tb_consulta`
--
ALTER TABLE `tb_consulta`
  ADD PRIMARY KEY (`codConsulta`);

--
-- Indexes for table `tb_funcionario`
--
ALTER TABLE `tb_funcionario`
  ADD PRIMARY KEY (`codFuncionario`);

--
-- Indexes for table `tb_marca`
--
ALTER TABLE `tb_marca`
  ADD KEY `codFuncionario_fk_marca` (`codFuncionario`),
  ADD KEY `codConsulta_fk_marca` (`codConsulta`);

--
-- Indexes for table `tb_tem`
--
ALTER TABLE `tb_tem`
  ADD KEY `codAnimal_fk_tem` (`codAnimal`),
  ADD KEY `codConsulta_fk_tem` (`codConsulta`);

--
-- Indexes for table `tb_veterinario`
--
ALTER TABLE `tb_veterinario`
  ADD PRIMARY KEY (`codVeterinario`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tb_animal`
--
ALTER TABLE `tb_animal`
  MODIFY `codAnimal` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `tb_cliente`
--
ALTER TABLE `tb_cliente`
  MODIFY `CodCliente` int(4) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tb_consulta`
--
ALTER TABLE `tb_consulta`
  MODIFY `codConsulta` int(4) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tb_funcionario`
--
ALTER TABLE `tb_funcionario`
  MODIFY `codFuncionario` int(4) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tb_veterinario`
--
ALTER TABLE `tb_veterinario`
  MODIFY `codVeterinario` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `tb_atendimento`
--
ALTER TABLE `tb_atendimento`
  ADD CONSTRAINT `codAnimal_fk_atend` FOREIGN KEY (`codAnimal`) REFERENCES `tb_animal` (`codAnimal`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `codVeterinario_fk_atend` FOREIGN KEY (`codVeterinario`) REFERENCES `tb_veterinario` (`codVeterinario`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `tb_cliente`
--
ALTER TABLE `tb_cliente`
  ADD CONSTRAINT `CodAnimal_fk` FOREIGN KEY (`CodAnimal`) REFERENCES `tb_animal` (`codAnimal`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `tb_marca`
--
ALTER TABLE `tb_marca`
  ADD CONSTRAINT `codConsulta_fk_marca` FOREIGN KEY (`codConsulta`) REFERENCES `tb_consulta` (`codConsulta`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `codFuncionario_fk_marca` FOREIGN KEY (`codFuncionario`) REFERENCES `tb_funcionario` (`codFuncionario`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `tb_tem`
--
ALTER TABLE `tb_tem`
  ADD CONSTRAINT `CodAnimal_fk_tem` FOREIGN KEY (`codAnimal`) REFERENCES `tb_animal` (`codAnimal`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `codVeterinario_fk_tem` FOREIGN KEY (`codConsulta`) REFERENCES `tb_consulta` (`codConsulta`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
