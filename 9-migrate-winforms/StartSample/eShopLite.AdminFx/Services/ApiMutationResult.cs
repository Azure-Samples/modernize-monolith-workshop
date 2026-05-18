namespace eShopLite.AdminFx.Services
{
    public class ApiMutationResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public static ApiMutationResult Ok(string message)
        {
            return new ApiMutationResult { Success = true, Message = message };
        }

        public static ApiMutationResult Failed(string message)
        {
            return new ApiMutationResult { Success = false, Message = message };
        }
    }
}
