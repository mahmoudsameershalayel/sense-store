using Sense.Domain.Enums;

namespace Sense.Domain.DBEntities
{
    public class ProviderRequestTbl : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string BusinessName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string BusinessDescription { get; set; } = string.Empty;

        public string DocumentStoredName { get; set; } = string.Empty;
        public string DocumentOriginalName { get; set; } = string.Empty;
        public string DocumentContentType { get; set; } = "application/octet-stream";
        public long DocumentFileSize { get; set; }

        public bool AcceptedTerms { get; set; }
        public ProviderRequestStatus Status { get; set; } = ProviderRequestStatus.Pending;
        public string? InternalNote { get; set; }
        public string? RejectionReason { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public string? ReviewedByUserId { get; set; }

        public int? ApprovedProviderId { get; set; }
        public ProviderTbl? ApprovedProvider { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}
