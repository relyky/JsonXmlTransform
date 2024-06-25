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
  FROM 'D:\GitHubRepos\JsonXmlTransform\JsonXmlTransform\bin\Release\JsonXmlTransform.dll' 
  WITH PERMISSION_SET = UNSAFE; --(UNSAFE�h�@�w�n�}��trustworthy)
GO

-- ���U Function
CREATE FUNCTION fnSayHello()
RETURNS NVARCHAR(50)
AS  
EXTERNAL NAME JsonXmlTransform.ScalarValuedFunction.SayHello 
--- �`�N�G�R�W�Ŷ����W�٨��ζ��Ǭ�[ModuleName].[NameSpace].[ClassName].[MethodName] 
GO

-- ���U Function
CREATE FUNCTION fnXml2Json(@xml NVARCHAR(max))
RETURNS NVARCHAR(max)
AS  
EXTERNAL NAME JsonXmlTransform.ScalarValuedFunction.Xml2Json 
--- �`�N�G�R�W�Ŷ����W�٨��ζ��Ǭ�[ModuleName].[NameSpace].[ClassName].[MethodName] 
GO

-- ���U Function
CREATE FUNCTION fnJson2Xml(@json NVARCHAR(max))
RETURNS NVARCHAR(max)
AS  
EXTERNAL NAME JsonXmlTransform.ScalarValuedFunction.Json2Xml 
--- �`�N�G�R�W�Ŷ����W�٨��ζ��Ǭ�[ModuleName].[NameSpace].[ClassName].[MethodName] 
GO

-- ���է��Ჾ�����U
DROP FUNCTION [dbo].[fnSayHello]
DROP FUNCTION [dbo].[fnXml2Json]
DROP FUNCTION [dbo].[fnJson2Xml]
DROP ASSEMBLY [JsonXmlTransform]
GO