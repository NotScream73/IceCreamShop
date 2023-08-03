using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.SearchModels;
using Microsoft.Extensions.Logging;

namespace IceCreamShopView
{
    public partial class FormSellIceCream : Form
    {
        private readonly ILogger _logger;
        private readonly IIceCreamLogic _logicI;
        private readonly IShopLogic _logicS;

        public FormSellIceCream(ILogger<FormAddIceCream> logger, IIceCreamLogic logicI, IShopLogic logicS)
        {
            InitializeComponent();
            _logger = logger;
            _logicI = logicI;
            _logicS = logicS;
        }

        private void FormSellIceCream_Load(object sender, EventArgs e)
        {
            _logger.LogInformation("Загрузка списка мороженого для продажи");
            try
            {
                var list = _logicI.ReadList(null);
                if (list != null)
                {
                    comboBoxIceCream.DisplayMember = "IceCreamName";
                    comboBoxIceCream.ValueMember = "Id";
                    comboBoxIceCream.DataSource = list;
                    comboBoxIceCream.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки списка мороженого");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxIceCream.SelectedValue == null)
            {
                MessageBox.Show("Выберите мороженое", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Продажа мороженого");
            try
            {
                var operationResult = _logicS.SellIceCreams(_logicI.ReadElement(new IceCreamSearchModel()
                {
                    Id = Convert.ToInt32(comboBoxIceCream.SelectedValue)
                })!, Convert.ToInt32(textBoxCount.Text));
                if (!operationResult)
                {
                    throw new Exception("Ошибка при продаже мороженого. Дополнительная информация в логах.");
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка продажи мороженого");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
