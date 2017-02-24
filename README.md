
As an employee, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist.
As an employee, I need to add new stylists to our system when they are hired.
As an employee, I need to be able to add new clients to a specific stylist.
As an employee, I need to be able to update a client's name.
As an employee, I need to be able to delete a client if they no longer visit our salon.

# Hair Salon
## by Keely Silva-Glenn

## Description

This is an app for a Hair Salon. In the app an employee can see all stylist with their personal information including their client lists. The app allows an employee to add, edit, and delete both stylist information and client information.

## Setup and Installation

* Clone repository
* Open index.html in browser of your choice

### Recreate Database

In SQLCMD:
* CREATE DATABASE to\_do;
* GO
* USE to\_do;
* GO
* CREATE TABLE categories (id INT IDENTITY(1,1), name VARCHAR(255));
* CREATE TABLE tasks (id INT IDENTITY(1,1), description VARCHAR(255));
* GO

## Technologies Used

* HTML
* Bootstrap
* CSS
* C#
* Nancy
* SQL

## Specs
#### Salon employee can view a list of all stylists.
* Input: View all stylists
* Output: Kendra, Maddy, Keely

#### Salon employee can select stylist and view their information
* Input: Select Kendra
* Output: Name: Kendra, Hire Date: 01-02-2017, Specialty: Mens hair

#### Salon employee can view each stylists list of clients
* Input: Kendras Clients
* Output: Jack, Tom, Jerry, John

#### Salon employee can add new stylists into the system
* Input: Add new Stylist
* Output: Enter stylist name: _____, stylist hire date: ____________, stylists specialty: ________

#### Salon employee can add new clients to a stylist  
* Input: Add Client
* Output: Client name: _______ client stylist: _______

#### Salon employee can edit client name
* Input: Edit Client
* Output: Client new name: ________

#### Salon employee delete client
* Input: Delete Client
* Output: Are You sure you want to delete client? Y or N?..... Client deleted

## Ice Box


## Legal
MIT License

Copyright (c) 2017 Keely Silva-Glenn
