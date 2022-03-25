 # Movies Api
  ---
  # 🎥 o que é a Movies API?
  É uma API criada para estudo e entendimento de padrões envolvendo desenvolvimento beckend, ela utiliza padrões REST FULL com todos os verbos mais utilizados: 
  GET, UPDATE, DELETE, POST e PUT
  
  <img src="https://user-images.githubusercontent.com/70205320/157096371-a1b27c5c-9486-491b-bcca-4d0972230296.png" alt="apifilmes"/>
  
  ---
  <div> 
  <a href="https://www.youtube.com/user/cursosemvideo" target="_blank"><img src="https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white" target="_blank"></a>
  <a href="https://instagram.com/lluasalvestr" target="_blank"><img src="https://img.shields.io/badge/-Instagram-%23E4405F?style=for-the-badge&logo=instagram&logoColor=white" target="_blank"></a>
  <a href = "mailto:lucasryanalves@gmail.com"><img src="https://img.shields.io/badge/-Gmail-%23333?style=for-the-badge&logo=gmail&logoColor=white" target="_blank"></a>
  <a href="https://www.linkedin.com/in/lucas-alves-55b925182/" target="_blank"><img src="https://img.shields.io/badge/-LinkedIn-%230077B5?style=for-the-badge&logo=linkedin&logoColor=white" target="_blank"></a>
  <a href="https://www.twitch.tv/calivem" target="_blank"><img src="https://img.shields.io/badge/Twitch-9146FF?style=for-the-badge&logo=twitch&logoColor=white" target="_blank"></a>
 <img src="https://img.shields.io/github/watchers/Ryanlucass/MoviesApi?style=social" target="-blank">
</div>

 # Tecnologias utilizazdas 
  ---
  
- SQL SERVER
- ORM (Entity Framework, Dapper)
- C# (ASP NET Core 5)
- JWT token (Atualizando)
- Consumindo a API ViaCep

# Referência da API 
## Cinema
 ---
 <img src="./assets/cinema.png" alt="cinemaapi"/>
 
 - POST </br>
    https://localhost:{porta}/cinema</br>

```javascript
{ 
  "nome": "string",
  "enderecoId": 0,
  "gerenteId": 0
}
```
- GET </br>
   https://localhost:{porta}/cinema{nomefilme}</br>

   NomeFilme <span style="color:green"> required</span>

- GET </br>
  https://localhost:{porta}/cinema{id}</br>
  
   id : int <span style="color:red">required</span> 

- DELETE </br>
   https://localhost:{porta}/cinema{id}</br>

   id : int <span style="color:red">required</span>> 

## Endereco

  ---
 <img src="./assets/endereco.png" alt="enderecoapi"/>
 
 - POST </br>
    https://localhost:{porta}/endereco</br>

```javascript
{ 
  "id": 0,
  "logradouro": "string",
  "bairoo": "string",
  "numero": "string"
}
```
- GET </br>
   https://localhost:{porta}/endereco</br>

- GET </br>
  https://localhost:{porta}/endereco{id}</br>

- GET </br>
  https://localhost:{porta}/endereco{id}</br>
  
   id : int <span style="color:red">required</span> 

- PUT </br>
    https://localhost:{porta}/endereco{id}</br>

    id : int <span style="color:orange">required</span>> 

```javascript
{
  "logradouro": "string",
  "bairoo": "string",
  "numero": "string"
}
```

- DELETE </br>
   https://localhost:{porta}/endereco{id}</br>

   id : int <span style="color:red">required</span> 

## Filme

  ---
 <img src="./assets/filme.png" alt="filmeapi"/>
 
 - POST </br>
    https://localhost:{porta}/filme</br>

```javascript
{
  "id": 0,
  "titulo": "string",
  "diretor": "string",
  "genero": "string",
  "duracao": 0,
  "avaliacao": 0,
  "classificacaoEtaria": 0
}
```
- GET </br>
   https://localhost:{porta}/filme</br>

- GET </br>
  https://localhost:{porta}/filme</br>

  classificacaoEtaria : <span style="color:green">required</span>

- GET </br>
  https://localhost:{porta}/filme{id}</br>
  
   id : int <span style="color:red">required</span>

- PUT </br>
    https://localhost:{porta}/filme{id}</br>

    id : int <span style="color:orange">required</span> 

```javascript
{
  "titulo": "string",
  "diretor": "string",
  "genero": "string",
  "duracao": 0,
  "avaliacao": 0,
  "classificacaoEtaria": 0
}
```

- DELETE </br>
   https://localhost:{porta}/endereco{id}</br>

   id : int <span style="color:red">required</span> 

## Gerente
 ---
 <img src="./assets/gerente.png" alt="gerenteapi"/>
 
 - POST </br>
    https://localhost:{porta}/gerente</br>

```javascript
{
  "nome": "string"
}
```
- GET </br>
   https://localhost:{porta}/gerente</br>

- GET </br>
  https://localhost:{porta}/gerente{id}</br>
  
   id : int <span style="color:red">required</span> 

- DELETE </br>
   https://localhost:{porta}/gerente{id}</br>

   id : int <span style="color:red">required</span>

## Sessao
 ---
 <img src="./assets/sessao.png" alt="gerenteapi"/>
 
 - POST </br>
    https://localhost:{porta}/sessao</br>

```javascript
{
  "id": 0,
  "cinemaId": 0,
  "filmeId": 0,
  "cinema": {
    "id": 0,
    "nome": "string",
    "enderecoId": 0,
    "gerenteId": 0
  },
  "filme": {
    "id": 0,
    "titulo": "string",
    "diretor": "string",
    "genero": "string",
    "duracao": 0,
    "avaliacao": 0,
    "classificacaoEtaria": 0
  },
  "horarioDeEncerramento": "2022-03-07T23:22:45.526Z"
}
```
- GET </br>
   https://localhost:{porta}/sessao</br>

- GET </br>
  https://localhost:{porta}/sessao{id}</br>
  
   id : int <span style="color:red">required</span> 
   
   





