FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/LgwCase.Shared/*.csproj Shared/LgwCase.Shared/
COPY Services/Product/LgwCase.Services.Product.Application/*.csproj Services/Product/LgwCase.Services.Product.Application/
COPY Services/Product/LgwCase.Services.Product.Domain/*.csproj Services/Product/LgwCase.Services.Product.Domain/
COPY Services/Product/LgwCase.Services.Product.Domain.Core/*.csproj Services/Product/LgwCase.Services.Product.Domain.Core/
COPY Services/Product/LgwCase.Services.Product.Infrastructure/*.csproj Services/Product/LgwCase.Services.Product.Infrastructure/
COPY Services/Product/LgwCase.Services.Product.API/*.csproj Services/Product/LgwCase.Services.Product.API/
RUN dotnet restore Services/Product/LgwCase.Services.Product.API/*.csproj
COPY . .
RUN dotnet publish Services/Product/LgwCase.Services.Product.API/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","LgwCase.Services.Product.API.dll" ]