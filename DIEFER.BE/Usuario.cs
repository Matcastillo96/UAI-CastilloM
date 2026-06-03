namespace DIEFER.BE
{
    // Entidad de negocio que representa un usuario del sistema DIEFER.
    public class Usuario_593CM
    {
        public string DNI_593CM       { get; set; }
        public string Apellidos_593CM { get; set; }
        public string Nombre_593CM    { get; set; }
        public string Login_593CM     { get; set; }
        public string Password_593CM  { get; set; }   // SHA-256 hash
        public int    ID_rol_593CM    { get; set; }   // FK → ROLES.ID_rol
        public string Rol_593CM       { get; set; }   // nombre del rol (cargado por JOIN)
        public string Email_593CM     { get; set; }
        public bool   Bloqueado_593CM { get; set; }   // false = no bloqueado (default)
        public bool   Activo_593CM    { get; set; }   // true  = activo (default)
    }
}
