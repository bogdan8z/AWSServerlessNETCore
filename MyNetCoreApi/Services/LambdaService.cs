using Amazon.Lambda;
using Amazon.Lambda.Model;
using Amazon.Runtime;
using MyNetCoreApi.Services.Interfaces;

namespace MyNetCoreApi.Services
{
    public class LambdaService : ILambdaService
    {
        private readonly AmazonLambdaClient _lambdaClient;
        private const string AwsKey = "todo";
        private const string AwsSecretKey = "todo";

        public LambdaService()
        {
            var awsCredentials = new BasicAWSCredentials(AwsKey, AwsSecretKey);
            _lambdaClient = new AmazonLambdaClient(awsCredentials);
        }

        public async Task<string> InvokeLambdaAsync(string functionName, string payload)
        {
            var request = new InvokeRequest
            {
                FunctionName = functionName,
                Payload = payload
            };

            var response = await _lambdaClient.InvokeAsync(request);
            using (var reader = new StreamReader(response.Payload))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
