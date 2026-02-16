# ---------- BUILD ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ./src/*.csproj ./
RUN dotnet restore

COPY ./src/ ./
RUN dotnet publish -c Release -o /app/publish

# ---------- RUNTIME ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "ProStudy-NET.dll"]
