<!--
+++
title = "CDK Module Overview"
date = 2019-10-12T18:06:59-04:00
weight = 10
+++
-->
Welcome to the `.NET AWS CDK` module of the workshop!

### Workshop Goals

The goal of this lab is to guide participants through adding support for MySQL database to both ASP.NET application codebase, and to the existing infra-as-code C# CDK projects defining cloud CI/CD pipeline and cloud application deployment environment. 

This workshop skips the "[Hello, World](https://docs.aws.amazon.com/cdk/latest/guide/getting_started.html)" CDK project creation, and instead focuses on somewhat more in-depth capabilities of the CDK, showing higher-fidelity code samples implementing closer-to-real-life scenarios. This means that the lab will start with a couple of existing, but still pretty small CDK projects, and the lab flow focuses on modifying these projects.

The aim is to help you learn how to take your cloud-unaware ASP.NET Core application and use `C#` to write code defining parts of:

1. **CI/CD pipeline** infrastructure in AWS cloud that builds and deploys the application.
2. AWS cloud **application deployment infrastructure**, including an application hosting components and a database: Amazon Elastic Container Service (`ECS` Fargate) and Amazon Relational Database Service (`RDS`) hosting a selection of popular relational databases like Aurora MySQL (HA), Aurora Postgres (HA), and SQL Server.

> If you find yourself struggling with the lab or running into unexpected errors, you may skip ahead by checking out `cdk-module-completed` Git branch, where all changes required for adding MySQL support are already implemented.

### CKD Demystified

> [AWS Cloud Development Kit](https://docs.aws.amazon.com/cdk/latest/guide/home.html) is higher-level abstraction components built on top of the Amazon CloudFormation - an indispensible previous-generation infrastructure-as-code service, with the major difference  that CDK lets programmers use most of their favorite programming languages, like C#, to generate CloudFormation templates while writing *order of magnitude less code* than with CloudFormation.

CDK consists of a CLI and a set of libraries available for most popular programming languages. In the case of .NET CDK, the libraries are added via [NuGet](https://www.nuget.org/packages/Amazon.CDK/).

A .NET CDK project is a Console app, generating AWS CloudFormation template. CDK CLI is a convenience tool making it possible to bypass direct contact with lower-level CloudFormation templates and related commands of AWS CLI.