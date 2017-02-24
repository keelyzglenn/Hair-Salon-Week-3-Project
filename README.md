# Hair Salon
## by Keely Silva-Glenn

## Description

This is an app for a Hair Salon. In the app an employee can see all stylist with their personal information including their client lists. The app allows an employee to add, edit, and delete both stylist information and client information.

## Setup and Installation

* Clone repository
* Open index.html in browser of your choice

### Recreate Database

In SQLCMD:
* CREATE DATABASE hair\_salon;
* GO
* USE hair\_salon;
* GO
* CREATE TABLE clients (name VARCHAR(255), stylist_id INT, id INT IDENTITY(1,1));
* GO
* CREATE TABLE stylist (name VARCHAR(255), shift VARCHAR(255), specialty VARCHAR(255), id INT IDENTITY(1,1));
* GO

## Link
https://github.com/keelyzglenn/Hair-Salon-Week-3-Project

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

## Legal
MIT License

Copyright (c) 2017 Keely Silva-Glenn
