FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5034

ENV ASPNETCORE_URLS=http://+:5034

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyShop.WebApi/MyShop.WebApi.csproj", "./MyShop.WebApi/"]
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
