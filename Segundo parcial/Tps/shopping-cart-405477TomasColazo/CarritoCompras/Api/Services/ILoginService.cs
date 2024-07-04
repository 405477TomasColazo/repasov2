namespace Api.Services
{
    public interface ILoginService
    {
        Task<string> ValidateUserAsync(string email, string password); 
    }
}
