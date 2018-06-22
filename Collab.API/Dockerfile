# Build image
FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /build

# Copy csproj and restore packages first
COPY *.csproj ./
RUN dotnet restore

# Copy everything else
COPY . ./
RUN dotnet build --no-restore
RUN dotnet publish -c Release -o Package --no-restore

# Runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build /build/Package ./
ENTRYPOINT [ "dotnet", "Collab.API.dll" ]