using IceCreamShopContracts.Attributes;
using IceCreamShopDataModels.Models;

namespace IceCreamShopContracts.ViewModels
{
    public class MessageInfoViewModel : IMessageInfoModel
    {
        [Column(visible: false)]
        public string MessageId { get; set; } = string.Empty;

        [Column(visible: false)]
        public int? ClientId { get; set; }

        [Column(title: "Отправитель", width: 150)]
        public string SenderName { get; set; } = string.Empty;

        [Column(title: "Дата письма", width: 150, style: "d")]
        public DateTime DateDelivery { get; set; }

        [Column(title: "Заголовок", width: 150)]
        public string Subject { get; set; } = string.Empty;

        [Column(title: "Текст", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string Body { get; set; } = string.Empty;

        [Column(title: "Прочитано", width: 25)]
        public bool HasRead { get; set; }

        [Column(title: "Ответ", width: 100)]
        public string? Answer { get; set; }

        [Column(visible: false)]
        public int Id => throw new NotImplementedException();
    }
}