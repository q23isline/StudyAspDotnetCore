import axios from 'axios'

export const AppApi = axios.create({
  // vite.config.ts で server.proxy を定義しても反映されないのでここで定義する
  // TODO: ローカル用の設定になっているので、環境変数を読み込んで動的に設定できるようにする
  baseURL: 'http://localhost:8080',
  responseType: 'json',
  headers: {
    'Content-Type': 'application/json',
  },
})
