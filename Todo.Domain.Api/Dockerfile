FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Todo.Domain.Api/Todo.Domain.Api.csproj", "Todo.Domain.Api/"]
RUN dotnet restore "Todo.Domain.Api/Todo.Domain.Api.csproj"
COPY . .
WORKDIR "/src/Todo.Domain.Api"
RUN dotnet build "Todo.Domain.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Todo.Domain.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Todo.Domain.Api.dll"]
