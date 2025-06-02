# ShapeShifter2D

A robust 2D vector graphics editor developed in C# with Windows Forms. This project serves as a comprehensive demonstration of fundamental computer graphics principles and interactive graphical user interface (GUI) development.

## 🚀 Overview

ShapeShifter2D allows users to create, manipulate, and organize various 2D vector shapes on a canvas. It's designed to provide a practical understanding of how vector-based drawing systems are implemented.

## ✨ Features

* **Primitive Drawing:** Create basic vector shapes like rectangles, ellipses, and lines.
* **Interactive Selection:** Select individual or multiple shapes via mouse interaction.
* **Shape Manipulation:**
    * **Translation:** Move shapes freely across the canvas.
    * **Scaling:** Resize shapes dynamically.
    * **Rotation:** Rotate shapes around their center.
* **Hierarchical Grouping:** Organize primitives and other groups into complex hierarchical structures.
    * Manipulate groups as a single entity (move, scale, rotate).
    * Support for various ungrouping options.
* **Visual Customization:** Adjust properties like fill color, border color, border width, and opacity.
* **Multi-Window Support:** Work on multiple independent drawing documents simultaneously.
* **Object Naming:** Assign custom names to shapes for easier identification.
* **Persistence:** Load and save drawings to external files.

## 💻 Technologies & Approaches

* **C#:** The primary programming language for the application logic.
* **Windows Forms (WinForms):** Used for building the desktop graphical user interface.
* **GDI+ (Graphics Device Interface Plus):** Leveraged for all 2D drawing operations on the canvas, providing robust rendering capabilities.
* **Object-Oriented Programming (OOP):** Core principles applied for modular and extensible design (e.g., `Shape` base class, inheritance for specific primitives, `GroupShape` for composition).
* **Hierarchical Transformations:** Implementation of matrix transformations to handle complex rotations, scaling, and translations, especially for grouped objects, ensuring accurate rendering and manipulation.
* **Event-Driven Architecture:** Utilizes standard WinForms events for user interaction (mouse clicks, moves, keyboard input, menu selections).
* **Serialization:** For saving and loading the drawing model.

## 🛠️ Usage

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/YourGitHubUsername/ShapeShifter2D.git](https://github.com/Nikzr0/ShapeShifter2D.git)
    ```
2.  **Open in Visual Studio:** Open the `Draw.sln` solution file in Visual Studio (2019 or newer recommended).
3.  **Run the application:** Build and run the project (F5).
4.  **Start Drawing:** Use the tools and menus to create and manipulate shapes. Experiment with grouping, transformations, and opening new drawing windows via `File > New`.
