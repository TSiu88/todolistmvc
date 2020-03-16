## Pair Program WFH Summary

- Group Members: Andrew Philpott, Tiffany Siu, Adela Darmansyah
- To Do List/Project Management Project
  - Currently not working
- SQL Practice
  - Researched how to not need to reinstall whenever start up MySQL after computer has been shut down
- Help answer questions for the new cohort
- Struggles: MySQL Workbench (always gave the same error: fail to connect to local server; must reinstall prior to use), Discord/Connection issues, understanding databases for the first day, data structure and placement of methods within classes/controllers, routes using razor link extensions,

## Notes

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
select all items from (table) items where categoryID = this category id
