# **Docker para projetos com .NET Core.**

Olá, Meu nome é Mauro, sou uma pessoa desenvolvedora, e recentemente surgiu a necessidade de utilizar docker para realizar os testes de integração do projeto. 

Com o intuito de transmitir um pouco do conhecimento que assimilei nessa jornada criei esse post ressaltando a importância dos testes de integração em qualquer projeto que esteja em um cenário semelhante.

Para estarmos todos na mesma página segue uma leve introdução sobre o que é teste de integração e docker. 

### **O que é Teste de Integração ?** 

De forma resumida um teste de integração é aquele que testa a integração entre duas partes do seu sistema. Os testes que você escreve para a sua classe API Todo, por exemplo, onde seu teste realiza requisições HTTP, é um teste de integração. Afinal, você está testando a integração do seu sistema com o sistema externo, que é a API Todo. Testes que garantem que suas classes comunicam-se bem com serviços web,escrevem arquivos texto, ou mesmo mandam mensagens via socket são considerados testes de integração.

### **O que é Docker ?** 

É uma ferramenta projetada para facilitar a criação, implementação e a execução de aplicativos usando containers. Os containers permitem que um desenvolvedor empacote um aplicativo com todas as dependências que precisa como bibliotecas e outras dependências, e envie tudo como um único pacote. Ao fazer isso, graças ao container, o desenvolvedor pode ter certeza de que o aplicativo será executado em qualquer outra máquina, independentemente de qualquer configurações personalizadas que a máquina possa ter e que possam difernciar da máquina usada para gravar e testar o código

### **Análise do Problema:**

Recentemente surgiu a necessidade de utilizar docker para realizar os testes de integração do meu projeto desenvolvido em .Net Core v2.1.

Com o intuito de garantir que os testes não estão sofrendo interferência do ambiente externo para serem executados, isto é, sofrendo impacto do computador onde o projeto foi clonado e evitar aquela famosa frase: "Funciona na minha maquina" resolvi utilizar o Docker, dessa forma encapsulo o ambiente com tudo que é necessário para o projeto ser executado e caso ocorra alguma falha posso "desconsiderar" problemas relacionados ao ambiente e focar no codigo fonte. 

Existem alguns arquivos docker necessários para preparar o cenário para os nossos testes de integração e são eles: 

1.  **Dockerfile**: Será utilizado para criar e publicar o  conteúdo do serviço e copiar o conteúdo publicado em um container.
2. **Dockerfile.integration**: Será utilizado para criar e restaurar o projeto de teste de integração, preparando-o para executar os testes. 

3. **docker-compose-integration.xml**: Será utilizado para manter o serviço Todo e executar nossos testes de integração consumindo o serviço:

Para executar basta clonar o repositorio e executar o arquivo .bat (./scripts/initialize.bat) ou executar o comando na pasta do projeto onde está o arquivo docker-compose-integration.yml:

docker-compose -f ../docker-compose-integration.yml up

Após realizar executar esse comando o projeto começara a criar o container, copiar o projeto, restaurar as depedências e executar o teste.

****** Atenção *******

O script delete_all_containers.bat so deve ser utilizado caso você queira apagar todos os containers docker que você tiver no seu computador, então use com sabedoria.



