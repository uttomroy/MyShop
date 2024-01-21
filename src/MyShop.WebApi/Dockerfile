FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5034


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MyShop.WebApi/MyShop.WebApi.csproj", "./MyShop.WebApi/"]
COPY ["MyShop.WebApi/MyShop.Database.csproj", "./MyShop.Database/"]
COPY ["MyShop.Core/MyShop.Core.csproj", "./MyShop.Core/"]
RUN dotnet restore "MyShop.WebApi/MyShop.WebApi.csproj"
COPY . .
WORKDIR "/src/MyShop.WebApi/."
RUN dotnet build "MyShop.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyShop.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyShop.WebApi.dll"]
