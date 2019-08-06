create table student
(id int identity(1,1) primary key ,
name varchar(50),age int,
sex int,
mobile varchar(10),
email varchar(50)
) 

--drop table student

insert into student values ('srinu vadapalli',
29,
1,
'9491378864',
'srinu.vadapalli664@gmail.com'
)

select * from student