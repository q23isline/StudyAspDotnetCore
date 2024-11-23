FROM mcr.microsoft.com/mssql/server:2022-latest

# <https://learn.microsoft.com/ja-jp/sql/linux/sql-server-linux-configure-environment-variables?view=sql-server-ver16#environment-variables>
# 使用許諾契約書の承諾
ENV ACCEPT_EULA=Y
# SQL Server に使用する言語 ID を設定（日本）
ENV MSSQL_LCID=1041
# SQL Server の既定の照合順序を設定
ENV MSSQL_COLLATION=Japanese_CI_AS

# タイムゾーンを設定（日本）
ENV TZ=Asia/Tokyo

COPY docker/local/mssql/init/ /usr/src/app/

EXPOSE 1433
