namespace WinFormsApp19
{
    partial class FormÚjFutócs
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
            components = new System.ComponentModel.Container();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            futókBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)futókBindingSource).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(315, 430);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Ok";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(205, 430);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "Mégse";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.DataBindings.Add(new Binding("Text", futókBindingSource, "VersenyzoID", true));
            textBox1.Location = new Point(30, 64);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(379, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.DataBindings.Add(new Binding("Text", futókBindingSource, "Nev", true));
            textBox2.Location = new Point(30, 137);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(379, 27);
            textBox2.TabIndex = 3;
            // 
            // futókBindingSource
            // 
            futókBindingSource.DataSource = typeof(Futó);
            // 
            // FormÚjFutócs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(421, 471);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "FormÚjFutócs";
            Text = "FormÚjFutócs";
            Load += FormÚjFutócs_Load;
            ((System.ComponentModel.ISupportInitialize)futókBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private BindingSource futókBindingSource;
        private TextBox textBox2;
    }
}