INSERT INTO CLIENT (ID, First_name, Last_name, Sec_last_name, Age, Birth_date, Phone_number, Password)
    VALUES  (1, 'Juan', 'Navarro', 'Navarro', '20', '2001-02-08', '87175508', 'password');

SELECT
    *
from
    CLIENT;


INSERT INTO MOVIE_THEATER (Name, Location, Cinema_amount)
    VALUES  ('Paseo', 'Cartago', 5),
            ('Multiplaza', 'San Jose', 6);

SELECT
    *
from 
    MOVIE_THEATER

INSERT INTO  CINEMA (Number, Rows, Columns, Capacity, Name_movie_theater)
    VALUES  (1, 10, 10, 50, 'Paseo'),
            (2, 10, 5, 30, 'Paseo');

SELECT
    *
from 
    CINEMA

INSERT INTO MOVIE (Original_name, Gendre, Director, Lenght)
    VALUES ('Titanic', 'Suspense', 'Cameron', 180),
           ('Minions', 'Comedy', 'Steven', 120);

SELECT
    *
from 
    MOVIE


