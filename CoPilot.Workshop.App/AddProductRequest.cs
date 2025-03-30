namespace CoPilot.Workshop.App
{
    public record AddProductRequest(decimal Price)
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
    }
}
