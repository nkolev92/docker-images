# .NET Core Console App sample

A bare bones docker image to test basic restore performance in docker images. 

The sample builds the application in a container based on the larger [.NET Core SDK Docker image](https://hub.docker.com/r/microsoft/dotnet/).

This sample requires [Docker 17.06](https://docs.docker.com/release-notes/docker-ce) or later of the [Docker client](https://www.docker.com/products/docker).

## Build and run the sample with Docker

```console
docker build -f .\Dockerfile --pull -t dotnetapp .
docker run --rm dotnetapp Hello .NET Core from Docker
```