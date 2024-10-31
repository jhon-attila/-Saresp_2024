create database AppSaresp2024;
use AppSaresp2024;

create table ProfessorAplicador(
IdProf int primary key auto_increment,
Nome varchar(200) not null,
CPF bigint not null,
RG int not null,
telefone bigint not null,
DataNasc date not null
);

create table Aluno(
IdAluno int primary key auto_increment,
nome varchar(200) not null,
Email varchar(200) not null,
Serie tinyint not null,
Turma char(1) not null,
datanasc date not null
);