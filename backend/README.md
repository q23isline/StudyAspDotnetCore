# StudyAspDotnetCore

## バックエンド開発ガイドライン

### コーディング標準チェック単体実行

```bash
# コーディング標準チェック実行
docker compose exec backend dotnet format --verify-no-changes src.sln --exclude Migrations
# コーディング標準チェック自動整形実行
docker compose exec backend dotnet format src.sln --exclude Migrations
```

### パッケージをインストールする

インストール済のパッケージは `backend/src.csproj` 参照

パッケージ一覧

<https://www.nuget.org/>

```bash
docker compose exec backend dotnet add package ｛パッケージ名｝
# Serilog.AspNetCore をインストールする例
# docker compose exec backend dotnet add package Serilog.AspNetCore

# インストールしたパッケージに実行権限を含めた全権限を与える
sudo chmod -R 777 backend/bin backend/obj
```

### 開発ツールをインストールする

インストール済の開発ツールは`backend/.config/dotnet-tools.json`参照

開発ツール一覧（パッケージと同様）

<https://www.nuget.org/>

```bash
docker compose exec backend dotnet tool install ｛ツール名｝
# EF Core をインストールする例
# docker compose exec backend dotnet tool install dotnet-ef

# インストールしたツールに実行権限を含めた全権限を与える
sudo chmod -R 777 backend/bin backend/obj
```

### VSCode で .cs ファイルを開いたときにアセンブリ参照がある事を確認してくださいエラーが表示される解決方法

1. キャッシュなどクリアする

    ```bash
    # インストールしたパッケージやビルド結果を削除する
    sudo rm -rf backend/bin backend/obj
    # 再インストール
    docker compose exec backend dotnet restore
    docker compose exec backend dotnet tool restore

    sudo chmod -R 777 backend/bin backend/obj
    ```

2. VSCode を閉じて、再度開く

### マイグレーションファイルをコード生成する

1. `backend/Models/`ディレクトリ内にモデルファイルを作成する
2. マイグレーションファイルを生成する

    ```bash
    docker compose exec backend dotnet ef migrations add ｛マイグレーションファイル名｝
    # Profile モデルを元にマイグレーションファイルを新規生成する例
    # docker compose exec backend dotnet ef migrations add CreateProfiles

    # マイグレーションファイルを DB のテーブルに反映させる
    docker compose exec backend dotnet ef database update
    ```

<https://learn.microsoft.com/ja-jp/ef/core/cli/dotnet>

### API の CRUD コントローラーをコード生成する

```bash
docker compose exec backend dotnet aspnet-codegenerator controller -name ｛コントローラー名｝ -async -api -m ｛モデル名｝ -dc ｛データベースコンテキスト名｝ -outDir Controllers
# Profile モデルを元にコントローラーファイルを生成する例
# docker compose exec backend dotnet aspnet-codegenerator controller -name ProfilesController -async -api -m Profile -dc MyContext -outDir Controllers
```

<https://learn.microsoft.com/ja-jp/aspnet/core/fundamentals/tools/dotnet-aspnet-codegenerator?view=aspnetcore-8.0>
