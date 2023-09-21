USE StudTraining
GO
ALTER TABLE ��������� DROP ���������_������� 
GO
ALTER TABLE [�������������� �����] DROP [�������������� �����_������]
GO
ALTER TABLE [�������������� �����] DROP [�������������� �����_���������]
GO
ALTER TABLE ��������� DROP ���������_�������
GO
ALTER TABLE ��������� DROP ���������_�������
GO
ALTER TABLE ������� DROP �������_���_�������
GO
ALTER TABLE ��������� DROP ���������_��������
GO
ALTER TABLE �������� DROP ��������_���������
GO
ALTER TABLE ������� DROP [Emai-l_UNIQUE]
GO
ALTER TABLE ��������� DROP [���� ���������_CHECK]
GO
ALTER TABLE ����� DROP [����/�����_CHECK]
GO
ALTER TABLE ����� DROP �����_���������
Go
 
Drop Table ���������
Go
Drop Table [�������������� �����]
Go
Drop Table �����
GO
Drop Table ������
Go
Drop Table ���������
GO
Drop Table ��������
GO
Drop Table ���������
GO
Drop Table �������
GO
Drop Table �������
GO
Drop Table [��� �������]
GO
Create Table ���������(
��� int Identity Primary Key
,[��� ��������] int NOT Null
,������������ varchar(80) Not Null
,[���� ���������] date Not Null   
)
Go
Create Table �������(
��� int Identity Primary Key
,��� varchar(30) Not Null
,������� varchar(30) Not Null
,�������� varchar(30)
,������� varchar(13) Not Null
,[Emai-l] varchar(40)
)
Go
Create Table ���������(
��� int Identity Primary Key
,[��� �������] int Not Null
,[���� ���������] date Not Null CHECK ([���� ���������] <= getdate())
,[��� ��������] int Not Null
,[��� ���������] int Not Null
,[���� ���������] date Not Null CHECK ([���� ���������] > getdate())
)
Go
Create Table �������(
��� int Identity Primary Key
,[���������� �������] int Not Null
,���� int Not Null
,������� int Not Null Unique
,[��� ���� �������] int Not Null
)
Go
Create Table [��� �������](
��� int Identity Primary Key
,��� varchar(30) Not Null
,[���������� ����] int Not Null
,[��������� �� ���������] money Not Null
)
Go
Create Table �����(
��� int Identity Primary Key
,[��� ���������] int Not Null
,��� varchar(80) Not Null
,[����/�����] dateTime Not Null Default getdate()
)
Go
Create Table [�������������� �����](
��� int Identity Primary Key
,[��� ������] int Not Null
,[��� ���������] int Not Null
,���� date Not Null Default getdate()
,[��� ���������] int Not Null
)
Go
Create Table ������(
��� int Identity Primary Key
,������������ varchar(40) Not Null Unique
)
GO
Create Table ��������(
��� int Identity Primary Key
,��� varchar(30) Not Null
,������� varchar(30) Not Null
,�������� varchar(30)
,[��� ���������] int Not Null
)
Go
Create Table ���������(
��� int Identity Primary Key
,������������ varchar(30) Not Null
)
Go

ALTER TABLE ���������
  ADD CONSTRAINT ���������_������� 
    FOREIGN KEY([��� ��������]) REFERENCES �������
GO

ALTER TABLE [�������������� �����]
  ADD CONSTRAINT [�������������� �����_������] 
    FOREIGN KEY([��� ������]) REFERENCES ������
GO

ALTER TABLE [�������������� �����]
  ADD CONSTRAINT [�������������� �����_���������]
        FOREIGN KEY([��� ���������]) REFERENCES ���������
GO
ALTER TABLE �����
  ADD CONSTRAINT �����_���������
        FOREIGN KEY ([��� ���������])  REFERENCES ���������
GO

ALTER TABLE ���������
  ADD CONSTRAINT ���������_�������
    FOREIGN KEY([��� ��������]) REFERENCES �������
GO

ALTER TABLE ���������
  ADD CONSTRAINT ���������_�������
    FOREIGN KEY([��� �������]) REFERENCES �������
GO

ALTER TABLE �������
  ADD CONSTRAINT �������_���_�������
    FOREIGN KEY([��� ���� �������]) REFERENCES [��� �������]
GO

ALTER TABLE ���������
  ADD CONSTRAINT ���������_��������
    FOREIGN KEY([��� ���������]) REFERENCES ��������
GO

