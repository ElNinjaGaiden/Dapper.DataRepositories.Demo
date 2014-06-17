DECLARE @dbname nvarchar(128)
SET @dbname = N'DapperDemo'

IF (NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = @dbname OR name = @dbname))) BEGIN
	CREATE DATABASE DapperDemo
	PRINT 'db created'
END