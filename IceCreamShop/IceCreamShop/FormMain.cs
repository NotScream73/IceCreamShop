using IceCreamShopBusinessLogic.BusinessLogics;
using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.DI;
using Microsoft.Extensions.Logging;

namespace IceCreamShopView
{
    public partial class FormMain : Form
    {
        private readonly ILogger _logger;
        private readonly IOrderLogic _orderLogic;
        private readonly IReportLogic _reportLogic;
        private readonly IWorkProcess _workProcessLogic;

        public FormMain(ILogger<FormMain> logger, IOrderLogic orderLogic, IReportLogic reportLogic, IWorkProcess workProcess)
        {
            InitializeComponent();
            _logger = logger;
            _orderLogic = orderLogic;
            _reportLogic = reportLogic;
            _workProcessLogic = workProcess;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dataGridView.FillAndConfigGrid(_orderLogic.ReadList(null));
                _logger.LogInformation("Загрузка заказов");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки заказов");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdditivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormAdditives>();
            form.ShowDialog();
        }

        private void IceCreamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormIceCreams>();
            form.ShowDialog();
        }

        private void ButtonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }

        private void ButtonTakeOrderInWork_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                _logger.LogInformation("Заказ №{id}. Меняется статус на 'В работе'", id);
                try
                {
                    var operationResult = _orderLogic.TakeOrderInWork(new OrderBindingModel
                    {
                        Id = id
                    });
                    if (!operationResult)
                    {
                        throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка передачи заказа в работу");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonOrderReady_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id =
               Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                _logger.LogInformation("Заказ №{id}. Меняется статус на 'Готов'", id);
                try
                {
                    var operationResult = _orderLogic.OrderReady(new OrderBindingModel
                    {
                        Id = id
                    });
                    if (!operationResult)
                    {
                        throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка отметки о готовности заказа");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonIssuedOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                _logger.LogInformation("Заказ №{id}. Меняется статус на 'Выдан'", id);
                try
                {
                    var operationResult = _orderLogic.IssuedOrder(new OrderBindingModel
                    {
                        Id = id
                    });
                    if (!operationResult)
                    {
                        throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                    }
                    _logger.LogInformation("Заказ №{id} выдан", id);
                    LoadData();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка отметки о выдачи заказа");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void IceCreamsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _reportLogic.SaveIceCreamsToWordFile(new ReportBindingModel { FileName = dialog.FileName });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void IceCreamAdditivesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormReportIceCreamAdditives>();
            form.ShowDialog();
        }

        private void OrdersReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormReportOrders>();
            form.ShowDialog();
        }

        private void ShopsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormShops>();
            form.ShowDialog();
        }

        private void ButtonAddIceCream_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormAddIceCream>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonSellIceCream_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormSellIceCream>();
            form.ShowDialog();
            LoadData();
        }

        private void ShopsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _reportLogic.SaveShopsToWordFile(new ReportBindingModel { FileName = dialog.FileName });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShopIceCreamsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormReportShopIceCreams>();
            form.ShowDialog();
        }

        private void GroupedOrdersReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormReportGroupedOrders>();
            form.ShowDialog();
        }

        private void ClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormClients>();
            form.ShowDialog();
        }

        private void ImplementersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormImplementers>();
            form.ShowDialog();
        }

        private void StartWorkingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _workProcessLogic.DoWork((DependencyManager.Instance.Resolve<IImplementerLogic>())!, _orderLogic);
            MessageBox.Show("Процесс обработки запущен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormMessages>();
            form.ShowDialog();
        }

        private void CreateBackUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DependencyManager.Instance.Resolve<IBackUpLogic>().CreateBackUp(new() { FolderName = dialog.SelectedPath });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}