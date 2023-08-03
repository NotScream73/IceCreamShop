using IceCreamShopBusinessLogic.MailWorker;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDatabaseImplement.Models;
using IceCreamShopDataModels.Models;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace IceCreamShopView
{
    public partial class FormMessageAnswer : Form
    {
        private readonly ILogger _logger;
        private readonly AbstractMailWorker _mailWorker;
        private readonly IMessageInfoLogic _logic;
        private MessageInfoViewModel message;

        public string MessageId { get; set; } = string.Empty;

        public FormMessageAnswer(ILogger<FormMessageAnswer> logger, AbstractMailWorker mailWorker, IMessageInfoLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _mailWorker = mailWorker;
            _logic = logic;
        }

        private void FormMessageAnswer_Load(object sender, EventArgs e)
        {
            try
            {
                _logger.LogInformation("Загрузка сообщения");
                message = _logic.ReadElement(new() { MessageId = MessageId });
                if (message != null)
                {
                    textBoxSubject.Text = message.Subject;
                    textBoxText.Text = message.Body;
                    if (!message.HasRead)
                    {
                        _logic.Update(new()
                        {
                            MessageId = MessageId,
                            HasRead = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки собщения");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAnswer.Text))
            {
                MessageBox.Show("Заполните ответ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _mailWorker.MailSendAsync(new()
            {
                MailAddress = message.SenderName,
                Subject = message.Subject,
                Text = textBoxAnswer.Text,
            });
            _logic.Update(new()
            {
                MessageId = MessageId,
                Answer = textBoxAnswer.Text,
                HasRead = true,
            });
            MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
