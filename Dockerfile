FROM microsoft/dotnet:2.1-sdk as builder
COPY . /code
WORKDIR /code/src/TodoService
RUN dotnet restore 
RUN dotnet publish -c Release -o publish

FROM microsoft/dotnet:2.1-runtime
COPY --from=builder /code/src/TodoService/publish /app
WORKDIR /app
ENV ASPNETCORE_URLS="http://*:5000"
EXPOSE 5000
ENTRYPOINT [ "dotnet", "/app/TodoService.dll" ]