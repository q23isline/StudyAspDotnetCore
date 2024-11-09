# StudyAspDotnetCore

ASP.NET Core Web API と Vue.js の勉強用リポジトリ

## はじめにやること

1. ソースダウンロード

    ```bash
    git clone https://github.com/q23isline/StudyAspDotnetCore.git
    ```

2. リポジトリのカレントディレクトリへ移動

    ```bash
    cd StudyAspDotnetCore
    ```

3. アプリ立ち上げ

    ```bash
    docker compose build --no-cache
    docker compose down -v
    docker compose up -d
    docker compose exec backend dotnet restore
    docker compose exec backend dotnet tool restore
    ```

## 日常的にやること

### システム起動

```bash
docker compose up -d
docker compose exec backend dotnet watch run --urls "http://0.0.0.0:8080"
```

### システム終了

```bash
docker compose down
```

## 動作確認

### URL

<http://localhost:8080/swagger/index.html>

## データベースへの接続

| 項目名                   | 設定値          |
| ------------------------ | --------------- |
| サーバー名               | 127.0.0.1       |
| 認証                     | SQL Server 認証 |
| ユーザー名               | sa              |
| パスワード               | Passw0rd        |
| サーバー証明書を信頼する | ON              |

## コーディング標準チェック単体実行

```bash
# コーディング標準チェック実行
docker compose exec backend dotnet format --verify-no-changes src.sln --exclude Migrations
# コーディング標準チェック自動整形実行
docker compose exec backend dotnet format src.sln --exclude Migrations
```

## ログ出力場所

### ASP.NET Core

backend/Logs

### SQL Server

logs/db
