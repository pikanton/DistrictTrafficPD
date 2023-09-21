USE ���2
GO
ALTER TABLE [������������ �������������] DROP CONSTRAINT FK_������������_�������������_��������
GO
ALTER TABLE [��������� �������������] DROP CONSTRAINT FK_���������_�������������_���������
GO
ALTER TABLE [��������� �������������]
  DROP CONSTRAINT FK_���������_�������������_������������_�������������
GO
ALTER TABLE ����������� DROP CONSTRAINT FK_�����������_��������
GO
ALTER TABLE ����������� DROP CONSTRAINT FK_�����������_����������
GO
ALTER TABLE ����������� DROP CONSTRAINT FK_�����������_���������
GO
ALTER TABLE ��������� DROP CONSTRAINT FK_���������_��������
	GO
ALTER TABLE ��������� DROP CONSTRAINT FK_���������_���������
GO
ALTER TABLE ��������� DROP CONSTRAINT FK_���������_���_���������
GO
ALTER TABLE ��������� DROP CONSTRAINT FK_���������_������
GO
ALTER TABLE ��������� DROP CONSTRAINT FK_���������_����
GO
ALTER TABLE ����������� DROP CONSTRAINT UNIQUE_�����������_���������������_����
GO
ALTER TABLE ��������� DROP CONSTRAINT CHECK_���������_����_�������_����
GO

DROP TABLE ����
GO
CREATE TABLE ����(
  ��� INT IDENTITY PRIMARY KEY
  ,������������ VARCHAR(30) NOT NULL UNIQUE
)
DROP TABLE ����������
GO
CREATE TABLE ����������(
  ��� INT IDENTITY PRIMARY KEY
  ,VIN VARCHAR(17) NOT NULL UNIQUE
  ,����� VARCHAR(30) NOT NULL
  ,������ VARCHAR(30) NOT NULL
  ,���� VARCHAR(30) NOT NULL
)
GO
DROP TABLE ��������
GO
CREATE TABLE ��������(
  ��� INT IDENTITY PRIMARY KEY
  ,������� VARCHAR(30) NOT NULL
  ,��� VARCHAR(30) NOT NULL
  ,�������� VARCHAR(30)
  ,������� VARCHAR(9) NOT NULL UNIQUE
  ,������� VARCHAR(11)
)
GO
DROP TABLE [������������ �������������]
GO
CREATE TABLE [������������ �������������](
  ��� INT IDENTITY PRIMARY KEY
  ,����� VARCHAR(7) NOT NULL UNIQUE
  ,[���� ������] DATETIME NOT NULL
  ,[���� ��������] DATETIME NOT NULL
  ,[��� ��������] INT NOT NULL
)
GO
DROP TABLE ������
GO
CREATE TABLE ������(
  ��� INT IDENTITY PRIMARY KEY
  ,������������ VARCHAR(30) NOT NULL UNIQUE
)
GO
DROP TABLE [��������� �������������]
GO
CREATE TABLE [��������� �������������](
  ��� INT IDENTITY PRIMARY KEY
  ,[��� ���������] INT NOT NULL
  ,[��� ������������� �������������] INT NOT NULL
)
GO
DROP TABLE ���������
GO
CREATE TABLE ���������(
  ��� INT IDENTITY PRIMARY KEY
  ,������������ VARCHAR(2) NOT NULL UNIQUE
  ,����������� VARCHAR(50)
)
GO
DROP TABLE ���������
GO
CREATE TABLE ���������(
  ��� INT IDENTITY PRIMARY KEY
  ,���� DATETIME NOT NULL
  ,[� ���������] VARCHAR(30) NOT NULL
  ,[������ ������] MONEY NOT NULL CHECK ([������ ������] >= 0)
  ,[���� ������� ����] INT NOT NULL DEFAULT 0
  ,[��� ��������] INT NOT NULL
  ,[��� ����������] INT NOT NULL
  ,[��� ���������] INT NOT NULL
)
GO
DROP TABLE �����������
GO
CREATE TABLE �����������(
  ��� INT IDENTITY PRIMARY KEY
  ,[��������������� ����] VARCHAR(8) NOT NULL
  ,���� DATETIME NOT NULL
  ,[��� ����������] INT NOT NULL
  ,[��� ��������] INT NOT NULL
  ,[��� ����������] INT NOT NULL
)
GO
DROP TABLE ���������
GO
CREATE TABLE ���������(
  ��� INT IDENTITY PRIMARY KEY
  ,����� VARCHAR(30) NOT NULL UNIQUE
  ,������ VARCHAR(60) NOT NULL
  ,������� VARCHAR(30) NOT NULL
  ,��� VARCHAR(30) NOT NULL
  ,�������� VARCHAR(30)
  ,������� VARCHAR(11) NOT NULL
  ,[��� ������] INT NOT NULL
  ,[��� ����] INT NOT NULL
)
GO
DROP TABLE [��� ���������]
GO
CREATE TABLE [��� ���������](
  ��� INT IDENTITY PRIMARY KEY
  ,������������ VARCHAR(255) NOT NULL UNIQUE
)
GO
--�����������
ALTER TABLE ���������
  ADD CONSTRAINT FK_���������_������ FOREIGN KEY ([��� ������]) REFERENCES ������ (���),
      CONSTRAINT FK_���������_���� FOREIGN KEY ([��� ����]) REFERENCES ���� (���)
