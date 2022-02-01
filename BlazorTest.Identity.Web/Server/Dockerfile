#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BlazorTest.Identity.Web/Server/BlazorTest.Identity.Web.Server.csproj", "BlazorTest.Identity.Web/Server/"]
COPY ["BlazorTest.Identity.Web/Client/BlazorTest.Identity.Web.Client.csproj", "BlazorTest.Identity.Web/Client/"]
RUN dotnet restore "BlazorTest.Identity.Web/Server/BlazorTest.Identity.Web.Server.csproj"
COPY . .
WORKDIR "/src/BlazorTest.Identity.Web/Server"
RUN dotnet build "BlazorTest.Identity.Web.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorTest.Identity.Web.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorTest.Identity.Web.Server.dll"]