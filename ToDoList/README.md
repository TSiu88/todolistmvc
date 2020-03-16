## Pair Program WFH Summary

- Group Members: Andrew Philpott, Tiffany Siu, Adela Darmansyah
- To Do List/Project Management Project
- SQL Practice
- Struggles: MySQL Workbench (always gave the same error: fail to connect to local server; must reinstall prior to use)

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
categoryitems
employeeitems

CategoryItems
CategoryId ItemId
1 1
1 2
1 3
2 4
1 5

Items
ItemId Title Desc Due CategoryId Complete
1
2
3

Employee
Id EmployeeId Name Developer ItemList

EmployeeItems
Id, EmployeeId, ItemId
EmployeeId ItemId
1 1
2 1
3 1
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
'
