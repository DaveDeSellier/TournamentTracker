IF NOT EXISTS (
        SELECT *
        FROM sys.databases
        WHERE name = 'TournamentTracker'
        )
BEGIN
    CREATE DATABASE TournamentTracker
END