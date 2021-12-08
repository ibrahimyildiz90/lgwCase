FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY GateWays/FreeCourse.Gateway/*.csproj GateWays/FreeCourse.Gateway/
RUN dotnet restore GateWays/FreeCourse.Gateway/*.csproj
COPY . .
RUN dotnet publish GateWays/FreeCourse.Gateway/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","FreeCourse.Gateway.dll" ]