GO
ALTER TABLE ���������
  ADD CONSTRAINT FK_���������_�������� FOREIGN KEY ([��� ��������]) REFERENCES �������� (���),
  CONSTRAINT FK_���������_��������� FOREIGN KEY ([��� ����������]) REFERENCES ��������� (���),
  CONSTRAINT FK_���������_���_���������
    FOREIGN KEY ([��� ���������]) REFERENCES [��� ���������] (���),
  CONSTRAINT CHECK_���������_����_�������_���� CHECK ([���� ������� ����] >= 0)
GO
ALTER TABLE �����������
  ADD CONSTRAINT FK_�����������_�������� FOREIGN KEY ([��� ��������]) REFERENCES �������� (���),
  CONSTRAINT FK_�����������_���������� FOREIGN KEY ([��� ����������]) REFERENCES ���������� (���),
  CONSTRAINT FK_�����������_��������� FOREIGN KEY ([��� ����������]) REFERENCES ��������� (���),
  CONSTRAINT UNIQUE_�����������_���������������_���� UNIQUE ([��������������� ����])
GO
ALTER TABLE [��������� �������������]
  ADD CONSTRAINT FK_���������_�������������_��������� 
    FOREIGN KEY ([��� ���������]) REFERENCES ��������� (���) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT FK_���������_�������������_������������_�������������
    FOREIGN KEY ([��� ������������� �������������]) REFERENCES [������������ �������������] (���) ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [������������ �������������]
  ADD CONSTRAINT FK_������������_�������������_��������
    FOREIGN KEY ([��� ��������]) REFERENCES �������� (���)
GO
--�������
--�������� ��� ����������
--������������ ��� ����������
DROP FUNCTION �������������
GO
CREATE FUNCTION �������������(@������������� INT) RETURNS VARCHAR(255)
AS
BEGIN
  DECLARE @������������� VARCHAR(255) = (
    SELECT ������� + ' ' + ��� + ' ' + �������� 
	  FROM ���������
	  WHERE ��� = @�������������)
  RETURN @�������������
END
GO
--SELECT ���, dbo.�������������(���) AS ��������� FROM ���������
--GO
--�������� ��� ��������
--������������ ��� ��������
DROP FUNCTION �����������
GO
CREATE FUNCTION �����������(@����������� INT) RETURNS VARCHAR(255)
AS
BEGIN
  DECLARE @����������� VARCHAR(255) = (
    SELECT ������� + ' ' + ��� + ' ' + �������� + ' ' + �������
	  FROM ��������
	  WHERE ��� = @�����������)
  RETURN @�����������
END
GO
--SELECT ���, dbo.�����������(���) AS �������� FROM ��������
--GO
--�������� ��� ����������
--������������ �����, ������ � VIN ����������
DROP FUNCTION �����������VIN����������
GO
CREATE FUNCTION �����������VIN����������(@������������� INT) RETURNS VARCHAR(255)
AS
BEGIN
  DECLARE @�����������VIN VARCHAR(255) = (
    SELECT ����� + ' ' + ������ + ' ' + VIN 
	  FROM ����������
	  WHERE ��� = @�������������)
  RETURN @�����������VIN
