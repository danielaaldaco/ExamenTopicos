using System;

namespace ExamenTopicos
{
    public enum UserRole
    {
        Cliente = 1,
        Empleado = 2,
        GerenteVentas = 3,
        Administrador = 4
    }

    public class Usuario
    {
        public string NombreUsuario { get; set; }
        public UserRole Rol { get; set; }
        public string NombrePersona { get; set; }

        public Usuario() { }
        public Usuario(string nombreUsuario, UserRole rol, string nombrePersona)
        {
            NombreUsuario = nombreUsuario;
            Rol = rol;
            NombrePersona = nombrePersona;
        }
    }
}
