# helloworld-xamarin

[![AppVeyor](https://img.shields.io/appveyor/ci/feedhenry/helloworld-xamarin/master.svg)](https://ci.appveyor.com/project/feedhenry/helloworld-xamarin/) 

Author: Erik Jan de Wit   
Level: Intermediate  
Technologies: C# xamarin, iOS, android, RHMAP
Summary: A demonstration of how to get started with remote cloud call in RHMAP.
Community Project : [Feed Henry](http://feedhenry.org)
Target Product: RHMAP  
Product Versions: RHMAP 3.7.0+   
Source: https://github.com/feedhenry-templates/helloworld-xamarin  
Prerequisites: fh-dotnet-sdk : 3.+, Visual Studio: 2015, Xamarin Studio: 5.3, iOS SDK : iOS7+, android sdk 23

## What is it?

Simple native iOS app and Android app based on Xamarin, to test your remote cloud connection in RHMAP. Its server side companion app: [HelloWorld Cloud App](https://github.com/feedhenry-templates/helloworld-cloud). This template app demos how to intialize a cloud call and make calls to cloud endpoints. The app uses [fh-dotnet-sdk](https://github.com/feedhenry/fh-dotnet-sdk).

If you do not have access to a RHMAP instance, you can sign up for a free instance at [https://openshift.feedhenry.com/](https://openshift.feedhenry.com/).

## How do I run it?  

### RHMAP Studio

This application and its cloud services are available as a project template in RHMAP as part of the "Native Xamarin Hello World Project" template.

### Local Clone (ideal for Open Source Development)
If you wish to contribute to this template, the following information may be helpful; otherwise, RHMAP and its build facilities are the preferred solution.

## Build instructions

1. Clone this project

2. Populate ```helloworld-ios/fhconfig.plist``` for iOS or ```helloworld-android/Assets/fhconfig.properties``` with your values as explained in our [documentation](http://docs.feedhenry.com/v3/dev_tools/sdks/windows.html#windows-existing_app-set_up_configuration).

3. Open helloworld-xamarin.sln

4. Run the project
 
## How does it work?

### Init

When the view has loaded the FH.init call is done:
```csharp
  await FHClient.Init();
```
That initialize the cloud connection.

### Cloud call

In ```iOS-Template-App/HomeViewController.m``` the FH.init call is done:
```csharp
 var response = await FH.Cloud ("hello", "GET", null, new Dictionary<string, string> () { { "hello", name.Text } });
 if (response.Error == null) {
  // cloudCall - success
  Console.WriteLine(response.GetResponseAsDictionary () ["msg"]);
 } else {
  //cloudCall - fail
 }
```
