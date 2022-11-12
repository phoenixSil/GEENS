#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Geens.Api/Geens.Api.csproj", "Geens.Api/"]
RUN dotnet restore "Geens.Api/Geens.Api.csproj"
COPY . .
WORKDIR "/src/Geens.Api"
RUN dotnet build "Geens.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Geens.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Geens.Api.dll"]