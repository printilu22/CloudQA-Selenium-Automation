🌩️ CloudQA Selenium Automation

This project is a C# console application that automates form interactions on the [CloudQA Automation Practice Form](https://app.cloudqa.io/home/AutomationPracticeForm) using **Selenium WebDriver** and **ChromeDriver**.

## 📌 Features

- ✅ Launches Chrome browser and navigates to the form
- ✅ Fills the **First Name** field in standard HTML
- ✅ Switches to an **iframe** to fill **Mobile Number**
- ✅ Selects a **State** from a dropdown inside the iframe
- ✅ Takes screenshots after each step and on error
- ✅ Uses **WebDriverWait** for stable element interaction

## 🔧 Technologies Used

- C# (.NET)
- Selenium WebDriver
- ChromeDriver
- Visual Studio 2022+
- NuGet packages:
  - `Selenium.WebDriver`
  - `Selenium.Support`
  - `Selenium.WebDriver.ChromeDriver`

## 🚀 How to Run:
1. Clone the repo:
   ```bash
   git clone https://github.com/printilu22/CloudQA-Selenium-Automation.git
   cd AutomationFormTest

2. Install NuGet Packages:
     Open your project in Visual Studio.
     Run the following commands in the Package Manager Console:
   
        Install-Package Selenium.WebDriver
        Install-Package Selenium.WebDriver.ChromeDriver
        Install-Package Selenium.Support
   
4. `dotnet build`
5. `dotnet run`


## Solution Summary

*. Fields Tested:*

1. First Name: A text input in normal HTML, filled with "Iliyas".
2. Mobile Number: A text input inside an iframe, filled with "9876543210".
3. State: A dropdown inside the same iframe, set to "India".

*. Robustness:*
Flexible locators use multiple attributes (e.g., id, name, placeholder) with contains() for resilience against property changes.
Explicit waits (WebDriverWait) handle dynamic loading or position shifts.
The iframe locator combines id, name, and src for adaptability.

*. Features:*
Validates each field’s value after interaction.
Captures timestamped screenshots after each action and on errors for debugging.
Includes error handling and cleanup with driver.Quit().


## Output

Console: Logs success () or failure () for each field, plus screenshot status.
Screenshots: Saved as screenshot_after_name_*.png, screenshot_after_mobile_*.png, screenshot_after_state_*.png, and screenshot_error_*.png (on failure) with timestamps.


       



