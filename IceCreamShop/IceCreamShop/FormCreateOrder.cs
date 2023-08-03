using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.SearchModels;
using Microsoft.Extensions.Logging;

namespace IceCreamShopView
{
	public partial class FormCreateOrder : Form
	{
		private readonly ILogger _logger;
		private readonly IIceCreamLogic _logicI;
		private readonly IOrderLogic _logicO;
		private readonly IClientLogic _logicC;

		public FormCreateOrder(ILogger<FormCreateOrder> logger, IIceCreamLogic logicI, IOrderLogic logicO, IClientLogic logicC)
		{
			InitializeComponent();
			_logger = logger;
			_logicI = logicI;
			_logicO = logicO;
			_logicC = logicC;
		}

		private void FormCreateOrder_Load(object sender, EventArgs e)
		{
			_logger.LogInformation("Загрузка списка мороженого для заказа");
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
			_logger.LogInformation("Загрузка списка клиентов для заказа");
			try
			{
				var list = _logicC.ReadList(null);
				if (list != null)
				{
					comboBoxClient.DisplayMember = "ClientFIO";
					comboBoxClient.ValueMember = "Id";
					comboBoxClient.DataSource = list;
					comboBoxClient.SelectedItem = null;
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки списка клиентов");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void CalcSum()
		{
			if (comboBoxIceCream.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
			{
				try
				{
					int id = Convert.ToInt32(comboBoxIceCream.SelectedValue);
					var iceCream = _logicI.ReadElement(new IceCreamSearchModel
					{
						Id = id
					});
					int count = Convert.ToInt32(textBoxCount.Text);
					textBoxSum.Text = Math.Round(count * (iceCream?.Price ?? 0), 2).ToString();
					_logger.LogInformation("Расчет суммы заказа");
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Ошибка расчета суммы заказа");
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void TextBoxCount_TextChanged(object sender, EventArgs e)
		{
			CalcSum();
		}

		private void ComboBoxIceCream_SelectedIndexChanged(object sender, EventArgs e)
		{
			CalcSum();
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
			if (comboBoxClient.SelectedValue == null)
			{
				MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			_logger.LogInformation("Создание заказа");
			try
			{
				var operationResult = _logicO.CreateOrder(new OrderBindingModel
				{
					IceCreamId = Convert.ToInt32(comboBoxIceCream.SelectedValue),
					ClientId = Convert.ToInt32(comboBoxClient.SelectedValue),
					Count = Convert.ToInt32(textBoxCount.Text),
					Sum = Convert.ToDouble(textBoxSum.Text)
				});
				if (!operationResult)
				{
					throw new Exception("Ошибка при создании заказа. Дополнительная информация в логах.");
				}
				MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка создания заказа");
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