# AWS Serverless Application with Tests (.NET Core - C#) - Visual Studio

This will create 2 AWS lamda functions that define 2 API endpoints which are accesible through API Gateway<br>
GET /greetings<br>
GET /students

<br>
For building the API this will use APIGatewayProxyRequest instead of traditional controller-based approach.

### Prerequisites
1. Create AWS user (only with access key) with admin rights and then generate an access key
2. Install AWS toolkit for Visual Studio locally from [**here**](https://marketplace.visualstudio.com/items?itemName=AmazonWebServices.AWSToolkitforVisualStudio2022)
3. Locally run in cmd: 
   >aws configure

and set the access key from the user you have just created
   
### Visual Studio
1. create new project of type **Aws serverless application with tests (.net core - C#)** and in Blueprint dialog select **Powertools for AWS Lambda**
2. The new project contains
   1. **Functions.cs** contains all the lambda function that you will define
   2. **serverless.template** contains the template to create the AWS Application and also the Api Url
   3. **Readme.md** contains a description of the project
3. to deploy: right click on the project and select **Publish to AWS Lambda**
   1. you need to select the profile (default)
   2. it will ask for a bucket name and a stack name
4. after the deployment is done it will create an Lambda Application, CloudFormation Stack, an Api in API Gateway and S3 bucket
   1. we can check this in AWS by going to S3, CloudFormation and Lambda
5. when we want to remove all the changes from AWS we can just remove the CF stack and the Api from API Gateway

<hr>

#### To do
1. fix tests (cold start issue)
2. Connect to dynamodb (get students)
3. CI/CD github->aws lambda using aws CodeBuild / docker


#### Links
1. [AWS - Tutorial: Build and Test a Serverless Application with AWS Lambda](https://docs.aws.amazon.com/toolkit-for-visual-studio/latest/user-guide/lambda-build-test-severless-app.html)
1. [Udemy - AWS Lambda For The .NET Developer](https://www.udemy.com/course/aws-lambda-dotnet/)
1. [AWS::Serverless::Function](https://docs.aws.amazon.com/serverless-application-model/latest/developerguide/sam-resource-function.html)
2. [AWS - Create Free Tier account](https://aws.amazon.com/free/)
3. [AWS - Step 1: Set Up an AWS Account and Create an Administrator User](https://docs.aws.amazon.com/streams/latest/dev/setting-up.html)
4. [AWS - Security best practices for AWS account administrators](https://docs.aws.amazon.com/signin/latest/userguide/best-practices-admin.html)
5. [AWS - Security best practices in IAM](https://docs.aws.amazon.com/IAM/latest/UserGuide/best-practices.html)
6. [AWS - Apply for $300 AWS Credits](https://aws-experience.com/amer/smb/exclusive-offers/aws-credits)
7. [Continuous Integration: C# to AWS Lambda](https://maxhorstmann.net/blog/2017/05/22/ci-dotnetcore-lambda/)
   
