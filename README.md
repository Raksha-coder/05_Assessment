# Patient Assessment Management System

This project is a **full-stack web application** built using **Angular**, **.NET Core**, and **SQL Server** that enables healthcare providers to manage patient assessments efficiently. The system follows the principles of **Clean Architecture** for backend development and utilizes **Entity Framework Core (EF Core)** for data access.

## 🛠️ Technologies Used

### Frontend:
- **Angular**
- **Angular Material**
- **Reactive Forms (Dynamic Form Rendering)**

### Backend:
- **.NET Core** (Clean Architecture)
- **Entity Framework Core (EF Core)**

### Database:
- **SQL Server**

---

## 📋 Features

### 🔹 Assessment Page (Frontend)
- A route to view the **list of assessments** associated with a patient.
- An option to **add a new assessment** with health-related questions.
- Uses a **dynamic form** to generate and render patient-specific questions dynamically at runtime.
- Assessment responses are submitted and saved through API calls to the backend.

### 🔹 Backend (Clean Architecture)
- Follows the **Clean Architecture** pattern with layers:
  - **Domain**
  - **Application**
  - **Infrastructure**
  - **Web API**
- Uses **EF Core** for database operations.
- Implements a clear separation of concerns for maintainability and scalability.
- Handles data validation and business logic within appropriate layers.

---

## 📁 Project Structure

### Backend (`.NET Core`)
/Domain
Entities
Interfaces

/Application
DTOs
Services
Interfaces

/Infrastructure
Data
EF Repositories
Configurations

/WebAPI
Controllers
Middleware
DI Configuration


### Frontend (`Angular`)
/src
/app
/assessment
- assessment-list.component.ts
- add-assessment.component.ts
/services
- assessment.service.ts

- 
---

## 🔄 Workflow

1. The user navigates to the **Assessment List Page** to view existing assessments.
2. Clicking on **Add Assessment** opens a dynamic form built from backend-provided metadata.
3. The user fills out the form and submits their responses.
4. The data is validated and saved in the database using the backend API.

---

## 🚀 How to Run the Project

### Backend
1. Navigate to the backend project folder.
2. Run the following commands:

```bash
dotnet restore
dotnet ef database update
dotnet run
