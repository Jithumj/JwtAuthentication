# JWT Authentication in .NET Core Web API

This project demonstrates JWT (JSON Web Token) authentication in a .NET Core Web API without using a separate database connection,the user credentials are defined within the code.

To run this sample, you need the following prerequisites.

**Software prerequisites:**

1. SQL Server 2016 (or higher) or an Azure SQL Database
2. Visual Studio  with the ASP.NET Core


## Run this sample

### Setup


1. From Visual Studio , open the **Auth_JWT.xproj** file from the root directory. Restore packages using right-click menu on the project in Visual Studio and by choosing Restore Packages item. As an alternative, you may run **dotnet restore** from the command line (from the root folder of application).

3. Add a connection Jwt key in the appsettings.json or appsettings.development.json file. An example of the content of appsettings.development.json is shown in the following configuration:

```
{
  "Jwt": {
    "key": "This_Is_key_for_jwt_authentication"
  },
}
```

### Build and run the REST services

1. Build solution using Ctrl+Shift+B, right-click on project + Build, Build/Build Solution from menu, or **dotnet build** command from the command line (from the root folder of application).

2. Run sample app using F5 or Ctrl+F5,
  1. Open /api/Url to get all Todo items as a JSON array,
  2. Open /api/Crud/1 Url to get details about a single Todo item with id 1,
  3. Send POST, PUT, PATCH, or DELETE Http requests to update content of notes table.

<a name=sample-details></a>

## Sample details

The user details for authentication is present in the models folder as UserModels such as username and password.The implentation of JWT authentication can be found in the Implementation folder.The IUserImpl file implements the login services and usermodel is passed to this interface.JWT functionality is implemented in the UserFunction file. Also the Microsoft.AspNetCore.Authentication.JwtBearer  is the middle ware that provides JWT authentication support.
it has the following funtionalities:-

1. The login user will check whether the incoming data matches the predefined credentials i.e. “Batman” and “Joker” in this case.
2. If the loginUser is null, it means the credentials are different and it will return an empty string.
3. If loginUser contains some value, a new JwtTokenHandler is generated and will be assigned to tokenHandler.
4. THE JWT key is accessed from appsettings and store it in a variable named key.
5. A new token descriptor is created and will assign the UserName as a claim.
6. Expiry time is assigned
7. Using the a Security Algorithm, new signing credentials will be created
8. Using the token descriptor parameter,  a new token is created.
9. Store this token in a variable and return it upon successfully validating the user.


