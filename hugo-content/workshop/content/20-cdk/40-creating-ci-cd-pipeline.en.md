<!--
+++
title = "Creating AWS CI/CD Pipeline"
menutitle = "Creating Cloud CI/CD Pipeline"
date = 2019-10-14T11:11:14-04:00
weight = 40
pre = "<b>3. </b>"
+++
-->
Before we dive into the code base of the Unicorn Store solution and start hacking it, let's spend a few moments to create the CI/CD pipeline in AWS, as creating it takes a few minutes to complete, and while that is in progress, we'll spend some time looking into the structure of project and getting familiar with CDK concepts.

|      | Notes |
| ---- | ----- |
| ![VS Build Configurations](images/solution-build-configurations.png) | Again, please select either Posgres or SQL Server configuration from Solution's Build Configuration drop-down in Visual Studio...  |
| ![CI/CD project as startup](./images/CicdInfraAsCode-csproj-as-startup.png) | ...and mark "CicdInfraAsCode" project as a startup project.<br/><br/>Please run the project. If all went well you should see a console window with output starting with something like *Synthesized to "C:\Users\username\AppData\Local\Temp\cdk.outjLaGkJ".* That path is the location of where CloudFormation templates generated.  |

### Launching CI/CD Pipeline Infrastructure Creation

Now please open a Command Prompt window and cd into the directory containing "CicdInfraAsCode.csproj" project file, which relative to the solution root is in "infra-as-code/CicdInfraAsCode/src".

> If you never ran `cdK` CLI before in the currently-configured AWS Region, and you are not using an AWS event supplied VM, you may need to run `cdk bootstrap` command that runs a CloudFormation template that configures some resources required for the CDK to function. This is a one-time thing per AWS region.

Next, run the following command to start creation of the CI/CD pipeline:
```bash
cdk deploy --require-approval never
```
That will start a process of creating a CI/CD pipeline for the application using AWS CodePipeline service, which in turn orchestrates few other AWS services, like CodeCommit and CodeBuild. This CI/CD infrastructure build-out job should take a few minutes, which will be well spent in the next section, which deals with the structure of the project.