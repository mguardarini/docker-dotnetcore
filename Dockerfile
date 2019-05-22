# Informa a partir de qual imagem será gerada a nova imagem.
FROM microsoft/dotnet:2.1-sdk as builder
# Copia arquivos ou diretórios locais para dentro da imagem.
COPY . /code
# Define qual será o diretório de trabalho (lugar onde serão copiados os arquivos, e criadas novas pastas);
WORKDIR /code/src/TodoService
# Especifica que o argumento seguinte será executado, ou seja, realiza a execução de um comando;
RUN dotnet restore 
RUN dotnet publish -c Release -o publish
FROM microsoft/dotnet:2.1-runtime
COPY --from=builder /code/src/TodoService/publish /app
WORKDIR /app
# Instrução que cria e atribui um valor para uma variável dentro da imagem.
ENV ASPNETCORE_URLS="http://*:5000"
# Expõem uma ou mais portas, isso quer dizer que o container quando iniciado poderá ser acessível através dessas portas;
EXPOSE 5000
#Informa qual comando será executado quando um container for iniciado utilizando esta imagem.
ENTRYPOINT [ "dotnet", "/app/TodoService.dll" ]