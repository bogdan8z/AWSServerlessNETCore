using Amazon.Lambda;
using Amazon.Lambda.Model;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using MyNetCoreApi.Services.Interfaces;

namespace MyNetCoreApi.Services
{
    public class LambdaService : ILambdaService
    {
        private readonly AmazonLambdaClient _lambdaClient;
        private const bool ReadFromProfile = true;
        private const string AwsKey = "todo";
        private const string AwsSecretKey = "todo";
        private const string AwsProfileName = "todo";        

        public LambdaService()
        {
            AWSCredentials awsCredentials = GetAwsCredentials();
            _lambdaClient = new AmazonLambdaClient(awsCredentials);
        }

        private static AWSCredentials DefaultAWSCredentialsFromProfile
        {
            get
            {
                var credentialProfileStoreChain = new CredentialProfileStoreChain();
                if (credentialProfileStoreChain.TryGetAWSCredentials(AwsProfileName, out AWSCredentials defaultCredentials))
                    return defaultCredentials;
                else
                    throw new AmazonClientException("Unable to find a default profile in CredentialProfileStoreChain.");
            }
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

        private static AWSCredentials GetAwsCredentials()
        {            
            if (ReadFromProfile)
            {
                return DefaultAWSCredentialsFromProfile;
            }
            return new BasicAWSCredentials(AwsKey, AwsSecretKey);
        }
    }
}
