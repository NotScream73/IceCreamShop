using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.DI;
using IceCreamShopContracts.SearchModels;
using IceCreamShopDataModels.Models;
using Microsoft.Extensions.Logging;


namespace IceCreamShopView
{
    public partial class FormIceCream : Form
    {
        private readonly ILogger _logger;
        private readonly IIceCreamLogic _logic;
        private int? _id;
        private Dictionary<int, (IAdditiveModel, int)> _iceCreamAdditives;
        public int Id { set { _id = value; } }

        public FormIceCream(ILogger<FormIceCream> logger, IIceCreamLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
            _iceCreamAdditives = new Dictionary<int, (IAdditiveModel, int)>();
        }

        private void FormIceCream_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                _logger.LogInformation("Загрузка мороженого");
                try
                {
                    var view = _logic.ReadElement(new IceCreamSearchModel
                    {
                        Id = _id.Value
                    });
                    if (view != null)
                    {
                        textBoxName.Text = view.IceCreamName;
                        textBoxPrice.Text = view.Price.ToString();
                        _iceCreamAdditives = view.IceCreamAdditives ?? new Dictionary<int, (IAdditiveModel, int)>();
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка загрузки мороженого");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadData()
        {
            _logger.LogInformation("Загрузка добавок мороженого");
            try
            {
                if (_iceCreamAdditives != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var element in _iceCreamAdditives)
                    {
                        dataGridView.Rows.Add(new object[] { element.Key, element.Value.Item1.AdditiveName, element.Value.Item2 });
                    }
                    textBoxPrice.Text = CalcPrice().ToString();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки добавок мороженого");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormIceCreamAdditive>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.AdditiveModel == null)
                {
                    return;
                }
                _logger.LogInformation("Добавление новой добавки: {AdditiveName} - {Count}", form.AdditiveModel.AdditiveName, form.Count);
                if (_iceCreamAdditives.ContainsKey(form.Id))
                {
                    _iceCreamAdditives[form.Id] = (form.AdditiveModel, form.Count);
                }
                else
                {
                    _iceCreamAdditives.Add(form.Id, (form.AdditiveModel, form.Count));
                }
                LoadData();
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = DependencyManager.Instance.Resolve<FormIceCreamAdditive>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = _iceCreamAdditives[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.AdditiveModel == null)
                    {
                        return;
                    }
                    _logger.LogInformation("Изменение добавки: {AdditiveName} - {Count}", form.AdditiveModel.AdditiveName, form.Count);
                    _iceCreamAdditives[form.Id] = (form.AdditiveModel, form.Count);
                    LoadData();
                }
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _logger.LogInformation("Удаление добавки:{AdditiveName} - {Count}", dataGridView.SelectedRows[0].Cells[1].Value);
                        _iceCreamAdditives?.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
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

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_iceCreamAdditives == null || _iceCreamAdditives.Count == 0)
            {
                MessageBox.Show("Заполните добавки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Сохранение мороженого");
            try
            {
                var model = new IceCreamBindingModel
                {
                    Id = _id ?? 0,
                    IceCreamName = textBoxName.Text,
                    Price = Convert.ToDouble(textBoxPrice.Text),
                    IceCreamAdditives = _iceCreamAdditives
                };
                var operationResult = _id.HasValue ? _logic.Update(model) : _logic.Create(model);
                if (!operationResult)
                {
                    throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка сохранения мороженого");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private double CalcPrice()
        {
            double price = 0;
            foreach (var elem in _iceCreamAdditives)
            {
                price += (elem.Value.Item1?.Cost ?? 0) * elem.Value.Item2;
            }
            return Math.Round(price * 1.1, 2);
        }
    }
}