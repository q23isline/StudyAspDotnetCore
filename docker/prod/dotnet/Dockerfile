# ベースの作成ステージ
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS init
ENV TZ=Asia/Tokyo
ENV DOTNET_ENVIRONMENT=Production
ENV ASPNETCORE_HTTP_PORTS=5000
WORKDIR /src
COPY backend/src.csproj /src/src.csproj
RUN dotnet restore src.csproj
COPY backend/ /src

# 本番用のビルドステージ
FROM init AS build
RUN dotnet build src.csproj -c Release -o /app/build

# 本番用の公開ステージ
FROM build AS publish
RUN dotnet publish src.csproj -c Release -o /app/publish /p:UseAppHost=false

# 本番用のバックエンド起動ステージ
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
ENV TZ=Asia/Tokyo
ENV DOTNET_ENVIRONMENT=Production
ENV ASPNETCORE_HTTP_PORTS=5000
WORKDIR /var/www/html
COPY --from=publish /app/publish .
EXPOSE 5000
ENTRYPOINT ["dotnet", "src.dll"]

# マイグレーション用のステージ
FROM init AS migration
RUN dotnet tool restore
ENTRYPOINT ["dotnet", "ef", "database", "update"]
