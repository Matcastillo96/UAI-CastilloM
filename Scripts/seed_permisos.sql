-- ============================================================================
-- seed_permisos.sql
-- Datos mínimos para el sistema de permisos dinámicos (patrón Composite).
--
-- FormPrincipal habilita los menús de administración consultando las cadenas
-- de permiso efectivas del rol del usuario. Sin estos registros, ningún
-- usuario verá los menús de ADMIN. Ejecutar una única vez sobre la BD DIEFER.
--
-- Idempotente: cada INSERT verifica existencia previa.
-- ============================================================================

USE DIEFER;
GO

-- ── 1. Patentes con sus cadenas de permiso ──────────────────────────────────

IF NOT EXISTS (SELECT 1 FROM Patente WHERE Permiso = 'admin.usuarios')
    INSERT INTO Patente (Nombre, Permiso) VALUES ('Gestión de Usuarios', 'admin.usuarios');

IF NOT EXISTS (SELECT 1 FROM Patente WHERE Permiso = 'admin.bitacora')
    INSERT INTO Patente (Nombre, Permiso) VALUES ('Bitácora de Eventos', 'admin.bitacora');

IF NOT EXISTS (SELECT 1 FROM Patente WHERE Permiso = 'admin.perfiles')
    INSERT INTO Patente (Nombre, Permiso) VALUES ('Gestión de Perfiles', 'admin.perfiles');
GO

-- ── 2. Familia "Administración" que agrupa las patentes de admin ────────────
IF NOT EXISTS (SELECT 1 FROM Familia WHERE Nombre = 'Administración')
    INSERT INTO Familia (Nombre) VALUES ('Administración');
GO

DECLARE @idFamiliaAdmin INT = (SELECT ID_familia FROM Familia WHERE Nombre = 'Administración');

INSERT INTO Familia_Patente (ID_familia, ID_patente)
SELECT @idFamiliaAdmin, P.ID_patente
FROM Patente P
WHERE P.Permiso IN ('admin.usuarios', 'admin.bitacora', 'admin.perfiles')
  AND NOT EXISTS (SELECT 1 FROM Familia_Patente FP
                  WHERE FP.ID_familia = @idFamiliaAdmin
                    AND FP.ID_patente = P.ID_patente);
GO

-- ── 3. Asignar la familia al rol Administrador ──────────────────────────────
DECLARE @idRolAdmin     INT = (SELECT ID_rol     FROM ROLES   WHERE Nombre = 'Administrador');
DECLARE @idFamiliaAdmin INT = (SELECT ID_familia FROM Familia WHERE Nombre = 'Administración');

IF @idRolAdmin IS NULL
    RAISERROR ('No existe el rol "Administrador". Crearlo antes de ejecutar este script.', 16, 1);
ELSE IF NOT EXISTS (SELECT 1 FROM Rol_Familia
                    WHERE ID_rol = @idRolAdmin AND ID_familia = @idFamiliaAdmin)
    INSERT INTO Rol_Familia (ID_rol, ID_familia) VALUES (@idRolAdmin, @idFamiliaAdmin);
GO

-- ── 4. El rol "Auditor" (si existe) recibe solo la bitácora ─────────────────
DECLARE @idRolAuditor INT = (SELECT ID_rol     FROM ROLES   WHERE Nombre = 'Auditor');
DECLARE @idPatBitacora INT = (SELECT ID_patente FROM Patente WHERE Permiso = 'admin.bitacora');

IF @idRolAuditor IS NOT NULL
   AND NOT EXISTS (SELECT 1 FROM Rol_Patente
                   WHERE ID_rol = @idRolAuditor AND ID_patente = @idPatBitacora)
    INSERT INTO Rol_Patente (ID_rol, ID_patente) VALUES (@idRolAuditor, @idPatBitacora);
GO

PRINT 'Seed de permisos completado.';
