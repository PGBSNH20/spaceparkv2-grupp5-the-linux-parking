# Documentation

## Stucutre

### Endpoints
  - `/api` - base endpoint
#### Auth
##### POST
  -  `/auth/login` - Login with an existing user.
  -  `/auth/register` - Register a new user, that exists within swapi.
#### Station - Requiers authentication
##### POST
  - `/station` - Create new station
##### GET
  - `/station` - List all avaible stations
  - `/station/{id}` - List station with {id}
##### PUT
  - `/station/{id}` - Update station with {id}
##### DELETE
  - `/station/{id}` - Delete station with {id}
#### Spot - Requiers authentication
##### POST
  - `/station/{id}/spot` - Create new spot at station {id}
##### GET
  - `/station/{id}/spot` - List all spots at station {id}
  - `/station/{id}/spot/{sid}` - Show information for spot {sid} at station {id}
##### PUT
  - `/station/{id}/spot/{sid}` - Update spot with {sid} at station {id}
##### DELETE
  - `/station/{id}/spot/{sid}` - Delete spot with {sid} at statio {id}

#### Parking - Requires authentication
##### POST
  - `/station/{id}/spot/{sid}/parking` - Park at this spot.
##### GET
  - `/station/{id}/spot/{sid}/parking` - Get whos parked on this spot.
  - `/station/{id}/parking` - Get all spots and their parking status.
##### DELETE
  - `/station/{id}/spot/{sid}/parking` - Delete customer from parking/unpark.

### Project
```
├── Documentation
└── Source
    ├── LinuxParking.API
    │   ├── Configuration - Application configuration such as JWT, Swagger, Dependecy injections.
    │   ├── Controllers - API Controllers
    │   ├── Database - Database management, repositories
    │   ├── Domain - Models, Resources, Response .
    │   ├── Extensions - Extentions of classes and objects.
    │   ├── External - 3rd-party resources.
    │   ├── Mappings - Mapping configuration.
    │   ├── Migrations - Database migrations.
    │   ├── Services - Internal services.
    │   └── Utils - Utils such as JWT generation and parsing.
    ├── LinuxParking.API.Test
    └── docker-compose.yml
```

#### Packages & Dependencies used
##### API
- AutoMapper - Mapping between models/objects.
- AspNetCore.Authentication.JwtBearer - JWT token management.
- AspNetCore.Identity - Authentication management helper.
- EntityFrameWorkCore - Database management | Code first
- RestSharp - Utilize rest api's.
- Npgsql - PostgreSQL support.

##### Test
- xUnit - UnitTesting package.