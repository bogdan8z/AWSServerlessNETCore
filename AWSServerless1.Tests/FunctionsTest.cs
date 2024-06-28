using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;


namespace AWSServerless1.Tests;

public class FunctionTest
{
    public FunctionTest()
    {
    }

    [Fact]
    public void TestGetMethod()
    {
        Environment.SetEnvironmentVariable("POWERTOOLS_METRICS_NAMESPACE", "AWSLambdaPowertools");

        TestLambdaContext context;
        APIGatewayProxyRequest request;
        APIGatewayProxyResponse response;

        Functions functions = new Functions();

        request = new APIGatewayProxyRequest();
        context = new TestLambdaContext();
        response = functions.Get(request, context);
        Assert.Equal(200, response.StatusCode);
        Assert.Equal("Hello Powertools for AWS Lambda (.NET) 456", response.Body);
    }
}