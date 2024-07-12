namespace MyNetCoreApi.Services.Interfaces
{
    public interface ILambdaService
    {
        Task<string> InvokeLambdaAsync(string functionName, string payload);
    }
}
