<p align="center">
  # Installment
  <img alt="logotype" src="logotype-new.png" width="256px">
  # Calculator
</p>

# Installment Calculator

## Purpose and Functions of the Application
The installment calculator is a console application that allows you to calculate a loan repayment schedule based on the loan amount, repayment period, interest rate, and optional overpayment. The user inputs the data, and the application calculates and displays the monthly loan installments, dividing them into principal and interest parts. The calculator also helps understand how overpayment affects the shortening of the loan period and the reduction of interest amounts.

## Problem Solved by the Application
The application facilitates accurate loan repayment planning for users, taking into account variable interest rates and overpayments. It allows for quick calculations and simulations that can be difficult to perform manually, providing the user with clear data on their loan obligations.

# App Architecture
| **Module** | **Functions** | **Description** |
|:---------:|:-----------:|:-----------:|
| **Data Loading** | | **Responsible for collecting and validating user data.** |
| Loading loan amount | *wczytywanieKwotyKredytu()* | The function collects the loan amount from the user. It validates whether the entered value is a positive number. If not, it displays an error and asks for the value to be re-entered.
| Loading number of months | *wczytywanieLiczbyMiesiecy()* | The function collects the number of months for loan repayment. It validates the correctness of the data (the number must be greater than 0).
| Loading loan interest rate | *wczytywanieOprocentowaniaKredytu()* | The function collects the annual interest rate in percentage. It checks if the user has entered a correct value greater than 0.
| Loading loan overpayment | *wczytywanieNadplatyKredytu(decimal kwotaKredytu)* | The function asks the user if they want to add an overpayment to the loan. If so, it collects the overpayment amount and verifies that the overpayment does not exceed the remaining loan amount.
| **Calculations and Processing** | | **Responsible for all calculations related to the loan repayment schedule and installments.**
| Calculating interest rate | *obliczanieOprocentowania()* | The function converts the annual interest rate to a monthly rate (annual interest rate divided by 12).
| Calculating loan installment | *obliczRateKredytu()* | The function calculates the amount of the monthly loan installment. It takes into account the interest rate and the number of months. It uses the formula for fixed installments.
| Recalculating new installment | *przeliczNowaRate() | The function recalculates the new loan installment after applying the overpayment. It calculates the new installment amount based on the remaining principal.
| **Displaying Results** | | **Displays user loan data in the console.**
| Displaying schedule | *wyswietlanieHarmonogramu()* |  Presents the loan repayment schedule, showing for each month the principal part, interest part, overpayment amount, and remaining amount to be repaid.
| **Additional Information** | | **Additional functions**
| Displaying authors | *wyswietlanieAutorow()* | Displays information about the program’s authors.

## Application Modules

### Data Loading Module
* Responsible for entering user data such as loan amount, number of months, interest rate, and overpayment. The data is validated for correctness.

### Calculation Module
* Calculates the monthly loan installment, dividing it into principal and interest parts, based on the entered data. It considers the impact of overpayment on the remaining principal and modifies the repayment schedule.


# Description of Functions and Functionalities

### Function *wczytywanieKwotyKredytu*
* Collects the loan amount from the user. Checks if the entered value is a positive number. In case of an error, the user is asked to re-enter the data.

### Function *wczytywanieLiczbyMiesiecy*
* Responsible for entering the number of repayment months. Prevents entering negative or incorrect values.

### Function *wczytywanieOprocentowaniaKredytu*
* The user provides the annual interest rate in percentage. The program converts it to a monthly interest rate.

### Function *wczytywanieNadplatyKredytu*
* Allows the user to optionally enter an overpayment amount. Checks if the overpayment does not exceed the loan amount.

### Function *obliczanieOprocentowania*
* Calculates the monthly interest rate based on the annual interest rate.

### Function *obliczRateKredytu*
* Calculates the monthly loan installment, considering the principal and interest parts. The algorithm uses the formula for fixed installments.

### Function *wyswietlanieHarmonogramu*
* Displays a detailed repayment schedule, which includes information on the principal, interest parts, and overpayment.

# Installation and Configuration

## System Requirements

### Operating System
* Windows
* Linux
* macOS

### .NET SDK
* Version 6.0 or newer

### IDE 
* Visual Studio 2022 (or newer)

## Installation and Configuration
* **1.** Download and install the .NET SDK from the <a href = "https://developer.microsoft.com/en-us/windows/downloads/windows-sdk/">Microsoft</a> website..
* **2.** Open the project in Visual Studio or run it from the command line.
* **3.** Copy the program’s source files to the selected directory.
* **4.** In Visual Studio, select the Open Project option and point to the .csproj file, then click Run or use dotnet run in the command line.

# Code Documentation
* **Class Program**: The main class that contains all the program’s functions.
* **Functions wczytywanieKwotyKredytu, wczytywanieLiczbyMiesiecy, wczytywanieOprocentowaniaKredytu, wczytywanieNadplatyKredytu**: These functions load data from the user and handle potential errors, such as incorrect input values.
* **Function obliczRateKredytu**: The key algorithm that calculates the fixed loan installment using the equal installment formula.
* **Function wyswietlanieHarmonogramu**:  Displays the installment schedule on the console, dividing it into principal, interest, and remaining debt.

# Usage Examples

## Example 1
* **Input Data**
   * Loan amount: 10,000 PLN
   * Number of months: 24
   * Interest rate: 5%
   * Overpaymenta: none

* **Result:** Repayment schedule with a monthly installment of approximately 438.71 PLN (including principal and interest)

## Example 2
* **Input Data**
   * Loan amount: 50,000 PLN
   * Number of months: 60
   * Overpayment: 3%
   * Overpayment: 200 PLN monthly

* **Result:** Repayment schedule with overpayment, which shortens the repayment period and reduces interest

# Errors and Their Handling

## The application handles errors by
* Checking if the entered values are positive numbers.
* Handling incorrect data formats (e.g., letters instead of numbers).
* Limiting overpayment to an amount less than the remaining principal.

# Conclusions and Future Improvements

## Areas for Improvement
* Adding a graphical user interface (GUI) for better interaction.

## Conclusions:
The project was a valuable experience that taught us effective use of error handling functions and mathematical algorithms. In future versions, we could focus on expanding the program’s functionality and user interface.


# Authors
* *Jakub Golonka*
* *Krystian Frączek* 
* *Jakub Matras*
* *Łukasz Szewczyk*
