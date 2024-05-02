/*Create following tables in SQL Schema with appropriate class and 
write the unit test case for the Project Management application*/
CREATE SCHEMA Case_Study

CREATE DATABASE ProjectManagementSystem
USE ProjectManagementSystem

--Creating table 'Employee'
CREATE TABLE Employee(
id INT IDENTITY(01,1) NOT NULL PRIMARY KEY,
[name] VARCHAR(20),
Designation VARCHAR(35),
Gender VARCHAR(10),
Salary MONEY,
project_id INT)

--Creating table 'Project'
CREATE TABLE Project(
Id INT IDENTITY (200,1) NOT NULL PRIMARY KEY,
ProjectName VARCHAR(35),
[Description] TEXT,
[Start date] DATE,
[Status] VARCHAR(25),
CONSTRAINT Status_check CHECK ([Status] IN ('Started','Developed','Build','Tested','Deployed')))

--Creating table 'Task'
CREATE TABLE Task(
task_id INT IDENTITY(50,1) NOT NULL PRIMARY KEY,
task_name VARCHAR(45),
project_id INT,
FOREIGN KEY(project_id) REFERENCES Project(Id),
employee_id INT,
FOREIGN KEY(employee_id) REFERENCES Employee(id),
[Status] VARCHAR(20),
CONSTRAINT Status_ck CHECK ([Status] IN ('Assigned','Started','Completed')))

--Creating constraints for Referential Integrity
ALTER TABLE Employee
ADD CONSTRAINT Project_FK
FOREIGN KEY(project_id) REFERENCES Project(Id)

--Inserting values into the tables
INSERT INTO Employee VALUES ('Richard','UX Designer','Male',62000,202),
                            ('Camila','Programmer','Female',65000,204),
							('Benjamin','Analyst','Male',54200,201),
							('Michaela','QA Engineer','Female',45000,205),
							('Grace','Full Stack Developer','Female',72500,203)

INSERT INTO Project VALUES 
('Expense Tracker',
'An Application that tracks user income and expenses helping them stay on budget', 
'2024-02-16','Build'),
('E-commerce Website',
'Web Application that allows to users to browse products,add them to shopping cart and checkout securely',
GETDATE(),'Started'),
('Smart Home Assistant',
'An Application allows users to control smart home devices through voice commands or a mobile interface',
'2023-11-25','Tested'),
('Task Management System',
'Application to manage tasks,deadlines and team collaboration with progress tracking',
'2022-05-08','Deployed'),
('Polyglot','Application to help users learn a new languages through interactive lessons,quizzes and vocabulary exercises',
'2024-03-17','Developed')

INSERT INTO Task VALUES('Create Interface',201,01,'Started'),
                       ('Analyse Market Conditions',203,03,'Completed'),
                       ('Develop User Profile',204,05,'Completed'),
                       ('Create Visualization Graphs',200,02,'Assigned'),
                       ('Ensure Quality',202,04,'Assigned')



