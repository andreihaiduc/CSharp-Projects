# C# Windows Forms Projects

A collection of C# projects built with Windows Forms in Visual Studio. I created them while preparing for the **County and National C# Olympiad in Romania**. Each folder in this repository is a separate project. All projects are built the same way, so the instructions below apply to every one of them.

---

## 📂 Where to find the code I wrote

Each project contains many files, but most of them are generated automatically by Visual Studio. The code I wrote (the application logic) is in the **`FormX.cs`** files: `Form1.cs`, `Form2.cs`, `Form3.cs` and so on, one for each window in the application. A project can have one or more forms.

| File | What it contains |
|---|---|
| `Form1.cs`, `Form2.cs`, … | **Code I wrote**: the application logic for each window |
| `Form1.Designer.cs`, `Form2.Designer.cs`, … | Auto-generated: buttons, labels and the layout of each window |
| `Program.cs` | Auto-generated: starts the application and opens the first window (`Form1`) |
| `.sln` / `.csproj` | Project files: open these in Visual Studio to load the whole project |
| `bin/Debug/` | The compiled application (the `.exe` file) |

### On GitHub
1. Open a project folder.
2. Click any `FormX.cs` file (for example `Form1.cs`) to view the code directly in your browser.

### In Visual Studio
1. Open the project folder and double-click the **`.sln`** file. If there is no `.sln` file, open the **`.csproj`** file instead.
2. In **Solution Explorer** (on the right), **right-click a `FormX.cs` file → View Code** (or select it and press **F7**).

> ⚠️ Always open the `.sln` file, not individual `.cs` files. Opening a `.cs` file directly from File Explorer shows it as plain text, without the rest of the project, so you cannot run the application or see the designer.

> ⚠️ In Solution Explorer, double-clicking a `FormX.cs` file opens the **visual designer**, not the code. Use **View Code** instead.

---

## ▶️ How to run a project without Visual Studio

1. On the main page of this repository, click the green **`<> Code`** button (above the file list, on the right).
2. In the menu that opens, click **Download ZIP**.
3. Open the downloaded `.zip` file, right-click it and choose **Extract All**.
4. Open the extracted project folder, then go to **`bin` → `Debug`**.
5. Double-click the **`.exe`** file (it has the same name as the project).

> ⚠️ If you see the message **"Windows protected your PC"**, click **More info → Run anyway**. It appears because the application is not digitally signed, not because it is harmful.

**Requirements:** Windows 10 or 11 (.NET Framework is already included).

---

## ▶️ How to run a project from Visual Studio

1. Open the `.sln` file in the project folder (see above).
2. Press **F5** or click the green **Start** button.

---

## 🎉 Have fun!

Feel free to explore the code, run the projects and play around with them. Enjoy! 😄
