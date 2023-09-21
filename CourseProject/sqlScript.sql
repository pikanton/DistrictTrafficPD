USE StudTraining
GO
ALTER TABLE Проступок DROP Проступок_Студент 
GO
ALTER TABLE [Предоставление услуг] DROP [Предоставление услуг_Услуги]
GO
ALTER TABLE [Предоставление услуг] DROP [Предоставление услуг_Заселение]
GO
ALTER TABLE Заселение DROP Заселение_Студент
GO
ALTER TABLE Заселение DROP Заселение_Комната
GO
ALTER TABLE Комната DROP Комната_Тип_комнаты
GO
ALTER TABLE Заселение DROP Заселение_Персонал
GO
ALTER TABLE Персонал DROP Персонал_Должность
GO
ALTER TABLE Студент DROP [Emai-l_UNIQUE]
GO
ALTER TABLE Заселение DROP [Дата заселения_CHECK]
GO
ALTER TABLE Гости DROP [Дата/Время_CHECK]
GO
ALTER TABLE Гости DROP Гости_Заселение
Go
 
Drop Table Проступок
Go
Drop Table [Предоставление услуг]
Go
Drop Table Гости
GO
Drop Table Услуги
Go
Drop Table Заселение
GO
Drop Table Персонал
GO
Drop Table Должность
GO
Drop Table Студент
GO
Drop Table Комната
GO
Drop Table [Тип комнаты]
GO
Create Table Проступок(
Код int Identity Primary Key
,[Код студента] int NOT Null
,Наименование varchar(80) Not Null
,[Дата проступка] date Not Null   
)
Go
Create Table Студент(
Код int Identity Primary Key
,Имя varchar(30) Not Null
,Фамилия varchar(30) Not Null
,Отчество varchar(30)
,Телефон varchar(13) Not Null
,[Emai-l] varchar(40)
)
Go
Create Table Заселение(
Код int Identity Primary Key
,[Код комнаты] int Not Null
,[Дата заселения] date Not Null CHECK ([Дата заселения] <= getdate())
,[Код студента] int Not Null
,[Код персонала] int Not Null
,[Дата выселения] date Not Null CHECK ([Дата выселения] > getdate())
)
Go
Create Table Комната(
Код int Identity Primary Key
,[Количество человек] int Not Null
,Этаж int Not Null
,Комната int Not Null Unique
,[Код типа комнаты] int Not Null
)
Go
Create Table [Тип комнаты](
Код int Identity Primary Key
,Вид varchar(30) Not Null
,[Количество мест] int Not Null
,[Стоимость за общежитие] money Not Null
)
Go
Create Table Гости(
Код int Identity Primary Key
,[Код заселения] int Not Null
,ФИО varchar(80) Not Null
,[Дата/Время] dateTime Not Null Default getdate()
)
Go
Create Table [Предоставление услуг](
Код int Identity Primary Key
,[Код услуги] int Not Null
,[Код заселения] int Not Null
,Дата date Not Null Default getdate()
,[код персонала] int Not Null
)
Go
Create Table Услуги(
Код int Identity Primary Key
,Наименование varchar(40) Not Null Unique
)
GO
Create Table Персонал(
Код int Identity Primary Key
,Имя varchar(30) Not Null
,Фамилия varchar(30) Not Null
,Отчество varchar(30)
,[код должности] int Not Null
)
Go
Create Table Должность(
Код int Identity Primary Key
,Наименование varchar(30) Not Null
)
Go

ALTER TABLE Проступок
  ADD CONSTRAINT Проступок_Студент 
    FOREIGN KEY([Код студента]) REFERENCES Студент
GO

ALTER TABLE [Предоставление услуг]
  ADD CONSTRAINT [Предоставление услуг_Услуги] 
    FOREIGN KEY([код услуги]) REFERENCES Услуги
GO

ALTER TABLE [Предоставление услуг]
  ADD CONSTRAINT [Предоставление услуг_Заселение]
        FOREIGN KEY([код заселения]) REFERENCES Заселение
GO
ALTER TABLE Гости
  ADD CONSTRAINT Гости_Заселение
        FOREIGN KEY ([код заселения])  REFERENCES Заселение
GO

ALTER TABLE Заселение
  ADD CONSTRAINT Заселение_Студент
    FOREIGN KEY([Код студента]) REFERENCES Студент
GO

ALTER TABLE Заселение
  ADD CONSTRAINT Заселение_Комната
    FOREIGN KEY([Код комнаты]) REFERENCES Комната
GO

ALTER TABLE Комната
  ADD CONSTRAINT Комната_Тип_комнаты
    FOREIGN KEY([код типа комнаты]) REFERENCES [Тип комнаты]
GO

ALTER TABLE Заселение
  ADD CONSTRAINT Заселение_Персонал
    FOREIGN KEY([Код персонала]) REFERENCES Персонал
GO

ALTER TABLE Персонал
  ADD CONSTRAINT Персонал_Должность
    FOREIGN KEY([Код должности]) REFERENCES Должность
GO

ALTER TABLE Студент
  ADD CONSTRAINT [Emai-l_UNIQUE]
    UNIQUE ([Emai-l])
GO

ALTER TABLE Заселение
  ADD CONSTRAINT [Дата заселения_CHECK]
   CHECK ([Дата заселения] >= '20000101') 
GO

ALTER TABLE Гости
  ADD CONSTRAINT [Дата/Время_CHECK]
   CHECK ([Дата/Время] <= '20240901') 
GO

