# WinAppDriver - Test to check setup
## 📋 WinAppDriver Complete Setup Guide

### **Step 1: Enable Developer Mode on Windows 10/11**

**Purpose:** Required for WinAppDriver to access and control Windows apps.

**Instructions:**
1. Press `Win + I` to open Settings
2. Navigate to **System → For developers**
3. Toggle **Developer Mode** to **ON**
4. Click **Yes** to confirm the warning dialog
5. Windows will install the required Developer Mode package
6. Restart your computer (recommended)

---

### **Step 2: Download WinAppDriver**

**Official GitHub Repository:** 
- **Link:** https://github.com/Microsoft/WinAppDriver/releases
- Download the latest `.msi` installer (e.g., `WinAppDriver.msi`)

**Download Steps:**
1. Visit the releases page above
2. Find the latest stable release
3. Download `WinAppDriver.msi` file
4. Save to your Downloads folder

**Current Stable Version:** recommended

---

### **Step 3: Install WinAppDriver**

**Installation Process:**
1. Double-click `WinAppDriver.msi`
2. Follow the installer wizard
3. Accept the license agreement
4. Choose installation directory (default: `C:\Program Files\Windows Application Driver\`)
5. Click **Install**
6. Click **Finish** when complete

**Verify Installation:**
- Navigate to `C:\Program Files\Windows Application Driver\`
- Confirm you see `WinAppDriver.exe`

---

### **Step 4: Start WinAppDriver Service**

**Option A: Manual Startup (Development)**
1. Open **Command Prompt** or **PowerShell** as Administrator
2. Navigate to: `C:\Program Files\Windows Application Driver\`
3. Run:
```powershell
WinAppDriver.exe
```
4. You should see output like:
```
Windows Application Driver listening on http://127.0.0.1:4723/
Press any key to exit...
```

**Option B: Run as Service (Production)**
1. Open **Services** (`services.msc`)
2. Look for **Windows Application Driver**
3. Right-click → **Properties**
4. Set **Startup type** to **Automatic**
5. Click **Start**

**Key Information:**
- **Default URL:** `http://127.0.0.1:4723`
- **Port:** 4723
- **Keep running** while executing tests

---

### **Step 5: Install Windows SDK (For Element Inspection)**

**Purpose:** Use `Inspect.exe` tool to identify UI elements for automation.

**Installation:**
1. Download Windows SDK from: https://developer.microsoft.com/en-us/windows/downloads/windows-sdk/
2. Run the installer
3. Select **Debugging Tools for Windows**
4. Complete installation

**Using Inspect.exe:**
1. Press `Win + R`
2. Type: `Inspect.exe`
3. Click **OK**
4. Use the **pointing tool** to identify element properties:
   - ClassName
   - AutomationId
   - Name attribute
5. These properties help you build your test locators

---

### **Step 6: Install Appium.WebDriver NuGet Package**

**For your .NET 8 project:**

**Command Line:**
```powershell
dotnet add package Appium.WebDriver --version 4.4.1
```

**Or via NuGet Package Manager:**
```
Package: Appium.WebDriver
Version: 4.4.1 (or latest stable)
```

**NuGet Package Page:** https://www.nuget.org/packages/Appium.WebDriver/

---

### **Step 7: Configure Your Test Project**

**Project Structure (Your Setup):**
- ✅ Target Framework: `.NET 8.0`
- ✅ Test Framework: `NUnit`
- ✅ WebDriver Package: `Appium.WebDriver`
- ✅ ImplicitWait: 10 seconds (in Setup method)

**Key Classes Used:**
```csharp
using OpenQA.Selenium.Appium.Windows;    // WindowsDriver
using OpenQA.Selenium.Appium;            // AppiumOptions
using OpenQA.Selenium;                   // By, Keys, IWebElement
```

---

### **Step 8: Write and Run Your First Test**

**Your Current Test File:** `UnitTest1.cs` ✅

**Running Tests:**
```powershell
cd to your class file path
dotnet test
```

**Test Execution Flow:**
1. ✅ WinAppDriver service running on port 4723
2. ✅ Test [SetUp] creates AppiumOptions with desired capabilities
3. ✅ WindowsDriver connects to WinAppDriver
4. ✅ Test executes automation steps
5. ✅ Test [TearDown] closes the application

---

## 🔧 Troubleshooting Common Issues

| Issue | Solution |
|-------|----------|
| **Connection refused (127.0.0.1:4723)** | Ensure WinAppDriver.exe is running; restart service if needed |
| **"Developer Mode not enabled"** | Go to Settings → For developers → Enable Developer Mode |
| **"Element not found"** | Use Inspect.exe to verify correct ClassName or AutomationId |
| **Application not launching** | Verify app path is correct; use full path (e.g., `C:\\Windows\\notepad.exe`) |
| **Permission denied errors** | Run Command Prompt/PowerShell as Administrator |

---

## 📚 Official Resources & Documentation

| Resource | Link | Purpose |
|----------|------|---------|
| **WinAppDriver GitHub** | https://github.com/Microsoft/WinAppDriver | Official source, releases, issues |
| **WinAppDriver Wiki** | https://github.com/Microsoft/WinAppDriver/wiki | Comprehensive documentation |
| **Appium Documentation** | https://appium.io/docs/en/latest/ | WebDriver protocol reference |
| **NuGet - Appium.WebDriver** | https://www.nuget.org/packages/Appium.WebDriver/ | Package info & versions |
| **Windows SDK** | https://developer.microsoft.com/en-us/windows/downloads/windows-sdk/ | Required for Inspect.exe tool |
| **Selenium .NET Docs** | https://www.selenium.dev/documentation/webdriver/ | C# WebDriver patterns |
| **NUnit Framework** | https://docs.nunit.org/ | NUnit test framework docs |
| **WinAppDriver** | https://devstringx-technologies.medium.com/windows-application-driver-winappdriver-with-c-devstringx-8181764bca3 | Windows Application Driver (WinAppDriver) With C# — Devstringx|

---

## 🚀 Quick Reference Checklist

- [ ] **Developer Mode Enabled** (Settings → For developers)
- [ ] **WinAppDriver Installed** (`C:\Program Files\Windows Application Driver\`)
- [ ] **WinAppDriver Running** (Port 4723 listening)
- [ ] **Windows SDK Installed** (with Inspect.exe)
- [ ] **Appium.WebDriver NuGet Package** (v4.4.1+)
- [ ] **Test File Created** (UnitTest1.cs with 10 tests)
- [ ] **Project Compiles** (dotnet build successful)
- [ ] **Tests Ready to Run** (dotnet test)

---

## 💡 Next Steps

1. **Verify Setup:** Run `dotnet test` with WinAppDriver running
2. **Inspect Elements:** Use Inspect.exe on Notepad to find element properties
3. **Expand Tests:** Add more test cases for additional features