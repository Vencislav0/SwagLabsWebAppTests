# SwagLabs WebApp Tests

![Test Automation](https://img.shields.io/badge/Test%20Automation-Passing-brightgreen)

This repository contains automated tests for the SwagLabs web application using Selenium WebDriver and the NUnit framework. The project is designed to ensure the stability and reliability of the SwagLabs application by executing a suite of end-to-end tests.

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Installation](#installation)
- [Usage](#usage)  
- [License](#license)

## Overview

SwagLabs WebApp Tests is a test automation project focused on validating the functionalities of the SwagLabs web application. It includes tests for various user scenarios such as login, product browsing, adding items to the cart, and the checkout process.

## Features

- **Automated Tests:** End-to-end test coverage for SwagLabs using Selenium WebDriver.
- **NUnit Integration:** Structured test execution and reporting with NUnit.
- **Cross-browser Testing:** Support for testing across multiple web browsers.
- **CI/CD Ready:** Easily integrable with CI/CD pipelines for continuous testing.

## Technologies Used

- **Selenium WebDriver:** Browser automation for web applications.
- **NUnit:** A unit-testing framework for .NET languages.
- **C#:** The primary programming language for the tests.

## Installation

To get started with this project, clone the repository and set up the necessary dependencies.

```bash
 git clone https://github.com/Vencislav0/SwagLabsWebAppTests.git
 cd SwagLabsWebAppTests
```

 Ensure that you have the following installed:

- **.NET SDK
- **NuGet Package Manager
- **ChromeDriver or GeckoDriver for browser automation

 Restore the required packages using NuGet:

```bash
 dotnet restore
```
## Usage

To run the test suite, use the following command:

```bash
 dotnet test
```
## License

- **This project is licensed under the MIT License - see the LICENSE file for details.

