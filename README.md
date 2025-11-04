# Dependency Injection in C# [Full-Day Workshop]

## Description  

Loosely coupled code is easier to maintain, extend, and test. Dependency Injection (DI) help us get there. In this workshop, we'll see how interfaces can add "seams" to our code that makes it more flexible and maintainable. From there, we'll dig into loose coupling with Dependency Injection. DI doesn't have to be complicated. With just a few simple changes to our constructors or properties, we can have code that is easy to extend and test.  

After laying a good foundation, we'll take a closer look by diving into various DI patterns (such as constructor injection and property injection) as well as other patterns that help us handle interception and optional dependencies. Along the way, we'll see how DI helps us adhere to the SOLID principles in our code. We'll also we'll look at common stumbling blocks like dealing with constructor over-injection, managing static dependencies, and handling disposable dependencies.  

Throughout the day, we'll go hands-on with labs to give you a chance to put the concepts into action.  

If you're a C# developer who wants to get better with concepts like abstraction, loose coupling, extensibility, and unit testing, then this is the workshop for you.  

---  

### Pre-Requisites  

Basic understanding of C# and object-oriented programming (classes, inheritance, methods, and properties). No prior experience with the primary topics is necessary; we’ll take care of that as we go.  

## Hands-on Lab Requirements:

* You must provide your own laptop computer for the hands-on lab portions of the day.

* Interactive labs can be completed using Windows, macOS, or Linux -- anywhere .NET 8 or .NET 9 will run.

* You need to have the .NET 8 SDK or .NET 9 SDK installed as well as the code editor of your choice (Visual Studio 2022 Community Edition or Visual Studio Code are both good (free) choices).  

* You will also need the lab files with the code and instructions. These can be obtained from this repository (in the Labs folder).

### Links:

* .NET 9.0 SDK  
[https://dotnet.microsoft.com/en-us/download](https://dotnet.microsoft.com/en-us/download)

* Visual Studio 2022 (Community)  
[https://visualstudio.microsoft.com/downloads/](https://visualstudio.microsoft.com/downloads/)  
Note: Install the "ASP.NET and web development" workload for the labs and samples. Include ".NET desktop development" for WPF-based samples.

* Visual Studio Code  
[https://code.visualstudio.com/download](https://code.visualstudio.com/download)  

---

## Labs

These are the hands-on portions of the workshop. Labs can be completed with Visual Studio Code or Visual Studio 2022. All labs run on Windows, macOS, and Linux. Each lab consists of the following:

* **Labxx-Instructions** (Markdown)  
A markdown file containing the lab instructions. This includes the scenario, a set of goals, and step-by-step instructions.  
This can be viewed in on GitHub or in Visual Studio Code (just click the "Open Preview to the Side" button in the upper right corner).

* **Starter** (Folder)  
This folder contains the starting code for the lab.

* **Completed** (Folder)  
This folder contains the completed solution. If at any time, you get stuck during the lab, you can check this folder for a solution.

--- 

## Topics + Code  

The following connects the topics with the sample code.  

### Basics 
**Constructor Injection**  
* [PeopleViewer/PeopleController.cs](/DemoCode/PeopleViewer/Controllers/PeopleController.cs) - Web application controller
* [PeopleViewer.Desktop/PeopleViewerWindow.xaml.cs](/DemoCode/PeopleViewer.Desktop/PeopleViewerWindow.xaml.cs) - Desktop application main window
* [PeopleViewer.Presentation/PeopleViewModel.cs](/DemoCode/PeopleViewer.Presentation/PeopleViewModel.cs) - Desktop application view model

**Object Composition / Composition Root**  
* [PeopleViewer/Program.cs](/DemoCode/PeopleViewer/Program.cs) - Web application program file (no DI container)
* [PeopleViewer.Desktop/App.xaml.cs](/DemoCode/PeopleViewer.Desktop/App.xaml.cs) - Desktop application main window (no DI container)
* [PeopleViewer.Desktop.Ninject/App.xaml.cs](/DemoCode/PeopleViewer.Desktop.Ninject/App.xaml.cs) - Desktop application main window (using Ninject)

**Decorators**
* [PersonDataReader.Decorators/CachingReader.cs](/DemoCode/PersonDataReader.Decorators/CachingReader.cs) - Local cache decorator  
* [PersonDataReader.Decorators/RetryReader.cs](/DemoCode/PersonDataReader.Decorators/RetryReader.cs) - Retry decorator  
* [PersonDataReader.Decorators/ExceptionLoggingReader.cs](/DemoCode/PersonDataReader.Decorators/ExceptionLoggingReader.cs) - Exception logging decorator  
* [PeopleViewer/Program.cs](/DemoCode/PeopleViewer/Program.cs) - Web application composition (with decorators)  

**Proxy / IDisposable**  
* [PersonDataReader.SQL/SQLReaderProxy.cs](/DemoCode/PersonDataReader.SQL/SQLReaderProxy.cs) - Proxy to wrap IDisposable SQL Reader  

**Late Binding**  
* [WithConfiguration: PeopleViewer/ReaderFactory.cs](/LateBindingSamples/LateBinding-WithConfiguration/PeopleViewer/ReaderFactory.cs) - Creates data reader based on configuration  
* [WithConfiguration: PeopleViewer/App.config](/LateBindingSamples/LateBinding-WithConfiguration/PeopleViewer/App.config) - Configuration File  
* [NoConfiguration: PeopleViewer/ReaderFactory.cs](/LateBindingSamples/LateBinding-NoConfiguration/PeopleViewer/ReaderFactory.cs) - Creates data reader based on files in a particular folder (no configuration)  
* [PeopleViewer/ReaderLoadContext.cs](/LateBindingSamples/LateBinding-WithConfiguration/PeopleViewer/ReaderLoadContext.cs) - The context for dynamically loading assemblies (same for both configuration and no configuration samples)  

**Unit Testing**
* [PeopleViewer.Presentation.Tests/PeopleViewModelTests.cs](/DemoCode/PeopleViewer.Presentation.Tests/PeopleViewModelTests.cs) - View Model unit tests (constructor injection)  
* [PersonDataReader.CSV.Test/CSVReaderTests.cs](/DemoCode/PersonDataReader.CSV.Test/CSVReaderTests.cs) - CSV reader unit tests (property injection)  

**Dependency Injection Containers**  
* [PeopleViewer/Program.cs](/DemoCode/PeopleViewer/Program.cs) - Web application (using ASP.NET Core DI container)
* [PeopleViewer.Desktop.Ninject/App.xaml.cs](/DemoCode/PeopleViewer.Desktop.Ninject/App.xaml.cs) - Desktop application main window (using Ninject)
* [PeopleViewer.Desktop.Autofac/App.xaml.cs](/DemoCode/PeopleViewer.Desktop.Autofac/App.xaml.cs) - Desktop application main window (using Autofac)  
* [PeopleViewer.Desktop.GenericHost/App.xaml.cs](/DemoCode/PeopleViewer.Desktop.GenericHost/App.xaml.cs) - Desktop application main window (using Generic Host / ASP.NET Core container)  

---

## Resources

**DI Patterns**  
* [Dependency Injection: The Property Injection Pattern](http://jeremybytes.blogspot.com/2014/01/dependency-injection-property-injection.html)  
* [Property Injection: Simple vs. Safe](http://jeremybytes.blogspot.com/2015/06/property-injection-simple-vs-safe.html)  
* [Dependency Injection: The Service Locator Pattern](http://jeremybytes.blogspot.com/2013/04/dependency-injection-service-locator.html)  

**Decorators and Async Interfaces**
* [Async Interfaces, Decorators, and .NET Standard](https://jeremybytes.blogspot.com/2019/01/more-di-async-interfaces-decorators-and.html)  
* [Async Interfaces](https://jeremybytes.blogspot.com/2019/01/more-di-async-interfaces.html)  
* [Adding Retry with the Decorator Pattern](https://jeremybytes.blogspot.com/2019/01/more-di-adding-retry-with-decorator.html)  
* [Unit Testing Async Methods](https://jeremybytes.blogspot.com/2019/01/more-di-unit-testing-async-methods.html)  
* [Adding Exception Logging with the Decorator Pattern](https://jeremybytes.blogspot.com/2019/01/more-di-adding-exception-logging-with.html)  
* [Adding a Client-Side Cache with the Decorator Pattern](https://jeremybytes.blogspot.com/2019/01/more-di-adding-client-side-cache-with.html)  
* [The Real Power of Decorators -- Stacking Functionality](https://jeremybytes.blogspot.com/2019/01/more-di-real-power-of-decorators.html)  

**Challenges**  
* Static Objects: [Mocking Current Time with a Simple Time Provider](https://jeremybytes.blogspot.com/2015/01/mocking-current-time-with-time-provider.html)  

**Related Topics**
* Session: [DI Why? Getting a Grip on Dependency Injection](http://www.jeremybytes.com/Demos.aspx#DI)
* Pluralsight: [Getting Started with Dependency Injection in .NET](https://app.pluralsight.com/library/courses/using-dependency-injection-on-ramp/table-of-contents) 

More information at [http://www.jeremybytes.com](http://www.jeremybytes.com)  

---  