INSERT INTO [Тип комнаты] 
  VALUES ('Блочная',6, 20),
         ('Семейная', 2, 10),
         ('Квартирная', 1, 70),
         ('Коридоная', 3, 13),
         ('Гостиничные', 4, 22),
		 ('Квартирная', 1, 70)
GO

INSERT INTO Услуги
 VALUES ('Уборка'),
        ('Ремонт'),
        ('Выдача белья'),
        ('Буфет'),
        ('Охрана')
GO

INSERT INTO Должность
  VALUES ('Заведующая этажа'),
         ('Уборщица'),
  	     ('Сантехник'),
  	     ('Сторож'),
  	     ('Электрик'),
		 ('Воспитатель')
GO
INSERT INTO Персонал 
  VALUES ('Лера','Романенко','Витальевна',1),
         ('Светлана','Прокофьева','Олеговна',2),
         ('Михаил','Зубенко','Петрович',3),
         ('Артем','Копцов','Максимович',4),
		 ('Руслан','Костюк','Олегович',5), 
		 ('Артем','Копцов','Максимович',3),
         ('Артем','Копцов','Максимович',5),
         ('Антон','Аккурат','Васильевич',6)
GO

INSERT INTO Студент
  VALUES ('Дмитрий','Молочко', 'Васильевич','+375293445723','Molochko_bragin@gmail.com'),
         ('Руслан','Дроздов', 'Юрьевич','+375336532178','Tenzor_Flou@mail.com'),
         ('Евгений','Яковцев', 'Яковлевич','+375445745436','Lera_One_love@gmail.com'),
	     ('Ангелина','Потапенко', 'Александровна','+375298501687','Angelusik_One_love@yandex.com'),
         ('Александр','Дроздов', 'Богданович','+375295137743','Brat_Ruslana@gmail.com')
GO

INSERT INTO Проступок 
  VALUES (1,'Курил в туалете','20200902'),
         (2,'Приход в нетрезвом состоянии','20210322'),
	     (3,'Включение запрещенных электроприборов','20200912'),
	     (4,'Распитие спиртных напитков','20221113'),
	     (5,'Шум в комнате после 23:00','20190510'),
	     (1,'Курил в комнате','20210807'),
	   	 (2,'Нет флюорографии','20211015'),
		 (5,'Пропустил технику безопасноти','20171205'),
		 (2,'Пропустил тихий час','20200426')
GO

INSERT INTO Комната 
  VALUES (4,2,228,4),
         (3,2,225,4),
         (2,2,227,2),
         (1,5,555,3),
         (6,3,331,1),
		 (3,1,111,5),
		 (3,2,208,4)
GO

INSERT INTO Заселение 
  VALUES  (1,'20200901',5,1,'20240722'),
          (2,'20200901',2,6,'20240721'),
          (2,'20200901',3,6,'20240720'),
          (2,'20191105',1,1,'20240615'),
		  (3,'20190512',4,1,'20241010'),
		  (4,'20180501',4,1,'20250101'),
		  (2,'20211204',5,6,'20250620'),
		  (7,'20211008',4,6,'20250326'),
		  (5,'20180304',3,1,'20240830')
GO

INSERT INTO [Предоставление услуг]
  VALUES (1,1,'20220510',2),
         (2,2,'20120111',3),
         (3,3,'20150201',4),
         (4,1,'20160201',5),
         (5,4,'20180622',3),
         (2,5,'20191208',2),
		 (1,1,'20110101',2),
         (3,6,'20130313',4),
         (5,7,'20140414',5),
		 (4,3,'20150312',4),
		 (2,5,'20170202',3)
GO

INSERT INTO Гости 
  VALUES (1,'Маргарита Потапенко Олеговна','20211109 12:32:05'),
         (2,'Марк Бехтольд Емельяненко','20220410 13:22:04'),
         (2,'Антон Пикулик Геннадьевич','20220201 09: 10:04'),
         (4,'Юлия Кравчинская Николаевна','20221005 09:15:04'),
         (5,'Николай Нагорных Александрович','20171012 09:20:04'),
         (6,'Александра Гирина Евгеньевна','20161007 12:15:04'),
         (7,'Артем Шафаренко Геннадьевич','20171007 13:11:04'),
         (7,'Артем Шафаренко Геннадьевич','20171007 15:55:04'),
		 (3,'Александра Гирина Евгеньевна','20161007 12:15:04')
GO

DROP VIEW ИнформацияОПредостовленииУслуг
GO
CREATE VIEW ИнформацияОПредостовленииУслуг
AS
  SELECT [Предоставление услуг].Код, [Код услуги],
         [Код заселения], Дата, [Предоставление услуг].[код персонала],
         Наименование AS Услуга, Комната, 
	     Фамилия + ' ' + Имя + ' ' + Отчество AS Персонал
    FROM [Предоставление услуг], Услуги,
         Заселение, Комната, Персонал
    WHERE [Код услуги] = Услуги.Код
      AND [Код заселения] = Заселение.Код
   	  AND [Код комнаты] = Комната.Код
	  AND [Предоставление услуг].[код персонала] = Персонал.Код
GO

DROP VIEW КоличествоПроступковСтудентов
GO
CREATE VIEW КоличествоПроступковСтудентов
AS
  SELECT Фамилия, Имя, Отчество, Телефон, COUNT(*) AS КоличествоПроступков
    FROM Студент, Проступок
	WHERE [Код студента] = Студент.Код
	GROUP BY Студент.Код, Фамилия, Имя, Отчество, Телефон
GO
SELECT * FROM КоличествоПроступковСтудентов