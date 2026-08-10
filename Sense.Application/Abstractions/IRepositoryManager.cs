namespace Sense.Application.Abstractions
{
    public interface IRepositoryManager
    {
        IApplicationUserRepository ApplicationUser { get; }
        IAppointmentRepository Appointment { get; }
        IAddressRepository Address { get; }
        IBranchRepository Branch { get; }
        IBannerRepository Banner { get; }
        IBrandRepository Brand { get; }
        IModelRepository Model { get; }
        ICategoryRepository Category { get; }
		ICartItemRepository CartItem { get; }
        ICashbackOfferRepository CashbackOffer { get; }
        ICashbackOfferUsageRepository CashbackOfferUsage { get; }
        ICouponRepository Coupon { get; }
        ICenterSettingRepository CenterSetting { get; }
        IConnectionRepository Connection { get; }
        IContactUsRepository ContactUs { get; }
        IChatMessageRepository ChatMessage { get; }
        IChatSessionRepository ChatSession { get; }
        ICouponUsageRepository CouponUsage { get; }
        IInvoiceRepository Invoice { get; }
        IFreeMaintenanceOfferRepository FreeMaintenanceOffer { get; }
        IFreeMaintenanceEligibilityRepository FreeMaintenanceEligibility { get; }
        IMaintenanceRecordRepository MaintenanceRecord { get; }
        IOrderRepository Order { get; }
        IOrderDetailsRepository OrderDetails { get; }
        IPointsTransactionRepository PointsTransaction { get; }
        IProductRepository Product { get; }
        IProviderRepository Provider { get; }
        IServiceListingRepository ServiceListing { get; }
        IServiceProviderRepository ServiceProvider { get; }
        IPartnerInquiryRepository PartnerInquiry { get; }
        IPhoneVerificationRepository PhoneVerification { get; }
        ISupervisorRepository Supervisor { get; }
        IStatementRepository Statement { get; }
		IShoppingCartRepository ShoppingCart { get; }
		IServiceRepository Service { get; }
        ITransactionRepository Transaction { get; }
		IWalletRepository Wallet { get; }
		IInventoryRepository Inventory { get; }
        ITechSupportRepository TechSupport { get; }
        ISupervisorActivityLogRepository SupervisorActivity { get; }
        ICustomerActivityLogRepository CustomerActivity { get; }
        Task<int> SaveAsync();
    }
}
