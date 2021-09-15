#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV TZ=America/Sao_Paulo 
RUN ln -snf /usr/shaire/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["api-fullstack-challenge/api-fullstack-challenge.csproj", "api-fullstack-challenge/"]
COPY ["api-fullstack-challenge.Repository/api-fullstack-challenge.Repository.csproj", "api-fullstack-challenge.Repository/"]
COPY ["api-fullstack-challenge.Models/api-fullstack-challenge.Models.csproj", "api-fullstack-challenge.Models/"]
COPY ["api-fullstack-challenge.Services/api-fullstack-challenge.Services.csproj", "api-fullstack-challenge.Services/"]
RUN dotnet restore "api-fullstack-challenge/api-fullstack-challenge.csproj"
COPY . .
WORKDIR "/src/api-fullstack-challenge"
RUN dotnet build "api-fullstack-challenge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api-fullstack-challenge.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# ENTRYPOINT ["dotnet", "api-fullstack-challenge.dll"]

CMD ASPNETCORE_URLS=http://*:$PORT dotnet api-fullstack-challenge.dll