namespace IceCreamShopContracts.DI
{
    public interface IBusinessLogicImplementationExtension
    {
        public int Priority { get; }
        /// <summary>
        /// Регистрация сервисов
        /// </summary>
        public void RegisterServices();
    }
}