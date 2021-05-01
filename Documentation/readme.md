# Documentation

## Stucutre

### Endpoints
  - `/api` - base endpoint
#### Station
##### POST
  - `/station` - Create new station
##### GET
  - `/station` - List all avaible stations
  - `/station/{id}` - List station with {id}
##### PUT
  - `/station/{id}` - Update station with {id}
##### DELETE
  - `/station/{id}` - Delete station with {id}
#### Spot
##### POST
  - `/station/{id}/spot` - Create new spot at station {id}
##### GET
  - `/station/{id}/spot` - List all spots at station {id}
  - `/station/{id}/spot/{sid}` - Show information for spot {sid} at station {id}
##### PUT
  - `/station/{id}/spot/{sid}` - Update spot with {sid} at station {id}
##### DELETE
  - `/station/{id}/spot/{sid}` - Delete spot with {sid} at statio {id}
### Project
