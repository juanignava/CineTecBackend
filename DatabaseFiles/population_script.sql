INSERT INTO CLIENT (ID, First_name, Last_name, Sec_last_name, Age, Birth_date, Phone_number, Password)
    VALUES  (1, 'Juan', 'Navarro', 'Navarro', '20', '2001-02-08', '87175508', 'passwordnacho'),
            (2, 'Monica', 'Waterhouse', 'Montoya', '20', '2001-02-08', '871755555', 'passwordmoni'),
            (3, 'Luis', 'Morales', 'Rodriguez', '20', '2001-02-08', '87778899', 'passwordluis'),
            (4, 'Ignacio', 'Grnados', 'Marin', '20', '2001-02-08', '87176644', 'passwordnacho');


INSERT INTO MOVIE_THEATER (Name, Location, Cinema_amount)
    VALUES  ('Paseo', 'Cartago', 2),
            ('Multiplaza', 'San Jose', 1),
            ('CineMark', 'Heredia', 2);


INSERT INTO  CINEMA (Number, Rows, Columns, Capacity, Name_movie_theater)
    VALUES  (1, 10, 10, 50, 'Paseo'),
            (2, 15, 15, 50, 'Paseo'),
            (3, 10, 15, 30, 'Multiplaza'),
            (4, 20, 15, 50, 'CineMark'),
            (5, 10, 10, 50, 'CineMark');


INSERT INTO MOVIE (Original_name, Gendre, Director, Image_url, Lenght)
    VALUES ('Titanic', 'Suspense', 'Cameron', 'https://github.com/juanignava/CineTecBackend/blob/main/MovieImages/Titanic.jpg', 180),
           ('Minions', 'Comedy', 'Polack', 'https://github.com/juanignava/CineTecBackend/blob/main/MovieImages/Minions.jpg', 120),
           ('Space Jam', 'Comedy', 'Lee', 'https://github.com/juanignava/CineTecBackend/blob/main/MovieImages/Space%20Jam.jpg', 140),
           ('Black Widow', 'Action', 'Shortlan', 'https://github.com/juanignava/CineTecBackend/blob/main/MovieImages/Black%20Widow.jpg', 110);


INSERT INTO ACTORS(Original_movie_name, Actor_name)
    VALUES  ('Titanic', 'DiCaprio'),
            ('Titanic', 'Winslet'),
            ('Space Jam', 'LeBron'),
            ('Space Jam', 'Zendaya'),
            ('Space Jam', 'Jordan'),
            ('Black Widow', 'Johansson'),
            ('Black Widow', 'Pugh');


