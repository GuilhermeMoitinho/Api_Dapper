# Livro API

Esta é uma API REST desenvolvida utilizando o padrão Clean Architecture, Dapper e seguindo a estrutura de pastas organizada em Application, UI, Infra e Domain. O projeto utiliza o padrão Repository para operações de banco de dados.

## Visão Geral

Este projeto é uma API para gerenciar informações de livros. Ele fornece operações CRUD (Criar, Ler, Atualizar e Deletar) para livros.

## Funcionalidades

- `GET /api/Livro`: Recupera todos os livros cadastrados.
- `GET /api/Livro/{id}`: Recupera um livro específico com base no ID.
- `POST /api/Livro`: Cria um novo livro.
- `PUT /api/Livro`: Atualiza as informações de um livro existente.
- `DELETE /api/Livro/{id}`: Exclui um livro com base no ID.

## Tecnologias Utilizadas

- ASP.NET Core
- Dapper (para acesso ao banco de dados)
- Clean Architecture (para organização do projeto)
- Padrão Repository (para operações de banco de dados)

## Pré-requisitos

Antes de executar o projeto, certifique-se de ter os seguintes pré-requisitos instalados:

- .NET Core SDK
- SQL Server (ou outro banco de dados suportado)

## Como Executar

1. Clone este repositório em sua máquina local.
2. Configure a string de conexão com o banco de dados no arquivo `appsettings.json`.
3. Execute o projeto usando o comando `dotnet run` no diretório raiz do projeto.
4. Acesse a API em `http://localhost:5000` no seu navegador ou em uma ferramenta como o Swagger.

## Exemplo de Uso

Você pode assistir a um vídeo de demonstração da aplicação em funcionamento no Swagger [aqui](link_para_o_video).

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir um problema ou enviar um pull request.

## Licença

Este projeto é licenciado sob a Licença MIT. Consulte o arquivo [LICENSE](LICENSE) para obter mais detalhes.

