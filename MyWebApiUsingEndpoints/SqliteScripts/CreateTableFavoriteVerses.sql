-- Script Date: 1/28/2022 10:42 AM  - ErikEJ.SqlCeScripting version 3.5.2.90
CREATE TABLE [FavoriteVerses] (
  [Id] INTEGER NOT NULL
, [VerseName] TEXT NOT NULL
, [VerseNameAbrv] TEXT NOT NULL
, [ScriptureIdBeg] INTEGER NOT NULL
, [ScriptureIdEnd] INTEGER NOT NULL
, [BookID] INTEGER NOT NULL
, [Commentary] TEXT NULL
, CONSTRAINT [PK_FavoriteVerses] PRIMARY KEY ([Id])
);
