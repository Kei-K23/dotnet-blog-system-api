# Blog System API

The **Blog System API** provides user authentication and authorization functionalities, including JWT-based authentication, refresh token management, and CRUD operations for users, blogs, comments, advanced-filter and high performance searching contents.

## Features

- **User Authentication**: Login using username and password with hashed passwords.
- **JWT Authorization**: Secure access to protected routes with JSON Web Tokens.
- **Refresh Token Management**: Token refresh mechanism for seamless session management.
- **CRUD Operations**: Manage blog posts, users, comments, tags, etc.
- **Advanced Filter and Searching**: Manage filter and search the content with high performance.

## Technologies Used

- **.NET 9**
- **Entity Framework Core**
- **Postgres**
- **BCrypt**
- **Scalar**

## Installation

1. **Clone the repository**:

   ```bash
   git clone https://github.com/your-username/dotnet-blog-system-api.git
   cd blog-system-api
   ```

2. **Configure the database**:

   - Update the connection string in `appsettings.json`:

     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=your-server;Database=BlogSystemDb;User Id=your-username;Password=your-password;"
     },
     "Jwt": {
        "Key": "YourSuperSecretKey",
        "Issuer": "YourIssuer",
        "Audience": "YourAudience"
     }
     ```

3. **Run migrations**:

   ```bash
   dotnet ef migrations add Init
   dotnet ef database update
   ```

4. **Run the application**:

   ```bash
   dotnet run
   ```

5. **Access the API**:
   - API documentation: `http://localhost:5086/scalar/v1`.

## Environment Variables

The API uses environment variables to configure sensitive information. Create an `.env` file with the following variables:

```env
JWT__Key=YourSuperSecretKey
JWT__Issuer=YourIssuer
JWT__Audience=YourAudience
ConnectionStrings__DefaultConnection=Server=your-server;Database=BlogSystemDb;User Id=your-username;Password=your-password;
```

## Security

1. **Password Hashing**:

   - Passwords are hashed using `BCrypt` for security.

2. **JWT Tokens**:

   - Tokens are signed with a secret key stored in the environment variables.

3. **Refresh Tokens**:
   - Stored securely in the database and linked to users.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contributing

1. Fork the repository.
2. Create a new branch:
   ```bash
   git checkout -b feature/your-feature
   ```
3. Commit your changes:
   ```bash
   git commit -m "Add your feature"
   ```
4. Push to your branch:
   ```bash
   git push origin feature/your-feature
   ```
5. Open a pull request.
