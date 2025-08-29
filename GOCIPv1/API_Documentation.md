# GOCIP API Documentation

## Overview
The GOCIP API is a .NET Core Web API that provides user management functionality. It allows you to create, read, update, and delete user accounts with profile information.

## Base URL
```
https://localhost:7000/api
```

## Authentication
Currently, this API does not require authentication tokens. All endpoints are publicly accessible.

## Data Models

### User Model
The complete user object returned by the API:

```json
{
  "id": 1,
  "userId": "123e4567-e89b-12d3-a456-426614174000",
  "email": "user@example.com",
  "password": "hashedpassword",
  "profilePictureUrl": "https://example.com/profile.jpg",
  "userName": "johndoe",
  "age": 25,
  "gender": "Male",
  "createdAt": "2024-01-01T00:00:00.000Z"
}
```

### UserDto (Request Model)
The data structure required for creating and updating users:

```json
{
  "userId": "123e4567-e89b-12d3-a456-426614174000",
  "email": "user@example.com",
  "password": "password123",
  "profilePictureUrl": "https://example.com/profile.jpg",
  "userName": "johndoe",
  "age": 25,
  "gender": "Male"
}
```

## API Endpoints

### 1. Get All Users
Retrieves a list of all users in the system.

**Endpoint:** `GET /api/Users`

**Request:**
- Method: `GET`
- Headers: None required
- Body: None

**Response:**
- **Success (200 OK):**
```json
[
  {
    "id": 1,
    "userId": "123e4567-e89b-12d3-a456-426614174000",
    "email": "user1@example.com",
    "password": "hashedpassword1",
    "profilePictureUrl": "https://example.com/profile1.jpg",
    "userName": "user1",
    "age": 25,
    "gender": "Male",
    "createdAt": "2024-01-01T00:00:00.000Z"
  },
  {
    "id": 2,
    "userId": "456e7890-e89b-12d3-a456-426614174001",
    "email": "user2@example.com",
    "password": "hashedpassword2",
    "profilePictureUrl": "https://example.com/profile2.jpg",
    "userName": "user2",
    "age": 30,
    "gender": "Female",
    "createdAt": "2024-01-02T00:00:00.000Z"
  }
]
```

**Error Responses:**
- **500 Internal Server Error:** Database connection issues or server errors

---

### 2. Get User by ID
Retrieves a specific user by their unique identifier.

**Endpoint:** `GET /api/Users/{userId}`

**Request:**
- Method: `GET`
- Headers: None required
- Body: None
- Parameters: 
  - `userId` (path parameter): GUID of the user to retrieve

**Example:** `GET /api/Users/123e4567-e89b-12d3-a456-426614174000`

**Response:**
- **Success (200 OK):**
```json
{
  "id": 1,
  "userId": "123e4567-e89b-12d3-a456-426614174000",
  "email": "user@example.com",
  "password": "hashedpassword",
  "profilePictureUrl": "https://example.com/profile.jpg",
  "userName": "johndoe",
  "age": 25,
  "gender": "Male",
  "createdAt": "2024-01-01T00:00:00.000Z"
}
```

**Error Responses:**
- **404 Not Found:** User with the specified ID does not exist
- **500 Internal Server Error:** Database connection issues or server errors

---

### 3. Create User
Creates a new user account.

**Endpoint:** `POST /api/Users`

**Request:**
- Method: `POST`
- Headers: 
  - `Content-Type: application/json`
- Body: UserDto object

**Example Request Body:**
```json
{
  "userId": "123e4567-e89b-12d3-a456-426614174000",
  "email": "newuser@example.com",
  "password": "securepassword123",
  "profilePictureUrl": "https://example.com/newprofile.jpg",
  "userName": "newuser",
  "age": 28,
  "gender": "Female"
}
```

**Response:**
- **Success (201 Created):**
```json
{
  "id": 3,
  "userId": "123e4567-e89b-12d3-a456-426614174000",
  "email": "newuser@example.com",
  "password": "securepassword123",
  "profilePictureUrl": "https://example.com/newprofile.jpg",
  "userName": "newuser",
  "age": 28,
  "gender": "Female",
  "createdAt": "2024-01-03T00:00:00.000Z"
}
```

**Error Responses:**
- **400 Bad Request:** 
  - User data is null
  - Invalid email format
  - Missing required fields
- **500 Internal Server Error:** Database connection issues or server errors

---

### 4. Update User
Updates an existing user's information.

**Endpoint:** `PUT /api/Users/{userId}`

**Request:**
- Method: `PUT`
- Headers: 
  - `Content-Type: application/json`
- Body: UserDto object with updated information
- Parameters: 
  - `userId` (path parameter): GUID of the user to update

**Example:** `PUT /api/Users/123e4567-e89b-12d3-a456-426614174000`

**Example Request Body:**
```json
{
  "userId": "123e4567-e89b-12d3-a456-426614174000",
  "email": "updateduser@example.com",
  "password": "newpassword123",
  "profilePictureUrl": "https://example.com/updatedprofile.jpg",
  "userName": "updateduser",
  "age": 26,
  "gender": "Male"
}
```

