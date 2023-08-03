using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;

namespace IceCreamShopView
{
    public partial class FormIceCreamAdditive : Form
    {
        private readonly List<AdditiveViewModel>? _list;
        public int Id
        {
            get
            {
                return Convert.ToInt32(comboBoxAdditive.SelectedValue);
            }
            set
            {
                comboBoxAdditive.SelectedValue = value;
            }
        }
        public IAdditiveModel? AdditiveModel
        {
            get
            {
                if (_list == null)
                {
                    return null;
                }
                foreach (var elem in _list)
                {
                    if (elem.Id == Id)
                    {
                        return elem;
                    }
                }
                return null;
            }
        }
        public int Count
        {
            get
            {
                return Convert.ToInt32(textBoxCount.Text);
            }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }

        public FormIceCreamAdditive(IAdditiveLogic logic)
        {
            InitializeComponent();
            _list = logic.ReadList(null);
            if (_list != null)
            {
                comboBoxAdditive.DisplayMember = "AdditiveName";
                comboBoxAdditive.ValueMember = "Id";
                comboBoxAdditive.DataSource = _list;
                comboBoxAdditive.SelectedItem = null;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxAdditive.SelectedValue == null)
            {
                MessageBox.Show("Выберите добавку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}