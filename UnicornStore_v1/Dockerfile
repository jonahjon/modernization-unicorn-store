FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.2-alpine3.11 AS base
# https://github.com/dotnet/SqlClient/issues/220
RUN apk add libgdiplus --update-cache --repository http://dl-3.alpinelinux.org/alpine/edge/testing/ --allow-untrusted && \
    apk add terminus-font && \
    apk add icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY UnicornStore_v1/UnicornStore.csproj UnicornStore_v1/
RUN dotnet restore UnicornStore_v1/UnicornStore.csproj
COPY . .
WORKDIR /src/UnicornStore_v1
RUN dotnet build UnicornStore.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish UnicornStore.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UnicornStore.dll"]