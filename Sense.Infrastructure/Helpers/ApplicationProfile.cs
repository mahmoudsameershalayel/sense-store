using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DTOs.AddressDTOs;
using Sense.Application.DTOs.AppointmentDTOs;
using Sense.Application.DTOs.AuthDTOs;
using Sense.Application.DTOs.BannerDTOs;
using Sense.Application.DTOs.BranchDTOs;
using Sense.Application.DTOs.BrandDTOs;
using Sense.Application.DTOs.CashbackOfferUsageDTOs;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.CenterSettingDTOs;
using Sense.Application.DTOs.CouponDTOs;
using Sense.Application.DTOs.CustomerDTOs;
using Sense.Application.DTOs.FreeMaintenanceEligibilityDTOs;
using Sense.Application.DTOs.FreeMaintenanceOfferDTOs;
using Sense.Application.DTOs.InventoryDTOs;
using Sense.Application.DTOs.InvoiceDTOs;
using Sense.Application.DTOs.MaintenanceRecordDTOs;
using Sense.Application.DTOs.ModelDTOs;
using Sense.Application.DTOs.OfferCashbackDTOs;
using Sense.Application.DTOs.OrderDTOs;
using Sense.Application.DTOs.PointsDTOs;
using Sense.Application.DTOs.ProductDTOs;
using Sense.Application.DTOs.ProviderDTOs;
using Sense.Application.DTOs.ServiceDTOs;
using Sense.Application.DTOs.ShoppingCartDTOs;
using Sense.Application.DTOs.StatementDTOs;
using Sense.Application.DTOs.SupervisorDTOs;
using Sense.Application.DTOs.TechSupportDTOs;
using Sense.Application.DTOs.TransactionDTOs;
using Sense.Application.DTOs.WalletDTOs;
using Sense.Infrastructure.Extensions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Infrastructure.Helpers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            //Application User
            CreateMap<ApplicationUserTbl, UserForRegisterDto>().ReverseMap();
            CreateMap<ApplicationUserTbl, UserDto>().ForMember(x => x.FullName, opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}")).ReverseMap();

            //Customer
            CreateMap<CustomerTbl, CustomerDto>().ForMember(x => x.FullName, opt => opt.MapFrom(x => $"{x.ApplicationUser.FirstName} {x.ApplicationUser.LastName}"))
                                                 .ForMember(x => x.FullName, opt => opt.MapFrom(x =>  $"{x.ApplicationUser.FirstName} {x.ApplicationUser.LastName}"))
                                                 .ForMember(x => x.IsActive, opt => opt.MapFrom(x => x.ApplicationUser.IsActive))
                                                 .ForMember(x => x.Email, opt => opt.MapFrom(x => x.ApplicationUser.Email))
                                                 .ForMember(x => x.Username, opt => opt.MapFrom(x => x.ApplicationUser.UserName))
                                                 .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.ApplicationUser.PhoneNumber))
                                                 .ForMember(x => x.FCMToken, opt => opt.MapFrom(x => x.ApplicationUser.FCMToken)).ReverseMap();


            //Appointment
            CreateMap<AppointmentTbl, AppointmentForCreateDto>().ReverseMap();
            CreateMap<AppointmentTbl, AppointmentDto>().ForMember(x => x.ScheduledDate, opt => opt.MapFrom(x => x.ScheduledDate.Value.ToString("yyyy-MM-dd")))
                                                       .ForMember(x => x.ScheduledTime, opt => opt.MapFrom(x => x.ScheduledDate.Value.ToString("HH:mm tt")))
                                                       .ForMember(x => x.CreatedAtDate, opt => opt.MapFrom(x => x.CreatedAt.Value.ToString("yyyy-MM-dd")))
                                                       .ReverseMap();

            //Appointment
            CreateMap<AddressTbl, AddressDto>().ReverseMap();
            CreateMap<AddressTbl, AddressForCreateDto>().ReverseMap();
            CreateMap<AddressTbl, AddressForUpdateDto>().ReverseMap();

            //Branch
            CreateMap<BranchTbl, BranchDto>().ReverseMap();
            CreateMap<BranchTbl, BranchForCreateUpdateDto>().ReverseMap();

            //Banner
            CreateMap<BannerTbl, BannerDto>().ReverseMap();
            CreateMap<BannerTbl, BannerForCreateUpdateDto>().ReverseMap();

            //Brand
            CreateMap<BrandTbl, BrandDto>().ReverseMap();
            CreateMap<BrandTbl, BrandForCreateUpdateDto>().ReverseMap();
         

            //Category
            CreateMap<CategoryTbl, CategoryDto>().ReverseMap();
            CreateMap<CategoryTbl, CategoryForCreateUpdateDto>().ReverseMap();

            //Cart Item
            CreateMap<CartItemTbl, CartItemDto>().ReverseMap();
            CreateMap<CartItemTbl, CartItemForUpdateDto>().ReverseMap();
            CreateMap<CartItemTbl, CartItemForCreateDto>().ReverseMap();

            //Cart Item
            CreateMap<CenterSettingTbl, CenterSettingDto>().ReverseMap();
            CreateMap<CenterSettingTbl, CenterSettingForUpdateDto>().ReverseMap();

            //Customer
            CreateMap<CustomerTbl, CustomerDto>().ForMember(x => x.FullName, opt => opt.MapFrom(x => $"{x.ApplicationUser.FirstName} {x.ApplicationUser.LastName}"))
                                                 .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.ApplicationUser.Id))
                                                 .ForMember(x => x.IsActive, opt => opt.MapFrom(x => x.ApplicationUser.IsActive))
                                                 .ForMember(x => x.Email, opt => opt.MapFrom(x => x.ApplicationUser.Email))
                                                 .ForMember(x => x.Username, opt => opt.MapFrom(x => x.ApplicationUser.UserName))
                                                 .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.ApplicationUser.PhoneNumber))
                                                 .ForMember(x => x.ImageURL, opt => opt.MapFrom(x => x.ApplicationUser.ImageURL))
                                                 .ForMember(x => x.FCMToken, opt => opt.MapFrom(x => x.ApplicationUser.FCMToken)).ReverseMap();

            CreateMap<CustomerTbl, UserDto>().ForMember(x => x.FullName, opt => opt.MapFrom(x => $"{x.ApplicationUser.FirstName} {x.ApplicationUser.LastName}"))
                                                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.ApplicationUser.Id))
                                                .ForMember(x => x.IsActive, opt => opt.MapFrom(x => x.ApplicationUser.IsActive))
                                                .ForMember(x => x.UserType, opt => opt.MapFrom(x => x.ApplicationUser.UserType.ToString()))
                                                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.ApplicationUser.Email))
                                                .ForMember(x => x.Username, opt => opt.MapFrom(x => x.ApplicationUser.UserName))
                                                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.ApplicationUser.PhoneNumber))
                                                .ForMember(x => x.ImageURL, opt => opt.MapFrom(x => x.ApplicationUser.ImageURL))
                                                .ForMember(x => x.FCMToken, opt => opt.MapFrom(x => x.ApplicationUser.FCMToken)).ReverseMap();

            //Cashback Offer
            CreateMap<CashbackOfferTbl, CashbackOfferDto>()
                .ForMember(x => x.StartDate, opt => opt.MapFrom(x => x.StartDate.HasValue ? x.StartDate.Value.ToString("yyyy-MM-dd") : null))
                .ForMember(x => x.EndDate, opt => opt.MapFrom(x => x.EndDate.HasValue ? x.EndDate.Value.ToString("yyyy-MM-dd") : null))
                .ReverseMap();
            CreateMap<CashbackOfferTbl, CashbackOfferForCreateDto>().ReverseMap();
            CreateMap<CashbackOfferTbl, CashbackOfferForUpdateDto>().ReverseMap();

            //Cashback Offer Usage
            CreateMap<CashbackOfferUsageTbl, CashbackOfferUsageDto>()
                .ForMember(dest => dest.DateUsed, opt => opt.MapFrom(src => src.CreatedAt.Value.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.TimeUsed, opt => opt.MapFrom(src => src.CreatedAt.Value.ToString("HH:mm tt")))
                .ReverseMap();
            CreateMap<CashbackOfferUsageTbl, CashbackOfferUsageForCreateDto>().ReverseMap();

            //Coupon
            CreateMap<CouponTbl, CouponDto>().ForMember(x => x.StartDate, opt => opt.MapFrom(x => x.StartDate.ToString("yyyy-MM-dd")))
                                             .ForMember(x => x.EndDate, opt => opt.MapFrom(x => x.EndDate.ToString("yyyy-MM-dd")))
                                             .ReverseMap();
            CreateMap<CouponTbl, CouponForCreateDto>().ReverseMap();

            //Statement
            CreateMap<StatementTbl, StatementDto>().ReverseMap();
            CreateMap<StatementTbl, StatementForCreateDto>().ReverseMap();
            CreateMap<StatementTbl, StatementForUpdateDto>().ReverseMap();
            CreateMap<CouponTbl, CouponForUpdateDto>().ReverseMap();

            //Free Maintenance Offer
            CreateMap<FreeMaintenanceOfferTbl, FreeMaintenanceOfferDto>().ReverseMap();
            CreateMap<FreeMaintenanceOfferTbl, FreeMaintenanceOfferForCreateDto>().ReverseMap();

            //Free Maintenance Offer
            CreateMap<FreeMaintenanceEligibilityTbl, FreeMaintenanceEligibilityDto>()
                .ForMember(dest => dest.ActivatedAtDate, opt => opt.MapFrom(src => src.ActivatedAt.HasValue ? src.ActivatedAt.Value.ToString("yyyy-MM-dd") : null))
                .ForMember(dest => dest.ActivatedAtTime, opt => opt.MapFrom(src => src.ActivatedAt.HasValue ? src.ActivatedAt.Value.ToString("HH:mm tt") : null))
                .ForMember(dest => dest.ExpiresAtDate, opt => opt.MapFrom(src => src.ExpiresAt.HasValue ? src.ExpiresAt.Value.ToString("yyyy-MM-dd") : null))
                .ForMember(dest => dest.ExpiresAtTime, opt => opt.MapFrom(src => src.ExpiresAt.HasValue ? src.ExpiresAt.Value.ToString("HH:mm tt") : null))
                .ReverseMap();
            CreateMap<FreeMaintenanceEligibilityTbl, FreeMaintenanceEligibilityForCreateDto>().ReverseMap();


            //Invoice
            CreateMap<InvoiceTbl, InvoiceDto>().ForMember(dest => dest.CreatedAtDate, opt => opt.MapFrom(src => src.CreatedAt.Value.ToString("yyyy-MM-dd")))  // DateTime? to string
                                               .ForMember(dest => dest.CreatedAtTime, opt => opt.MapFrom(src => src.CreatedAt.Value.ToString("HH:mm tt")))
                                               .ReverseMap();
            CreateMap<InvoiceTbl, InvoiceForCreateDto>().ReverseMap();
            CreateMap<InvoiceTbl, InvoiceForUpdateDto>().ReverseMap();


            //Maintenance Record
            CreateMap<MaintenanceRecordTbl, MaintenanceRecordDetailDto>()
                      .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.Value.ToString("yyyy-MM-dd")))  // DateTime? to string
                      .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartDate.Value.ToString("HH:mm tt")))  // Custom time format
                      .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.Value.ToString("yyyy-MM-dd")))
                      .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndDate.Value.ToString("HH:mm tt")))
                      .ForMember(dest => dest.Invoices, opt => opt.MapFrom(src => src.Invoices))
                      .ForMember(dest => dest.Appointment, opt => opt.MapFrom(src => src.Appointment))
                      .ReverseMap();

            CreateMap<MaintenanceRecordTbl, MaintenanceRecordDto>().ForMember(x => x.StartDate, opt => opt.MapFrom(x => x.StartDate.Value.ToString("yyyy-MM-dd")))
                                                                   .ForMember(x => x.StartTime, opt => opt.MapFrom(x => x.StartDate.Value.ToString("HH:mm tt")))
                                                                   .ForMember(x => x.EndDate, opt => opt.MapFrom(x => x.EndDate.Value.ToString("yyyy-MM-dd")))
                                                                   .ForMember(x => x.EndTime, opt => opt.MapFrom(x => x.EndDate.Value.ToString("HH:mm tt")))
                                                                   .ForMember(x => x.CustomerName, opt => opt.MapFrom(x => $"{x.Appointment.Customer.ApplicationUser.FirstName} {x.Appointment.Customer.ApplicationUser.LastName}"))
                                                                   .ForMember(x => x.CustomerId, opt => opt.MapFrom(x => x.Appointment.Customer.Id))
                                                                   .ForMember(x => x.SupervisorName, opt => opt.MapFrom(x => $"{x.Supervisor.ApplicationUser.FirstName} {x.Supervisor.ApplicationUser.LastName}"))
                                                                   .ReverseMap();
            CreateMap<MaintenanceRecordTbl, MaintenanceRecordForCreateDto>().ReverseMap();
            CreateMap<MaintenanceRecordTbl, MaintenanceRecordForUpdateDto>().ReverseMap();


            //Model 
            CreateMap<ModelTbl, ModelDto>().ReverseMap();
            CreateMap<ModelTbl, ModelForCreateUpdateDto>().ReverseMap();


            //Order
            CreateMap<OrderTbl, OrderDto>().ForMember(x => x.OrderDate, opt => opt.MapFrom(x => x.OrderDate.Value.ToString("yyyy-MM-dd")))
                                           .ForMember(x => x.OrderTime, opt => opt.MapFrom(x => x.OrderDate.Value.ToString("HH:mm tt")))
                                           .ForMember(x => x.OrderStatus, opt => opt.MapFrom(x => EnumExtensions.GetDisplayName(x.OrderStatus)))
                                           .ForMember(x => x.PaymentMethod, opt => opt.MapFrom(x => EnumExtensions.GetDisplayName(x.PaymentMethod)))
                                           .ForMember(x => x.PaymentStatus, opt => opt.MapFrom(x => EnumExtensions.GetDisplayName(x.PaymentStatus)))
                                           .ReverseMap();
            CreateMap<OrderTbl, OrderForCreateDto>().ReverseMap();

            //Order Details
            CreateMap<OrderDetailsTbl, OrderDetailsDto>().ForMember(x => x.Address , opt => opt.MapFrom(x => x.Order.Address)).ReverseMap();

            //Points Transaction
            CreateMap<PointsTransactionTbl, PointsTransactionDto>().ReverseMap();

            //Product
            CreateMap<ProductTbl, ProductDto>().ForMember(x => x.ProviderName, opt => opt.MapFrom(x => x.Provider != null ? x.Provider.DisplayName : null))
                                               .ReverseMap()
                                               .ForMember(x => x.Provider, opt => opt.Ignore());
            CreateMap<ProductTbl, ProductForCreateUpdateDto>().ReverseMap();

            //Provider
            CreateMap<ProviderTbl, ProviderDto>().ForMember(x => x.Email, opt => opt.MapFrom(x => x.ApplicationUser != null ? x.ApplicationUser.Email : null))
                                                 .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.ApplicationUserId))
                                                 .ForMember(x => x.LogoURL, opt => opt.MapFrom(x => x.LogoURL ?? (x.ApplicationUser != null ? x.ApplicationUser.ImageURL : null)))
                                                 .ReverseMap();

            //Service
            CreateMap<ServiceTbl, ServiceDto>().ReverseMap();
            CreateMap<ServiceTbl, ServiceForCreateUpdateDto>().ReverseMap();


            //Supervisor
            CreateMap<SupervisorTbl, UserDto>().ReverseMap();
            CreateMap<SupervisorTbl, SupervisorDto>().ForMember(x => x.FullName, opt => opt.MapFrom(x => $"{x.ApplicationUser.FirstName} {x.ApplicationUser.LastName}"))
                                                     .ForMember(x => x.IsActive, opt => opt.MapFrom(x => x.ApplicationUser.IsActive))
                                                     .ForMember(x => x.Email, opt => opt.MapFrom(x => x.ApplicationUser.Email))
                                                     .ForMember(x => x.Username, opt => opt.MapFrom(x => x.ApplicationUser.UserName))
                                                     .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.ApplicationUser.PhoneNumber))
                                                     .ForMember(x => x.FCMToken, opt => opt.MapFrom(x => x.ApplicationUser.FCMToken)).ReverseMap();


            //Wallet
            CreateMap<WalletTbl, WalletDto>().ForMember(x => x.CreatedAtDate, opt => opt.MapFrom(x => x.CreatedAt.Value.ToString("yyyy-MM-dd")))
                                             .ForMember(x => x.CreatedAtTime, opt => opt.MapFrom(x => x.CreatedAt.Value.ToString("HH:mm tt")))
                                             .ReverseMap();
            CreateMap<WalletTbl, WalletForCreateDto>().ReverseMap();
            CreateMap<WalletTbl, WalletForUpdateDto>().ReverseMap();

            // Transaction 
            CreateMap<TransactionTbl, TransactionDto>().ForMember(x => x.CreatedAtDate, opt => opt.MapFrom(x => x.CreatedAt.Value.ToString("yyyy-MM-dd")))
                                                       .ForMember(x => x.CreatedAtTime, opt => opt.MapFrom(x => x.CreatedAt.Value.ToString("HH:mm tt")))
                                                       .ReverseMap();

            //Tech Support
            CreateMap<TechSupportTbl, UserDto>().ReverseMap();
            CreateMap<TechSupportTbl, TechSupportDto>().ForMember(x => x.FullName, opt => opt.MapFrom(x => $"{x.ApplicationUser.FirstName} {x.ApplicationUser.LastName}"))
                                                                     .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.ApplicationUser.Id))
                                                                     .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.ApplicationUser.FirstName))
                                                                     .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.ApplicationUser.LastName))
                                                                     .ForMember(x => x.IsActive, opt => opt.MapFrom(x => x.ApplicationUser.IsActive))
                                                                     .ForMember(x => x.Email, opt => opt.MapFrom(x => x.ApplicationUser.Email))
                                                                     .ForMember(x => x.Username, opt => opt.MapFrom(x => x.ApplicationUser.UserName))
                                                                     .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.ApplicationUser.PhoneNumber))
                                                                     .ForMember(x => x.UserType, opt => opt.MapFrom(x => x.ApplicationUser.UserType))
                                                                     .ForMember(x => x.ImageURL, opt => opt.MapFrom(x => x.ApplicationUser.ImageURL))
                                                                     .ForMember(x => x.FCMToken, opt => opt.MapFrom(x => x.ApplicationUser.FCMToken)).ReverseMap();


            // Supervisor Activity Log
            CreateMap<SupervisorActivityLog, SupervisorActivityLogDto>().ReverseMap();
            CreateMap<SupervisorActivityLog, SupervisorActivityLogForCreateDto>().ReverseMap();

            // Customer Activity Log
            CreateMap<CustomerActivityLog, CustomerActivityLogDto>().ReverseMap();
            CreateMap<CustomerActivityLog, CustomerActivityLogForCreateDto>().ReverseMap();


            //Inventory
            CreateMap<InventoryTbl, InventoryActionDto>().ForMember(x => x.CreatedAtDate, opt => opt.MapFrom(x => x.Date.Value.ToString("yyyy-MM-dd")))
                                                         .ForMember(x => x.CreatedAtTime, opt => opt.MapFrom(x => x.Date.Value.ToString("HH:mm tt")))
                                                         .ReverseMap();
            CreateMap<InventoryTbl, InventoryActionForCreateDto>().ReverseMap();
            CreateMap<InventoryTbl, ApplyInventoryActionDto>().ReverseMap();


        }
    }
}
