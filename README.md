# Fullstack Challenge 🏅 2021

## Introdução

Este é um desafio para que possamos ver as suas habilidades como Fullstack Developer.

Nesse desafio trabalharemos no desenvolvimento de uma REST API que utilizará os dados do projeto Open Food Facts, um banco de dados aberto com informação nutricional de diversos produtos alimentícios.

O projeto tem como objetivo dar suporte a equipe de nutricionistas da empresa Fitness Foods LC para que possam comparar de maneira rápida a informação nutricional dos alimentos da base do Open Food Facts. Para isso vamos precisar de um projeto front-end usando um framework javascript moderno com a usabilidade focada no nutricionistas.

### Sobre

O projeto conta com uma SPA em Angular no frontend e uma API .NET Core no backend e MongoDB como banco de dados. O projeto visa realizar um Web Scraping do site Open Food Facts para adicionar produtos ao nosso banco de dados para que possamos interagir com eles na nossa aplicação. Na interface temos uma página de "Serviços" onde podemos realizar essa ação manualmente (ela roda diariamente às 14h). Nessa mesma página podemos também rodar um segundo serviço que limpa nossa base de produtos, assim podemos verificar a adição de novos produtos desse site ao rodar o serviço manualmente. Na página "Produtos", temos um filtro de busca onde podemos listar dos os produtos no nosso banco com filtros de "Status", "Nome" e "Código de Barras".

### Logs

Sempre que um serviço é rodado, ele grava um log no nosso banco que pode ser acessado pelo usuário na tela de 'Serviços' . Ao clicar, é aberto uma modal que exibe todos os logs daquele serviço (com paginação).

### Produtos

Nessa tela, nós podemos buscar todos os produtos do nosso banco com um filtro de busca com os campos 'Código de Barras', 'Nome' e 'Status'. O status do produto pode ser 'Imported' (importado pelo serviço) ou 'Drafted' (inseriro manualmente). Nós podemos inserir os produtos manualmente clicando no botão 'Cadastrar Novo Produto'. Esta tela também conta com paginação.

### Live Demo

Esta aplicação está publicada no Heroku (API) e no Netlify (SPA):

* Aplicação: https://svynct-openfoodfacts.netlify.app/
* API: https://api-fullstack-challenge-2021.herokuapp.com/
