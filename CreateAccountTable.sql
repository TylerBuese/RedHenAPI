CREATE TABLE Account (
AccountNumber INTEGER PRIMARY KEY,
Password TEXT NOT NULL,
FirstName TEXT NOT NULL,
LastName TEXT NOT NULL,
Email TEXT NOT NULL,
IsParent INTEGER NOT NULL,
CreationDate TEXT NOT NULL,
CareGiverID TEXT NOT NULL,
CareGiverStreet TEXT NOT NULL,
CareGiverCity TEXT NOT NULL,
CareGiverCounty TEXT NOT NULL,
CareGiverState TEXT NOT NULL,
CareGiverNumOfSlotsAvailable INTEGER,
CareGiverEmail TEXT NOT NULL,
CareGiverPhoneNumber TEXT NOT NULL
)
