use master
go
if(DB_ID('KFC_DB2') is not null)
	drop database KFC_DB2
go
create database KFC_DB2
go

use KFC_DB2
go
--table FOOD
create table FOOD
(
FoodID varchar(5) not null,
FoodName ntext NOT NULL, 
FoodPrice int NOT null,
DiscountPrice int,
Image text,
Description ntext,
FoodGroupID varchar(5),

primary key (foodID)
)

--TABLE FOOD_GROUP
go
create table FOOD_GROUP
(
FoodGroupID varchar(5) not null,
FoodGroupName nvarchar(100) NOT null,

primary key (foodGroupID)
)

--TABLE BILL
go
create table BILL
(
BillID varchar(30) not null,
BillDate datetime,
Total int NOT NULL,
BillStatus int NOT NULL,
DeleteNote ntext,
EmpID varchar(5) NOT NULL,
OrderID varchar(30) NOT NULL,

primary key ( BillID)
)

--TABLE ORDER
go
create table ORDER_
(
OrderID varchar(30) not null,
OrderDate datetime NOT NULL,
TableNum int NOT NULL,
OrderStatus int NOT NULL,
OrderNote ntext,

primary key (OrderID)
)

--TABLE ORDER_DETAIL
go
create table ORDER_DETAIL
(
OrderID varchar(30) not null,
FoodID varchar(5) not null,
Quantity int NOT NULL,
CompleteTime datetime ,
Priority int,
FoodNote ntext,

primary key (OrderID, FoodID)
)

--TABLE EMPLOYEE
go
create table EMPLOYEE
(
EmpID varchar(5) not null,
PositionID varchar(5),
Username nvarchar(50) NOT NULL,
Password varchar(30) NOT NULL,

primary key (EmpID)
)

--TABLE PERMISSION
go
create table PERMISSION
(
PositionID varchar(5) not null,
Position nvarchar(100),
Permission varchar(100),

primary key (PositionID)
)

--TABLE EMPLOYEE_INFO
go
create table EMPLOYEE_INFO
(
EmpID  varchar(5) not null,
EmpName nvarchar(100) NOT NULL,
Sex bit NOT NULL,
DateOfBirth datetime,
PhoneNumber varchar(11),
Address nvarchar(1000),

primary key (EmpID)
)

--TABLE WARNING
go
create table WARNING
(
WarningID varchar(5),
WarningName varchar(100),
Content text,

primary key (WarningID)
)

--TABLE PARAMETER
go
create table PARAMETER
(
ParaID varchar(5) not null,
Type varchar(30),
Value varchar(100),
Status varchar(100),

primary key (ParaID)
)

--ADD CONSTRAINT

--TABLE FOOD
go
alter table FOOD 
add constraint FK_FOOD_FOOD_GROUP
foreign key (FoodGroupID)
references FOOD_GROUP (FoodGroupID)

--TABLE EMPLOYEE
go
alter table EMPLOYEE
add constraint FK_EMP_PERMISSION
foreign key (PositionID)
references PERMISSION (PositionID),

constraint FK_EMP_EMP_INFO
foreign key (EmpID)
references EMPLOYEE_INFO(EmpID)

--TABLE BILL
go
alter table BILL
add constraint FK_BILL_EMP
foreign key (EmpID)
references EMPLOYEE(EmpID),
constraint FK_BILL_ORDER
foreign key (OrderID)
references ORDER_(OrderID)

--TABLE ORDER_DETAIL
go
alter table ORDER_DETAIL
add constraint FK_ORDER_DETAIL_ORDER
foreign key (OrderID)
references ORDER_(OrderID),
constraint FK_ORDER_DETAIL_FOOD
foreign key (FoodID)
references FOOD(FoodID)