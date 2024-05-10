namespace ModelsBenchmarkUI
{
    public partial class ModelParameterView : UserControl
    {
        public string ParameterName 
        { 
            get { return this.modelLabel.Text; } 
            set { this.modelLabel.Text = value; } 
        }

        public object? ComboBoxDataSource
        {
            get { return this.modelComboBox.DataSource; }
            set 
            { 
                this.modelComboBox.DataSource = value; 
                this.modelComboBox.SelectedIndex = -1; 
            }
        }

        public string SelectedValue
        {
            get { return this.modelComboBox.Text ?? string.Empty; }
        }

        public ModelParameterView()
        {
            InitializeComponent();
        }
    }
}
