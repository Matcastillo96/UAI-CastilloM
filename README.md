# DIEFER — Sistema de Gestión

Trabajo práctico académico (UAI). Aplicación Windows Forms en C# (.NET Framework 4.8)
con arquitectura en capas y patrones de diseño aplicados.

## Arquitectura en capas

```
DIEFER.UI         →  Presentación (Windows Forms, MDI)
DIEFER.BLL        →  Lógica de negocio
DIEFER.DAL        →  Acceso a datos (ADO.NET / SQL Server)
DIEFER.Servicios  →  Entidades de dominio, interfaces y servicios transversales
```

Reglas de dependencia: `UI → BLL → DAL → Servicios`. Las interfaces de acceso a
datos viven en `DIEFER.Servicios/Interfaces/` para invertir la dependencia
(la BLL depende de contratos, no de implementaciones concretas).

## Patrones de diseño aplicados

| Patrón | Implementación | Propósito |
|--------|----------------|-----------|
| **Composite** | `IPermiso_593CM` (component), `Patente_593CM` (leaf), `Familia_593CM` (composite) | Componer permisos en jerarquías arbitrarias |
| **Observer** | `IIdiomaObserver_593CM` + `IdiomaService_593CM` | Internacionalización reactiva de la UI |
| **Singleton** | `SessionManager_593CM` (thread-safe, double-checked locking) | Estado único de la sesión activa |
| **Repository** | Interfaces `IFamilia_593CM`, `IRol_593CM`, `IUsuario_593CM`, etc. | Abstraer el acceso a datos |

## Decisiones de diseño relevantes

- **Grafo de permisos en memoria** (`GrafoFamilias_593CM`): el cálculo de
  permisos efectivos requiere recorridos BFS sobre la jerarquía de familias.
  El grafo completo se carga en 2 consultas y los recorridos corren en memoria,
  evitando el problema de consultas N+1.
- **Prevención de ciclos**: antes de vincular dos familias se verifica en ambas
  direcciones que no se genere un ciclo en el grafo.
- **Operaciones atómicas**: las asignaciones multi-paso (agregar familia +
  depurar patentes redundantes) se ejecutan dentro de `TransactionScope`.
- **Permisos dinámicos**: los menús de la UI se habilitan según las cadenas de
  permiso (`admin.usuarios`, `admin.bitacora`, `admin.perfiles`) alcanzables
  desde el rol del usuario — sin roles hardcodeados en el código.

## Puesta en marcha

1. Crear la base de datos ejecutando `DIEFER_Setup.sql`.
2. Ejecutar `Scripts/seed_permisos.sql` para cargar las patentes de
   administración y asignarlas al rol Administrador. **Sin este paso los menús
   de ADMIN quedan deshabilitados para todos los usuarios.**
3. En `DIEFER.UI/App.config`, configurar la connection string `DIEFER` y la
   clave `ClaveAES` (no commitear valores reales).
4. Compilar la solución `DIEFER.sln` y ejecutar `DIEFER.UI`.
