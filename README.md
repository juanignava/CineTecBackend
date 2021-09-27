# CineTecBackend
This repo corresponds to the backend of the backend of the first project of the course of Databases

## Instalation

***installation instructions will be placed here***

## Backend JSON Body

#### Clients

```Json
[
  {
    "id": "1",
    "name": "Juan",
    "username": "juanignava",
    "paswword": "1234",
    "phoneNumber": "88775544",
    "birthDateNumber": "2",
    "birthMonthNumber": "8"
  },
  {
    "id": "2",
    "name": "Luis",
    "username": "luismorales",
    "paswword": "12345",
    "phoneNumber": "88775533",
    "birthDateNumber": "21",
    "birthMonthNumber": "10"
  }
]
```

#### Movies

```Json
{
  "movieId": 1,
  "originalName": "Faast and Furious",
  "name": "Rapidos y furiosos",
  "image": "imageURL",
  "movieLenght": 140,
  "actors": [
      "Vin Diesel", "John Cena"
      ],
  "director": "Universal",
  "category": "action"
}
```

## Backend requests

Here we have a small description of the programmed requests and their respective response (if there is any).

### Client Requests

###### POST client

Add a new client, where their id is the key attribute. If theres al ready a client with the respective id there will be an 403 error (Forbidden). This is a POST request with this url `http://localhost:5000/client` the body to include corresponds to the one of the clients.

###### GET clients

Get all the clients saved in the database. This is a GET request with this url `http://localhost:5000/client` the body aswered has the form of the client JSON body.

###### GET client by username

Get an specific client based on the username. If the user doesn't exists then a not found error will be answered. This is a GET request with this url `http://localhost:5000/client/#` where `#` represents the username of the request. the body aswered has the form of the client JSON body.


###### DELETE client

Deletes a client from the database. If the client doesn't exists then a not found error (404) will be answered. This is a DELETE request with this url `http://localhost:5000/client/#` where `#` represents the username of the request. This request has no answer.

###### PUT client

Updates the information from a client in the databse. If the client doesn't exists then a not found error (404) will be answered. This is a PUT request with this url `http://localhost:5000/client/#` where `#` represents the username of the request. The body of this requests is the one specified for the clients.

### Movie Requests

###### POST movie

### Cinema Requests

### Cinema Room Requests

### Show Requests

### Capacity Requests
