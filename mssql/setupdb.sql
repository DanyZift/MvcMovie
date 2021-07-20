USE master
GO
    IF NOT EXISTS 
        (SELECT [name] FROM sys.databases
        WHERE [name] = N'MvcMovies')
        CREATE DATABASE MvcMovies
GO