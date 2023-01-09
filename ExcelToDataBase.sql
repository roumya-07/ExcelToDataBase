CREATE table Emp_1
(
Id   INT primary key,
Name VARCHAR(100),
Email VARCHAR(50),
Mobile Varchar(12),
Specialization Varchar(10)
);

CREATE TYPE Emp_2 AS TABLE
(
Id   INT primary key,
Name VARCHAR(100),
Email VARCHAR(50),
Mobile Varchar(12),
Specialization Varchar(10)
);


Create PROCEDURE InsertEmp_1
(
@ParLessonType Emp_2 READONLY,
@Action Varchar(20)
)
AS
begin
If(@Action='Insert')
	INSERT INTO Emp_1
	SELECT * FROM @ParLessonType
Else If(@Action='SelectAll')
	Select * from Emp_1
end;  
    
--EXECUTE InsertEmp_1;

--select * from Emp_1;

--Truncate Table Emp_1;