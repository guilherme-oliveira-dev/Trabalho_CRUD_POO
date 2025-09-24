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






