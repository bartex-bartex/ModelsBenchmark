namespace ModelsBenchmarkUI
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
            mainTabControl = new TabControl();
            tabPage1 = new TabPage();
            flowLayoutPanel = new FlowLayoutPanel();
            button1 = new Button();
            modelsComboBox = new ComboBox();
            tabPage2 = new TabPage();
            dataGridView = new DataGridView();
            mainTabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // mainTabControl
            // 
            mainTabControl.Controls.Add(tabPage1);
            mainTabControl.Controls.Add(tabPage2);
            mainTabControl.Dock = DockStyle.Fill;
            mainTabControl.Location = new Point(0, 0);
            mainTabControl.Name = "mainTabControl";
            mainTabControl.SelectedIndex = 0;
            mainTabControl.Size = new Size(800, 450);
            mainTabControl.TabIndex = 0;
            mainTabControl.SelectedIndexChanged += mainTabControl_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(flowLayoutPanel);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(modelsComboBox);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 417);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Benchmark";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Location = new Point(8, 40);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(776, 335);
            flowLayoutPanel.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(8, 382);
            button1.Name = "button1";
            button1.Size = new Size(776, 29);
            button1.TabIndex = 3;
            button1.Text = "Run Benchmark";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // modelsComboBox
            // 
            modelsComboBox.FormattingEnabled = true;
            modelsComboBox.Location = new Point(8, 6);
            modelsComboBox.Name = "modelsComboBox";
            modelsComboBox.Size = new Size(778, 28);
            modelsComboBox.TabIndex = 2;
            modelsComboBox.SelectedIndexChanged += modelsComboBox_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 417);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Hall of Fame";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 3);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(786, 411);
            dataGridView.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mainTabControl);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            mainTabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl mainTabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ComboBox modelsComboBox;
        private Button button1;
        private FlowLayoutPanel flowLayoutPanel;
        private DataGridView dataGridView;
    }
}
