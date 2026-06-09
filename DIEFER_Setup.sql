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

-- ── 2. Tabla ROLES ────────────────────────────────────────────────────────────
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'ROLES' AND xtype = 'U')
BEGIN
    CREATE TABLE ROLES (
        ID_rol  INT          NOT NULL IDENTITY(1,1) PRIMARY KEY,
        Nombre  NVARCHAR(50) NOT NULL UNIQUE
    );
END
GO

-- Roles del sistema
IF NOT EXISTS (SELECT 1 FROM ROLES)
BEGIN
    INSERT INTO ROLES (Nombre) VALUES
        ('Administrador'),
        ('Vendedor'),
        ('Cajero'),
        ('Despachador'),
        ('Supervisor'),
        ('Gerencial');
END
GO

-- ── 3. Tabla USUARIO ──────────────────────────────────────────────────────────
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'USUARIO' AND xtype = 'U')
BEGIN
    CREATE TABLE USUARIO (
        DNI       NVARCHAR(20)  NOT NULL PRIMARY KEY,
        Apellidos NVARCHAR(100) NOT NULL,
        Nombre    NVARCHAR(100) NOT NULL,
        Login     NVARCHAR(100) NOT NULL UNIQUE,
        Password  NVARCHAR(64)  NOT NULL,   -- SHA-256 en hex minúsculas
        ID_rol    INT           NOT NULL REFERENCES ROLES(ID_rol),
        Email     NVARCHAR(120) NOT NULL,
        Bloqueado BIT           NOT NULL DEFAULT 0,
        Activo    BIT           NOT NULL DEFAULT 1,
        Idioma    NVARCHAR(10)  NOT NULL DEFAULT 'es'
    );

    -- Migración para bases existentes: agregar columna Idioma si no existe
    IF NOT EXISTS (SELECT 1 FROM sys.columns
                   WHERE object_id = OBJECT_ID('USUARIO') AND name = 'Idioma')
        ALTER TABLE USUARIO ADD Idioma NVARCHAR(10) NOT NULL DEFAULT 'es';
END
GO

-- ── 4. Tabla EVENTOS ──────────────────────────────────────────────────────────
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

-- ── 5. Usuario administrador semilla ─────────────────────────────────────────
-- Login:    Sistema.Admin
-- Password: SHA-256('00000000Admin') — mismo algoritmo que usa la aplicación
DECLARE @passHash NVARCHAR(64) =
    LOWER(CONVERT(NVARCHAR(64), HASHBYTES('SHA2_256', N'00000000Admin'), 2));

DECLARE @idAdmin INT = (SELECT ID_rol FROM ROLES WHERE Nombre = 'Administrador');

IF NOT EXISTS (SELECT 1 FROM USUARIO WHERE DNI = '00000000')
    INSERT INTO USUARIO (DNI, Apellidos, Nombre, Login, Password, ID_rol, Email, Bloqueado, Activo)
    VALUES ('00000000', 'Admin', 'Sistema', 'Sistema.Admin', @passHash, @idAdmin, 'admin@diefer.com', 0, 1);
GO
