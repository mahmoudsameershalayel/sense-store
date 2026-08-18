namespace Sense.Models.ProviderRegistration
{
    public sealed class ProviderCategorySelectionViewModel
    {
        public IReadOnlyList<ProviderCategoryChoiceViewModel> Categories { get; init; }
            = Array.Empty<ProviderCategoryChoiceViewModel>();
    }

    public sealed class ProviderCategoryChoiceViewModel
    {
        public string Key { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public string? ImageUrl { get; init; }
        public bool IsRestaurant { get; init; }
    }

    public sealed class ProviderTemplateSelectionViewModel
    {
        public string CategoryKey { get; init; } = string.Empty;
        public string CategoryName { get; init; } = string.Empty;
        public IReadOnlyList<ProviderTemplateChoiceViewModel> Templates { get; init; }
            = Array.Empty<ProviderTemplateChoiceViewModel>();
    }

    public sealed class ProviderTemplateChoiceViewModel
    {
        public string Key { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
    }
}
