using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.SearchModels;
using Microsoft.Extensions.Logging;

namespace IceCreamShopView
{
    public partial class FormImplementer : Form
    {
        private readonly ILogger _logger;
        private readonly IImplementerLogic _logic;
        private int? _id;
        public int Id { set { _id = value; } }

        public FormImplementer(ILogger<FormImplementer> logger, IImplementerLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }

        private void FormImplementer_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                try
                {
                    _logger.LogInformation("Получение исполнителя");
                    var view = _logic.ReadElement(new ImplementerSearchModel
                    {
                        Id = _id.Value
                    });
                    if (view != null)
                    {
                        textBoxName.Text = view.ImplementerFIO;

                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка получения исполнителя");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxQualification.Text))
            {
                MessageBox.Show("Заполните квалификацию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxWorkExperience.Text))
            {
                MessageBox.Show("Заполните опыт работы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Сохранение ");
            try
            {
                var model = new ImplementerBindingModel
                {
                    Id = _id ?? 0,
                    ImplementerFIO = textBoxName.Text,
                    Password = textBoxPassword.Text,
                    Qualification = int.Parse(textBoxQualification.Text),
                    WorkExperience = int.Parse(textBoxWorkExperience.Text)

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
                _logger.LogError(ex, "Ошибка сохранения добавки");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}