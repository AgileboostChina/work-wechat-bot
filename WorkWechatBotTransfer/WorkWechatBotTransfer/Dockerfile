FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /code
COPY . /code
WORKDIR /code/WorkWechatBotTransfer/WorkWechatBotTransfer

RUN dotnet nuget add source https://mirrors.cloud.tencent.com/nuget/
RUN dotnet restore
RUN dotnet publish -c Release -o /output

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /output/ .

ENV TZ=Asia/Shanghai
EXPOSE 80
ENTRYPOINT [ "dotnet","WorkWechatBotTransfer.dll" ]