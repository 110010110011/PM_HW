
CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    first_name VARCHAR(50) UNIQUE,
    last_name VARCHAR(50) UNIQUE,
    email VARCHAR(50) UNIQUE
);

CREATE TABLE currency (
    id SERIAL PRIMARY KEY,
    name VARCHAR(3) UNIQUE
);

CREATE TABLE direction (
    id SERIAL PRIMARY KEY,
    name VARCHAR(7) UNIQUE
);

CREATE TABLE status (
    id SERIAL PRIMARY KEY,
    name VARCHAR UNIQUE
);

CREATE TABLE orders (
    id SERIAL PRIMARY KEY,
    user_id INTEGER REFERENCES  users(id),
    direction_id INTEGER REFERENCES  direction(id),
    currency_id INTEGER REFERENCES  currency(id),
    amount NUMERIC(10,2),
    comment TEXT,
    status_id INTEGER REFERENCES status(id),
    create_date TIMESTAMP
);

CREATE VIEW order_full AS
    SELECT orders.id,
           concat(first_name, ' ', last_name) AS "user",
           amount,
           currency.name AS "currency",
           direction.name AS "direction",
           status.name AS "status",
           create_date,
           comment
    FROM orders, users, currency, direction, status;
