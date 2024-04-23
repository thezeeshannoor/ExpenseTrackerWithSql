create table expense(ID int primary key,Expense_Name varchar(100),Expense_Desc varchar(200),Expense_Amount int,Expense_Time DateTime)
insert into expense values(1,'tyre','tyre blast',200, CURRENT_TIMESTAMP);
select * from expense;