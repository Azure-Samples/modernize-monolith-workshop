namespace eShopLite.Admin.Services;

public sealed record ApiMutationResult(bool Success, string Message)
{
    public static ApiMutationResult Ok(string message) => new(true, message);

    public static ApiMutationResult Failed(string message) => new(false, message);
}
