using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using Microsoft.Extensions.Logging;

namespace IceCreamShopView
{
    public partial class FormReportShopIceCreams : Form
    {
        private readonly ILogger _logger;

        private readonly IReportLogic _logic;

        public FormReportShopIceCreams(ILogger<FormReportShopIceCreams> logger, IReportLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }

        private void FormReportShopIceCreams_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = _logic.GetShopIceCreams();
                if (dict != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridView.Rows.Add(new object[] { elem.ShopName, "", "" });
                        foreach (var listElem in elem.IceCreams)
                        {
                            dataGridView.Rows.Add(new object[] { "", listElem.Item1, listElem.Item2 });
                        }
                        dataGridView.Rows.Add(new object[] { "Итого", "", elem.TotalCount });
                        dataGridView.Rows.Add(Array.Empty<object>());
                    }
                }
                _logger.LogInformation("Загрузка списка магазинов по мороженым");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки списка магазинов по мороженым");
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
                    _logic.SaveShopIceCreamsToExcelFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName
                    });
                    _logger.LogInformation("Сохранение списка магазинов по мороженым");
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка сохранения списка магазинов по мороженым");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
