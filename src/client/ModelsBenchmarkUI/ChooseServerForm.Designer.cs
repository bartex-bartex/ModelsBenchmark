namespace ModelsBenchmarkUI
{
    partial class ChooseServerForm
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
            serverComboBox = new ComboBox();
            selectServerBtn = new Button();
            SuspendLayout();
            // 
            // serverComboBox
            // 
            serverComboBox.FormattingEnabled = true;
            serverComboBox.Location = new Point(12, 12);
            serverComboBox.Name = "serverComboBox";
            serverComboBox.Size = new Size(273, 28);
            serverComboBox.TabIndex = 0;
            // 
            // selectServerBtn
            // 
            selectServerBtn.Location = new Point(12, 46);
            selectServerBtn.Name = "selectServerBtn";
            selectServerBtn.Size = new Size(273, 29);
            selectServerBtn.TabIndex = 1;
            selectServerBtn.Text = "Select Server";
            selectServerBtn.UseVisualStyleBackColor = true;
            selectServerBtn.Click += selectServerBtn_Click;
            // 
            // ChooseServerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(297, 81);
            Controls.Add(selectServerBtn);
            Controls.Add(serverComboBox);
            Name = "ChooseServerForm";
            Text = "ChooseServerForm";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox serverComboBox;
        private Button selectServerBtn;
    }
}