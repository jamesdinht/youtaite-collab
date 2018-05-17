# Build image
FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /build

# Copy csproj and restore packages first
COPY *.csproj ./
RUN dotnet restore

# Copy everything else
COPY . ./
RUN dotnet build --no-restore
RUN dotnet publish -c Release -o Package --no-restore

# Runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build /build/Package ./
ENTRYPOINT [ "dotnet", "Collab.API.dll" ]