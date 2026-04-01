# N-Layer Architecture Generation Prompts

These prompts have been reverse-engineered from your **ClinicManagement** project. You can copy and paste them into any AI coding assistant (like ChatGPT, Claude, Gemini, etc.) to generate code for a **new domain** (e.g., School Management, Library Management, E-Commerce) using the exact same structure, design patterns, and result-wrapping mechanisms as your current application.

Replace the bracketed variables (like `{Domain}`, `{EntityName}`) with your target use case.

## 1. Project Setup & Architecture Skeleton
Use this prompt first to scaffold the entire solution and its layers.

```text
I want to build a {Domain e.g., Library Management} system using a multi-tier N-Layer Architecture in .NET 8.
Please create three projects inside a single solution:

1. `DataLayer` (.NET 8 Class Library):
   - Folders: `Contract`, `Data`, `Entities`, `Migrations`.
   - Packages: Microsoft.EntityFrameworkCore.SqlServer, Microsoft.EntityFrameworkCore.Tools.
2. `BusinessLayer` (.NET 8 Class Library):
   - Folders: `BusinessLogic`, `DTOsPresentation`, `Validations`, `Profiles`.
   - Packages: AutoMapper.
   - References: `DataLayer`.
3. `{Domain}API` (ASP.NET Core Web API):
   - Folders: `Controllers`, `Config`, `Middlewares`.
   - References: `BusinessLayer`.
```

## 2. Operation Result Wrappers
Your project relies heavily on passing encapsulated results rather than throwing exceptions. Use this prompt to recreate the `DataLayerOperationResult` and `OperationResult`.

```text
Please create the standardized generic operation result wrappers for the layers:

1. In `DataLayer.Data`, create an enum `DataLayerResult` (Success, Conflict, InternalError, NotFound, NoContent, updated).
2. Create `DataLayerOperationResult<T>` containing `ResultType`, `Message`, and `Data`. Add static factory methods like `SuccessOperation`, `Fail`, `NotFound`, and `InternalError` which instantiate and return the class.
3. In `BusinessLayer.BusinessLogic`, create an enum `ResultStatus` (Success, ValidationError, NotFound, Conflict, InternalError, Updated, Valid).
4. Create `OperationResult<T>` containing `Status`, `Message`, and `Data` with static factory methods (e.g., `Success`, `Updated`, `ValidationError`, `NotFound`, `Conflict`, `InternalError`).
```

## 3. Data Entities (Entity Framework)
Use this to generate the database schema models.

```text
For the {Domain} system, I need an Entity framework model representing {EntityName}.
1. Create `{EntityName}Entity.cs` inside `DataLayer/Entities`.
2. It should be a pure POCO class holding properties mapped to database columns. Do not use Data Annotations.
3. Include foreign key properties ending with `_FK` where appropriate (e.g. `EmployeeID_FK`).
4. Include `virtual` navigation properties for 1-to-N or N-to-N relationships (e.g., `ICollection<{ChildEntity}Entity>`).
```

## 4. Repositories (Contracts & Data Access)
Use this prompt to generate the data access layer for any new entity.

```text
Create the Repository contract and implementation for `{EntityName}Entity`:

1. In `DataLayer.Contract`, create an interface `I{EntityName}Repository`. All task methods must return `Task<DataLayerOperationResult<T>>`.
2. In `DataLayer.Data`, create `{EntityName}Data` (which acts as the repository implementation).
3. Inject the project's Entity Framework `DbContext`.
4. Wrap all Entity Framework operations inside `try-catch` blocks. Return `DataLayerOperationResult<T>.SuccessOperation(...)` upon success, and `DataLayerOperationResult<T>.InternalError(...)` on exception catching. Map constraint failures or null checks into `Conflict` or `NotFound`.
```

## 5. Domain Models & DTOs
This extracts your approach to decoupling the UI inputs from the database entities.

```text
Create the Domain Model and Request DTOs for `{EntityName}` in the `BusinessLayer`:

1. Create a Request DTO: `{EntityName}RequestDTO` inside the `DTOsPresentation/{EntityName}DTO` directory. 
2. Create a Business logic model: `{EntityName}.cs` inside `BusinessLogic`.
3. In the business model, include two constructors:
   - One mapping from an instance of `{EntityName}Entity` (to convert DB data to Domain).
   - One mapping from an instance of `{EntityName}RequestDTO` (to convert Request data to Domain).
4. Add an `internal static List<{EntityName}> {EntityName}EntityListToModel(List<{EntityName}Entity> entities)` mapping helper.
```

## 6. Business Services Layer
This is the core mapping and validation prompt mimicking your `DoctorServices.cs`.

```text
Create a service class named `{EntityName}Services` in `BusinessLayer.BusinessLogic`:

1. Inject `I{EntityName}Repository` and `IMapper` via constructor injection.
2. Implement CRUD logic returning `Task<OperationResult<T>>`.
3. In each method, call the repository, then use a `switch` statement on the returned `DataLayerResult` to convert it to `OperationResult`:
   - `DataLayerResult.Success` -> `OperationResult.Success(...)`
   - `DataLayerResult.Conflict` -> `OperationResult.Conflict(...)`
   - `DataLayerResult.NotFound` -> `OperationResult.NotFound(...)`
   - default -> `OperationResult<T>.InternalError(...)`
4. Use `AutoMapper` to map the Domain Model back to `{EntityName}Entity` before calling repository write methods.
```

## 7. Web API Controllers
Use this prompt to build endpoints that correctly respond with standard HTTP Status Codes derived from your `OperationResult` statuses.

```text
Create `{EntityName}Controller.cs` in the `{Domain}API` project inheriting from `ControllerBase`:

1. Inject `{EntityName}Services` via constructor injection.
2. Create asynchronous HTTP endpoints (e.g., Add, Get, Update, Delete).
3. Call the associated service method, then use a `switch` statement on the returned `OperationResult<T>.Status` to return the right HTTP response:
   - `ResultStatus.Success` -> `Ok(result.Data)`
   - `ResultStatus.NotFound` -> `NotFound(result.Message)`
   - `ResultStatus.Conflict` -> `Conflict(result.Message)`
   - `ResultStatus.ValidationError` -> `BadRequest(result.Message)`
   - `ResultStatus.InternalError` -> `StatusCode(500, result.Message)`
```
