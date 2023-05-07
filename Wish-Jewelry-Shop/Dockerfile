FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
COPY . .
RUN dotnet restore "src/Wish.Web/Wish.Web.csproj"
COPY . .
WORKDIR /src
RUN dotnet build "Wish.Web/Wish.Web.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "Wish.Web/Wish.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Wish.Web.dll"]