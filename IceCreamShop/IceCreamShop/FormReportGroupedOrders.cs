using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using Microsoft.Extensions.Logging;
using Microsoft.Reporting.WinForms;

namespace IceCreamShopView
{
    public partial class FormReportGroupedOrders : Form
    {
        private readonly ReportViewer reportViewer;

        private readonly ILogger _logger;

        private readonly IReportLogic _logic;

        public FormReportGroupedOrders(ILogger<FormReportGroupedOrders> logger, IReportLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
            reportViewer = new ReportViewer
            {
                Dock = DockStyle.Fill
            };
            reportViewer.LocalReport.LoadReportDefinition(new FileStream("..\\..\\..\\ReportGroupedOrders.rdlc", FileMode.Open));
            Controls.Clear();
            Controls.Add(reportViewer);
            Controls.Add(panel);
        }

        private void ButtonMake_Click(object sender, EventArgs e)
        {
            try
            {
                var dataSource = _logic.GetGroupedOrders();
                var source = new ReportDataSource("DataSetGroupedOrders", dataSource);
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(source);

                reportViewer.RefreshReport();
                _logger.LogInformation("Загрузка списка заказов");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки списка заказов");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonToPdf_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _logic.SaveGroupedOrdersToPdfFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName
                    });
                    _logger.LogInformation("Загрузка списка заказов");
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка сохранения списка заказов");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
