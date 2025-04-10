# Data-Driven Framework for C# Automation

This project implements a Data-Driven Framework for automation testing using C#. The framework is designed to separate test data from test scripts, enabling flexibility and scalability in test execution.

## Key Features
- **Data-Driven Testing**: Test cases are executed with multiple sets of data stored in external sources like Excel, CSV, or databases.
- **Modular Design**: The framework is structured to promote code reusability and maintainability.
- **Customizable Reporting**: Generate detailed test execution reports.
- **Integration Ready**: Easily integrates with popular testing tools and CI/CD pipelines.

## Prerequisites
- .NET SDK installed
- A compatible IDE (e.g., Visual Studio)
- External data source (e.g., Excel file)

## Configuration
The framework uses an `App.config` file to manage basic settings like the base URL, browser type, and other variables. Update the `App.config` file located in the root directory with your project-specific values.

Example:
```xml
<appSettings>
  <add key="BaseUrl" value="https://example.com" />
  <add key="Browser" value="Chrome" />
</appSettings>
```

## Getting Started
1. Clone the repository.
2. Configure the data source in the framework.
3. Write test cases using the provided templates.
4. Execute tests and review the results.

## Folder Structure
- **TestCases/**: Contains all test scripts.
- **Data/**: Stores test data files.
- **Reports/**: Stores generated test execution reports.
- **Utilities/**: Contains helper classes and methods.

## Contributions
Contributions are welcome! Please follow the contribution guidelines outlined in the repository.



## Supported class and framework:
- Excel reader
- Logs
_ mails
- Zip
- Listeners - soft assertion, Test failure
- Jenkins
- Nuget
- ReportNG
- Extent Reports
- Database
- Properties
- Runmodes
- TestNG
- ScreenshotUtils


## Steps We Follow
Below are the steps we follow to implement and execute tests using this framework:

1. **Created Properties an Config file**: Ensure all prerequisites are installed and configured.
2. **Prepare Test Data**: Populate the external data source with the required test data.
3. **Write Test Cases**: Use the templates provided in the `TestCases/` folder to create test scripts.
4. **Configure the Framework**: Update configuration files to link the test scripts with the data source.
5. **Run Tests**: Execute the test suite using the test runner.
6. **Analyze Results**: Review the reports generated in the `Reports/` folder for test execution details.
7. **Debug and Refine**: Address any issues found during testing and refine the scripts or data as needed.

Feel free to customize these steps based on your specific project requirements.

- Create the Appsetting file -> ConfigReader [it will be used to fetch the variable and URL from the appsetting.json]
- `create the TestBase` with method setup, teardown, OnetimeSetup and OneTimeTeardown
- Create the testscript , and inherit the all testBase in each testscript


## steps i follow in this project

1. **Implement ConfigRerader:**
      a. Created the `static ` Config class to read the environment variable and URLs
      b. 
2. **Implement Logging:**
      a. Create the `static` loggerClass, so that can access globally and no multiple instance
      b. Add different method for operation like LogInfo, LogError, LogWarn and LogDebug
      c. call the the logging method in testBase class using className.Nethod under 
         - OneTimeSetup, Setup, OneTimeTearDown and Teardown method
      d. 
      
      
3. **Implement Reporting:** 
      a. Create the Reporting class
      b. implement the `static` methods like  StartReport, LogInfo, LogFail, Logpass, 
      c.  `extent.Flush()` is mandetory to Appends the HTML file with all the ended tests.
      d. we can create all the static object for this , but in case of parallel testing we will face challanges.

4. **Implement ExcelUtility**
      a. Create ExcelUtility Class
      b. create different method like readexcel  , returing an list of row/array i.e. `List<object[]>` .
      c. Call this method in a method where you want to do mult-data operation
      d. use the anotation like TestCaseSource(nameof(MethodName)) for passing the data using Nunit.
      e. it will take the row one by one and supply to this method belong to this annotation

5. **Implement BaseClass**
      a. Create the base class `TestBase`. it will create `static` variable to initiate all the objects for all class like reporting, config and logging.
      b. we can add some basic methods here that need to use in further Testclasses.


6. **Implement aserion**: 
      a. Assertions validate expected vs. actual results, ensuring your automation scripts verify functionality correctly.
      b. ests without assertions may pass even if the application is broken. Assertions confirm correct behavior.
      c. When an assertion fails, NUnit provides a detailed error message, making it easier to debug and fix issues

7. **Adding Screenshot:**

      a. Capturing the screenshot and save file in directory 
      b. We can include the  screenshot file link in logging file as well
      b. Capturing screenshot passing in extentreport as a string and then displaying as image using `MediaEntityBuilder`.

8.  



1.  Flow for adding the customer:

  - Created Base class => TestBase
  - Add customer class   - open the customer page  - Add the record with multi-dataset.
  - Multi-Data set: Achieve from the method returing an list of row/array i.e. `List<object[]>`  => Execlutility
  - 


### Precaution:
a. Initialize the ElementActions, Logging, Reporting and Excelutility class and take the object for further process
b. Make the reporting/loggin process in same `TestBase class`  by using setup and teardown anotations of Nunit.
c. inherit the Testbase class in "TestScript" that will provied all this object to work.
c. Test script: It should have the funcationality, and multi-data operation in seperate method.
d. 