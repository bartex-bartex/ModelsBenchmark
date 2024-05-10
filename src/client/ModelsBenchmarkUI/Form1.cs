using ModelsBenchmarkLibrary;
using ModelsBenchmarkLibrary.Api;
using ModelsBenchmarkLibrary.Models;
using System.Windows.Forms;

namespace ModelsBenchmarkUI
{
    public partial class Form1 : Form
    {
        List<string> availableModels = new();
        Dictionary<string, Dictionary<string, List<string>>> modelToParameters = new();

        public Form1()
        {
            InitializeComponent();
            ConfigureGridView();
            ApiHelper.InitializeClient();
        }

        private async Task LoadData()
        {
            availableModels = await ApiProcessor.LoadAvailableModels();

            foreach (string model in availableModels)
            {
                var responseObject = await ApiProcessor.LoadModelParameters(model);

                modelToParameters.Add(model, responseObject);
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadData();
            WireUpModelList();
        }
        private void modelsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            WireUpModelParametersList();
        }

        private void WireUpModelList()
        {
            modelsComboBox.DataSource = null;
            modelsComboBox.DataSource = availableModels;
        }

        private void WireUpModelParametersList()
        {
            flowLayoutPanel.Controls.Clear();
            var currentParameters = modelToParameters[modelsComboBox.Text];
            foreach (string key in currentParameters.Keys)
            {
                flowLayoutPanel.Controls.Add(new ModelParameterView() { ParameterName = key, ComboBoxDataSource = currentParameters[key] });
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string model = modelsComboBox.Text;
            Dictionary<string, string> parameters = new();
            string accuracy;

            foreach (ModelParameterView view in flowLayoutPanel.Controls)
            {
                parameters.Add(view.ParameterName, view.SelectedValue.ToString());
            }

            accuracy = await ApiProcessor.BenchmarkModel(model, parameters);

            GlobalConfig.Connection.TryAddScore(new ScoreModel
            {
                Model = model,
                Parameters = parameters.Select(pair => $"{pair.Key}={pair.Value}").ToList(),
                Score = accuracy
            });

            MessageBox.Show($"Accuracy: {accuracy}");
        }

        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainTabControl.SelectedIndex == 1)
            {
                WireUpLeaderboard();
            }
        }

        private void WireUpLeaderboard()
        {
            var scores = GlobalConfig.Connection.GetScores();

            dataGridView.Rows.Clear();
            foreach (var score in scores)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView);
                row.Cells[0].Value = score.Model;
                row.Cells[1].Value = string.Join(", ", score.Parameters);
                row.Cells[2].Value = score.Score;
                dataGridView.Rows.Add(row);
            }
        }

        private void ConfigureGridView()
        {
            // Assuming dataGridView is your DataGridView instance
            dataGridView.AutoGenerateColumns = false;
            dataGridView.ReadOnly = true;

            // Add columns for other properties
            dataGridView.Columns.Add("Model", "Model");
            dataGridView.Columns.Add("Parameters", "Parameters");
            dataGridView.Columns.Add("Score", "Score");

            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
    }
}
