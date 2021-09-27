# CineTecBackend
This repo corresponds to the backend of the backend of the first project of the course of Databases

## Instalation

***installation instructions will be placed here***

## Backend requests

Here we have a small description of the programmed requests and their respective response (if there is any).

### Client Requests

###### POST client

Add a new client, where their id is the key attribute. If theres al ready a client with the respective id there will be an 403 error (Forbidden). This is a POST request with this url `http://localhost:5000/client` the body to include has the following form

```Json
{
  "id": "1",
  "username": "juanignava",
  "paswword": "1234",
  "name": "Juan",
  "phoneNumber": "88775544",
  "birthDateNumber": "2",
  "birthMonthNumber": "8"
}
```

###### GET clients

Get all the clients saved in the database. This is a GET request with this url `http://localhost:5000/client` the body aswered has the following form

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

###### GET client by username


### Movie Requests

### Cinema Requests

### Cinema Room Requests

### Show Requests

### Capacity Requests
