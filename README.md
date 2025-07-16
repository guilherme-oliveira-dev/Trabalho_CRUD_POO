Trabalho final de POO, CRUD de tela de cadastro clinica veterinaria feita em c# com acesso a banco de dados MYSQL.

## 💾 Script de criação do banco de dados

CREATE DATABASE clinicavet;
USE clinicavet;
CREATE TABLE `pets` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(100) NOT NULL,
  `especie` VARCHAR(50),
  `raca` VARCHAR(50),
  `nome_dono` VARCHAR(100),
  `telefone_dono` VARCHAR(20),
  `data_nascimento` DATE,
  `tipo` VARCHAR(50),
  PRIMARY KEY (`id`)
);
