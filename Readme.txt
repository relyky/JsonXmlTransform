SQL Server 2019+ CLR 
with .NET Framework 4.7.2+
�Ω��X�ɮרt�ΡAŪ��(����)�ɮ׸�T�C

--------------------------------------------------
-- ���USQL Server CLR
--------------------------------------------------

-- �Ұ�CLR
EXEC sp_configure 'clr enabled', 1;  
RECONFIGURE;  
GO  

-- ����"UNSAFE"���պA�i�Ω�}�o�ɴ��A���������ɤ���ĳ�Φ��Ҧ��C
ALTER DATABASE MyLabDB SET TRUSTWORTHY ON
GO

-- ���UCLR.dll�Ҳ�
CREATE ASSEMBLY JsonXmlTransform 
  AUTHORIZATION dbo
  FROM 'D:\GitHubRepos\JsonXmlTransform\bin\Release\JsonXmlTransform.dll' 
  WITH PERMISSION_SET = UNSAFE; --(UNSAFE�h�@�w�n�}��trustworthy)
GO

-- ���U Function
CREATE FUNCTION fnSayHello()
RETURNS NVARCHAR(50)
AS  
EXTERNAL NAME JsonXmlTransform.ScalarValuedFunction.SayHello 
--- �`�N�G�R�W�Ŷ����W�٨��ζ��Ǭ�[ModuleName].[NameSpace].[ClassName].[MethodName] 
GO

-- ���է��Ჾ�����U
DROP FUNCTION [dbo].[SayHello]
DROP ASSEMBLY [JsonXmlTransform]
GO