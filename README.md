# DotNetMVCFoodService
 The DotNetMVCFoodService repository is an ASP.NET MVC app for snack bars, managing menus, inventory, and employees. It offers centralized menu creation, inventory management, and potential delivery integration. Built with .NET, it's a collaborative hub for enhancing snack bar operations.

## Setting Environment Variables for Database Migrations in Entity Framework Core

When executing the `Add-Migration` or `Update-Database` commands in the Package Manager Console in Visual Studio, you may need to manually set environment variables to ensure that the commands use the correct values from the environment configurations.

### Steps to Set Environment Variables in the Package Manager Console:

1. Open Visual Studio and navigate to the Package Manager Console (`Tools` > `NuGet Package Manager` > `Package Manager Console`).

2. Before executing the `Add-Migration` or `Update-Database` commands, manually set the environment variables using the `set` command. For example:

   ```plaintext
   set userid=your_username
   set pwd=your_password
   set port=your_database_port
   set database=your_database_name
