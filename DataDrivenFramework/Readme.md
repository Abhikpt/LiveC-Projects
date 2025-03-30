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


-- Create the Appsetting file -> config reader
-- create the base class with method setup, teardown
-- Create the testscript , and inherit the all testBase in each testscript
--