ALTER TABLE ��������
  ADD CONSTRAINT ��������_���������
    FOREIGN KEY([��� ���������]) REFERENCES ���������
GO

ALTER TABLE �������
  ADD CONSTRAINT [Emai-l_UNIQUE]
    UNIQUE ([Emai-l])
GO

ALTER TABLE ���������
  ADD CONSTRAINT [���� ���������_CHECK]
   CHECK ([���� ���������] >= '20000101') 
GO

ALTER TABLE �����
  ADD CONSTRAINT [����/�����_CHECK]
   CHECK ([����/�����] <= '20240901') 
GO

INSERT INTO [��� �������] 
  VALUES ('�������',6, 20),
         ('��������', 2, 10),
         ('����������', 1, 70),
         ('���������', 3, 13),
         ('�����������', 4, 22),
		 ('����������', 1, 70)
GO

INSERT INTO ������
 VALUES ('������'),
        ('������'),
        ('������ �����'),
        ('�����'),
        ('������')
GO

INSERT INTO ���������
  VALUES ('���������� �����'),
         ('��������'),
  	     ('���������'),
  	     ('������'),
  	     ('��������'),
		 ('�����������')
GO
INSERT INTO �������� 
  VALUES ('����','���������','����������',1),
         ('��������','����������','��������',2),
         ('������','�������','��������',3),
         ('�����','������','����������',4),
		 ('������','������','��������',5), 
		 ('�����','������','����������',3),
         ('�����','������','����������',5),
         ('�����','�������','����������',6)
GO

INSERT INTO �������
  VALUES ('�������','�������', '����������','+375293445723','Molochko_bragin@gmail.com'),
         ('������','�������', '�������','+375336532178','Tenzor_Flou@mail.com'),
         ('�������','�������', '���������','+375445745436','Lera_One_love@gmail.com'),
	     ('��������','���������', '�������������','+375298501687','Angelusik_One_love@yandex.com'),
         ('���������','�������', '����������','+375295137743','Brat_Ruslana@gmail.com')
GO

INSERT INTO ��������� 
  VALUES (1,'����� � �������','20200902'),
         (2,'������ � ��������� ���������','20210322'),
	     (3,'��������� ����������� ���������������','20200912'),
	     (4,'�������� �������� ��������','20221113'),
	     (5,'��� � ������� ����� 23:00','20190510'),
	     (1,'����� � �������','20210807'),
	   	 (2,'��� ������������','20211015'),
		 (5,'��������� ������� �����������','20171205'),
		 (2,'��������� ����� ���','20200426')
GO

INSERT INTO ������� 
  VALUES (4,2,228,4),
         (3,2,225,4),
         (2,2,227,2),
         (1,5,555,3),
         (6,3,331,1),
		 (3,1,111,5),
		 (3,2,208,4)
GO

INSERT INTO ��������� 
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

INSERT INTO [�������������� �����]
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

INSERT INTO ����� 
  VALUES (1,'��������� ��������� ��������','20211109 12:32:05'),
         (2,'���� �������� �����������','20220410 13:22:04'),
         (2,'����� ������� �����������','20220201 09: 10:04'),
         (4,'���� ����������� ����������','20221005 09:15:04'),
         (5,'������� �������� �������������','20171012 09:20:04'),
         (6,'���������� ������ ����������','20161007 12:15:04'),
         (7,'����� ��������� �����������','20171007 13:11:04'),
         (7,'����� ��������� �����������','20171007 15:55:04'),
		 (3,'���������� ������ ����������','20161007 12:15:04')
GO

DROP VIEW ������������������������������
GO
CREATE VIEW ������������������������������
AS
  SELECT [�������������� �����].���, [��� ������],
         [��� ���������], ����, [�������������� �����].[��� ���������],
         ������������ AS ������, �������, 
	     ������� + ' ' + ��� + ' ' + �������� AS ��������
    FROM [�������������� �����], ������,
         ���������, �������, ��������
    WHERE [��� ������] = ������.���
      AND [��� ���������] = ���������.���
   	  AND [��� �������] = �������.���
	  AND [�������������� �����].[��� ���������] = ��������.���
GO

DROP VIEW �����������������������������
GO
CREATE VIEW �����������������������������
AS
  SELECT �������, ���, ��������, �������, COUNT(*) AS ��������������������
    FROM �������, ���������
	WHERE [��� ��������] = �������.���
	GROUP BY �������.���, �������, ���, ��������, �������
GO
SELECT * FROM �����������������������������