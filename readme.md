# AnimeNexus API Backend

## Project Overview

This project is the backend API for a MyAnimeList (MAL) clone application, named AnimeNexus. It provides endpoints for user authentication, fetching anime data, retrieving producer information, and accessing seasonal anime details. The API leverages the external Jikan API for sourcing anime-related information.

## Features

- **User Authentication:**
  - User registration (`/api/auth/register`).
  - User login with JWT token generation (`/api/auth/login`).
- **Anime Data:** (`/api/anime`)
  - Search anime by name.
  - Get detailed anime information by MAL ID.
  - Get anime lists filtered by genre, status, or studio.
  - Get ranked anime lists (e.g., top by popularity, score).
  - Get a list of random anime.
  - Get anime recommendations.
- **Producer Data:** (`/api/producers`)
  - Get a list of anime producers/studios.
  - Get detailed information about a specific producer by ID.
- **Seasonal Anime Data:** (`/api/season`)
  - Get anime airing in the current season.
  - Get anime from a specific year and season.
  - Get anime scheduled for upcoming seasons.
  - Get a list of historically available seasons.
- **Health Check:**
  - Basic endpoint to verify API status (`/api/health`).

## Technologies Used

- **.NET 8 / ASP.NET Core 8:** Framework for building the web API.
- **Entity Framework Core 9:** ORM for database interaction.
- **PostgreSQL:** Relational database used for storing user data.
- **JWT Bearer Authentication:** For securing API endpoints.
- **AutoMapper:** For object-to-object mapping (e.g., Entities to DTOs).
- **Jikan API Client:** Custom client ([`JikanApiClient`](/home/jbct/Projects/MAL-CLONE/backend/AnimeNexus.API/Infrastructure/ExternalServices/JikanApiClient.cs)) to interact with the external Jikan API.
- **Swagger/OpenAPI:** For API documentation and testing UI.
- **BCrypt.Net-Next:** For hashing user passwords.

## API Endpoints

The API exposes several endpoints grouped by functionality:

- `/api/auth`: Handles user registration and login.
- `/api/anime`: Provides various ways to query anime data.
- `/api/producers`: Provides endpoints for anime producer information.
- `/api/season`: Provides endpoints for seasonal anime data.
- `/api/health`: Basic health check.

### Detailed Endpoints

Auth Endpoints

- POST `/api/auth/register` - Register a new user
- POST `/api/auth/login` - Authenticate and receive JWT token

Anime Endpoints

- GET `/api/anime` - Get anime list with filtering options
- GET `/api/anime/{id}` - Get detailed information about specific anime
- GET `/api/anime/genre/{genre}` - Get anime by genre
- GET `/api/anime/top-anime/{order}` - Get top anime ordered by various metrics
- GET `/api/anime/status/{status}` - Get anime by airing status
- GET `/api/anime/search/{animeName}` - Search for anime by name
- GET `/api/anime/recommendations` - Get anime recommendations
- GET `/api/anime/random` - Get random anime
- GET `/api/anime/studio/{studioId}` - Get anime from a specific studio

Producer Endpoints

- GET `/api/producers` - Get list of producers with filtering options
- GET `/api/producers/{id}` - Get detailed information about a specific producer

Season Endpoints

- GET `/api/season/current` - Get current season anime
- GET `/api/season/{year}/{season}` - Get anime from specific season and year
- GET `/api/season/available` - Get list of all available seasons
- GET `/api/season/upcoming` - Get upcoming season anime

Detailed information about each endpoint, including request/response models and parameters, can be explored using the Swagger UI available at `/swagger` when the application is running.

## Setup and Installation

1.  **Prerequisites:**
    - .NET 8 SDK ([Download](https://dotnet.microsoft.com/download/dotnet/8.0))
    - PostgreSQL Server (Version 12 or higher recommended)
    - Git
2.  **Clone the Repository:**
    ```bash
    git clone <repository-url>
    cd backend
    ```
3.  **Configure Settings:**
    - **Database Connection:** Update the `DefaultConnection` string in [`appsettings.json`](/home/jbct/Projects/MAL-CLONE/backend/appsettings.json) (or preferably use User Secrets for development) to point to your PostgreSQL database.
      ```json
      // filepath: appsettings.Development.json or User Secrets
      {
        "ConnectionStrings": {
          "DefaultConnection": "Host=localhost;Database=your_db_name;Username=your_username;Password=your_password;"
        }
        // ... other settings
      }
      ```
    - **JWT Configuration:** Set the JWT secret, issuer, and audience in [`appsettings.json`](/home/jbct/Projects/MAL-CLONE/backend/appsettings.json) (or User Secrets). **Ensure the `Jwt:Secret` is strong and kept confidential.**
      ```json
      // filepath: appsettings.Development.json or User Secrets
      {
        "Jwt": {
          "Secret": "YOUR_SUPER_SECRET_KEY_REPLACE_THIS_LONGER_THAN_16_CHARS", // Replace with a strong, unique secret
          "Issuer": "your_issuer_name", // e.g., AnimeNexusAPI
          "Audience": "your_audience_name", // e.g., AnimeNexusClient
          "ExpiryMinutes": 60 // Optional: Token expiry time in minutes
        }
        // ... other settings
      }
      ```
4.  **Apply Database Migrations:** Open a terminal in the project directory (`/home/jbct/Projects/MAL-CLONE/backend`) and run:
    ```bash
    dotnet ef database update
    ```
    This command will create the necessary tables (like the `Users` table) in your configured PostgreSQL database based on the existing migrations.

## Running the Project

1.  **Run the Application:** Use the .NET CLI to start the application:
    ```bash
    dotnet run
    ```
    Alternatively, run using your IDE (like Visual Studio Code).
2.  **Access Swagger UI:** Once the application is running, open your web browser and navigate to the URL specified in the launch profile (e.g., `http://localhost:5081/swagger` based on your [`launchSettings.json`](/home/jbct/Projects/MAL-CLONE/backend/Properties/launchSettings.json)). The Swagger UI allows you to explore and interact with the API endpoints.

## External Dependencies

- **Jikan API:** This project relies heavily on the unofficial MyAnimeList API, Jikan (https://jikan.moe/), for all anime-related data. Ensure the Jikan API is accessible for the backend to function correctly. Rate limits and availability of the Jikan API may affect this application.