END
GO
--SELECT ���, dbo.�����������VIN����������(���) AS ���������� FROM ����������
--GO
--�������� ��� ������������� �������������
--������������ ���� ��������� � ������� �������������
DROP FUNCTION ����������������������
GO
CREATE FUNCTION ����������������������(@���������������� INT) RETURNS VARCHAR(255)
AS
BEGIN
  DECLARE @��������� VARCHAR(255) = ''
  SELECT @��������� += ������������ + ',' 
    FROM ���������, [��������� �������������], [������������ �������������] 
	WHERE [������������ �������������].��� = [��� ������������� �������������]
	  AND ���������.��� = [��� ���������]
	  AND [��� ������������� �������������] = @����������������
  RETURN SUBSTRING(@���������, 1, LEN(@���������) - 1)
END
GO
--SELECT dbo.����������������������(1) AS ���������
--GO
--���������
-- ����� ��������� ��������� �� �������� ������
DROP PROC �������������������������������
GO
CREATE PROC ������������������������������� @Begin DATETIME, @End DATETIME
AS
  SELECT �����������, �������, �������, ����������� FROM
  (
    SELECT ������� + ' ' + ��� + ' ' + �������� AS �����������, �������, �������, SUM([������ ������]) AS �����������, 0 AS sort
      FROM �������� INNER JOIN ��������� ON (��������.��� = [��� ��������]) 
      WHERE ���� BETWEEN @Begin AND @End OR (@Begin IS NULL AND @End IS NULL)
	  GROUP BY ��������.���, �������, ���, ��������, �������, �������
    UNION ALL
    SELECT '�����',null,null,(
      SELECT ISNULL(SUM([������ ������]),0) 
	    FROM ���������
	    WHERE ���� BETWEEN @Begin AND @End OR (@Begin IS NULL AND @End IS NULL)),1
  ) AS T
  ORDER BY sort, 1
GO
--EXEC ������������������������������� '20300219', '20230516'
--GO
--EXEC ������������������������������� null, null
--GO
--���������� ������������ �������������, ��� ������� ���� ����������
DROP PROC �����������������������������������
GO
CREATE PROC �����������������������������������
AS
  SELECT COUNT(*) AS ���������� FROM [������������ �������������] ��1
    WHERE EXISTS(
	  SELECT * FROM [������������ �������������] AS ��2
	    WHERE ��1.[��� ��������] = ��2.[��� ��������]
		  AND ��2.[���� ������] > ��1.[���� ������])
GO
--EXEC �����������������������������������
--GO
--�������� ������������ ���������, ������� ���� ��������
DROP PROC ���������������������������������
GO
CREATE PROC ���������������������������������
AS
  DELETE FROM [������������ �������������]
    WHERE EXISTS(
	  SELECT * FROM [������������ �������������] ��
	    WHERE [������������ �������������].[��� ��������] = ��.[��� ��������]
		  AND ��.[���� ������] > [������������ �������������].[���� ������])
GO
--EXEC ���������������������������������
--GO
--��������
-- ��������� �������� ������� �� ������� ����������� ����� �������� ����������
ALTER TABLE ����������� DROP CONSTRAINT FK_�����������_����������
GO
CREATE TRIGGER trg����������DelCascade ON ����������
  AFTER DELETE
AS
  DELETE FROM �����������
    WHERE [��� ����������] IN (SELECT ��� FROM deleted)
GO
-- ��������� �������� ������� �� ������ �����������, ���������, ������������ ������������� ����� �������� ��������
ALTER TABLE ����������� DROP CONSTRAINT FK_�����������_��������
GO
ALTER TABLE ��������� DROP CONSTRAINT FK_���������_��������
GO
ALTER TABLE [������������ �������������] DROP CONSTRAINT FK_������������_�������������_��������
GO
CREATE TRIGGER trg��������DelCascade ON ��������
  AFTER DELETE
AS
  DELETE FROM �����������
    WHERE [��� ��������] IN (SELECT ��� FROM deleted)
  DELETE FROM ���������
    WHERE [��� ��������] IN (SELECT ��� FROM deleted)
  DELETE FROM [������������ �������������]
    WHERE [��� ��������] IN (SELECT ��� FROM deleted)
GO
-- ��������� �������� ������� �� ������ ����������� � ��������� ����� �������� ����������
ALTER TABLE ����������� DROP CONSTRAINT FK_�����������_���������
GO
ALTER TABLE ��������� DROP CONSTRAINT FK_���������_���������
GO
CREATE TRIGGER trg���������DelCascade ON ���������
  AFTER DELETE
AS
  DELETE FROM �����������
    WHERE [��� ����������] IN (SELECT ��� FROM deleted)
  DELETE FROM ���������
    WHERE [��� ����������] IN (SELECT ��� FROM deleted)
GO
CREATE TRIGGER trg�����������IU ON [�����������]
  AFTER INSERT, UPDATE
