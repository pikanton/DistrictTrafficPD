USE ГАИ2
GO
ALTER TABLE [Водительское удостоверение] DROP CONSTRAINT FK_Водительское_удостоверение_Водитель
GO
ALTER TABLE [Категории удостоверения] DROP CONSTRAINT FK_Категории_удостоверения_Категория
GO
ALTER TABLE [Категории удостоверения]
  DROP CONSTRAINT FK_Категории_удостоверения_Водительское_удостоверение
GO
ALTER TABLE Регистрация DROP CONSTRAINT FK_Регистрация_Водитель
GO
ALTER TABLE Регистрация DROP CONSTRAINT FK_Регистрация_Автомобиль
GO
ALTER TABLE Регистрация DROP CONSTRAINT FK_Регистрация_Сотрудник
GO
ALTER TABLE Нарушение DROP CONSTRAINT FK_Нарушение_Водитель
GO
ALTER TABLE Нарушение DROP CONSTRAINT FK_Нарушение_Сотрудник
GO
ALTER TABLE Нарушение DROP CONSTRAINT FK_Нарушение_Тип_нарушения
GO
ALTER TABLE Сотрудник DROP CONSTRAINT FK_Сотрудник_Звание
GO
ALTER TABLE Регистрация DROP CONSTRAINT UNIQUE_Регистрация_Регистрационный_знак
GO
ALTER TABLE Нарушение DROP CONSTRAINT CHECK_Нарушение_Срок_лишения_прав
GO

DROP TABLE Автомобиль
GO
CREATE TABLE Автомобиль(
  Код INT IDENTITY PRIMARY KEY
  ,VIN VARCHAR(17) NOT NULL UNIQUE
  ,Марка VARCHAR(30) NOT NULL
  ,Модель VARCHAR(30) NOT NULL
  ,Цвет VARCHAR(30) NOT NULL
)
GO
DROP TABLE Водитель
GO
CREATE TABLE Водитель(
  Код INT IDENTITY PRIMARY KEY
  ,Фамилия VARCHAR(30) NOT NULL
  ,Имя VARCHAR(30) NOT NULL
  ,Отчество VARCHAR(30)
  ,Паспорт VARCHAR(9) NOT NULL UNIQUE
  ,Телефон VARCHAR(11)
)
GO
DROP TABLE [Водительское удостоверение]
GO
CREATE TABLE [Водительское удостоверение](
  Код INT IDENTITY PRIMARY KEY
  ,Номер VARCHAR(7) NOT NULL UNIQUE
  ,[Дата выдачи] DATETIME NOT NULL
  ,[Срок действия] DATETIME NOT NULL
  ,[Код водителя] INT NOT NULL
)
GO
DROP TABLE Звание
GO
CREATE TABLE Звание(
  Код INT IDENTITY PRIMARY KEY
  ,Наименование VARCHAR(30) NOT NULL UNIQUE
)
GO
DROP TABLE [Категории удостоверения]
GO
CREATE TABLE [Категории удостоверения](
  Код INT IDENTITY PRIMARY KEY
  ,[Код категории] INT NOT NULL
  ,[Код водительского удостоверения] INT NOT NULL
)
GO
DROP TABLE Категория
GO
CREATE TABLE Категория(
  Код INT IDENTITY PRIMARY KEY
  ,Наименование VARCHAR(2) NOT NULL UNIQUE
  ,Расшифровка VARCHAR(50)
)
GO
DROP TABLE Нарушение
GO
CREATE TABLE Нарушение(
  Код INT IDENTITY PRIMARY KEY
  ,Дата DATETIME NOT NULL
  ,[№ Протокола] VARCHAR(30) NOT NULL
  ,[Размер штрафа] MONEY NOT NULL CHECK ([Размер штрафа] >= 0)
  ,[Срок лишения прав] INT NOT NULL DEFAULT 0
  ,[Код водителя] INT NOT NULL
  ,[Код сотрудника] INT NOT NULL
  ,[Код нарушения] INT NOT NULL
)
GO
DROP TABLE Регистрация
GO
CREATE TABLE Регистрация(
  Код INT IDENTITY PRIMARY KEY
  ,[Регистрационный знак] VARCHAR(8) NOT NULL
  ,Дата DATETIME NOT NULL
  ,[Код автомобиля] INT NOT NULL
  ,[Код водителя] INT NOT NULL
  ,[Код сотрудника] INT NOT NULL
)
GO
DROP TABLE Сотрудник
GO
CREATE TABLE Сотрудник(
  Код INT IDENTITY PRIMARY KEY
  ,Логин VARCHAR(30) NOT NULL UNIQUE
  ,Пароль VARCHAR(60) NOT NULL
  ,Фамилия VARCHAR(30) NOT NULL
  ,Имя VARCHAR(30) NOT NULL
  ,Отчество VARCHAR(30)
  ,Телефон VARCHAR(11) NOT NULL
  ,[Код звания] INT NOT NULL
)
GO
DROP TABLE [Тип нарушения]
GO
CREATE TABLE [Тип нарушения](
  Код INT IDENTITY PRIMARY KEY
  ,Наименование VARCHAR(255) NOT NULL UNIQUE
)
GO
--Ограничения
ALTER TABLE Сотрудник
  ADD CONSTRAINT FK_Сотрудник_Звание FOREIGN KEY ([Код звания]) REFERENCES Звание (Код)
