using MaterialSkin.Controls;
using MaterialSkin;
using System.Drawing;
using System.Windows.Forms;

public class BaseForm : MaterialForm
{
    public BaseForm()
    {
        // Configurar MaterialSkinManager
        var materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.AddFormToManage(this);

        // Configuración del tema
        materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

        // Configuración del esquema de colores (solo líneas superiores en tonos ámbar)
        materialSkinManager.ColorScheme = new ColorScheme(
            Primary.Amber50, // Fondo de la barra superior (más oscuro)
            Primary.Amber100, // Fondo de la barra de control
            Primary.Amber200, // Fondo de selección activa
            Accent.LightBlue200, // Color de acentos (puedes ajustarlo si lo deseas)
            TextShade.BLACK // Texto en negro
        );

        // Fondo del formulario en blanco
        this.BackColor = Color.FromArgb(255, 255, 255); // Blanco puro

        // Configurar imagen de fondo
        ConfigurarImagenDeFondo();

        // Configurar tipografía general
        this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);

        // Opcional: Deshabilitar otros estilos si es necesario
        DeshabilitarEstilosInterferentes();
    }

    /// <summary>
    /// Configura una imagen de fondo para todos los formularios que hereden de esta clase.
    /// </summary>
    private void ConfigurarImagenDeFondo()
    {
        // Establecer la imagen desde recursos (asegúrate de tener una imagen en tus recursos).
        this.BackgroundImage = ExamenTopicos.Properties.Resources.libros; // Cambia "libros" por el nombre de tu imagen en recursos.

        // Opcional: Si deseas cargar desde un archivo externo:
        // this.BackgroundImage = Image.FromFile("ruta/a/tu/imagen.jpg");

        // Ajustar el layout de la imagen
        this.BackgroundImageLayout = ImageLayout.Stretch; // La imagen se estirará para llenar el formulario
    }

    /// <summary>
    /// Deshabilita configuraciones predefinidas para elementos como botones y tablas.
    /// </summary>
    private void DeshabilitarEstilosInterferentes()
    {
        // Aquí no configuramos colores ni estilos para botones o tablas,
        // dejándote libertad para personalizarlos en cada formulario.
    }

    private void InitializeComponent()
    {

    }
}
