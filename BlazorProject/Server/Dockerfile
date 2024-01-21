#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BlazorProject/Server/BlazorProject.Server.csproj", "BlazorProject/Server/"]
COPY ["BlazorProject/Client/BlazorProject.Client.csproj", "BlazorProject/Client/"]
COPY ["BlazorProject/Shared/BlazorProject.Shared.csproj", "BlazorProject/Shared/"]
RUN dotnet restore "BlazorProject/Server/BlazorProject.Server.csproj"
COPY . .
WORKDIR "/src/BlazorProject/Server"
RUN dotnet build "BlazorProject.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorProject.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "BlazorProject.Server.dll"]
