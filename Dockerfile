FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 7255 
EXPOSE 5286

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY src/MTRPZ4.UI/MTRPZ4.UI.csproj MTRPZ4.UI/
COPY src/MTRPZ4.Application/MTRPZ4.Application.csproj MTRPZ4.Application/
COPY src/MTRPZ4.Infrastructure/MTRPZ4.Infrastructure.csproj MTRPZ4.Infrastructure/
COPY src/MTRPZ4.DomainCore/MTRPZ4.CoreDomain.csproj MTRPZ4.DomainCore/
COPY tests/MTRPZ4.UnitTests/MTRPZ4.UnitTests.csproj MTRPZ4.UnitTests/

RUN dotnet restore MTRPZ4.UI/MTRPZ4.UI.csproj
COPY . .

RUN dotnet publish src/MTRPZ4.UI/MTRPZ4.UI.csproj -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MTRPZ4.UI.dll"]