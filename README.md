# Ads API

## Overview

The Ads API is a RESTful service designed to manage advertisements. It allows for creating, retrieving, updating, and deleting ads, with role-based access control to ensure secure and appropriate access to the endpoints.

## Features

- **Retrieve all ads**: Allows authenticated users to get a list of all advertisements.
- **Retrieve a specific ad**: Allows authenticated users to get details of a specific advertisement by its ID.
- **Create a new ad**: Allows admin users to create a new advertisement.
- **Update an ad**: Allows admin users to update an existing advertisement.
- **Patch an ad**: Allows admin users to apply partial updates to an existing advertisement.
- **Delete an ad**: Allows admin users to delete an existing advertisement.

## Authentication and Authorization

- **Authentication**: The API uses JWT (JSON Web Token) for authentication.
- **Authorization**: Role-based access control is implemented. Only users with the "Admin" role can create, update, patch, or delete ads. Both "Admin" and "User" roles can retrieve ads.

## Endpoints

### Retrieve All Ads

- **Endpoint**: `GET /Ads`
- **Authorization**: Admin, User
- **Response Codes**:
  - `200 OK`: Returns the list of ads.

### Retrieve a Specific Ad

- **Endpoint**: `GET /Ads/{id}`
- **Authorization**: Admin, User
- **Response Codes**:
  - `200 OK`: Returns the ad with the specified ID.
  - `404 Not Found`: If the ad is not found.

### Create a New Ad

- **Endpoint**: `POST /Ads`
- **Authorization**: Admin
- **Request Body**: JSON representation of the ad.
- **Response Codes**:
  - `200 OK`: Returns the created ad.
  - `400 Bad Request`: If the ad is invalid.
  - `403 Forbidden`: If the user is not authorized.

### Update an Ad

- **Endpoint**: `PUT /Ads/{id}`
- **Authorization**: Admin
- **Request Body**: JSON representation of the updated ad.
- **Response Codes**:
  - `200 OK`: Returns the updated ad.
  - `404 Not Found`: If the ad is not found.
  - `403 Forbidden`: If the user is not authorized.

### Patch an Ad

- **Endpoint**: `PATCH /Ads/{id}`
- **Authorization**: Admin
- **Request Body**: JSON Patch document containing the changes to apply.
- **Response Codes**:
  - `200 OK`: Returns the updated ad.
  - `404 Not Found`: If the ad is not found.
  - `403 Forbidden`: If the user is not authorized.

### Delete an Ad

- **Endpoint**: `DELETE /Ads/{id}`
- **Authorization**: Admin
- **Response Codes**:
  - `200 OK`: Returns the deleted ad.
  - `404 Not Found`: If the ad is not found.
  - `403 Forbidden`: If the user is not authorized.
***

## Configuration
### JWT Configuration
- **The JWT settings should be configured in the `appsettings.json` file:**

```json
"Jwt": {
  "Key": "YourSecretKey",
  "Issuer": "YourIssuer",
  "Audience": "YourAudience"
}
```
