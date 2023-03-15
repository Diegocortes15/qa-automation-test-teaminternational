# QA Automation Test TEAM International

## Previous Requirements

- Install [Visual Studio Code](https://code.visualstudio.com/download)
- Install [.NET](https://dotnet.microsoft.com/en-us/download)

**_NOTE:_** Once you have already installed [.NET](https://dotnet.microsoft.com/en-us/download) make sure that you have set the environment variables correctly.

## Download and Open Project

### Workaround 1

#### Download Project

1. Click on the code button in this repository
2. Select the Download Zip option
3. Extract the .zip file with the **Extract here** option
4. Place the project folder on the desired location

#### Open Project

- **<u>First way</u>:** Right click on the folder and open it with Visual Studio Code
- **<u>Second way</u>:** Open Visual Studio code and drag the folder in Visual Studio Code Window
- **<u>Third way</u>:** Open Visual Studio, on top bar, click File and Open Folder or press `Ctrl+K Ctrl+O`, then choose the folder where you save it

### Workaround 2 - Gitbash

1. Select the folder when you would like clone the project
2. Clone: Open gitbash and paste the following command

```bash
git clone https://github.com/Diegocortes15/qa-automation-test-teaminternational.git
```

3. Open: Paste the following command to open up the project

```bash
cd qa-automation-test-teaminternational
```

```bash
code .
```

## Running Project

- In Visual Studio Code, open new terminal with `` Ctrl+Shift+` `` or `Ctrl+Shift+ñ` or on top bar click **Terminal**, then click **New Terminal**

- Type `dotnet run` to run the project

```bash
dotnet run
```

## Tests

### Triangle Not Valid

A(1, 1) B(2, 2) C(3, 3)

### Right Triangle

A(0, 0) B(3, 4) C(3, 0)

### Right and Equivalent Triangle

A(0, 0) B(0, 4) C(4, 0)

### Isosceles Triangle

A(0, 0) B(2, 3.46) C(4, 0)
