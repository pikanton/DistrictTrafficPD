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
ALTER TABLE Сотрудник DROP CONSTRAINT FK_Сотрудник_Роль
GO
ALTER TABLE Регистрация DROP CONSTRAINT UNIQUE_Регистрация_Регистрационный_знак
GO
ALTER TABLE Нарушение DROP CONSTRAINT CHECK_Нарушение_Срок_лишения_прав
GO

DROP TABLE Роль
GO
CREATE TABLE Роль(
  Код INT IDENTITY PRIMARY KEY
  ,Наименование VARCHAR(30) NOT NULL UNIQUE
)
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
  ,[Код роли] INT NOT NULL
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
  ADD CONSTRAINT FK_Сотрудник_Звание FOREIGN KEY ([Код звания]) REFERENCES Звание (Код),
      CONSTRAINT FK_Сотрудник_Роль FOREIGN KEY ([Код роли]) REFERENCES Роль (Код)
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
    FOREIGN KEY ([Код категории]) REFERENCES Категория (Код) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT FK_Категории_удостоверения_Водительское_удостоверение
    FOREIGN KEY ([Код водительского удостоверения]) REFERENCES [Водительское удостоверение] (Код) ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [Водительское удостоверение]
  ADD CONSTRAINT FK_Водительское_удостоверение_Водитель
    FOREIGN KEY ([Код водителя]) REFERENCES Водитель (Код)
GO
--Функции
--параметр код сотрудника
--конкатенация ФИО сотрудника
DROP FUNCTION ФИОСотрудника
GO
CREATE FUNCTION ФИОСотрудника(@КодСотрудника INT) RETURNS VARCHAR(255)
AS
BEGIN
  DECLARE @ФИОСотрудника VARCHAR(255) = (
    SELECT Фамилия + ' ' + Имя + ' ' + Отчество 
	  FROM Сотрудник
	  WHERE Код = @КодСотрудника)
  RETURN @ФИОСотрудника
END
GO
--SELECT Код, dbo.ФИОСотрудника(Код) AS Сотрудник FROM Сотрудник
--GO
--параметр код водителя
--конкатенация ФИО водителя
DROP FUNCTION ФИОВодителя
GO
CREATE FUNCTION ФИОВодителя(@КодВодителя INT) RETURNS VARCHAR(255)
AS
BEGIN
  DECLARE @ФИОВодителя VARCHAR(255) = (
    SELECT Фамилия + ' ' + Имя + ' ' + Отчество + ' ' + Паспорт
	  FROM Водитель
	  WHERE Код = @КодВодителя)
  RETURN @ФИОВодителя
END
GO
--SELECT Код, dbo.ФИОВодителя(Код) AS Водитель FROM Водитель
--GO
--параметр код автомобиля
--конкатенация Марки, Модели и VIN автомобиля
DROP FUNCTION МаркаМодельVINАвтомобиля
GO
CREATE FUNCTION МаркаМодельVINАвтомобиля(@КодАвтомобиля INT) RETURNS VARCHAR(255)
AS
BEGIN
  DECLARE @МодельМаркаVIN VARCHAR(255) = (
    SELECT Марка + ' ' + Модель + ' ' + VIN 
	  FROM Автомобиль
	  WHERE Код = @КодАвтомобиля)
  RETURN @МодельМаркаVIN
END
GO
--SELECT Код, dbo.МаркаМодельVINАвтомобиля(Код) AS Автомобиль FROM Автомобиль
--GO
--параметр код водительского удостоверения
--конкатенация всех категорий у данного удостоверения
DROP FUNCTION КатегорииУдостоверения
GO
CREATE FUNCTION КатегорииУдостоверения(@КодУдостоверения INT) RETURNS VARCHAR(255)
AS
BEGIN
  DECLARE @Категории VARCHAR(255) = ''
  SELECT @Категории += Наименование + ',' 
    FROM Категория, [Категории удостоверения], [Водительское удостоверение] 
	WHERE [Водительское удостоверение].Код = [Код водительского удостоверения]
	  AND Категория.Код = [Код категории]
	  AND [Код водительского удостоверения] = @КодУдостоверения
  RETURN SUBSTRING(@Категории, 1, LEN(@Категории) - 1)
