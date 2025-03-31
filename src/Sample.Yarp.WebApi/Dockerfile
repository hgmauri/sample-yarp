FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/Sample.Yarp.WebApi/Sample.Yarp.WebApi.csproj", "src/Sample.Yarp.WebApi/"]
COPY ["src/Sample.Yarp.WebApi.Core/Sample.Yarp.WebApi.Core.csproj", "src/Sample.Yarp.WebApi.Core/"]
RUN dotnet restore "src/Sample.Yarp.WebApi/Sample.Yarp.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Sample.Yarp.WebApi"
RUN dotnet build "Sample.Yarp.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sample.Yarp.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sample.Yarp.WebApi.dll"]