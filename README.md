

# Parky API - Smart Parking Management Backend 🚗🔧  

**Parky API** is a RESTful API built with **ASP.NET Core**, designed to manage parking spaces, reservations, and user authentication. It serves as the backend for the **Parky** smart parking management system, providing endpoints for seamless interaction with the front-end web application.  

## ✨ Features  
✅ **User Authentication** – Secure login and token-based authentication using JWT.  
✅ **Parking Slot Management** – Add, update, delete, and retrieve parking slots.  
✅ **Reservation System** – Users can reserve, cancel, and manage bookings.  
✅ **Real-time Availability** – Fetch available and occupied slots dynamically.  
✅ **Admin Role Management** – Control user roles and permissions.  
✅ **RESTful API** – Designed for easy integration with any front-end application.  
✅ **Payment Integration** (if applicable) – Supports online payments for reservations.  
✅ **Logging & Error Handling** – Built-in logging for debugging and monitoring.  

## 🛠️ Tech Stack  
- **ASP.NET Core Web API** – Backend framework  
- **Entity Framework Core** – ORM for database management  
- **SQL Server** – Relational database  
- **JWT Authentication** – Secure token-based authentication  
- **Swagger** – API documentation and testing  

## 📌 Endpoints Overview  
| Method | Endpoint | Description | Auth Required |
|--------|---------|-------------|--------------|
| `POST` | `/api/auth/register` | Register a new user | ❌ |
| `POST` | `/api/auth/login` | Authenticate user and get JWT token | ❌ |
| `GET` | `/api/parking-slots` | Get all parking slots | ❌ |
| `POST` | `/api/parking-slots` | Add a new parking slot | ✅ (Admin) |
| `PUT` | `/api/parking-slots/{id}` | Update parking slot details | ✅ (Admin) |
| `DELETE` | `/api/parking-slots/{id}` | Remove a parking slot | ✅ (Admin) |
| `POST` | `/api/reservations` | Book a parking slot | ✅ (User) |
| `GET` | `/api/reservations/user/{id}` | Get user reservations | ✅ (User) |
| `DELETE` | `/api/reservations/{id}` | Cancel a reservation | ✅ (User) |

## 🚀 Installation & Setup  
1. **Clone the repository**  
   ```bash
   git clone https://github.com/it2121/Parky.git
   cd Parky
   ```
2. **Configure the database**  
   - Update `appsettings.json` with your **SQL Server** connection string.  
   - Run migrations to set up the database:  
     ```bash
     dotnet ef database update
     ```
3. **Run the API**  
   ```bash
   dotnet run
   ```
4. **Test the API using Swagger**  
   Open your browser and visit:  
   ```
   http://localhost:5000/swagger
   ```

## 📜 License  
MIT License – Free to use, modify, and contribute!  

---

This should be a solid start! Let me know if you want any refinements. 🚀
