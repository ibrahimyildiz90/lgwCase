FROM mcr.microsoft.com/dotnet/sdk:3.1 as build
WORKDIR /app
EXPOSE 80
COPY Shared/LgwCase.Shared/*.csproj Shared/LgwCase.Shared/
COPY IdentityServer/LgwCase.IdentityServer/*.csproj IdentityServer/LgwCase.IdentityServer/ 
RUN dotnet restore  IdentityServer/LgwCase.IdentityServer/*.csproj
COPY . .
RUN dotnet publish IdentityServer/LgwCase.IdentityServer/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:3.1 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","LgwCase.IdentityServer.dll" ]