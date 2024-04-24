
create table expense(Id int  primary key IDENTITY(1,1)  ,Name nvarchar(100),Description nvarchar(200),Amount decimal,Time DateTime2)
insert into expense values(1,'tyre','tyre blast',200, CURRENT_TIMESTAMP);
select * from expense;
drop table  expense;

alter PROCEDURE spGetExpense
@name varchar(50)
with encryption
as
begin
select * from expense where Expense_Name=@name;
end
 spGetExpense 'tyre';
 sp_helptext spGetExpense;
DROP PROCEDURE spGetExpense

--stored procedure with input and output parameters
create procedure spGetExpensePara
--input parameter
@name varchar(60),

--output parameter
@id int output
as
begin
select @id=count(ID) from expense where Expense_Name=@name;
end

declare @Total int
execute spGetExpensePara 'tyre',@Total output;
select @Total

-- stored procedure to get data of expense
create procedure spGetExpense
as
begin
select * from expense;
end
spGetExpense;

--insert data to expense
alter procedure spAddExpense
@name nvarchar(100),
@desc nvarchar(200),
@amount decimal
as
begin
insert into expense values(@name,@desc,@amount,CURRENT_TIMESTAMP);
end
spAddExpense 'wall','wall paint',20

--total expense store procedure
alter procedure spTotalExpense
as
begin
select sum(Amount) as TotalExpense from expense;
end
spTotalExpense