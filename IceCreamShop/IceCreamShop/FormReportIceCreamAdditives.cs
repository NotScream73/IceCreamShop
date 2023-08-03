using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using Microsoft.Extensions.Logging;

namespace IceCreamShopView
{
    public partial class FormReportIceCreamAdditives : Form
    {
        private readonly ILogger _logger;

        private readonly IReportLogic _logic;

        public FormReportIceCreamAdditives(ILogger<FormReportIceCreamAdditives> logger, IReportLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }

        private void FormReportIceCreamAdditives_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = _logic.GetIceCreamAdditive();
                if (dict != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridView.Rows.Add(new object[] { elem.IceCreamName, "", "" });
                        foreach (var listElem in elem.Additives)
                        {
                            dataGridView.Rows.Add(new object[] { "", listElem.Item1, listElem.Item2 });
                        }
                        dataGridView.Rows.Add(new object[] { "Итого", "", elem.TotalCount });
                        dataGridView.Rows.Add(Array.Empty<object>());
                    }
                }
                _logger.LogInformation("Загрузка списка мороженых по добавкам");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки списка мороженых по добавкам");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSaveToExcel_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _logic.SaveIceCreamAdditiveToExcelFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName
                    });
                    _logger.LogInformation("Сохранение списка мороженых по добавкам");
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка сохранения списка мороженых по добавкам");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
