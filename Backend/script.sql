CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(150) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    profile_picture TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE categories (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL
);

CREATE TABLE books (
    id SERIAL PRIMARY KEY,
    title VARCHAR(200) NOT NULL,
    author VARCHAR(150) NOT NULL,
    description TEXT,
    category_id INT REFERENCES categories(id) ON DELETE SET NULL,
    image_url TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE reviews (
    id SERIAL PRIMARY KEY,
    user_id INT REFERENCES users(id) ON DELETE CASCADE,
    book_id INT REFERENCES books(id) ON DELETE CASCADE,
    comment TEXT,
    rating INT CHECK (rating >= 1 AND rating <= 5),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE EXTENSION IF NOT EXISTS pgcrypto;

INSERT INTO users (name, email, password)
VALUES (
  'Betsabe',
  'betsabehoyos@gmail.com',
  crypt('123456', gen_salt('bf'))
);

INSERT INTO categories (name) VALUES
('Fantasía'),
('Ciencia Ficción'),
('Romance'),
('Historia'),
('Aventura');

INSERT INTO books (title, author, description, category_id, image_url)
VALUES 
('Harry Potter y la piedra filosofal', 'J.K. Rowling', 
 'Un niño descubre que es mago y va a una escuela de magia.', 1, NULL),

('El señor de los anillos', 'J.R.R. Tolkien', 
 'Un hobbit va en un largo viaje para destruir un anillo mágico.', 5, NULL);
