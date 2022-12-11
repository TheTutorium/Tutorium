FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine as build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY TutoriumApi/TutoriumApi.csproj .
RUN dotnet restore

# copy everything else and build app
COPY TutoriumApi/. .
RUN dotnet publish -c release -o /app 
# Add '--no-restore' for optimization, currently does not work

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine as runtime
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT [ "dotnet", "./TutoriumApi.dll" ]
