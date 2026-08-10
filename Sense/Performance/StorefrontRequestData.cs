using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Sense.Application.DTOs.BannerDTOs;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.CenterSettingDTOs;
using Sense.Application.DTOs.CouponDTOs;
using Sense.Application.DTOs.OfferCashbackDTOs;
using Sense.Application.DTOs.ProviderDTOs;
using Sense.Application.DTOs.StatementDTOs;
using Sense.Application.UseCases.Banner.Queries.GetAllBannersQuery;
using Sense.Application.UseCases.CashbackOffer.Queries.GetAllCashbackOffersQuery;
using Sense.Application.UseCases.Cateogry.Queries.GetAllCategoriesQuery;
using Sense.Application.UseCases.CenterSetting.Queries.GetCenterSettingQuery;
using Sense.Application.UseCases.Coupon.Queries.GetAllCouponsQuery;
using Sense.Application.UseCases.Provider.Queries.GetAllProvidersQuery;
using Sense.Application.UseCases.Statement.Queries.GetActiveStatementsQuery;

namespace Sense.Performance;

public sealed class StorefrontDataCache
{
    private static readonly object BannerKey = new();
    private static readonly object CategoriesKey = new();
    private static readonly object ProvidersKey = new();
    private static readonly object CenterSettingKey = new();
    private static readonly object CashbackOffersKey = new();
    private static readonly object CouponsKey = new();
    private static readonly object StatementsKey = new();
    private static readonly TimeSpan CacheDuration = TimeSpan.FromSeconds(30);

    private readonly IMemoryCache _cache;
    private readonly IMediator _mediator;
    private CenterSettingDto? _requestCenterSetting;
    private List<CashbackOfferDto>? _requestCashbackOffers;

    public StorefrontDataCache(IMemoryCache cache, IMediator mediator)
    {
        _cache = cache;
        _mediator = mediator;
    }

    public async Task<BannerDto?> GetBannerAsync()
    {
        return await _cache.GetOrCreateAsync(BannerKey, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = CacheDuration;
            var result = await _mediator.Send(new GetAllBannersQuery());
            return result.Data?.FirstOrDefault();
        });
    }

    public async Task<List<CategoryDto>> GetCategoriesAsync()
    {
        return await _cache.GetOrCreateAsync(CategoriesKey, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = CacheDuration;
            var result = await _mediator.Send(new GetAllCategoriesQuery());
            return result.Data?.ToList() ?? [];
        }) ?? [];
    }

    public async Task<List<ProviderDto>> GetProvidersAsync()
    {
        return await _cache.GetOrCreateAsync(ProvidersKey, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = CacheDuration;
            var result = await _mediator.Send(new GetAllProvidersQuery());
            return result.Data?.ToList() ?? [];
        }) ?? [];
    }

    public async Task<CenterSettingDto?> GetCenterSettingAsync()
    {
        if (_requestCenterSetting != null)
        {
            return _requestCenterSetting;
        }

        _requestCenterSetting = await _cache.GetOrCreateAsync(CenterSettingKey, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = CacheDuration;
            var result = await _mediator.Send(new GetCenterSettingQuery());
            return result.Data;
        });

        return _requestCenterSetting;
    }

    public async Task<List<CashbackOfferDto>> GetCashbackOffersAsync()
    {
        if (_requestCashbackOffers != null)
        {
            return _requestCashbackOffers;
        }

        _requestCashbackOffers = await _cache.GetOrCreateAsync(CashbackOffersKey, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = CacheDuration;
            var result = await _mediator.Send(new GetAllCashbackOffersQuery());
            return result.Data?.ToList() ?? [];
        }) ?? [];

        return _requestCashbackOffers;
    }

    public async Task<List<CouponDto>> GetCouponsAsync()
    {
        return await _cache.GetOrCreateAsync(CouponsKey, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = CacheDuration;
            var result = await _mediator.Send(new GetAllCouponsQuery());
            return result.Data?.ToList() ?? [];
        }) ?? [];
    }

    public async Task<List<StatementDto>> GetStatementsAsync()
    {
        return await _cache.GetOrCreateAsync(StatementsKey, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = CacheDuration;
            var result = await _mediator.Send(new GetActiveStatementsQuery());
            return result.Data?.ToList() ?? [];
        }) ?? [];
    }
}
