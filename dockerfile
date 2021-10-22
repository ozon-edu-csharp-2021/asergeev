FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
    
WORKDIR /src

COPY ["./src/Ozon.MerchandiseService.Presentation/Ozon.MerchandiseService.Presentation.csproj", "src/Ozon.MerchandiseService.Presentation/"]

RUN dotnet restore "src/Ozon.MerchandiseService.Presentation/Ozon.MerchandiseService.Presentation.csproj"

COPY . .

WORKDIR "/src/src/Ozon.MerchandiseService.Presentation"

RUN dotnet build "Ozon.MerchandiseService.Presentation.csproj" -c Release -o /app/build

FROM build AS publish

RUN dotnet publish "Ozon.MerchandiseService.Presentation.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

WORKDIR /app

EXPOSE 80
 
FROM runtime AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ozon.MerchandiseService.Presentation.dll"]