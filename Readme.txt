SQL Server 2019+ CLR 
with .NET Framework 4.7.2+
用於整合檔案系統，讀取(附件)檔案資訊。

--------------------------------------------------
-- 註冊SQL Server CLR
--------------------------------------------------

-- 啟動CLR
EXEC sp_configure 'clr enabled', 1;  
RECONFIGURE;  
GO  

-- 此為"UNSAFE"的組態可用於開發時期，正式部版時不建議用此模式。
ALTER DATABASE MyLabDB SET TRUSTWORTHY ON
GO

-- 註冊CLR.dll模組
CREATE ASSEMBLY JsonXmlTransform 
  AUTHORIZATION dbo
  FROM 'D:\GitHubRepos\JsonXmlTransform\bin\Release\JsonXmlTransform.dll' 
  WITH PERMISSION_SET = UNSAFE; --(UNSAFE則一定要開啟trustworthy)
GO

-- 註冊 Function
CREATE FUNCTION fnSayHello()
RETURNS NVARCHAR(50)
AS  
EXTERNAL NAME JsonXmlTransform.ScalarValuedFunction.SayHello 
--- 注意：命名空間的名稱取用順序為[ModuleName].[NameSpace].[ClassName].[MethodName] 
GO

-- 測試完後移除註冊
DROP FUNCTION [dbo].[SayHello]
DROP ASSEMBLY [JsonXmlTransform]
GO