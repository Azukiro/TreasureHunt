# Treasure Hunt - Console Application

## Description

This project simulates adventurers exploring the Madre de Dios region in Peru, collecting treasures on a rectangular map. Adventurers move across plains, avoid impassable mountains, and collect treasures following a predefined sequence of moves. The system processes adventurer movements and treasure collection, and outputs the final state of the map.

For full details on the problem and requirements, refer to the instructions in the [PDF](./instructions.pdf) provided in the repository.


## Technologies Used

- **Language**: C# 12.0
- **Framework**: .NET 8.0
- **Testing**: XUnit
- **Logging**: NLog
 
## Prerequisites

Before you begin, make sure you have the following installed:

- **.NET SDK 8.0**: You can download it from [Microsoft](https://dotnet.microsoft.com/download/dotnet/8.0).
- **IDE** (Choose one):
  - Visual Studio 2022 (or later) with .NET Desktop Development support and unit testing tools.
  - Rider (JetBrains) with .NET Desktop Development support and unit testing tools.

## How to Run the Project

### From the Command Line

1. **Restore dependencies**:
   ```bash
   dotnet restore
    ```
2. **Build the project**:
   ```bash
   dotnet build
    ```
3. **Run the application**:
    ```bash
   dotnet run --project Path/To/YourProject <inputFile> <outputFile>
    ```

### From Visual Studio

1. Open the project in **Visual Studio**.
2. Go to **Build** > **Build Solution** (or use the shortcut `Ctrl+Shift+B`).
3. Run the application by pressing the **Start** button or using the `F5` shortcut.


### From Rider

1. Open the project in **Rider**.
2. Go to **Build** > **Build Project**.
3. Run the project using the **Run** button.
## How to Run Tests

### From the Command Line

1. **Restore dependencies** (if not already done):
   ```bash
   dotnet restore
   ```
2. **Run the tests**:
   ```bash
   dotnet test
   ```

### From Visual Studio

1. Open the project in **Visual Studio**.
2. Go to **Test** > **Run All Tests** (or use the `Ctrl+R, A` shortcut).


### From Rider

1. Open the project in **Rider**.
2. Click the **Unit Tests** tab at the bottom of the IDE.
3. Click **Run All** to execute all tests.


## Log Configuration

The application logs information about the execution to a file named `.\log\treasure-map.log`. The log file is created in the same directory as the executable. The log file contains information about the application's execution, such as the start and end of the program and any errors that occurred during execution.

To configure the logging settings, modify the `NLog.config` file located in the root directory of the project. For more details on configuring NLog, refer to the [NLog documentation](https://nlog-project.org/config/).

## Authors

- [@Azukiro](https://github.com/Azukiro)

