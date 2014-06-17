use DapperDemo

IF NOT EXISTS (SELECT * FROM Users WHERE Login = 'jordan@dapper.demo')
INSERT INTO Users ([Login], FirstName, LastName, [Status]) VALUES ('jordan@dapper.demo', 'Michael', 'Jordan', 1)

IF NOT EXISTS (SELECT * FROM Users WHERE Login = 'lebron@dapper.demo')
INSERT INTO Users ([Login], FirstName, LastName, [Status]) VALUES ('lebron@dapper.demo', 'Lebron', 'James', 1)

IF NOT EXISTS (SELECT * FROM Users WHERE Login = 'messi@dapper.demo')
INSERT INTO Users ([Login], FirstName, LastName, [Status]) VALUES ('messi@dapper.demo', 'Lionel', 'Messi', 1)

IF NOT EXISTS (SELECT * FROM Users WHERE Login = 'wade@dapper.demo')
INSERT INTO Users ([Login], FirstName, LastName, [Status]) VALUES ('wade@dapper.demo', 'Dwyane', 'Wade', 2)

IF NOT EXISTS (SELECT * FROM Users WHERE Login = 'marley@dapper.demo')
INSERT INTO Users ([Login], FirstName, LastName, [Status]) VALUES ('marley@dapper.demo', 'Bob', 'Marley', 3)