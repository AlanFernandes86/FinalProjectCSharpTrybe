#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FinalProjectCSharpTrybe/FinalProjectCSharpTrybe.csproj", "FinalProjectCSharpTrybe/"]
RUN dotnet restore "FinalProjectCSharpTrybe/FinalProjectCSharpTrybe.csproj"
COPY . .
WORKDIR "/src/FinalProjectCSharpTrybe"
RUN dotnet build "FinalProjectCSharpTrybe.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinalProjectCSharpTrybe.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinalProjectCSharpTrybe.dll"]