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

3. 開発準備

    ```bash
    cp frontend/.vscode/settings.json.default frontend/.vscode/settings.json
    ```

4. アプリ立ち上げ

    ```bash
    docker compose build --no-cache
    docker compose down -v
    docker compose up -d
    docker compose exec backend dotnet restore
    docker compose exec backend dotnet tool restore
    docker compose exec backend dotnet ef database update
    docker compose exec frontend npm install
    ```

## 日常的にやること

### システム起動

```bash
# DB、バックエンド、フロントエンドコンテナ起動
docker compose up -d
# バックエンド起動
docker compose exec backend dotnet watch run --urls "http://0.0.0.0:8080"
# フロントエンド起動
docker compose exec frontend npm run dev -- --host
```

### システム終了

```bash
# フロントエンド起動ターミナルで Ctrl + c
# バックエンド起動ターミナルで Ctrl + c

docker compose down
```

## 動作確認

### URL

#### バックエンド

<http://localhost:8080/swagger/index.html>

#### フロントエンド

<http://localhost:5173/>

DevTools の起動

<http://localhost:5173/__devtools__/>

## Permission Deniedエラーが出た時の解決方法

```bash
# プロジェクト全体のファイルすべてに読み込み、書き込み権限を与える
sudo chmod -R ugo+rw ./
# インストールしたライブラリに実行権限を含めた全権限を与える
sudo chmod -R 777 backend/bin backend/obj frontend/node_modules
```

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
# バックエンド
# コーディング標準チェック実行
docker compose exec backend dotnet format --verify-no-changes src.sln --exclude Migrations
# コーディング標準チェック自動整形実行
docker compose exec backend dotnet format src.sln --exclude Migrations

# フロントエンド
# コーディング標準チェック実行
docker compose exec frontend npm run format-check
# コーディング標準チェック自動整形実行
docker compose exec frontend npm run format
```

## コード静的解析実行

```bash
# フロントエンド
docker compose exec frontend npm run lint
```

## ログ出力場所

|サービス|ログ出力場所|
|---|---|
|Node.js|logs/frontend|
|ASP.NET Core|backend/Logs|
|SQL Server|logs/db|