END
GO
--SELECT dbo.КатегорииУдостоверения(1) AS Категории
--GO
--Процедуры
-- Сумма нарушений водителей за заданный период
DROP PROC СуммаНарушенийВодителейЗаПериод
GO
CREATE PROC СуммаНарушенийВодителейЗаПериод @Begin DATETIME, @End DATETIME
AS
  SELECT ФИОВодителя, Паспорт, Телефон, СуммаШтрафа FROM
  (
    SELECT Фамилия + ' ' + Имя + ' ' + Отчество AS ФИОВодителя, Паспорт, Телефон, SUM([Размер штрафа]) AS СуммаШтрафа, 0 AS sort
      FROM Водитель INNER JOIN Нарушение ON (Водитель.Код = [Код водителя]) 
      WHERE Дата BETWEEN @Begin AND @End OR (@Begin IS NULL AND @End IS NULL)
	  GROUP BY Водитель.Код, Фамилия, Имя, Отчество, Паспорт, Телефон
    UNION ALL
    SELECT 'Итого',null,null,(
      SELECT ISNULL(SUM([Размер штрафа]),0) 
	    FROM Нарушение
	    WHERE Дата BETWEEN @Begin AND @End OR (@Begin IS NULL AND @End IS NULL)),1
  ) AS T
  ORDER BY sort, 1
GO
--EXEC СуммаНарушенийВодителейЗаПериод '20300219', '20230516'
--GO
--EXEC СуммаНарушенийВодителейЗаПериод null, null
--GO
--Количество водительских удостоверений, для которых есть продленные
DROP PROC КоличествоВодительскихУдостоверений
GO
CREATE PROC КоличествоВодительскихУдостоверений
AS
  SELECT COUNT(*) AS Количество FROM [Водительское удостоверение] ВУ1
    WHERE EXISTS(
	  SELECT * FROM [Водительское удостоверение] AS ВУ2
	    WHERE ВУ1.[Код водителя] = ВУ2.[Код водителя]
		  AND ВУ2.[Дата выдачи] > ВУ1.[Дата выдачи])
GO
--EXEC КоличествоВодительскихУдостоверений
--GO
--Удаление водительских нарушений, которые были продлены
DROP PROC УдалениеВодительскихУдостоверений
GO
CREATE PROC УдалениеВодительскихУдостоверений
AS
  DELETE FROM [Водительское удостоверение]
    WHERE EXISTS(
	  SELECT * FROM [Водительское удостоверение] ВУ
	    WHERE [Водительское удостоверение].[Код водителя] = ВУ.[Код водителя]
		  AND ВУ.[Дата выдачи] > [Водительское удостоверение].[Дата выдачи])
GO
--EXEC УдалениеВодительскихУдостоверений
--GO
--Триггеры
-- каскадное удаление записей из таблицы Регистрация после удаления автомобиля
ALTER TABLE Регистрация DROP CONSTRAINT FK_Регистрация_Автомобиль
GO
CREATE TRIGGER trgАвтомобильDelCascade ON Автомобиль
  AFTER DELETE
AS
  DELETE FROM Регистрация
    WHERE [Код автомобиля] IN (SELECT Код FROM deleted)
GO
-- каскадное удаление записей из таблиц Регистрация, Нарушение, Водительское удостоверения после удаления водителя
ALTER TABLE Регистрация DROP CONSTRAINT FK_Регистрация_Водитель
GO
ALTER TABLE Нарушение DROP CONSTRAINT FK_Нарушение_Водитель
GO
ALTER TABLE [Водительское удостоверение] DROP CONSTRAINT FK_Водительское_удостоверение_Водитель
GO
CREATE TRIGGER trgВодительDelCascade ON Водитель
  AFTER DELETE
AS
  DELETE FROM Регистрация
    WHERE [Код водителя] IN (SELECT Код FROM deleted)
  DELETE FROM Нарушение
    WHERE [Код водителя] IN (SELECT Код FROM deleted)
  DELETE FROM [Водительское удостоверение]
    WHERE [Код водителя] IN (SELECT Код FROM deleted)
GO
-- каскадное удаление записей из таблиц Регистрация и Нарушение после удаления сотрудника
ALTER TABLE Регистрация DROP CONSTRAINT FK_Регистрация_Сотрудник
GO
ALTER TABLE Нарушение DROP CONSTRAINT FK_Нарушение_Сотрудник
GO
CREATE TRIGGER trgСотрудникDelCascade ON Сотрудник
  AFTER DELETE
AS
  DELETE FROM Регистрация
    WHERE [Код сотрудника] IN (SELECT Код FROM deleted)
  DELETE FROM Нарушение
    WHERE [Код сотрудника] IN (SELECT Код FROM deleted)
GO
CREATE TRIGGER trgРегистрацияIU ON [Регистрация]
  AFTER INSERT, UPDATE
AS
  IF (SELECT COUNT(*) FROM inserted) <> 
     (SELECT COUNT(*) 
	    FROM inserted, Автомобиль, Водитель, Сотрудник
	    WHERE [Код автомобиля] = Автомобиль.Код
		  AND [Код водителя] = Водитель.Код
		  AND [Код сотрудника] = Сотрудник.Код)
  BEGIN
    RAISERROR('Неверные значение для автомобиля, сотрудника или водителя!',16,2)
	ROLLBACK TRAN
	RETURN
  END
