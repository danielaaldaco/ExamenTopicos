namespace ExamenTopicos
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            /*
            FormLogin loginForm = new FormLogin();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Usuario usuarioLogueado = loginForm.UsuarioLogueado;
                Application.Run(new FormMenu(usuarioLogueado));
            }
            */

            Usuario usuarioLogueado = new Usuario("Juan", UserRole.Administrador, "Juan");
            Application.Run(new FormMenu(usuarioLogueado));
        }
    }
}