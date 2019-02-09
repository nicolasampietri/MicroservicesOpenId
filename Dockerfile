FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["TestOpenID/TestOpenID.csproj", "TestOpenID/"]
RUN dotnet restore "TestOpenID/TestOpenID.csproj"
COPY . .
WORKDIR "/src/TestOpenID"
RUN dotnet build "TestOpenID.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TestOpenID.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TestOpenID.dll"]