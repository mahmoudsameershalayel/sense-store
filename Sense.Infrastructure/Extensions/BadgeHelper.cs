using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Infrastructure.Extensions
{
    public static class BadgeHelper
    {
        public static string GetOrderStatusBadge(OrderStatus? status)
        {
            string badgeClass = status switch
            {
                OrderStatus.Deliverd => "badge-light-success",
                OrderStatus.OutForDelivery => "badge-light-warning",
                OrderStatus.Preparing => "badge-light-primary",
                OrderStatus.Prepared => "badge-light-primary",
                OrderStatus.Rejected => "badge-light-danger",
                OrderStatus.Pending => "badge-light-info",
                _ => "badge-light-info"
            };

            return $"<span class='badge {badgeClass} fs-7 fw-bold'>{status?.GetDisplayName() ?? string.Empty}</span>";
        }

        public static string GetMaintenanceRecordStatus(MaintenanceStatus? status)
        {
            string badgeClass = status switch
            {
                MaintenanceStatus.UnderMaintenance => "badge-light-warning",
                MaintenanceStatus.Completed => "badge-light-success",
                _ => "badge-light-info"
            };

            return $"<span class='badge {badgeClass} fs-7 fw-bold'>{status?.GetDisplayName() ?? string.Empty}</span>";
        }

        public static string GetInvoiceTypeBadge(InvoiceType? type)
        {
            string badgeClass = type switch
            {
                InvoiceType.SparePartInvoice => "badge-light-success",
                InvoiceType.LaborCostInvoice => "badge-light-primary",
                _ => "badge-light-info"
            };

            return $"<span class='badge {badgeClass} fs-7 fw-bold'>{type?.GetDisplayName() ?? string.Empty}</span>";
        }

        public static string GetPaymentMethodBadge(PaymentMethod? method)
        {
            // „À«·
            return $"<span class='badge badge-light-secondary fs-7 fw-bold'>{method?.GetDisplayName() ?? string.Empty}</span>";
        }

        public static string GetPaymentStatusBadge(PaymentStatus? status)
        {
            // „À«· „‘«»Â
            string badgeClass = status switch
            {
                PaymentStatus.Completed => "badge-light-success",
                PaymentStatus.Pending => "badge-light-warning",
                PaymentStatus.Failed => "badge-light-danger",
                _ => "badge-light-secondary"
            };
            return $"<span class='badge {badgeClass} fs-7 fw-bold'>{status?.GetDisplayName() ?? string.Empty}</span>";
        }
    }
}
