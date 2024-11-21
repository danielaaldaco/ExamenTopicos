using System;

namespace ExamenTopicos
{

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

    public enum UserRole
    {
        Cliente,
        Empleado,
        GerenteVentas,
        Administrador
    }
}