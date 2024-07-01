using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;
using AWSServerless1.Models;
using Moq;

namespace AWSServerless1.Tests;

public class FunctionTest
{
    private Functions _functions;
    private readonly Mock<ILambdaContext> _context;

    public FunctionTest()
    {
        Environment.SetEnvironmentVariable("POWERTOOLS_METRICS_NAMESPACE", "AWSLambdaPowertools");
        _functions = new Functions();
        _context = new Mock<ILambdaContext>();
    }

    [Fact]
    public void TestGetAGreetingMethod()
    {
        _functions = new Functions();
        var request = new APIGatewayProxyRequest();

        var response = _functions.GetAGreetingLambda(request, _context.Object);
        Assert.Equal(200, response.StatusCode);
        Assert.Equal("Hello Powertools for AWS Lambda (.NET) 456", response.Body);
    }

    [Fact]
    public void TestGetAllStudentsMethod()
    {
        _functions = new Functions();
        var request = new APIGatewayProxyRequest();

        var response = _functions.GetAllStudentsLambda(request, _context.Object);

        Assert.Equal(200, response.StatusCode);
        var students = JsonConvert.DeserializeObject<List<Student>>(response.Body);
        Assert.Equal(2, students?.Count);
        Assert.Equal(2, students?[1].Id);
    }
}