namespace ExamenTopicos
{
    partial class FormMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnPuestos = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // btnPuestos
            // 
            btnPuestos.Image = Properties.Resources.icons8_work_50;
            btnPuestos.Location = new Point(46, 54);
            btnPuestos.Name = "btnPuestos";
            btnPuestos.Size = new Size(201, 127);
            btnPuestos.TabIndex = 0;
            btnPuestos.Text = "Puestos";
            btnPuestos.TextAlign = ContentAlignment.BottomCenter;
            btnPuestos.TextImageRelation = TextImageRelation.TextAboveImage;
            btnPuestos.UseVisualStyleBackColor = true;
            btnPuestos.Click += btnPuestos_Click;
            // 
            // button2
            // 
            button2.Image = Properties.Resources.icons8_books_50;
            button2.Location = new Point(46, 196);
            button2.Name = "button2";
            button2.Size = new Size(201, 85);
            button2.TabIndex = 1;
            button2.Text = "Editoriales";
            button2.TextImageRelation = TextImageRelation.TextBeforeImage;
            button2.UseVisualStyleBackColor = true;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(btnPuestos);
            Name = "FormMenu";
            Text = "FormMenu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnPuestos;
        private Button button2;
    }
}