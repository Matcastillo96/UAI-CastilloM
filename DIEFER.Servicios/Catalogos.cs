namespace DIEFER.Servicios
{
    // Catálogos estáticos del dominio DIEFER.
    public static class Catalogos_593CM
    {
        public static readonly string[] Modulos_593CM =
        {
            "Usuario", "Maestro", "Ventas", "Compras", "Perfiles", "Servicio"
        };

        // Catálogo oficial: (Evento, Módulo, Criticidad)
        public static readonly CatalogoEvento_593CM[] EventosCatalogo_593CM =
        {
            new CatalogoEvento_593CM("Login",                            "Usuario", 1),
            new CatalogoEvento_593CM("Logout",                           "Usuario", 1),
            new CatalogoEvento_593CM("Login fallido",                    "Usuario", 1),
            new CatalogoEvento_593CM("Bloquear Usuario",                 "Usuario", 1),
            new CatalogoEvento_593CM("Desbloquear Usuario",              "Usuario", 1),
            new CatalogoEvento_593CM("Crear Usuario",                    "Usuario", 2),
            new CatalogoEvento_593CM("Modificar Usuario",                "Usuario", 2),
            new CatalogoEvento_593CM("Activar / Desactivar Usuario",     "Usuario", 2),
            new CatalogoEvento_593CM("Cambiar Clave",                    "Usuario", 2),
            new CatalogoEvento_593CM("Registrar Cliente",                "Maestro", 3),
            new CatalogoEvento_593CM("Modificar Cliente",                "Maestro", 3),
            new CatalogoEvento_593CM("Generar Carrito",                  "Ventas",  3),
            new CatalogoEvento_593CM("Eliminar Producto",                "Maestro", 2),
            new CatalogoEvento_593CM("Generar Presupuesto",              "Ventas",  3),
            new CatalogoEvento_593CM("Aprobar Presupuesto",              "Ventas",  2),
            new CatalogoEvento_593CM("Generar Orden de Reparación",      "Ventas",  2),
            new CatalogoEvento_593CM("Generar Orden de Compra",          "Compras", 3),
            new CatalogoEvento_593CM("Registrar Recepción de Mercadería","Compras", 3),
            new CatalogoEvento_593CM("Imprimir Factura",                 "Ventas",  4),
            new CatalogoEvento_593CM("Backup ejecutado",                 "Servicio",2),
            new CatalogoEvento_593CM("Restore ejecutado",                "Servicio",1),
            new CatalogoEvento_593CM("Error de sistema",                 "Servicio",1),
        };

        public static string[] GetNombresEvento_593CM()
        {
            var nombres = new string[EventosCatalogo_593CM.Length];
            for (int i = 0; i < EventosCatalogo_593CM.Length; i++)
                nombres[i] = EventosCatalogo_593CM[i].Nombre_593CM;
            return nombres;
        }
    }

    // Elemento del catálogo de eventos del sistema.
    public class CatalogoEvento_593CM
    {
        public string Nombre_593CM     { get; }
        public string Modulo_593CM     { get; }
        public int    Criticidad_593CM { get; }

        public CatalogoEvento_593CM(string nombre, string modulo, int criticidad)
        {
            Nombre_593CM     = nombre;
            Modulo_593CM     = modulo;
            Criticidad_593CM = criticidad;
        }
    }
}
