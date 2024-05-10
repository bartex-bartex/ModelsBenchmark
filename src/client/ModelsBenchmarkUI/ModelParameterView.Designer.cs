namespace ModelsBenchmarkUI
{
    partial class ModelParameterView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            modelLabel = new Label();
            modelComboBox = new ComboBox();
            SuspendLayout();
            // 
            // modelLabel
            // 
            modelLabel.AutoSize = true;
            modelLabel.Dock = DockStyle.Fill;
            modelLabel.Location = new Point(0, 0);
            modelLabel.Name = "modelLabel";
            modelLabel.Size = new Size(50, 20);
            modelLabel.TabIndex = 0;
            modelLabel.Text = "label1";
            // 
            // modelComboBox
            // 
            modelComboBox.Dock = DockStyle.Right;
            modelComboBox.FormattingEnabled = true;
            modelComboBox.Location = new Point(132, 0);
            modelComboBox.Name = "modelComboBox";
            modelComboBox.Size = new Size(238, 28);
            modelComboBox.TabIndex = 1;
            // 
            // ModelParameterView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(modelComboBox);
            Controls.Add(modelLabel);
            Name = "ModelParameterView";
            Size = new Size(370, 26);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label modelLabel;
        private ComboBox modelComboBox;
    }
}
