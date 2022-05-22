FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ContractFirst/ContractFirst.csproj", "ContractFirst/"]
RUN dotnet restore "ContractFirst/ContractFirst.csproj"
COPY . .
WORKDIR "/src/ContractFirst"
RUN dotnet build "ContractFirst.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContractFirst.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContractFirst.dll"]
