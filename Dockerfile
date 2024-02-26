#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8888
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["example_payloads.csproj", "."]
RUN dotnet restore "./example_payloads.csproj"
COPY . .
WORKDIR "/src/."
EXPOSE 8888
EXPOSE 443
RUN dotnet build "example_payloads.csproj" -c Release -o /app/build

FROM build AS publish
EXPOSE 8888
EXPOSE 443
RUN dotnet publish "example_payloads.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "example_payloads.dll"]
EXPOSE 8888
EXPOSE 443