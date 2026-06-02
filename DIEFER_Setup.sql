-- =============================================================================
-- DIEFER_Setup.sql
-- Script de inicialización de base de datos — Sistema DIEFER
-- Ejecutar UNA SOLA VEZ desde SQL Server Management Studio o sqlcmd
-- antes de iniciar la aplicación por primera vez.
--
-- Requisito: SQL Server LocalDB instalado (incluido con Visual Studio 2022)
-- Conexión:  (localdb)\MSSQLLocalDB
-- =============================================================================

-- ── 1. Crear base de datos ────────────────────────────────────────────────────
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'DIEFER')
    CREATE DATABASE DIEFER;
GO

USE DIEFER;
GO

-- ── 2. Tabla USUARIO ──────────────────────────────────────────────────────────
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'USUARIO' AND xtype = 'U')
BEGIN
    CREATE TABLE USUARIO (
        DNI       NVARCHAR(20)  NOT NULL PRIMARY KEY,
        Apellidos NVARCHAR(100) NOT NULL,
        Nombre    NVARCHAR(100) NOT NULL,
        Login     NVARCHAR(100) NOT NULL UNIQUE,
        Password  NVARCHAR(64)  NOT NULL,   -- SHA-256 en hex minúsculas
        Rol       NVARCHAR(30)  NOT NULL,
        Email     NVARCHAR(120) NOT NULL,
        Bloqueado BIT           NOT NULL DEFAULT 0,
        Activo    BIT           NOT NULL DEFAULT 1
    );
END
GO

-- ── 3. Tabla EVENTOS ──────────────────────────────────────────────────────────
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'EVENTOS' AND xtype = 'U')
BEGIN
    CREATE TABLE EVENTOS (
        Id_Evento  INT IDENTITY(1,1) PRIMARY KEY,
        Login      NVARCHAR(100) NOT NULL,
        Fecha      DATE          NOT NULL,
        Hora       TIME          NOT NULL,
        Modulo     NVARCHAR(40)  NOT NULL,
        Evento     NVARCHAR(80)  NOT NULL,
        Criticidad INT           NOT NULL CHECK (Criticidad BETWEEN 1 AND 5),
        CONSTRAINT FK_EVENTOS_USUARIO FOREIGN KEY (Login) REFERENCES USUARIO(Login)
    );
END
GO

-- ── 4. Usuario administrador semilla ─────────────────────────────────────────
-- Login:    Sistema.Admin
-- Password: SHA-256('00000000Admin') — mismo algoritmo que usa la aplicación
DECLARE @passHash NVARCHAR(64) =
    LOWER(CONVERT(NVARCHAR(64), HASHBYTES('SHA2_256', N'00000000Admin'), 2));

IF NOT EXISTS (SELECT 1 FROM USUARIO WHERE DNI = '00000000')
    INSERT INTO USUARIO (DNI, Apellidos, Nombre, Login, Password, Rol, Email, Bloqueado, Activo)
    VALUES ('00000000', 'Admin', 'Sistema', 'Sistema.Admin', @passHash, 'Administrador', 'admin@diefer.com', 0, 1);
GO
