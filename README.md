# AWS Serverless Application with Tests (.NET Core - C#) - Visual Studio



### Prerequisites
1. Create AWS user (only with access key) with admin rights and then generate an access key
2. Install AWS toolkit for Visual Studio locally from [**here**](https://marketplace.visualstudio.com/items?itemName=AmazonWebServices.AWSToolkitforVisualStudio2022)
3. Locally run in cmd: 
   >aws configure

and set the access key from the user you have just created
   
### Visual Studio
1. create new project of type **Aws serverless application with tests (.net core - C#)**
   1. **Functions.cs** contains all the lambda function that you will define
   2. **serverless.template** contains the template to create the AWS Application and also the Api Url
   3. **Readme.md** contains a description of the project
2. to deploy: right click on the project and select **Publish to AWS Lambda**
   1. you need to select the profile (default)
   2. it will ask for a bucket name and a stack name
3. after the deployment is done it will create an Lambda Application Stack and S3 bucket
   1. we can check this in AWS by going to S3, CloudFormation and Lambda
4. when we want to remove all the changes from AWS we can just remove the CF stack

<hr>

#### To do
1. Connect to dynamodb
2. Get data in an api
3. Use api gateway

#### Links
1. [Udemy - AWS Lambda For The .NET Developer](https://www.udemy.com/course/aws-lambda-dotnet/)
2. [AWS - Create Free Tier account](https://aws.amazon.com/free/)
3. [AWS - Step 1: Set Up an AWS Account and Create an Administrator User](https://docs.aws.amazon.com/streams/latest/dev/setting-up.html)
4. [AWS - Security best practices for AWS account administrators](https://docs.aws.amazon.com/signin/latest/userguide/best-practices-admin.html)
5. [AWS - Security best practices in IAM](https://docs.aws.amazon.com/IAM/latest/UserGuide/best-practices.html)
6. [AWS - Apply for $300 AWS Credits](https://aws-experience.com/amer/smb/exclusive-offers/aws-credits)
   