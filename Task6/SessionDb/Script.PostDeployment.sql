/*
 Шаблон скрипта после развертывания							
--------------------------------------------------------------------------------------
 В данном файле содержатся инструкции SQL, которые будут исполнены перед скриптом построения-	
 Используйте синтаксис SQLCMD для включения файла в скрипт, выполняемый перед развертыванием-			
 Пример:      :r -\myfile-sql								
 Используйте синтаксис SQLCMD для создания ссылки на переменную в скрипте перед развертыванием-		
 Пример:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO Groups(Name)
VALUES ('IP-22'),('IT-11');

INSERT INTO Students (FullName, Gender, BirthDate, GroupId)
VALUES ('Sachek Denis Nikolaevich', 'M', '1999-09-06', 1),
       ('Lapichkiy Igor Dmitrievich', 'M', '2000-08-01', 2),
       ('Antonova Anna Vasilevna', 'F', '2000-01-02', 2);

INSERT INTO Sessions (StartDate,EndDate, GroupId)
VALUES ('2019-12-20', '2020-01-14', 1),
       ('2019-12-25', '2020-01-25', 2);

INSERT INTO Subjects (Name,Date,SessionId)
VALUES ('Informatics', '2019-12-26', 1),
       ('Mathematical analysis', '2020-01-05', 1),
       ('Mathematical modeling', '2020-01-08', 1),
       ('Internet application development','2019-12-20',1),
       ('English', '2019-12-23', 1),
       ('Basics of algorithmization', '2020-01-07', 2),
       ('Mathematical analysis', '2020-01-10', 2),
       ('English', '2020-01-15', 2),
       ('PE', '2019-12-15', 2),
       ('Belarusian language', '2019-12-28', 2);

INSERT INTO CreditRecord (StudentId,CreditId,Passed)
VALUES (1,4,1),
       (1,5,1),
       (2,9,1),
       (2,10,0),
       (3,9,1),
       (3,10,1);

INSERT INTO ExamRecord (StudentId,ExamId,Mark)
VALUES (1,1,9),
       (1,2,8),
       (1,3,10),
       (2,6,7),
       (2,7,9),
       (2,8,9),
       (3,6,2),
       (3,7,5),
       (3,8,5);