using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.DI;
using Microsoft.Extensions.Logging;

namespace IceCreamShopView
{
    public partial class FormMessages : Form
    {
        private readonly ILogger _logger;
        private readonly IMessageInfoLogic _logic;
        private int currentPage = 1;
        private int pageSize = 2;
        private int maxPages;
        public FormMessages(ILogger<FormIceCreams> logger, IMessageInfoLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }

        private void FormMessages_Load(object sender, EventArgs e)
        {
            maxPages = (int)Math.Ceiling(_logic.ReadList(null).Count / (double)pageSize);
            LoadData();
        }

        private bool LoadData()
        {
            try
            {
                var list = _logic.ReadList(new()
                {
                    PageSize = pageSize,
                    CurrentPage = currentPage
                }
                );
                dataGridView.FillAndConfigGrid(_logic.ReadList(null));
                labelPage.Text = currentPage + " страница";
                _logger.LogInformation("Загрузка сообщений");
                ValidateButtons();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки сообщений");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            currentPage--;
            LoadData();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadData();
        }
        private void ValidateButtons()
        {
            buttonNext.Enabled = true;
            buttonPrevious.Enabled = true;
            if (maxPages <= 0)
            {
                buttonNext.Enabled = false;
                buttonPrevious.Enabled = false;
            }
            if (currentPage == maxPages)
            {
                buttonNext.Enabled = false;
            }
            if (currentPage == 1)
            {
                buttonPrevious.Enabled = false;
            }
        }

        private void ButtonAnswer_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = DependencyManager.Instance.Resolve<FormMessageAnswer>();
                form.MessageId = Convert.ToString(dataGridView.SelectedRows[0].Cells["MessageId"].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
    }
}
