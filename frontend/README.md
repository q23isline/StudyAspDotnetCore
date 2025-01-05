# study-asp-dotnet-core

This template should help get you started developing with Vue 3 in Vite.

## フロントエンド開発ガイドライン

### コーディング標準チェック単体実行

```bash
# コーディング標準チェック実行
docker compose exec frontend npm run format-check
# コーディング標準チェック自動整形実行
docker compose exec frontend npm run format
```

### 静的解析単体実行する

```bash
docker compose exec frontend npm run type-check
docker compose exec frontend npm run lint
```

### ビルドする

```bash
docker compose exec frontend npm run build
# ビルド結果のファイルたちに Linux の読み取り・書き込み権限を与える
sudo chmod -R ogu+rw frontend/dist
```

### ライブラリをインストールする

インストール済のライブラリは `frontend/package.json` 参照

ライブラリ一覧

<https://www.npmjs.com/>

```bash
docker compose exec frontend npm install ｛ライブラリ名｝
# axios をインストールする例
# docker compose exec frontend npm install axios

# インストールしたライブラリに実行権限を含めた全権限を与える
sudo chmod -R 777 frontend/node_modules
```

### VSCode で .vue や .ts ファイルを開いたときにモジュールが読み込めないエラーが表示される解決方法

1. node_modules ディレクトリの中身を Docker コンテナのものに上書きする

    ```bash
    # インストールしたライブラリを削除する
    sudo rm -rf frontend/node_modules
    # 再インストール
    docker compose exec frontend npm install
    # コンテナから WSL2 上に持ってくる（VSCode でライブラリを認識できるようにする）
    sudo docker cp frontend:/src/node_modules $(pwd)/frontend/

    sudo chmod -R 777 frontend/node_modules
    ```

2. VSCode を閉じて、再度開く

---

## Recommended IDE Setup

[VSCode](https://code.visualstudio.com/) + [Volar](https://marketplace.visualstudio.com/items?itemName=Vue.volar) (and disable Vetur).

## Type Support for `.vue` Imports in TS

TypeScript cannot handle type information for `.vue` imports by default, so we replace the `tsc` CLI with `vue-tsc` for type checking. In editors, we need [Volar](https://marketplace.visualstudio.com/items?itemName=Vue.volar) to make the TypeScript language service aware of `.vue` types.

## Customize configuration

See [Vite Configuration Reference](https://vite.dev/config/).

## Project Setup

```sh
npm install
```

### Compile and Hot-Reload for Development

```sh
npm run dev
```

### Type-Check, Compile and Minify for Production

```sh
npm run build
```

### Lint with [ESLint](https://eslint.org/)

```sh
npm run lint
```
