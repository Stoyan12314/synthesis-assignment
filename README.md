# Synthesis Project

A software solution for RobertHeijn B.V. that enables online shopping for customers and provides a desktop interface for staff to manage products, orders, and promotions.

---

## Table of Contents

- [Overview](#overview)
- [Features](#features)
  - [Staff (Desktop Application)](#staff-desktop-application)
  - [Customers (Website)](#customers-website)
  - [Visitors](#visitors)


---

## Overview

The **Synthesis Project** is designed to provide RobertHeijn B.V. with a comprehensive solution for online grocery shopping. The solution consists of:

- A **desktop application** for staff, enabling them to log in, manage grocery items (create, read, update, delete), update order statuses, and handle product categorization.
- A **web application** for customers, where they can register, log in, browse products, place orders, check order history, update shipping details, and even return items under specific conditions.
- A read-only view for visitors to browse the product catalog without placing orders.

---

## Features

### Staff (Desktop Application)

- **Authentication:** Secure login/logout for staff members.
- **Product Management:** 
  - Add new grocery items by specifying name, sub-category, category, price, and unit.
  - Edit existing grocery items.
  - Remove grocery items.
- **Order Management:** Update order statuses.
- **Category Management:** 
  - Create new categories.
  - Add sub-categories to existing categories.
- **Bonus Card Management:** Manage bonus points (add points, view current points, and deduct points).

### Customers (Website)

- **User Account:** 
  - Customer registration and login.
  - Ability to update account information, including shipping address.
- **Shopping:** 
  - Browse the product catalog.
  - Add items to a shopping cart.
  - Place orders by entering delivery details.
- **Order Tracking:** View current order status and complete order history.
- **Returns:** Initiate a return process for an item (with validation on time constraints).
- **Bonus Points:** Use accumulated bonus points during checkout.

### Visitors

- **Catalog Browsing:** 
  - View the product catalog without requiring registration or login.
  - Access detailed product information without the ability to make purchases.

---

## Architecture and UML

The project is structured in multiple layers:

- **Presentation Layer:**
  - **Desktop Application:** Developed using Windows Forms for staff operations.
  - **Web Application:** Built using ASP.NET Core to handle customer interactions.
  
- **Business Logic Layer:**
  - Contains managers and controllers (e.g., `OrderManager`, `ItemManager`, `UserManager`, `CategoryManager`, `BonusCardManager`, etc.) that implement the core functionality and business rules.
  
- **Data Access Layer:**
  - Responsible for database interactions using MySQL.
  - Classes such as `DBUser`, `DBOrder`, `DBItem`, and `DBCategory` provide CRUD operations and other data manipulation functionalities.
  
- **UML Design:**
  - The UML diagram details the classes, interfaces, enumerations, and their relationships (associations, generalizations, and realizations). It provides a clear overview of the system’s structure.
  - For a detailed view of the UML design, please refer to the project documentation or the UML diagram file included in the repository.

---

## Technologies

- **Programming Languages:** C#, HTML, CSS
- **Frameworks:** 
  - ASP.NET Core (Web Application)
  - Windows Forms (Desktop Application)
- **Database:** MySQL
- **Development Tools:** Visual Studio, SmartGit, GitLab

---

## Installation

### Prerequisites

- [.NET Framework / .NET Core SDK](https://dotnet.microsoft.com/download)
- [MySQL Server](https://dev.mysql.com/downloads/)
- [Visual Studio](https://visualstudio.microsoft.com/) or your preferred C# IDE
- [Git](https://git-scm.com/)

### Steps

1. **Clone the Repository:**

   ```bash
   git clone https://gitlab.com/your-repository-url.git
   ```

2. **Open the Solution:**
   - Open the solution file in Visual Studio.

3. **Restore NuGet Packages:**
   - Ensure all required NuGet packages are restored.

4. **Configure the Database:**
   - Update the connection string in the configuration file (e.g., `appsettings.json` or `Web.config`) to point to your MySQL database.

5. **Build the Project:**
   - Build the solution to compile the desktop and web applications.

6. **Run the Applications:**
   - Launch the desktop application for staff operations.
   - Run the web application (via IIS Express or your preferred method) for customer interactions.

---

## Contact

**Stoyan Grozdev**  
Email: [s.grozdev@student.fontys.nl](mailto:s.grozdev@student.fontys.nl)

---

## License

This project is licensed under the MIT License.

