FROM mcr.microsoft.com/dotnet/sdk:6.0-focal  AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/runtime:6.0-focal
WORKDIR /app
COPY --from=build-env /app/out ./

RUN useradd -ms /bin/bash moduleuser && chown -R moduleuser /app
USER moduleuser

ENTRYPOINT ["dotnet", "PLC-Publisher.dll"]