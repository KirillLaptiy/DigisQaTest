# Digis QA - API Automation

This repository contains a C# (.NET) API automation test suite written for the Digis Trainee QA

## Tech Stack
*   **Language:** C#
*   **Framework:** .NET 11.0, NUnit
*   **Library:** RestSharp, Newtonsoft.Json

## Project Structure
*   `ApiTests.cs`: Contains 3 automated tests (GET, Data-Driven GET, POST) covering the JSONPlaceholder API.
*   **Test Cases:**
    1.  `GetUser_ShouldReturnOkAndValidData`: Verifies a successful GET request and validates the response body
    2.  `GetUser_WithDifferentIds_ShouldReturnExpectedStatus`: Data-driven test checking both existing (200) and non-existing (404) users
    3.  `CreateUser_ShouldReturnCreated`: Verifies POST request returns 201 Created and correctly parses the response

## How to Run
1. Clone the repository
2. Navigate to the project folder
3. Run the following command:
   - dotnet test