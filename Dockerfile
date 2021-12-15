FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_14.x | bash - \
    && apt-get install -y \
        nodejs \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /src
COPY ["MemberClub.WEB/MemberClub.WEB.csproj", "MemberClub/"]
RUN dotnet restore "MemberClub/MemberClub.WEB.csproj"
COPY . .
WORKDIR "/src/MemberClub.WEB"
RUN dotnet build "MemberClub.WEB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MemberClub.WEB.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet MemberClub.WEB.dll