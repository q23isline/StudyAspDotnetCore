# フロントエンドのビルドステージ
FROM node:20-buster AS node-build
ENV TZ=Asia/Tokyo
WORKDIR /src
COPY frontend/package*.json /src/
RUN npm install
COPY frontend/ /src
ARG VITE_API_BASE_URL=/
ENV VITE_API_BASE_URL=$VITE_API_BASE_URL
RUN npm run build-only

# Web サーバー起動ステージ
FROM nginx:1.21-alpine AS final
ENV TZ=Asia/Tokyo
COPY docker/prod/nginx/default.conf /etc/nginx/conf.d/default.conf
COPY docker/prod/nginx/ssl /etc/nginx/ssl
COPY --from=node-build /src/dist /var/www/html
EXPOSE 80
EXPOSE 443
CMD ["nginx", "-g", "daemon off;"]
