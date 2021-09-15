# Endpoints API 💿 

### GET

* / => Retorna a frase "Fullstack Challenge 2021"
* /Products/{code} => Retorna um produto passando seu código de barras
* /Products/Filtro => Retorna uma lista de produtos passando um filtro
* /Products => Retorna todos os produtos do banco
* /Products/Retrieve => Retorna a lista dos 100 primeiros produtos do Open Food Facts

### POST

* /Product => Cadastra um novo produto no banco

### PUT

* /Product/Update/{code} => Atualiza os campos: brands, packaging, categories e quantity de um produto passando o seu código de barras

### DELETE

* /Product/DeleteAll => Deleta todos os produtos do nosso banco