GO
CREATE TRIGGER trgНарушениеIU ON Нарушение
  AFTER INSERT, UPDATE
AS
  IF (SELECT COUNT(*) FROM inserted) <> 
     (SELECT COUNT(*) 
	    FROM inserted, Водитель, Сотрудник
	    WHERE [Код водителя] = Водитель.Код
		  AND [Код сотрудника] = Сотрудник.Код)
  BEGIN
    RAISERROR('Неверные значение для сотрудника или водителя!',16,2)
	ROLLBACK TRAN
	RETURN
  END
GO
CREATE TRIGGER trgУдостоверениеIU ON [Водительское удостоверение]
  AFTER INSERT, UPDATE
AS
  IF (SELECT COUNT(*) FROM inserted) <> 
     (SELECT COUNT(*) 
	    FROM inserted, Водитель
	    WHERE [Код водителя] = Водитель.Код)
  BEGIN
    RAISERROR('Неверные значение для водителя!',16,2)
	ROLLBACK TRAN
	RETURN
  END
GO
--Представления
DROP VIEW НарушениеExt
GO
CREATE VIEW НарушениеExt
AS
  SELECT Нарушение.Код, Дата, [№ Протокола], [Размер штрафа], [Срок лишения прав]
       , [Код водителя], [Код сотрудника], [Код нарушения]
       , dbo.ФИОВодителя([Код водителя]) AS [ФИО водителя]
       , dbo.ФИОСотрудника([Код сотрудника]) AS [ФИО сотрудника]
       , Наименование AS Нарушение 
    FROM Нарушение, Водитель, Сотрудник, [Тип нарушения] 
    WHERE Водитель.Код = [Код водителя] 
      AND Сотрудник.Код = [Код сотрудника]
      AND [Тип нарушения].Код = [Код нарушения]
GO
DROP VIEW РегистрацияExt
GO
CREATE VIEW РегистрацияExt
AS
  SELECT Регистрация.Код, [Регистрационный знак], Дата, [Код автомобиля], [Код водителя], [Код сотрудника],
         dbo.ФИОВодителя([Код водителя]) AS [ФИО Водителя],
         dbo.ФИОСотрудника([Код сотрудника]) AS [ФИО Сотрудника],
         dbo.МаркаМодельVINАвтомобиля([Код автомобиля]) AS [Автомобиль]
    FROM Регистрация, Автомобиль, Водитель, Сотрудник
    WHERE Автомобиль.Код = [Код автомобиля]
      AND Водитель.Код = [Код водителя]
	  AND Сотрудник.Код = [Код сотрудника]
GO
DROP VIEW ВодительскоеУдостоверениеExt
GO
CREATE VIEW ВодительскоеУдостоверениеExt
AS
  SELECT [Водительское удостоверение].Код
        ,Номер
	    ,[Дата выдачи]
	    ,[Срок действия]
	    ,[Код водителя]
        ,dbo.ФИОВодителя([Код водителя]) AS [ФИО Водителя]
	    ,dbo.КатегорииУдостоверения([Водительское удостоверение].Код) AS Категории
    FROM [Водительское удостоверение], Водитель
    WHERE Водитель.Код = [Код водителя]
GO
DROP VIEW СотрудникExt
GO
CREATE VIEW СотрудникExt
AS
  SELECT Сотрудник.Код, Логин, Пароль, Фамилия, Имя, Отчество, Телефон, [Код звания]
        ,[Код роли], Звание.Наименование AS Звание, Роль.Наименование AS Роль
    FROM Сотрудник, Звание, Роль
    WHERE Звание.Код = [Код звания]
      AND Роль.Код = [Код роли]
GO
DROP VIEW СотрудникОтчет
GO
CREATE VIEW СотрудникОтчет
AS
  SELECT Фамилия, Имя, Отчество, Телефон
        ,Звание.Наименование AS Звание
    FROM Сотрудник, Звание
    WHERE Звание.Код = [Код звания]
GO
SELECT * FROM СотрудникОтчет
DROP VIEW ЭффективностьСотрудниковЗаПоследнийМесяц
GO
CREATE VIEW ЭффективностьСотрудниковЗаПоследнийМесяц
AS
  SELECT Фамилия, Имя, Отчество, Звание.Наименование AS Звание
       , COUNT(*)AS КоличествоЗарегестрированныхНарушений
	   , SUM([Размер штрафа]) AS СуммаВыписанныхШтрафов
    FROM Сотрудник, Звание, Нарушение
	WHERE Сотрудник.Код = [Код сотрудника]
	  AND Звание.Код = [Код звания]
	  AND Дата BETWEEN GETDATE() - 30 AND GETDATE()
	GROUP BY Фамилия, Имя, Отчество, Звание.Наименование
GO
SELECT * FROM ЭффективностьСотрудниковЗаПоследнийМесяц