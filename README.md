# API de Gerenciamento de Projetos

Esta é uma API para geerenciamento de projetos, tem como principal objetivo visualizar cenários de implementação de Domain-Driven Design (DDD) e Clean Architecture em C# com .NET 7. Ainda está em desenvolvimento e atualmente se encontra em fase inicial. Haverão diversas decisões aqui com foco exclusivo em experimentação, uma vez que não tenho pretensão de disponibilizar esta aplicação em produção com usuários reais (ainda).

## Visão Geral
A API tem como foco principal a criação e gerenciamento básico de um projeto. Para cumprir esse objetivo, o usuário deve ser um membro cadastrado, criar um projeto, definir tarefas para esse projeto e outros membros para essas tarefas. O usuário cadastrado se torna o gerente do projeto. Simples e prático.

Para fins de praticidade, inicialmente foram implementados os endpoints, services e repositorios com acesso a dados. Detahes de autenticacao e autorização ainda não foram implementados e não serão por enquanto. KISS.

Também é possível ver que as implementações estão em português. Não tem nenhum motivo especial para isso, inglês para mim não é problema, mas na verdade acho que deveria ter um motivo especial para usar inglês.

A solução possui 4 projetos distintos, que fazem alusão às camadas do clean architecture, são essas camadas: 
1. API: Nossa camada de apresentação e interface com o usuário externo;
2. Infra: Nossa camada de infraestrutura responsável por interagir com recursos externos e de complexidade eventual, como nosso banco de dados;
3. Application: Nossa camada de aplicação onde implementaremos toda a lógica necessária para atingir o nosso objetivo;
4. Core: Nossa camada de domínio, onde estão nossas entidades e abstrações para respositórios de acesso a dados, por exemplo.

### Banco de dados
Escolhi usar o MS SQL Server inicialmente. Para interagir com o banco de dados code first, utilizei o Entity Framework, mas nada impede que outros como Dapper ou NHibernate no futuro. Atualmente o código já caminha para o baixo acoplamento e maior abstração das camadas, principalmente acesso a dados, o que favorece essas decições.

### Implementado até o momento
1. Repositories e suas Abstrações
2. Controllers com IoC
3. Services e suas Abstrações
4. Acesso a dados via EF Core ao SQL Server

### Próximas implementações
1. Exception handling
2. Rich domain models
3. Autenticação e Autorização





