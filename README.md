# Clinic Management System API

## Short Project Overview
A backend system for managing daily clinic operations. It handles patients, doctors, appointments, and payments. The main users are clinic administrators, receptionists, and doctors who need a reliable way to manage their workflows.

## Features

### Authentication & Authorization
* User login and token generation
* JWT-based secure authentication

### Patient Management
* Add, update, and retrieve patient profiles
* Manage patient medical records and personal details

### Staff Management
* Manage doctors, employee profiles, and roles
* Track doctor types and consultation modes

### Appointments
* Book, update, and cancel patient appointments
* Track appointment statuses and types
* Assign patients to available doctors and clinics

### Billing & Payments
* Manage payment records for appointments
* Configured for external payment provider integration (e.g., PayPal)

### Logging & Validation
* Structured event logging using Serilog
* Input data validation to prevent bad requests
* Global error handling to return clean HTTP responses

## Tech Stack
* **Framework:** ASP.NET Core Web API (.NET 8)
* **Database:** SQL Server
* **ORM:** Entity Framework Core 8
* **Authentication:** JWT (JSON Web Tokens)
* **Object Mapping:** AutoMapper
* **Logging:** Serilog
* **Testing:** XUnit for unit testing

## Architecture
The project follows a clean **3-Tier Architecture** to ensure maintainability:
* **API Layer:** Controllers that handle HTTP requests and responses.
* **Business Layer:** Contains business logic, validation, and object mapping. It uses **DTOs (Data Transfer Objects)** to hide internal database models from the client.
* **Data Layer:** Uses Entity Framework Core and the **Repository Pattern** for clean database access.

This structure ensures a clear **Separation of Concerns**, making the code easier to test, read, and extend.

## Database Design
* **Tables:** 16 structured tables including Patients, Doctors, Appointments, Payments, and Clinics.
* **Relationships:** Logical One-to-Many and Many-to-Many relationships (e.g., an Appointment connects a Patient, a Doctor, and a Clinic).
* **Constraints & Indexing:** Primary keys, foreign keys, and required data constraints are configured via EF Core Migrations to maintain data integrity.

## API Endpoints
Here are some of the most important endpoints in the system:

**Authentication**
* `POST /api/Auth/Login` - Authenticate a user and return a JWT

**Patients**
* `GET /api/Patient` - Retrieve a list of patients
* `GET /api/Patient/{id}` - Retrieve details of a specific patient
* `POST /api/Patient` - Register a new patient
* `PUT /api/Patient/{id}` - Update a patient record

**Doctors**
* `GET /api/Doctor` - Retrieve all doctors
* `POST /api/Doctor` - Add a new doctor profile

**Appointments**
* `GET /api/Appointment` - View all appointments
* `POST /api/Appointment` - Book a new appointment
* `PUT /api/Appointment/{id}` - Update appointment details



## How to Run the Project

1. **Clone the repository:**
   ```bash
   git clone <repository-url>
   ```

2. **Database Setup:**
   * Open `ClinicAPI/appsettings.json`.
   * Find the `constr` connection string and update it to match your local SQL Server instance.

3. **Apply Migrations:**
   Open the Package Manager Console or your terminal and run:
   ```bash
   dotnet ef database update --project DataLayer --startup-project ClinicAPI
   ```

4. **Run the API:**
   ```bash
   cd ClinicAPI
   dotnet run
   ```

## Future Improvements
* Add Redis caching for frequently accessed data like the list of clinics or doctors.
* Implement pagination and filtering for endpoints that return large lists.
* Add a background task worker to send appointment reminder emails.

## Folder Structure
```text
Clinic-Management/
├── BusinessLayer/        # Business logic, DTOs, and AutoMapper profiles
├── ClinicAPI/            # Controllers, Middlewares, and Program.cs
├── Clinic_Test/          # XUnit test projects for the modules
└── DataLayer/            # DbContext, Entities, Repositories, and Migrations
```

## Conclusion
This project demonstrates my ability to build a practical, well-structured backend system using modern .NET technologies. It focuses on clean architecture, secure authentication, and proper database management, reflecting the daily responsibilities and best practices of a backend engineer.
