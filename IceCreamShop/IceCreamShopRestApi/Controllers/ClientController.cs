using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IceCreamShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly ILogger _logger;

        private readonly IClientLogic _logic;

        private readonly IMessageInfoLogic _mailLogic;

        public ClientController(IClientLogic logic, ILogger<ClientController> logger, IMessageInfoLogic mailLogic)
        {
            _logger = logger;
            _logic = logic;
            _mailLogic = mailLogic;
        }

        [HttpGet]
        public ClientViewModel? Login(string login, string password)
        {
            try
            {
                return _logic.ReadElement(new ClientSearchModel
                {
                    Email = login,
                    Password = password
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка входа в систему");
                throw;
            }
        }

        [HttpPost]
        public void Register(ClientBindingModel model)
        {
            try
            {
                _logic.Create(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка регистрации");
                throw;
            }
        }

        [HttpPost]
        public void UpdateData(ClientBindingModel model)
        {
            try
            {
                _logic.Update(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка обновления данных");
                throw;
            }
        }

        [HttpGet]
        public List<MessageInfoViewModel>? GetMessages(int clientId, int currentPage)
        {
            try
            {
                if(currentPage == 0)
                {
                    return _mailLogic.ReadList(new MessageInfoSearchModel
                    {
                        ClientId = clientId
                    });
                }
                return _mailLogic.ReadList(new MessageInfoSearchModel
                {
                    ClientId = clientId,
                    CurrentPage = currentPage,
                    PageSize = 2
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения писем клиента");
                throw;
            }
        }
    }
}
