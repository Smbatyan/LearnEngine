#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LearnEngine.API/LearnEngine.API.csproj", "LearnEngine.API/"]
RUN dotnet restore "LearnEngine.API/LearnEngine.API.csproj"
COPY . .
WORKDIR "/src/LearnEngine.API"
RUN dotnet build "LearnEngine.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LearnEngine.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LearnEngine.API.dll"]