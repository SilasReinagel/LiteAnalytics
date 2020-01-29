FROM mcr.microsoft.com/dotnet/core/sdk:3.0 as build

WORKDIR /source

COPY . ./

RUN dotnet restore -r linux-x64
WORKDIR /source/LiteAnalytics.WebApi

RUN dotnet publish -c release -o /app -r linux-x64 --self-contained false --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0

WORKDIR /app
COPY --from=build /app ./

EXPOSE 80

ENTRYPOINT ["dotnet", "./LiteAnalytics.WebApi.dll"]
