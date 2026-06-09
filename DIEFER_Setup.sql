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

-- ── 5. Composite de Permisos: Patente / Familia ──────────────────────────────

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Patente' AND xtype = 'U')
BEGIN
    CREATE TABLE Patente (
        ID_patente INT          NOT NULL IDENTITY(1,1) PRIMARY KEY,
        Nombre     NVARCHAR(80) NOT NULL UNIQUE,
        Permiso    NVARCHAR(80) NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Familia' AND xtype = 'U')
BEGIN
    CREATE TABLE Familia (
        ID_familia INT          NOT NULL IDENTITY(1,1) PRIMARY KEY,
        Nombre     NVARCHAR(80) NOT NULL UNIQUE
    );
END
GO

-- Familia contiene Patentes (hoja)
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Familia_Patente' AND xtype = 'U')
BEGIN
    CREATE TABLE Familia_Patente (
        ID_familia INT NOT NULL REFERENCES Familia(ID_familia) ON DELETE CASCADE,
        ID_patente INT NOT NULL REFERENCES Patente(ID_patente) ON DELETE CASCADE,
        CONSTRAINT PK_Familia_Patente PRIMARY KEY (ID_familia, ID_patente)
    );
END
GO

-- Familia contiene sub-Familias (composite recursivo)
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Familia_Familia' AND xtype = 'U')
BEGIN
    CREATE TABLE Familia_Familia (
        ID_familiaPadre INT NOT NULL REFERENCES Familia(ID_familia),
        ID_familiaHija  INT NOT NULL REFERENCES Familia(ID_familia),
        CONSTRAINT PK_Familia_Familia  PRIMARY KEY (ID_familiaPadre, ID_familiaHija),
        CONSTRAINT CK_FF_NoAutoRef     CHECK (ID_familiaPadre <> ID_familiaHija)
    );
END
GO

-- Rol asignado a Patentes directas
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Rol_Patente' AND xtype = 'U')
BEGIN
    CREATE TABLE Rol_Patente (
        ID_rol     INT NOT NULL REFERENCES ROLES(ID_rol) ON DELETE CASCADE,
        ID_patente INT NOT NULL REFERENCES Patente(ID_patente) ON DELETE CASCADE,
        CONSTRAINT PK_Rol_Patente PRIMARY KEY (ID_rol, ID_patente)
    );
END
GO

-- Rol asignado a Familias
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Rol_Familia' AND xtype = 'U')
BEGIN
    CREATE TABLE Rol_Familia (
        ID_rol     INT NOT NULL REFERENCES ROLES(ID_rol) ON DELETE CASCADE,
        ID_familia INT NOT NULL REFERENCES Familia(ID_familia) ON DELETE CASCADE,
        CONSTRAINT PK_Rol_Familia PRIMARY KEY (ID_rol, ID_familia)
    );
END
GO

-- Patentes semilla (precargadas — la app no las crea)
IF NOT EXISTS (SELECT 1 FROM Patente)
BEGIN
    INSERT INTO Patente (Nombre, Permiso) VALUES
        ('Alta de usuario',        'USUARIO_ALTA'),
        ('Baja de usuario',        'USUARIO_BAJA'),
        ('Modificar usuario',      'USUARIO_MODIFICAR'),
        ('Ver bitácora',           'BITACORA_VER'),
        ('Exportar bitácora',      'BITACORA_EXPORTAR'),
        ('Crear orden de trabajo', 'OT_CREAR'),
        ('Cerrar orden de trabajo','OT_CERRAR'),
        ('Ver stock',              'STOCK_VER'),
        ('Modificar stock',        'STOCK_MODIFICAR'),
        ('Ver reportes',           'REPORTES_VER'),
        ('Generar reportes',       'REPORTES_GENERAR'),
        ('Gestionar perfiles',     'PERFILES_GESTIONAR');
END
GO

-- ── 6. Usuario administrador semilla ─────────────────────────────────────────
-- Login:    Sistema.Admin
-- Password: SHA-256('00000000Admin') — mismo algoritmo que usa la aplicación
DECLARE @passHash NVARCHAR(64) =
    LOWER(CONVERT(NVARCHAR(64), HASHBYTES('SHA2_256', N'00000000Admin'), 2));

DECLARE @idAdmin INT = (SELECT ID_rol FROM ROLES WHERE Nombre = 'Administrador');

IF NOT EXISTS (SELECT 1 FROM USUARIO WHERE DNI = '00000000')
    INSERT INTO USUARIO (DNI, Apellidos, Nombre, Login, Password, ID_rol, Email, Bloqueado, Activo)
    VALUES ('00000000', 'Admin', 'Sistema', 'Sistema.Admin', @passHash, @idAdmin, 'admin@diefer.com', 0, 1);
GO
