CREATE TABLE CLIENT
(
    ID              INT  PRIMARY KEY,
    First_name      VARCHAR(10),
    Last_name       VARCHAR(10),
    Sec_last_name   VARCHAR(10),
    Age             INT,
    Birth_date      DATE,
    Phone_number    VARCHAR(10)
);

CREATE TABLE MOVIE_THEATER
(
    Name            VARCHAR(10) PRIMARY KEY,
    Location        VARCHAR(10),
    Cinema_amount   INT
);

CREATE TABLE CINEMA
(
    Number              INT PRIMARY KEY,
    Rows                INT,
    Columns             INT,
    Capacity            INT,
    Name_movie_theater  VARCHAR(10)
);

CREATE TABLE MOVIE
(
    Original_name       VARCHAR(10) PRIMARY KEY,
    Gendre              VARCHAR(10),
    Name                VARCHAR(10),
    Director            VARCHAR(10),
    Lenght              INT
);

CREATE TABLE SCREENING
(
    Cinema_number       INT,
    Movie_original_name VARCHAR(10),
    Hour                INT,
    PRIMARY KEY (Cinema_number, Movie_original_name, Hour)
);

CREATE TABLE ACTORS
(
    Original_movie_name VARCHAR(10),
    Actor_name          VARCHAR(10),
    PRIMARY KEY (Original_movie_name, Actor_name)
);

CREATE TABLE SEAT
(
    Cinema_number       INT,
    Row_num                 INT,
    Column_num              INT,
    State               VARCHAR(10),
    PRIMARY KEY (Cinema_number, Row, Column)
);

ALTER TABLE CINEMA
ADD CONSTRAINT CINEMA_MOVIE_THEATER_FK FOREIGN KEY (Name_movie_theater)
REFERENCES MOVIE_THEATER(Name)

ALTER TABLE SCREENING
ADD CONSTRAINT SCREENING_CINEMA_FK FOREIGN KEY (Cinema_number)
REFERENCES CINEMA(Number)

ALTER TABLE SCREENING
ADD CONSTRAINT SCREENING_MOVIE_FK FOREIGN KEY (Movie_original_name)
REFERENCES MOVIE(Original_name)

ALTER TABLE SEAT
ADD CONSTRAINT SEAT_CINEMA_FK FOREIGN KEY (Cinema_number)
REFERENCES CINEMA(Number)

ALTER TABLE ACTORS
ADD CONSTRAINT ACTORS_MOVIE_FK FOREIGN KEY (Original_movie_name)
REFERENCES MOVIE (Original_name)