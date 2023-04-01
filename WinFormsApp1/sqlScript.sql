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
ALTER TABLE ����������� DROP CONSTRAINT UNIQUE_�����������_���������������_����
GO
ALTER TABLE ��������� DROP CONSTRAINT CHECK_���������_����_�������_����
GO

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
  ADD CONSTRAINT FK_���������_������ FOREIGN KEY ([��� ������]) REFERENCES ������ (���)
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
    FOREIGN KEY ([��� ���������]) REFERENCES ��������� (���),
  CONSTRAINT FK_���������_�������������_������������_�������������
    FOREIGN KEY ([��� ������������� �������������]) REFERENCES [������������ �������������] (���)
GO
ALTER TABLE [������������ �������������]
  ADD CONSTRAINT FK_������������_�������������_��������
    FOREIGN KEY ([��� ��������]) REFERENCES �������� (���)
GO
INSERT INTO ���������� VALUES
  ('JN1HS34P113487234','Nissan','Almera','�������')
  ,('VG3HS34P1KW012341','Renault','Logan','������')
  ,('STPHS34P1KH727349','Toyota','Corolla','�����-�����')
GO
INSERT INTO �������� VALUES
  ('������','������','�����������','HB3008972','80291391385')
  ,('�����','������','���������','HB5374738','80447185162')
  ,('�������','�������','���������','HB4121384','80447118833')
  ,('���������','�������','���������','HB1267356','80447152361')
GO
INSERT INTO ������ VALUES
  ('������� ���������')
  ,('��������')
  ,('������� �������')
GO
INSERT INTO ��������� VALUES
  ('A','���������')
  ,('B','���������� � �������� �� 3.5 ����')
  ,('D','��������')
GO
INSERT INTO [��� ���������] VALUES
  ('���������� ��������')
  ,('��������� ������ ��������������')
  ,('�������� ������ �� ����� ��������')
GO
INSERT INTO [������������ �������������] VALUES
  ('3896561','20090802','20190802',1)
  ,('3897123','20090803','20190803',2)
  ,('5431041','20190811','20290811',1)
  ,('5445656','20190811','20290811',2)
  ,('5646534','20190813','20290813',3)
GO
INSERT INTO [��������� �������������] VALUES
  (1,1)
  ,(2,1)
  ,(2,2)
  ,(1,3)
  ,(2,3)
  ,(2,4)
  ,(2,5)
GO
INSERT INTO ��������� VALUES
  ('avsumonchik','vLFfghR5tNV3K9DKhmwArV+SbjWAcgZZzIDTnJ0JgCo=','��������','������','����������','80445653274',1)
  ,('vasolovyev','TMj01gm3FzVnAcV6A+c35ayP6IXajHFj095H4BhJxjU=','��������','������','������������','80296548783',2)
  ,('eeveremeychik','aEh9wpUFKqecUw4oPOaYuMa7G0L/CUQlLhkQ2+zcVCU=','����������','�������','����������','80293193487',2)
  ,('lvyakovtseva','aff3p/i8qZcPpvnAuNrQaQHT7yP9WZ0yE6pe7lYhw+M=','��������','�������','����������','80335674428',3)
  ,('vsanafiev','r0HmjhMJ+imlBEy9w2uQo4IdiAfmjHZ1psSVESvIpV8=','�������','������','���������','80291917643',1)
GO
INSERT INTO ����������� VALUES
  ('2819KX-3','20051219',1,1,1)
  ,('1566KK-3','20051220',1,2,3)
  ,('6593KB-3','20051221',2,2,5)
  ,('2417II-3','20060504',3,3,4)
  ,('6767KI-3','20060909',1,3,1)
  ,('1212KK-3','20061010',3,2,3)
  ,('5643KB-3','20061212',2,3,4)
GO
INSERT INTO ��������� VALUES
  ('20191120','13941234',300,0,1,1,1)
  ,('20191221','14012541',400,0,1,3,3)
  ,('20200102','14056341',1000,6,2,2,1)
  ,('20200203','14115611',300,0,2,2,2)
  ,('20200204','14123437',400,0,3,3,3)
  ,('20200412','14354658',1000,6,3,3,1)
  ,('20201215','14019231',800,0,3,3,3)
GO
