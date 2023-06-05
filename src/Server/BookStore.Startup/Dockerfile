FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BookStore.Application/BookStore.Application.csproj", "BookStore.Application/"]
COPY ["BookStore.Domain/BookStore.Domain.csproj", "BookStore.Domain/"]
COPY ["BookStore.Infrastructure/BookStore.Infrastructure.csproj", "BookStore.Infrastructure/"]
COPY ["BookStore.Startup/BookStore.Startup.csproj", "BookStore.Startup/"]
COPY ["BookStore.Web/BookStore.Web.csproj", "BookStore.Web/"]
RUN dotnet restore "BookStore.Startup/BookStore.Startup.csproj"
COPY . .
WORKDIR "/src/BookStore.Startup"
RUN dotnet build "BookStore.Startup.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookStore.Startup.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookStore.Startup.dll"]