GO
ALTER TABLE Нарушение
  ADD CONSTRAINT FK_Нарушение_Водитель FOREIGN KEY ([Код водителя]) REFERENCES Водитель (Код),
  CONSTRAINT FK_Нарушение_Сотрудник FOREIGN KEY ([Код сотрудника]) REFERENCES Сотрудник (Код),
  CONSTRAINT FK_Нарушение_Тип_нарушения
    FOREIGN KEY ([Код нарушения]) REFERENCES [Тип нарушения] (Код),
  CONSTRAINT CHECK_Нарушение_Срок_лишения_прав CHECK ([Срок лишения прав] >= 0)
GO
ALTER TABLE Регистрация
  ADD CONSTRAINT FK_Регистрация_Водитель FOREIGN KEY ([Код водителя]) REFERENCES Водитель (Код),
  CONSTRAINT FK_Регистрация_Автомобиль FOREIGN KEY ([Код автомобиля]) REFERENCES Автомобиль (Код),
  CONSTRAINT FK_Регистрация_Сотрудник FOREIGN KEY ([Код сотрудника]) REFERENCES Сотрудник (Код),
  CONSTRAINT UNIQUE_Регистрация_Регистрационный_знак UNIQUE ([Регистрационный знак])
GO
ALTER TABLE [Категории удостоверения]
  ADD CONSTRAINT FK_Категории_удостоверения_Категория 
    FOREIGN KEY ([Код категории]) REFERENCES Категория (Код),
  CONSTRAINT FK_Категории_удостоверения_Водительское_удостоверение
    FOREIGN KEY ([Код водительского удостоверения]) REFERENCES [Водительское удостоверение] (Код)
GO
ALTER TABLE [Водительское удостоверение]
  ADD CONSTRAINT FK_Водительское_удостоверение_Водитель
    FOREIGN KEY ([Код водителя]) REFERENCES Водитель (Код)
GO
INSERT INTO Автомобиль VALUES
  ('JN1HS34P113487234','Nissan','Almera','Красный')
  ,('VG3HS34P1KW012341','Renault','Logan','Черный')
  ,('STPHS34P1KH727349','Toyota','Corolla','Темно-синий')
GO
INSERT INTO Водитель VALUES
  ('Иванов','Сергей','Анатольевич','HB3008972','80291391385')
  ,('Попов','Никита','Антонович','HB5374738','80447185162')
  ,('Симонов','Аркадий','Сергеевич','HB4121384','80447118833')
  ,('Петрушкин','Алексей','Федорович','HB1267356','80447152361')
GO
INSERT INTO Звание VALUES
  ('Младший лейтенант')
  ,('Старшина')
  ,('Старший сержант')
GO
INSERT INTO Категория VALUES
  ('A','мотоциклы')
  ,('B','автомобиль и грузовые до 3.5 тонн')
  ,('D','автобусы')
GO
INSERT INTO [Тип нарушения] VALUES
  ('Превышение скорости')
  ,('Нарушение правил маневрирования')
  ,('Открытие дверей во время движения')
GO
INSERT INTO [Водительское удостоверение] VALUES
  ('3896561','20090802','20190802',1)
  ,('3897123','20090803','20190803',2)
  ,('5431041','20190811','20290811',1)
  ,('5445656','20190811','20290811',2)
  ,('5646534','20190813','20290813',3)
GO
INSERT INTO [Категории удостоверения] VALUES
  (1,1)
  ,(2,1)
  ,(2,2)
  ,(1,3)
  ,(2,3)
  ,(2,4)
  ,(2,5)
GO
INSERT INTO Сотрудник VALUES
  ('avsumonchik','vLFfghR5tNV3K9DKhmwArV+SbjWAcgZZzIDTnJ0JgCo=','Сумончик','Андрей','Валерьевич','80445653274',1)
  ,('vasolovyev','TMj01gm3FzVnAcV6A+c35ayP6IXajHFj095H4BhJxjU=','Соловьев','Виктор','Алексанрович','80296548783',2)
  ,('eeveremeychik','aEh9wpUFKqecUw4oPOaYuMa7G0L/CUQlLhkQ2+zcVCU=','Веремейчик','Евгений','Евгеньевич','80293193487',2)
  ,('lvyakovtseva','aff3p/i8qZcPpvnAuNrQaQHT7yP9WZ0yE6pe7lYhw+M=','Яковцева','Людмила','Васильевна','80335674428',3)
  ,('vsanafiev','r0HmjhMJ+imlBEy9w2uQo4IdiAfmjHZ1psSVESvIpV8=','Анафьев','Виктор','Сергеевич','80291917643',1)
GO
INSERT INTO Регистрация VALUES
  ('2819KX-3','20051219',1,1,1)
  ,('1566KK-3','20051220',1,2,3)
  ,('6593KB-3','20051221',2,2,5)
  ,('2417II-3','20060504',3,3,4)
  ,('6767KI-3','20060909',1,3,1)
  ,('1212KK-3','20061010',3,2,3)
  ,('5643KB-3','20061212',2,3,4)
GO
INSERT INTO Нарушение VALUES
  ('20191120','13941234',300,0,1,1,1)
  ,('20191221','14012541',400,0,1,3,3)
  ,('20200102','14056341',1000,6,2,2,1)
  ,('20200203','14115611',300,0,2,2,2)
  ,('20200204','14123437',400,0,3,3,3)
  ,('20200412','14354658',1000,6,3,3,1)
  ,('20201215','14019231',800,0,3,3,3)
GO
