# LeilaoAPI

Esta é uma API simples para gerenciar um sistema de leilão,para obtenção da terceira nota na matéria ESW242 TÉCNICAS AVANÇADAS DE CONSTRUÇÃO DE SOFTWARE, onde os usuários podem cadastrar itens para leilão, cadastrar compradores e efetuar lances nos itens em leilão.

## Funcionalidades

- Cadastro de Itens: Os vendedores podem cadastrar os itens para leilão, fornecendo descrições detalhadas, lance inicial e tempo de leilão.
- Cadastrar Compradores: Os compradores podem se cadastrar fornecendo apenas o nome e o email.
- Efetuar Lance: Os compradores podem efetuar lances para os itens cadastrados. O comprador pode fazer quantos lances quiser para o mesmo item desde que seja em um valor maior que o lance anterior.
- Listagem e Descrição de Itens: Os usuários podem listar os itens em leilão, qual o maior lance dado para o item e quanto tempo falta para finalizar o leilão do item.


## Pré-requisitos

- [.NET 7 SDK](https://dotnet.microsoft.com/download)
- [Postman](https://www.postman.com/downloads/) ou qualquer cliente de API REST para testar os endpoints

## Como Executar

1. Clone este repositório:

   ```bash
   git clone https://github.com/lucianomartisnjr/leilaoapi.git

2. Navegue até o diretório do projeto:
   
   ```bash
    cd LeilaoAPI
   
4. Execute o projeto:
   
   ```bash
    dotnet run
      
4.Abra o Postman ou qualquer outro cliente de API REST e teste os endpoints conforme necessário.
