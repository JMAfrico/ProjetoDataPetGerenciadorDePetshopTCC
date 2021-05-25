create table tab_pacientes(

	id_paciente int identity(1,1),
	nome_paciente varchar(50) not null,
    endereco_paciente varchar(50) not null,
    telefone_paciente varchar(11) not null,
    sexo_paciente varchar (1),
    nascimento_paciente date,
    primary key(id_paciente)
)

create table tab_medicos(

	id_medico int identity (1,1) ,
    nome_medico varchar(50) not null,
    endereco_medico varchar (50) not null,
    telefone_medico varchar (11) not null,
    sexo_medico varchar (1),
	especialidade_medico varchar(30)
    primary key(id_medico)
)

create table tab_consultas(

	id_consulta int identity (1,1),
    nome_paciente varchar(50) not null,
    nome_medico varchar(50)not null,
    dia_consulta date,
	primary key (id_consulta)
    
)
