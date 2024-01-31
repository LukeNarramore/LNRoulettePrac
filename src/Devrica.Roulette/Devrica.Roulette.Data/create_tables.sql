---- Create a new SQLite database
--CREATE DATABASE IF NOT EXISTS roulette;

---- Use the created database
--USE roulette;

-- Create a table to store spin results
CREATE TABLE IF NOT EXISTS spin_results (
    spin_number INTEGER PRIMARY KEY,
    color TEXT NOT NULL,
    outcome TEXT NOT NULL,
    timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


-- Create a table to store straight bets
CREATE TABLE IF NOT EXISTS straight_bets (
    bet_id INTEGER PRIMARY KEY,
    spin_number INTEGER,
    bet_amount INTEGER,
    bet_number INTEGER,
    color TEXT,
    outcome TEXT,
    FOREIGN KEY (spin_number) REFERENCES spin_results(spin_number)
);

-- Create a table to store split bets
CREATE TABLE IF NOT EXISTS split_bets (
    bet_id INTEGER PRIMARY KEY,
    spin_number INTEGER,
    bet_amount INTEGER,
    bet_numbers TEXT,
    color TEXT,
    outcome TEXT,
    FOREIGN KEY (spin_number) REFERENCES spin_results(spin_number)
);

-- Create the SQL lite DB
-- sqlite3 roulette.sqlt < CreateDB.sql