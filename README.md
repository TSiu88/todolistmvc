# _[To Do List MVC](https://github.com/TSiu88/todolistmvc)_

#### _Practice with MVC and MySQL, 03.16.2020_

#### By _**Tiffany Siu, Andrew Philpott, and Adela Darmansyah**_

[![Project Status: WIP – Initial development is in progress, but there has not yet been a stable, usable release suitable for the public.](https://www.repostatus.org/badges/latest/wip.svg)](https://www.repostatus.org/#wip)
![LastCommit](https://img.shields.io/github/last-commit/tsiu88/todolistmvc)
![Languages](https://img.shields.io/github/languages/top/tsiu88/todolistmvc)
[![MIT license](https://img.shields.io/badge/License-MIT-orange.svg)](https://lbesson.mit-license.org/)

---
## Table of Contents
1. [Description](#description)
2. [Setup/Installation Requirements](#setup/installation-requirements)
    - [Requirements to Run](#requirements-to-run)
    - [Instructions](#instructions)
    - [Other Technologies Used](#other-technologies-used)
3. [Known Bugs](#known-bugs)
4. [Support and Contact Details](#support-and-contact-details)
5. [License](#license)
---
## Description

This project practices MVC and MySQL databases in an attempt to do a many to many database.

## Pair Program WFH Summary

- Group Members: Andrew Philpott, Tiffany Siu, Adela Darmansyah
- To Do List/Project Management Project
  - Currently not working
- SQL Practice
  - Researched how to not need to reinstall whenever start up MySQL after computer has been shut down
- Help answer questions for the new cohort
- Struggles: MySQL Workbench (always gave the same error: fail to connect to local server; must reinstall prior to use), Discord/Connection issues, understanding databases for the first day, data structure and placement of methods within classes/controllers, routes using razor link extensions,

<!-- ## Notes

Tasks? Categories, items - Task due

Tasks have different categories

- Back end, Front end?

Task/Item

- Title
- Description
- Due date
- CategoryID
- Completed (bool)

- Employees assigned to task
  -Type (1 step, 2 step process?) Process is completed after assigned to 2 different people
- or can just have it possible to check off task when completed manually?
- list of categories task falls into

Employee

- Name
- Profession/Specialties?
- Skill/experience level?
- Current tasks?

Project management.....
Employee - Profession (match with task)

Employee
Based on profession can work on different items. Items
what kind of profession values do we want to have?
1, 2, 3
Front end developer
back end developer
senior full stack developer
business processs

Categories
Create Item. This item must match

tables:
categories
items
employees
employeeitems

Categories
CategoryId Name Description
1 Front-end UI-design
2 Back-end Business Logic
3 ...

Items
ItemId Title Description Due CategoryId Complete
1 Class-A Code-class-A 3/16/20 2 false
2
3

Employee
Id Name Developer
1 Aname Front-end
2 ...

EmployeeItems
Id, EmployeeId, ItemId
Id EmployeeId ItemId
1 1 1
2 1 2
3 2 1
4

SELECT \*
FROM Items
Inner join categories
on items.categoryId = categories.Id

Select Id, Description, Title, Due, IsComplete
From Items O
Join CategoryItems I ON O.Id = I.itemId
Where categoryId is equal to this id
On
select all items from (table) items where categoryID = this category id -->

## Setup/Installation Requirements

_This program requires .NET Core SDK to run. [Here is a free tutorial](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-c-and-net) for installing .NET on Mac or Windows 10 from the [official website](https://dotnet.microsoft.com/download/dotnet-core/)._ 

_This program also makes use of SQL databases. We recommend using MySQL Workbench to build your databases. [Here is a free tutorial](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql) for installing MySQL WorkBench and MySQL Community Server on Mac (using links [Mac1](https://dev.mysql.com/downloads/file/?id=484914) and [Mac2](https://dev.mysql.com/downloads/file/?id=484391)) or [Windows 10](https://dev.mysql.com/downloads/file/?id=484919)._ 

### Requirements to Run

* _.NET Core_
* _ASP.NET Core MVC_
* _MySQL Workbench_
* _MySQL Community Server_
* _Entity Framework_
* _Command Prompt_
* _Web Browser_ 

### Instructions

*This application may be viewed by:*

1. Download and install .NET Core from the [official website](https://dotnet.microsoft.com/download/dotnet-core/)
2. Download and install MySQL Workbench and Community Server for Mac or Windows by following the instructions [here](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql).
3. Click clone the [repository](https://github.com/TSiu88/todolistmvc.git) from my [GitHub page](https://github.com/TSiu88) to copy the repository link
4. Use a command line interface to type `git clone (repository-link-here)` to copy the project into the current folder and then move into the repository's directory that was just created with `cd (project-name-here)`
5. Start up a local server by opening MySQL Workbench and adding a `MySQL Connections` using the default IP address and Port (IP 127.0.0.1, Port 3306), username (root), and password from setup.
6. Construct the database by entering in table info into MySQL Workbench
7. Run `dotnet restore` and `dotnet build` in command line interface of the repository's main project directory
8. Run `dotnet run` to start up the program in the command line interface
9. Type the URL listed under "Now listening on:" into a web browser to run

## Other Technologies Used

* _C#_
* _HTML_
* _CSS_
* _MSTest_
* _Razor_
* _Markdown_

## Known Bugs

_There are currently no known bugs in this program_

## Support and contact details

_If there are any question or concerns please contact me at my [email](mailto:tsiu88@gmail.com). Thank you._

### License

*This software is licensed under the MIT license*

Copyright (c) 2020 **_Tiffany Siu, Andrew Philpott, Adela Darmansyah_**

