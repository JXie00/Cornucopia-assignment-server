FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Cornucopia-assignment-serve/Cornucopia-assignment-serve.csproj", "Cornucopia-assignment-serve/"]
RUN dotnet restore "Cornucopia-assignment-serve/Cornucopia-assignment-serve.csproj"
COPY . .
WORKDIR "/src/Cornucopia-assignment-serve"
RUN dotnet build "Cornucopia-assignment-serve.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cornucopia-assignment-serve.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cornucopia-assignment-serve.dll"]
