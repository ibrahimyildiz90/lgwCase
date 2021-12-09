FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY GateWays/LgwCase.Gateway/*.csproj GateWays/LgwCase.Gateway/
RUN dotnet restore GateWays/LgwCase.Gateway/*.csproj
COPY . .
RUN dotnet publish GateWays/LgwCase.Gateway/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","LgwCase.Gateway.dll" ]