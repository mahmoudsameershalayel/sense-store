using Sense.Application.AddressRepositories;
using Sense.Application.ApplicationUserRepositories;
using Sense.Application.Apstracts.InventoryRepositories;
using Sense.Application.AppointmentRepositories;
using Sense.Application.BannerRepositories;
using Sense.Application.BranchRepositories;
using Sense.Application.BrandRepositories;
using Sense.Application.CartItemRepositories;
using Sense.Application.CashbackOfferRepositories;
using Sense.Application.CashbackOfferUsageRepositories;
using Sense.Application.CategoryRepositories;
using Sense.Application.CenterSettingRepositories;
using Sense.Application.ChatMessageRepositories;
using Sense.Application.ChatSessionRepositories;
using Sense.Application.ConnectionRepositories;
using Sense.Application.ContactUsRepositories;
using Sense.Application.CouponRepositories;
using Sense.Application.CouponUsageRepositories;
using Sense.Application.CustomerActivityLogRepositories;
using Sense.Application.FreeMaintenanceEligibilityRepositoris;
using Sense.Application.FreeMaintenanceOfferRepositories;
using Sense.Application.InvoiceRepositories;
using Sense.Application.MaintenanceRecordRepositories;
using Sense.Application.ModelRepositories;
using Sense.Application.OrderDetailsRepositories;
using Sense.Application.OrderRepositories;
using Sense.Application.PhoneVerificationRepositories;
using Sense.Application.PointsTransactionRepositories;
using Sense.Application.ProductRepositories;
using Sense.Application.ServiceRepositories;
using Sense.Application.ShoppingCartRepositories;
using Sense.Application.StatementRepositories;
using Sense.Application.SupervisorActivityLogRepositories;
using Sense.Application.SupervisorRepositories;
using Sense.Application.TechSupportRepositories;
using Sense.Application.TransactionRepositories;
using Sense.Application.WalletRepositories;
using Sense.Domain;
using Sense.Domain.DBEntities;
using Microsoft.AspNetCore.Identity;