AS
  IF (SELECT COUNT(*) FROM inserted) <> 
     (SELECT COUNT(*) 
	    FROM inserted, ����������, ��������, ���������
	    WHERE [��� ����������] = ����������.���
		  AND [��� ��������] = ��������.���
		  AND [��� ����������] = ���������.���)
  BEGIN
    RAISERROR('�������� �������� ��� ����������, ���������� ��� ��������!',16,2)
	ROLLBACK TRAN
	RETURN
  END
GO
CREATE TRIGGER trg���������IU ON ���������
  AFTER INSERT, UPDATE
AS
  IF (SELECT COUNT(*) FROM inserted) <> 
     (SELECT COUNT(*) 
	    FROM inserted, ��������, ���������
	    WHERE [��� ��������] = ��������.���
		  AND [��� ����������] = ���������.���)
  BEGIN
    RAISERROR('�������� �������� ��� ���������� ��� ��������!',16,2)
	ROLLBACK TRAN
	RETURN
  END
GO
CREATE TRIGGER trg�������������IU ON [������������ �������������]
  AFTER INSERT, UPDATE
AS
  IF (SELECT COUNT(*) FROM inserted) <> 
     (SELECT COUNT(*) 
	    FROM inserted, ��������
	    WHERE [��� ��������] = ��������.���)
  BEGIN
    RAISERROR('�������� �������� ��� ��������!',16,2)
	ROLLBACK TRAN
	RETURN
  END
GO
--�������������
DROP VIEW ���������Ext
GO
CREATE VIEW ���������Ext
AS
  SELECT ���������.���, ����, [� ���������], [������ ������], [���� ������� ����]
       , [��� ��������], [��� ����������], [��� ���������]
       , dbo.�����������([��� ��������]) AS [��� ��������]
       , dbo.�������������([��� ����������]) AS [��� ����������]
       , ������������ AS ��������� 
    FROM ���������, ��������, ���������, [��� ���������] 
    WHERE ��������.��� = [��� ��������] 
      AND ���������.��� = [��� ����������]
      AND [��� ���������].��� = [��� ���������]
GO
DROP VIEW �����������Ext
GO
CREATE VIEW �����������Ext
AS
  SELECT �����������.���, [��������������� ����], ����, [��� ����������], [��� ��������], [��� ����������],
         dbo.�����������([��� ��������]) AS [��� ��������],
         dbo.�������������([��� ����������]) AS [��� ����������],
         dbo.�����������VIN����������([��� ����������]) AS [����������]
    FROM �����������, ����������, ��������, ���������
    WHERE ����������.��� = [��� ����������]
      AND ��������.��� = [��� ��������]
	  AND ���������.��� = [��� ����������]
GO
DROP VIEW �������������������������Ext
GO
CREATE VIEW �������������������������Ext
AS
  SELECT [������������ �������������].���
        ,�����
	    ,[���� ������]
	    ,[���� ��������]
	    ,[��� ��������]
        ,dbo.�����������([��� ��������]) AS [��� ��������]
	    ,dbo.����������������������([������������ �������������].���) AS ���������
    FROM [������������ �������������], ��������
    WHERE ��������.��� = [��� ��������]
GO
DROP VIEW ���������Ext
GO
CREATE VIEW ���������Ext
AS
  SELECT ���������.���, �����, ������, �������, ���, ��������, �������, [��� ������]
        ,[��� ����], ������.������������ AS ������, ����.������������ AS ����
    FROM ���������, ������, ����
    WHERE ������.��� = [��� ������]
      AND ����.��� = [��� ����]
GO
DROP VIEW ��������������
GO
CREATE VIEW ��������������
AS
  SELECT �������, ���, ��������, �������
        ,������.������������ AS ������
    FROM ���������, ������
    WHERE ������.��� = [��� ������]
GO
SELECT * FROM ��������������
DROP VIEW ����������������������������������������
GO
CREATE VIEW ����������������������������������������
AS
  SELECT �������, ���, ��������, ������.������������ AS ������
       , COUNT(*)AS �������������������������������������
	   , SUM([������ ������]) AS ����������������������
    FROM ���������, ������, ���������
	WHERE ���������.��� = [��� ����������]
	  AND ������.��� = [��� ������]
	  AND ���� BETWEEN GETDATE() - 30 AND GETDATE()
	GROUP BY �������, ���, ��������, ������.������������
GO
SELECT * FROM ����������������������������������������