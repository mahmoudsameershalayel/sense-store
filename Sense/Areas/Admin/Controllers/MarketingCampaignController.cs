using Sense.Domain;
using Sense.Domain.DBEntities;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Areas.Admin.Controllers
{
    public class MarketingCampaignController : AdminBaseController
    {
        private readonly SenseDbContext _context;

        public MarketingCampaignController(SenseDbContext context)
        {
            _context = context;
        }

        // إنشاء حملة للمنتج
        public async Task<IActionResult> PromoteProduct(int productId)
        {
            var product = await _context.ProductTbls.FindAsync(productId);
            if (product == null) return NotFound();

            // إنشاء الحملة
            var campaign = new MarketingCampaignTbl
            {
                ProductId = product.Id,
                CreatedAt = DateTime.Now
            };

            _context.MarketingCampaignTbls.Add(campaign);
            await _context.SaveChangesAsync();

            // توليد الرابط الديناميكي للصفحة العامة
            string campaignUrl = Url.Action("Promo", "Product", new { id = product.Id }, Request.Scheme);

            // يمكن إعادة الرابط للمسؤول للعرض أو النسخ
            TempData["CampaignUrl"] = campaignUrl;

            return RedirectToAction("Promo", "Product", new { area = "", id = product.Id });
        }
    }
}
