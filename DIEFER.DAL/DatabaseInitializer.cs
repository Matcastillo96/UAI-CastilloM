// DatabaseInitializer_593CM — reemplazado por DIEFER_Setup.sql
// Ejecutar el script SQL manualmente antes de iniciar la aplicación por primera vez.
//
// #if false
// using System;
// using System.Data.SqlClient;
// using DIEFER.Servicios;
//
// namespace DIEFER.DAL
// {
//     public static class DatabaseInitializer_593CM
//     {
//         public static void InicializarBD_593CM()
//         {
//             CrearBaseDeDatos_593CM();
//             CrearTablas_593CM();
//             SembrarAdministrador_593CM();
//         }
//
//         private static void CrearBaseDeDatos_593CM()
//         {
//             string master = ConexionDB_593CM.ObtenerConexion_593CM().ConnectionString
//                 .Replace("Initial Catalog=DIEFER", "Initial Catalog=master");
//             using (var conn = new SqlConnection(master))
//             {
//                 conn.Open();
//                 EjecutarComando_593CM(conn,
//                     "IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'DIEFER') CREATE DATABASE DIEFER");
//             }
//         }
//
//         private static void CrearTablas_593CM()
//         {
//             using (var conn = ConexionDB_593CM.ObtenerConexion_593CM())
//             {
//                 conn.Open();
//
//                 const string sqlUsuario = @"
// IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='USUARIO' AND xtype='U')
// BEGIN
//     CREATE TABLE USUARIO (
//         DNI       NVARCHAR(20)  NOT NULL PRIMARY KEY,
//         Apellidos NVARCHAR(100) NOT NULL,
//         Nombre    NVARCHAR(100) NOT NULL,
//         Login     NVARCHAR(100) NOT NULL UNIQUE,
//         Password  NVARCHAR(64)  NOT NULL,
//         Rol       NVARCHAR(30)  NOT NULL,
//         Email     NVARCHAR(120) NOT NULL,
//         Bloqueado BIT           NOT NULL DEFAULT 0,
//         Activo    BIT           NOT NULL DEFAULT 1
//     )
// END";
//
//                 const string sqlEventos = @"
// IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='EVENTOS' AND xtype='U')
// BEGIN
//     CREATE TABLE EVENTOS (
//         Id_Evento  INT IDENTITY(1,1) PRIMARY KEY,
//         Login      NVARCHAR(100) NOT NULL,
//         Fecha      DATE          NOT NULL,
//         Hora       TIME          NOT NULL,
//         Modulo     NVARCHAR(40)  NOT NULL,
//         Evento     NVARCHAR(80)  NOT NULL,
//         Criticidad INT           NOT NULL CHECK (Criticidad BETWEEN 1 AND 5),
//         CONSTRAINT FK_EVENTOS_USUARIO FOREIGN KEY (Login) REFERENCES USUARIO(Login)
//     )
// END";
//
//                 EjecutarComando_593CM(conn, sqlUsuario);
//                 EjecutarComando_593CM(conn, sqlEventos);
//             }
//         }
//
//         private static void SembrarAdministrador_593CM()
//         {
//             const string dni      = "00000000";
//             const string apellido = "Admin";
//             const string nombre   = "Sistema";
//             string login          = $"{nombre}.{apellido}";
//             string passInicial    = CriptoService_593CM.HashSHA256_593CM($"{dni}{apellido}");
//
//             const string sql = @"
// IF NOT EXISTS (SELECT 1 FROM USUARIO WHERE DNI = @DNI)
//     INSERT INTO USUARIO (DNI, Apellidos, Nombre, Login, Password, Rol, Email, Bloqueado, Activo)
//     VALUES (@DNI, @Ape, @Nom, @Login, @Pass, 'Administrador', 'admin@diefer.com', 0, 1)";
//
//             using (var conn = ConexionDB_593CM.ObtenerConexion_593CM())
//             {
//                 conn.Open();
//                 using (var cmd = new SqlCommand(sql, conn))
//                 {
//                     cmd.Parameters.AddWithValue("@DNI",   dni);
//                     cmd.Parameters.AddWithValue("@Ape",   apellido);
//                     cmd.Parameters.AddWithValue("@Nom",   nombre);
//                     cmd.Parameters.AddWithValue("@Login", login);
//                     cmd.Parameters.AddWithValue("@Pass",  passInicial);
//                     cmd.ExecuteNonQuery();
//                 }
//             }
//         }
//
//         private static void EjecutarComando_593CM(SqlConnection conn, string sql)
//         {
//             using (var cmd = new SqlCommand(sql, conn))
//                 cmd.ExecuteNonQuery();
//         }
//     }
// }
// #endif
