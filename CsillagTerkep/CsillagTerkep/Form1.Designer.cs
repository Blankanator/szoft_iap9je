namespace CsillagTerkep
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonGraph = new Button();
            SuspendLayout();
            // 
            // buttonGraph
            // 
            buttonGraph.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonGraph.Location = new Point(713, 12);
            buttonGraph.Name = "buttonGraph";
            buttonGraph.Size = new Size(75, 23);
            buttonGraph.TabIndex = 0;
            buttonGraph.Text = "Rajzolás";
            buttonGraph.UseVisualStyleBackColor = true;
            buttonGraph.Click += buttonGraph_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonGraph);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonGraph;
    }
}