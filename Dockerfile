FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic
COPY dist /app
WORKDIR /app
ENV ASPNETCORE_URLS http://+:80
EXPOSE 80/tcp
EXPOSE 443/tcp
ENTRYPOINT ["dotnet", "ToonClient31.dll"]