namespace Sense.Application
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly SenseDbContext _context;
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly Lazy<IApplicationUserRepository> _applicationUser;
        private readonly Lazy<IAppointmentRepository> _appointment;
        private readonly Lazy<IAddressRepository> _address;
        private readonly Lazy<IBranchRepository> _branch;
        private readonly Lazy<IBannerRepository> _banner;
        private readonly Lazy<IBrandRepository> _brand;
        private readonly Lazy<IModelRepository> _model;
        private readonly Lazy<ICategoryRepository> _category;
        private readonly Lazy<ICartItemRepository> _cartItem;
        private readonly Lazy<ICashbackOfferRepository> _cashbackOffer;
        private readonly Lazy<ICashbackOfferUsageRepository> _cashbackOfferUsage;
        private readonly Lazy<ICouponRepository> _couponRepository;
        private readonly Lazy<ICenterSettingRepository> _centerSetting;
        private readonly Lazy<IContactUsRepository> _contactUs;
        private readonly Lazy<IConnectionRepository> _connection;
        private readonly Lazy<IChatMessageRepository> _chatMessage;
        private readonly Lazy<IChatSessionRepository> _chatSession;
        private readonly Lazy<ICouponUsageRepository> _couponUsage;
        private readonly Lazy<IInvoiceRepository> _invoice;
        private readonly Lazy<IFreeMaintenanceOfferRepository> _freeMaintenanceOffer;
        private readonly Lazy<IFreeMaintenanceEligibilityRepository> _freeMaintenanceEligibility;
        private readonly Lazy<IMaintenanceRecordRepository> _maintenanceRecord;
        private readonly Lazy<IOrderRepository> _order;
        private readonly Lazy<IOrderDetailsRepository> _orderDetails;
        private readonly Lazy<IPointsTransactionRepository> _pointsTransaction;
        private readonly Lazy<IProductRepository> _product;
        private readonly Lazy<IProviderRepository> _provider;
        private readonly Lazy<IPhoneVerificationRepository> _phone;
        private readonly Lazy<ISupervisorRepository> _supervisor;
        private readonly Lazy<IStatementRepository> _statement;
		private readonly Lazy<IShoppingCartRepository> _shoppingCart;
		private readonly Lazy<IServiceRepository> _service;
		private readonly Lazy<ITransactionRepository> _transactionRepository;
		private readonly Lazy<IWalletRepository> _wallet;
		private readonly Lazy<IInventoryRepository> _inventory;
		private readonly Lazy<ITechSupportRepository> _techSupport;
		private readonly Lazy<ISupervisorActivityLogRepository> _supervisorActivityLog;
		private readonly Lazy<ICustomerActivityLogRepository> _customerActivityLog;
        public RepositoryManager(SenseDbContext context , UserManager<ApplicationUserTbl> userManager)
        {
            _context = context;
            _applicationUser = new Lazy<IApplicationUserRepository>(() => new ApplicationUserRepository(context , userManager));
            _appointment = new Lazy<IAppointmentRepository>(() => new AppointmentRepository(context));
            _address = new Lazy<IAddressRepository>(() => new AddressRepository(context));
            _branch = new Lazy<IBranchRepository>(() => new BranchRepository(context));
            _banner = new Lazy<IBannerRepository>(() => new BannerRepository(context));
            _brand = new Lazy<IBrandRepository>(() => new BrandRepository(context));
            _model = new Lazy<IModelRepository>(() => new ModelRepository(context));
            _category = new Lazy<ICategoryRepository>(() => new CategoryRepository(context));
			_cartItem = new Lazy<ICartItemRepository>(() => new CartItemRepository(context));
            _cashbackOffer = new Lazy<ICashbackOfferRepository>(() => new CashbackOfferRepository(context));
            _cashbackOfferUsage = new Lazy<ICashbackOfferUsageRepository>(() => new CashbackOfferUsageRepository(context));
            _couponRepository = new Lazy<ICouponRepository>(() => new CouponRepository(context));
            _contactUs = new Lazy<IContactUsRepository>(() => new ContactUsRepository(context));
            _centerSetting = new Lazy<ICenterSettingRepository>(() => new CenterSettingRepository(context));
            _connection = new Lazy<IConnectionRepository>(() => new ConnectionRepository(context));
            _chatMessage = new Lazy<IChatMessageRepository>(() => new ChatMessageRepository(context));
            _chatSession = new Lazy<IChatSessionRepository>(() => new ChatSessionRepository(context));
            _couponUsage = new Lazy<ICouponUsageRepository>(() => new CouponUsageRepository(context));
            _invoice = new Lazy<IInvoiceRepository>(() => new InvoiceRepository(context));
            _freeMaintenanceOffer = new Lazy<IFreeMaintenanceOfferRepository>(() => new FreeMaintenanceOfferRepository(context));
            _freeMaintenanceEligibility = new Lazy<IFreeMaintenanceEligibilityRepository>(() => new FreeMaintenanceEligibilityRepository(context));
            _maintenanceRecord = new Lazy<IMaintenanceRecordRepository>(() => new MaintenanceRecordRepository(context));
            _order = new Lazy<IOrderRepository>(() => new OrderRepository(context));
            _orderDetails = new Lazy<IOrderDetailsRepository>(() => new OrderDetailsRepository(context));
            _pointsTransaction = new Lazy<IPointsTransactionRepository>(() => new PointsTransactionRepository(context));
            _product = new Lazy<IProductRepository>(() => new ProductRepository(context));
            _provider = new Lazy<IProviderRepository>(() => new ProviderRepositories.ProviderRepository(context));
            _phone = new Lazy<IPhoneVerificationRepository>(() => new PhoneVerificationRepository(context));
            _supervisor = new Lazy<ISupervisorRepository>(() => new SupervisorRepository(context));
            _statement = new Lazy<IStatementRepository>(() => new StatementRepository(context));
			_shoppingCart = new Lazy<IShoppingCartRepository>(() => new ShoppingCartRepository(context));
			_service = new Lazy<IServiceRepository>(() => new ServiceRepository(context));
            _transactionRepository = new Lazy<ITransactionRepository>(() => new TransactionRepository(context));
            _wallet = new Lazy<IWalletRepository>(() => new WalletRepository(context));
            _inventory = new Lazy<IInventoryRepository>(() => new InventoryRepository(context));
            _techSupport = new Lazy<ITechSupportRepository>(() => new TechSupportRepository(context));
            _supervisorActivityLog = new Lazy<ISupervisorActivityLogRepository>(() => new SupervisorActivityLogRepository(context));
            _customerActivityLog = new Lazy<ICustomerActivityLogRepository>(() => new CustomerActivityLogRepository(context));
        }
        public IApplicationUserRepository ApplicationUser
            => _applicationUser.Value;

        public IAppointmentRepository Appointment
            => _appointment.Value;

        public IAddressRepository Address
          => _address.Value;

        public IBranchRepository Branch
            => _branch.Value;

        public IBannerRepository Banner
             => _banner.Value;

        public IBrandRepository Brand
            => _brand.Value;
        public IModelRepository Model 
           => _model.Value;

        public ICategoryRepository Category
           => _category.Value;

		public ICartItemRepository CartItem
		  => _cartItem.Value;

        public ICashbackOfferRepository CashbackOffer
          => _cashbackOffer.Value;

        public ICashbackOfferUsageRepository CashbackOfferUsage
           => _cashbackOfferUsage.Value;

        public ICouponRepository Coupon
          => _couponRepository.Value;

        public IStatementRepository Statement
          => _statement.Value;

        public ICouponUsageRepository CouponUsage
        => _couponUsage.Value;

        public IContactUsRepository ContactUs
         => _contactUs.Value;

        public IConnectionRepository Connection
        => _connection.Value;

        public IChatMessageRepository ChatMessage
            => _chatMessage.Value;

        public IChatSessionRepository ChatSession
           => _chatSession.Value;

        public IInvoiceRepository Invoice
           => _invoice.Value;
        public IFreeMaintenanceOfferRepository FreeMaintenanceOffer
           => _freeMaintenanceOffer.Value;
        public IFreeMaintenanceEligibilityRepository FreeMaintenanceEligibility
          => _freeMaintenanceEligibility.Value;
        public IMaintenanceRecordRepository MaintenanceRecord
           => _maintenanceRecord.Value;

        public IOrderRepository Order
          => _order.Value;

        public IOrderDetailsRepository OrderDetails
          => _orderDetails.Value;

        public IPointsTransactionRepository PointsTransaction
          => _pointsTransaction.Value;

        public IProductRepository Product
           => _product.Value;

        public IProviderRepository Provider
           => _provider.Value;

        public IPhoneVerificationRepository PhoneVerification
          => _phone.Value;

        public ISupervisorRepository Supervisor
           => _supervisor.Value;

		public IShoppingCartRepository ShoppingCart
		  => _shoppingCart.Value;

		public IServiceRepository Service
		  => _service.Value;
        public ITransactionRepository Transaction
          => _transactionRepository.Value;

        public IWalletRepository Wallet
          => _wallet.Value;

        public IInventoryRepository Inventory
         => _inventory.Value;
        public ITechSupportRepository TechSupport
        => _techSupport.Value;

        public ICenterSettingRepository CenterSetting
            => _centerSetting.Value;

        public ISupervisorActivityLogRepository SupervisorActivity
            => _supervisorActivityLog.Value;

        public ICustomerActivityLogRepository CustomerActivity
            => _customerActivityLog.Value;

        public Task<int> SaveAsync()
            => _context.SaveChangesAsync();
    }
}
