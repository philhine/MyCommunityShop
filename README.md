# MyCommunityShop
Community Shop

## Background

This project is part of a technical test and the objective was to create a shop. It should be able to calculate items added to a shopping basket including applying discounts. 

It has been written with the best practice in mind and therefore I have decided to architect it as I would in a large commerical application. 

## Prerequisites
Git - [https://www.atlassian.com/git/tutorials/install-git#windows](https://www.atlassian.com/git/tutorials/install-git#windows)
Visual Studio 2019 or later.
.NET Core 3.1 
.NET Framework 4.7.2

## Setup Instructions

```git clone https://github.com/philhine/InvestmentForecaster.git```

Open the solution file in the root - MyCommunityShop.Sln 

In visual studio right click on the solution and select Set StartUp Projects. Then select the following:
MyCommunityShop.Api
MyCommunityShop.App

Press F5 to restore, build and launch the application.

## Usage

Ensure you have the applications console window open and follow the instructions on screen.

## What went well?

The shop as a whole has the full functionality as per the original spec. I enjoyed writing the api most of all and following the standard patterns I would implement. Writing the console application was enjoyable as I haven't written one for a while. The idea behind my approach was to allow screens to be easily added and I hope that it accomplishes that. I've enjoyed using the ConsoleTable nuget package to display tables in the console as this was quick to use.

## Challenges
Unfortunately Resharper wasn't loading in Visual Studio. I usually like to scan for suggestions and make corrections. Also it helps with navigating and performing tasks like moving files and changing the namespaces automatically so not having it made developing a bit slower.

I attempted to create my console application in .Net Core but even with the correct SDKs installed it threw error messages on starting up without any custom code in it. I decided to revert to using .NET Framework 4.7.2 which has been ok except I would have liked to have made use of the new features in C# 7.1 whereby you can mark you main method as async rather than calling async methods from synchronous code.

## Was there anything that was attempted but was not possible to get working in the time so is not visible in the code?

Creating a React front end and implemented best practices would have been my choice with an unlimited deadline. This is something I am looking into carrying on as a learning exercise.

Also finishing the hypermedia links both from a client and server point was my next priority but I ran out time. This is something I will pick up as it will be a good learning experience.

## What would you do to improve it / continue development?

- Upgrade the console application to .NET Core so I could implement async a bit more seamlessly.I would like to add further functionality to create/update/delete products and offers.

- Adding tests to the console application would also add to the integrity of the application as a whole and there are quite a number of areas that can be tested.

- Implement logging in the areas where I have left placeholders. 

- Ensuring the hypermedia links were being used by the client.
