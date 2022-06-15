<a href="https://fontmeme.com/ben-10-font/"><img src="https://fontmeme.com/permalink/220615/a104da11aabf99c44433306f7cd6e9d8.png" alt="ben-10-font" border="0"></a>

![At'choo Banner](AtchooClient/wwwroot/img/banner-small.png)

#### By Meron Tekie, Mark McConnel, Caleb Coughenour, Marcus Lorenzo, Jake Edgar, and Evgeniya Meshuris
____
## A web application for an allergy-themed dating app 
___
## 🖥️ Technologies Used
* C#
* DotNet 
* Razor 
* HTML
* CSS
* Entity Core
* Identity Authorization
* MySQL
* Javascript
* REPL
* Git
* VsCode 
___
## ✅ Description

A web application that allows a user to create authentication and login to the website with their authenticated creditentials. After becoming an authorized user, a user can create a user profile and add their allergies. Once their user proflie and allergies have been added our application will match users with otherusers with complimentary/similar allergies for dating purposes. The application has user authentication and only logged-in users can create, update and delete. 
___
## ⚙️ Setup/Installation Requirements
---
* First, make sure you have MySql Workbench downloaded and properly installed. You will also need a text editor and a command line that you are comfortable with. 

* In your command line navigate to your desktop directory and clone this project using *Git Clone*

* Open the project in your preferred text editor, we recommend VSCode.
* In the root directory, confirm there is a .gitignore file
* Add:

    ```
    */obj/
    */bin/
    *.vscode
    */appsettings.json
    ```

* To the .gitignore file. It will keep your repository clean of unnecessary files and protect your database from unauthorized access
* Create an appsetting.json file at the root directory
* Open the appsetting.json file and enter: 

* To create the database please do as follows:

  * First create a file using the *touch* command in your command line, at the root of the project directory called "appsettings.json" and in that file add the following code, but substituting the text in the brackets for your own information. 

  ```
      { 
        "ConnectionStrings": { 
          "DefaultConnection": "Server=localhost;Port=3306;database=[your_database];uid=[Your ID];pwd=[Your Password];" 
        }
      }
  ```
* Run the following from the project directory of ```AtchooClient```
  * Run ```dotnet add package Microsoft.EntityFrameworkCore -v 5.0.0```
  * Run ```dotnet add package Pomelo.EntityFrameworkCore.MySql -v 5.0.0-alpha.2```
  * Run ```dotnet add package Microsoft.EntityFrameworkCore.Proxies -v 5.0.0```
  * Run ```dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 5.0.0```
* Once all of the necessary setup is in place, In your command line navigate to the directory "AtchooClient" and run the following commands in order:
    * ```dotnet restore```
    * ```dotnet build```
    * ```dotnet ef migrations add Initial```
* Once we have verified that the migration looks correct and made any necessary changes, we'll run the following commands: 
    * ```dotnet ef database update```
    * ```dotnet ef database update```
    * ```dotnet run```

* To interact with the local host website navigate to the project directory and run ```dotnet run```
* Click on  <http://localhost:5000>
___
## Known 🐛 Bugs

No known bugs at this time.
___
## 🎫 License 👈

Licensed under the [MIT License](LICENSE).
Copyright (c) 2022 Meron Tekie, Mark McConnel, Caleb Coughenour, Marcus Lorenzo, Jake Edgar and Evgeniya Meshuris