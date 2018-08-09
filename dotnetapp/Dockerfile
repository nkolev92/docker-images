FROM microsoft/dotnet-nightly:2.1-sdk AS build
WORKDIR /app

# restore
COPY dotnetapp/*.csproj ./dotnetapp/
WORKDIR /app/dotnetapp
RUN dotnet restore

# build and publish
WORKDIR /app/
COPY dotnetapp/. ./dotnetapp/
WORKDIR /app/dotnetapp
RUN dotnet publish -c Release -o out

# entrypoint
FROM microsoft/dotnet-nightly:2.1-runtime AS runtime
WORKDIR /app
COPY --from=build /app/dotnetapp/out ./
ENTRYPOINT ["dotnet", "dotnetapp.dll"]