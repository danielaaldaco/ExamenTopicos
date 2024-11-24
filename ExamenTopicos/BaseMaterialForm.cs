using MaterialSkin.Controls;
using MaterialSkin;
    

public class BaseForm : MaterialForm
{
    public BaseForm()
    {
        var materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.AddFormToManage(this);

        // Tema predeterminado
        materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

        // Esquema de colores predeterminado
        materialSkinManager.ColorScheme = new ColorScheme(
            Primary.Teal500,
            Primary.Teal700,
            Primary.Teal100,
            Accent.LightBlue200,
            TextShade.WHITE
        );
    }
}
