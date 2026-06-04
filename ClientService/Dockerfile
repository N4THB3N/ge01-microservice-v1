FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

COPY ["ClientService.csproj", "ClientService/"]
RUN dotnet restore "ClientService/ClientService.csproj"

COPY . ./ClientService
WORKDIR "/src/ClientService"
RUN dotnet build "ClientService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClientService.csproj" -c Release -o /app/publish

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish ./
ENTRYPOINT ["dotnet", "ClientService.dll"]