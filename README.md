# API for project management

This is an API for project management, with the primary goal of showcasing the implementation of Domain-Driven Design (DDD) and Clean Architecture in C# with .NET 7. It is still under development and currently in its initial phase. There will be numerous decisions made here, with a sole focus on experimentation, as I do not have any intention of deploying this application for real users (at least not yet).

## Overview
The API primarily focuses on the creation and basic management of a project. To achieve this goal, a registered user must create a project, define tasks for that project, and assign other members to these tasks. The registered user becomes the project manager. Simple and practical.

For the sake of simplicity, the endpoints, services, and data access repositories have been initially implemented. Authentication and authorization details have not been implemented yet and will not be for the time being. KISS (Keep It Simple, Stupid).

The solution consists of four distinct projects, reflecting the layers of clean architecture. These layers are:

1. API: Our presentation layer and interface with the external user;
2. Infra: Our infrastructure layer responsible for interacting with external resources and handling eventual complexity, such as our database;
3. Application: Our application layer where we implement all the logic needed to achieve our goal;
4. Core: Our domain layer, where our entities and abstractions for data access repositories are located, for example.

### Database
I chose to initially use MS SQL Server. To interact with the database code-first, I used Entity Framework, but there's nothing preventing the use of others like Dapper or NHibernate in the future. Currently, the code is moving towards lower coupling and greater abstraction of the layers, especially data access, which favors these decisions.

### Implemented
- Repositories and their Abstractions
- Controllers with IoC (Inversion of Control)
- Services and their Abstractions
- Data access via EF Core to SQL Server
- Basic Exception handling

### Next Implementations
- Exception handling
- Rich domain models
- Authentication and Authorization
- Adding tests



