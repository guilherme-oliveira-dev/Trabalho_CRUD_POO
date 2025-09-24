select *from aluno where altura in (1.52,1.65,1.67);

select * from aluno where sexo = "f" and altura > (1.65);

select * from caixa where DataFechamento > '2025-05-05' and DataFechamento < '2025-05-08';

select * from aluno urdeby nome;

select * from aluno where nome like 'a%';

select * from aluno where nome like '%a';

select * from aluno where nome like '%a%';

select * from aluno where nome like '_a%';

select * from aluno where CPF like '360.2__.947-70';

select count(*) from aluno where sexo= "f";
select count(*) from aluno where sexo= "m";

select sum(saldofinal) from caixa;

select avg(saldofinal) from caixa; 

select max(saldofinal) from caixa;

select min(saldofinal) from caixa;

select distinct(nome) from aluno;

select * from aluno where altura between 1.65 and 1.75;

alter table aluno add column peso varchar(50);

update aluno set peso= "50" where id_aluno = "1";
update aluno set peso= "55" where id_aluno = "2";
update aluno set peso= "60" where id_aluno = "3";
update aluno set peso= "65" where id_aluno = "4";
update aluno set peso= "70" where id_aluno = "5";
update aluno set peso= "75" where id_aluno = "6";
update aluno set peso= "11"where id_aluno = "7";
update aluno set peso= "55" where id_aluno = "8";
update aluno set peso= "60" where id_aluno = "9";
update aluno set peso= "65" where id_aluno = "10";
update aluno set peso= "70" where id_aluno = "11";
update aluno set peso= "75" where id_aluno = "12";
update aluno set peso= "55" where id_aluno = "13";
update aluno set peso= "60" where id_aluno = "14";
update aluno set peso= "65" where id_aluno = "15";
update aluno set peso= "70" where id_aluno = "16";
update aluno set peso= "75" where id_aluno = "17";
update aluno set peso= "55" where id_aluno = "18";
update aluno set peso= "60" where id_aluno = "19";
update aluno set peso= "65" where id_aluno = "20";
update aluno set peso= "70" where id_aluno = "21";
update aluno set peso= "75" where id_aluno = "22";
update aluno set peso= "55" where id_aluno = "23";
update aluno set peso= "60" where id_aluno = "24";
update aluno set peso= "65" where id_aluno = "25";
update aluno set peso= "70" where id_aluno = "26";
update aluno set peso= "75" where id_aluno = "27";
update aluno set peso= "55" where id_aluno = "28";
update aluno set peso= "60" where id_aluno = "29";
update aluno set peso= "65" where id_aluno = "30";

select * from aluno;











