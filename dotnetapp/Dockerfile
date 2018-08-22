FROM buildpack-deps:jessie-scm as build

# Install .NET CLI dependencies
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        libc6 \
        libcurl3 \
        libgcc1 \
        libgssapi-krb5-2 \
        libicu52 \
        liblttng-ust0 \
        libssl1.0.0 \
        libstdc++6 \
        libunwind8 \
        libuuid1 \
        zlib1g \
    && rm -rf /var/lib/apt/lists/*

# Install dotnet.exe
WORKDIR /app
ADD . /app

ENV DOTNET_SDK_VERSION 2.1.400

RUN curl -SL --output dotnet.tar.gz https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$DOTNET_SDK_VERSION/dotnet-sdk-$DOTNET_SDK_VERSION-linux-x64.tar.gz \
    && mkdir -p /usr/share/dotnet \
    && tar -xzf dotnet.tar.gz -C /usr/share/dotnet \
    && ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet

# Install the plugin
RUN mkdir -p /app/CP
RUN tar -xzf /app/Microsoft.NuGet.CredentialProvider.tar.gz -C /app/CP

ENV NUGET_PLUGIN_PATHS /app/CP/plugins/netcore/CredentialProvider.Microsoft/CredentialProvider.Microsoft.dll

COPY /nuget-patch/ /usr/share/dotnet/sdk/$DOTNET_SDK_VERSION

# Trigger the population of the local package cache
ENV NUGET_XMLDOC_MODE skip
RUN mkdir warmup \
    && cd warmup \
    && dotnet new \
    && cd .. \
    && rm -rf warmup \
    && rm -rf /tmp/NuGetScratch

# restore
COPY dotnetapp/*.csproj ./dotnetapp/
WORKDIR /app/dotnetapp
RUN dotnet restore /v:d

# build and publish
WORKDIR /app/
COPY dotnetapp/. ./dotnetapp/
WORKDIR /app/dotnetapp
RUN dotnet publish -c Release -o out

# entrypoint
FROM microsoft/dotnet-nightly:2.1-runtime AS runtime
WORKDIR /app
COPY --from=build /app/dotnetapp/out ./
ENTRYPOINT ["dotnet", "dotnetapp.dll"]
