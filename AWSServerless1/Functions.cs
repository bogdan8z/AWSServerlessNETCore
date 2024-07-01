using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using AWS.Lambda.Powertools.Logging;
using AWS.Lambda.Powertools.Metrics;
using AWS.Lambda.Powertools.Tracing;
using AWSServerless1.Models;
using Newtonsoft.Json;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSServerless1;

/// <summary>
/// Learn more about Powertools for AWS Lambda (.NET) at https://awslabs.github.io/aws-lambda-powertools-dotnet/
/// Powertools for AWS Lambda (.NET) Logging: https://awslabs.github.io/aws-lambda-powertools-dotnet/core/logging/
/// Powertools for AWS Lambda (.NET) Tracing: https://awslabs.github.io/aws-lambda-powertools-dotnet/core/tracing/
/// Powertools for AWS Lambda (.NET) Metrics: https://awslabs.github.io/aws-lambda-powertools-dotnet/core/metrics/
/// </summary>
public class Functions
{
    /// <summary>
    /// A Lambda function to respond to HTTP Get greetings methods from API Gateway
    /// </summary>
    /// <param name="request"></param>
    /// <returns>The API Gateway response.</returns>
    [Logging(LogEvent = true, CorrelationIdPath = CorrelationIdPaths.ApiGatewayRest)]
    [Metrics(CaptureColdStart = true)]
    [Tracing(CaptureMode = TracingCaptureMode.ResponseAndError)]
    public APIGatewayProxyResponse GetAGreetingLambda(APIGatewayProxyRequest request, ILambdaContext context)
    {
        Logger.LogInformation("Get Greeting Request");
        var greeting = GetGreeting();

        var response = new APIGatewayProxyResponse
        {
            StatusCode = (int)HttpStatusCode.OK,
            Body = greeting,
            Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
        };

        return response;
    }

    /// <summary>
    /// A Lambda function to respond to HTTP Get students methods from API Gateway
    /// </summary>
    /// <param name="request"></param>
    /// <returns>The API Gateway response.</returns>
    [Logging(LogEvent = true, CorrelationIdPath = CorrelationIdPaths.ApiGatewayRest)]
    [Metrics(CaptureColdStart = true)]
    [Tracing(CaptureMode = TracingCaptureMode.ResponseAndError)]
    public APIGatewayProxyResponse GetAllStudentsLambda(APIGatewayProxyRequest request, ILambdaContext context)
    {
        Logger.LogInformation($"{nameof(GetAllStudents)}");

        context.Logger.LogInformation($"aaa");
        var students = GetAllStudents();

        string studentsJson = JsonConvert.SerializeObject(students);


        var response = new APIGatewayProxyResponse
        {
            StatusCode = (int)HttpStatusCode.OK,
            Body = studentsJson,
            Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
        };

        return response;
    }

    [Tracing(SegmentName = "GetGreeting Method")]
    private static string GetGreeting()
    {
       Metrics.AddMetric("GetGreeting_Invocations", 1, MetricUnit.Count);

        return "Hello Powertools for AWS Lambda (.NET) 456";
    }

    [Tracing(SegmentName = "GetAllStudents Method")]
    private static List<Student> GetAllStudents()
    {
        Metrics.AddMetric("GetAllStudents_Invocations", 1, MetricUnit.Count);
        return new List<Student>
        {
            new()
            {
                Id = 1,
                FirstName = "First1"
            },
            new()
            {
                Id = 2,
                FirstName = "First2"
            }
        };
    }
}