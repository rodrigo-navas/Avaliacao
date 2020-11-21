# Ploomes API #

Projeto que contém a API do projeto de avaliação da Ploomes.
O projeto foi desenvolvido orientado a camadas segundo o DDD (Domain Driven Design) e possui as seguintes camadas.

### Ploomes.API ###
Camada responsável pela Entrada e Saída de informações através de uma API RESTFul.

### Ploomes.API.Business ###
Camada responsável pelo controle de domínio (regra de negócio) do projeto.

### Ploomes.API.Cross ###
Camada com responsabilidade transversal (cross-cutting), para auxílio em todos os projetos.

### Ploomes.API.Infra###
Camada responsável por implementar a parte de infraestrutura do projeto, com acesso ao Banco de Dados com Dapper, acesso à api's externas.  