FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ItemFinder/ItemFinder.csproj ItemFinder/
RUN dotnet restore ItemFinder/ItemFinder.csproj
COPY . .
WORKDIR /src/ItemFinder
RUN dotnet build ItemFinder.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ItemFinder.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ItemFinder.dll"]
