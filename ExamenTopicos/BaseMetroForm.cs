using MetroFramework.Controls;
using MetroFramework.Forms;
using System.Drawing;

public class BaseMetroForm : MetroForm
{
    public BaseMetroForm()
    {
        // Configuración del tema y estilo del formulario
        this.Theme = MetroFramework.MetroThemeStyle.Light; // Tema claro
        this.Style = MetroFramework.MetroColorStyle.Pink;  // Color rosado claro para la línea superior
        this.BackColor = Color.White;                     // Fondo blanco (255, 255, 255)

        // Configuración adicional de fuente
        this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);

        // Opcional: Configurar controles base
        ConfigurarControlesBase();
    }

    private void ConfigurarControlesBase()
    {
        foreach (var control in this.Controls)
        {
            if (control is MetroLabel label)
            {
                label.FontSize = MetroFramework.MetroLabelSize.Medium;
                label.FontWeight = MetroFramework.MetroLabelWeight.Regular;
                label.Theme = this.Theme;
                label.Style = this.Style;
            }
            else if (control is MetroButton button)
            {
                button.Theme = this.Theme;
                button.Style = this.Style;
                button.BackColor = Color.FromArgb(255, 240, 245); // Color rosado muy claro para botones (opcional)
                button.ForeColor = Color.Black;                   // Texto negro en botones
            }
            else if (control is MetroTextBox textBox)
            {
                textBox.Theme = this.Theme;
                textBox.Style = this.Style;
            }
            //else if (control is MetroGrid grid)
            //{
            //    // Configuración general de tablas
            //    grid.Theme = this.Theme;
            //    grid.Style = this.Style;
            //    grid.BackgroundColor = Color.White; // Fondo blanco
            //    grid.GridColor = Color.Black;       // Líneas de la tabla en negro

            //    // Configurar estilo de las celdas
            //    grid.DefaultCellStyle.BackColor = Color.White;   // Fondo blanco para celdas
            //    grid.DefaultCellStyle.ForeColor = Color.Black;   // Texto negro en celdas
            //    grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(234, 222, 205); // Color beige claro para selección
            //    grid.DefaultCellStyle.SelectionForeColor = Color.Black;                  // Texto negro en selección

            //    // Configurar encabezados de columnas
            //    grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 128, 128); // Rosado claro
            //    grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;                  // Texto negro
            //    grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            //    grid.EnableHeadersVisualStyles = false; // Permitir personalización de encabezados
            //}
        }
    }
}
