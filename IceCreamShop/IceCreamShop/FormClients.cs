using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using Microsoft.Extensions.Logging;

namespace IceCreamShopView
{
    public partial class FormClients : Form
    {
        private readonly ILogger _logger;

        private readonly IClientLogic _logic;

        public FormClients(ILogger<FormClients> logger, IClientLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }

        private void FormClients_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dataGridView.FillAndConfigGrid(_logic.ReadList(null));
                _logger.LogInformation("Загрузка клиентов");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки клиентов");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                    try
                    {
                        if (!_logic.Delete(new ClientBindingModel { Id = id }))
                        {
                            throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
                        }
                        _logger.LogInformation("Удаление клиента");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Ошибка удаления клиента");
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