**Response:**
- **Success (204 No Content):** User updated successfully

**Error Responses:**
- **404 Not Found:** User with the specified ID does not exist
- **400 Bad Request:** Invalid data format
- **500 Internal Server Error:** Database connection issues or server errors

---

### 5. Delete User
Removes a user from the system.

**Endpoint:** `DELETE /api/Users/{userId}`

**Request:**
- Method: `DELETE`
- Headers: None required
- Body: None
- Parameters: 
  - `userId` (path parameter): GUID of the user to delete

**Example:** `DELETE /api/Users/123e4567-e89b-12d3-a456-426614174000`

**Response:**
- **Success (204 No Content):** User deleted successfully

**Error Responses:**
- **404 Not Found:** User with the specified ID does not exist
- **500 Internal Server Error:** Database connection issues or server errors

---

## Field Descriptions

### Required Fields
- **userId**: Unique identifier for the user (GUID format)
- **email**: User's email address (must be valid email format)
- **password**: User's password (stored as plain text - consider hashing in production)

### Optional Fields
- **profilePictureUrl**: URL to the user's profile picture
- **userName**: Display name for the user (max 50 characters)
- **age**: User's age (integer)
- **gender**: User's gender (max 10 characters)

### System Fields (Auto-generated)
- **id**: Database primary key (auto-increment)
- **createdAt**: Timestamp when the user was created (auto-generated)

## Data Validation Rules

- **Email**: Must be a valid email address format
- **UserName**: Maximum length of 50 characters
- **Gender**: Maximum length of 10 characters
- **Age**: Must be a positive integer
- **UserId**: Must be a valid GUID format

## HTTP Status Codes

- **200 OK**: Request successful
- **201 Created**: Resource created successfully
- **204 No Content**: Request successful, no content to return
- **400 Bad Request**: Invalid request data
- **404 Not Found**: Resource not found
- **500 Internal Server Error**: Server error

## CORS Policy

The API allows cross-origin requests from any origin with the following policy:
- **AllowAnyOrigin**: Requests from any domain
- **AllowAnyMethod**: All HTTP methods (GET, POST, PUT, DELETE)
- **AllowAnyHeader**: All request headers

## Database

The API uses PostgreSQL as the database with the following connection:
- **Host**: dpg-d2m3rnruibrs73fqie4g-a.oregon-postgres.render.com
- **Port**: 5432
- **Database**: GOCIP

## Development Features

- **Swagger UI**: Available at the root URL (`/`) when running in development mode
- **OpenAPI**: JSON specification available at `/openapi/v1.json`
- **CORS**: Enabled for all origins in development

## Example Usage

### Using cURL

**Get all users:**
```bash
curl -X GET "https://localhost:7000/api/Users"
```

**Create a new user:**
```bash
curl -X POST "https://localhost:7000/api/Users" \
  -H "Content-Type: application/json" \
  -d '{
    "userId": "123e4567-e89b-12d3-a456-426614174000",
    "email": "test@example.com",
    "password": "password123",
    "userName": "testuser",
    "age": 25,
    "gender": "Male"
  }'
```

**Update a user:**
```bash
curl -X PUT "https://localhost:7000/api/Users/123e4567-e89b-12d3-a456-426614174000" \
  -H "Content-Type: application/json" \
  -d '{
    "userId": "123e4567-e89b-12d3-a456-426614174000",
    "email": "updated@example.com",
    "password": "newpassword",
    "userName": "updateduser",
    "age": 26,
    "gender": "Male"
  }'
```

**Delete a user:**
```bash
curl -X DELETE "https://localhost:7000/api/Users/123e4567-e89b-12d3-a456-426614174000"
```

### Using JavaScript/Fetch

**Get all users:**
```javascript
fetch('https://localhost:7000/api/Users')
  .then(response => response.json())
  .then(data => console.log(data))
  .catch(error => console.error('Error:', error));
```

**Create a new user:**
```javascript
const userData = {
  userId: "123e4567-e89b-12d3-a456-426614174000",
  email: "test@example.com",
  password: "password123",
  userName: "testuser",
  age: 25,
  gender: "Male"
};

fetch('https://localhost:7000/api/Users', {
  method: 'POST',
  headers: {
    'Content-Type': 'application/json',
  },
  body: JSON.stringify(userData)
})
.then(response => response.json())
.then(data => console.log('Success:', data))
.catch(error => console.error('Error:', error));
```

## Notes and Recommendations

1. **Security**: The current implementation stores passwords as plain text. In production, implement proper password hashing (e.g., bcrypt, Argon2).

2. **Authentication**: Consider adding JWT token authentication for secure access to user data.

3. **Validation**: Add more comprehensive input validation and sanitization.

4. **Error Handling**: Implement more detailed error messages and logging.

5. **Rate Limiting**: Consider adding rate limiting to prevent abuse.

6. **HTTPS**: Ensure HTTPS is enabled in production for secure data transmission.

## Support

For API support or questions, please refer to the project documentation or contact the development team.

