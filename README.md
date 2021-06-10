## ShopBridge Backend Assignment

API to cover the basic CRUD operation for Item module.

#### Git Folder structure

**ShopBridge** - Contains the backend solution codebase

**DB** - Contains the sql script for generating necessary db objects

**Payload** - Contains snapshots of API methods

#### Application configuration

- Generate database and object using sql script in DB folder.
- Load ShopBridge solution using the ShopBridge.sln file under ShopBridge folder.
- Change the connection string in Connection.config file of service located in Service Layer> ShopBridge.Service > Config folder in solution.
- Run project, it will open up in new browser window with url http://localhost:59030/ This will be base url for accessing different operations of Item service.

#### Functional Aspects

- The ShopBridge API provide following operations
- Fetch all items as per paging
- Fetch specific item by item id
- Add new item
- Update existing item 
- Remove item (soft delete)

#### Technical Aspects

N-tier application to implemeted using WebAPI, EntityFramework, LINQ, SQL Server. Key features are as follows

- Dependency injection using Microsoft Unity block
- Mapping mechanism to transfer data from entities to models and reverse using AutoMapper
- Global exception handling using exception filter and logging in database
- Extension methods to generate customized success/failure responses from API
- Singleton pattern to initialize and configure entity mapper
- EF and LINQ used for Item Add/Update/Remove
- SQL Server stored procedure to fetch items with paging
