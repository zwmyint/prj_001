# prj_001 [my note]

dotnet new webapi -o JWTAuthentication

dotnet sln add JWTAuthentication/JWTAuthentication.csproj

dotnet run -p JWTAuthentication/JWTAuthentication.csproj



dotnet new webapi -o JWTAuthentication_2

dotnet sln add JWTAuthentication_2/JWTAuthentication_2.csproj

dotnet run -p JWTAuthentication_2/JWTAuthentication_2.csproj



dotnet new webapi -o API_LoginRegistration

dotnet sln add API_LoginRegistration/API_LoginRegistration.csproj

// now for the mapping we are gonna use AutoMapper.
// For that we need to add to packages to our API project with:
dotnet add API_LoginRegistration/API_LoginRegistration.csproj package AutoMapper 
dotnet add API_LoginRegistration/API_LoginRegistration.csproj package AutoMapper.Extensions.Microsoft.DependencyInjection

//Microsoft.EntityFrameworkCore

dotnet run -p API_LoginRegistration/API_LoginRegistration.csproj



//ASP.Net Core 5 Web API
dotnet new webapi -o ASPNetCore5WEBAPI

dotnet sln add ASPNetCore5WEBAPI/ASPNetCore5WEBAPI.csproj

dotnet run -p ASPNetCore5WEBAPI/ASPNetCore5WEBAPI.csproj

