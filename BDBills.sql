SET IDENTITY_INSERT Users ON
Insert into Users (Id, DateCreation, DateModification, Name, IsDeleted) VALUES (100, GETDATE(), NULL, 'Joseph Carlton', 0);
Insert into Users (Id, DateCreation, DateModification, Name, IsDeleted) VALUES (200, GETDATE(), NULL, 'María Juárez', 0);
Insert into Users (Id, DateCreation, DateModification, Name, IsDeleted) VALUES (300, GETDATE(), NULL, 'Albert Kenny', 0);
Insert into Users (Id, DateCreation, DateModification, Name, IsDeleted) VALUES (400, GETDATE(), NULL, 'Jessica Phillips', 0);
Insert into Users (Id, DateCreation, DateModification, Name, IsDeleted) VALUES (500, GETDATE(), NULL, 'Charles Johnson', 0);
SET IDENTITY_INSERT Users OFF
GO
SET IDENTITY_INSERT BillCurrencies ON
Insert into BillCurrencies (Id, Name, DateCreation, DateModification, IsDeleted) VALUES (1, 'USD', GETDATE(), NULL, 0);
SET IDENTITY_INSERT BillCurrencies OFF
GO
SET IDENTITY_INSERT BillStates ON
Insert into BillStates (Id, Name, DateCreation, DateModification, IsDeleted) VALUES (1, 'PENDING', GETDATE(), NULL, 0);
Insert into BillStates (Id, Name, DateCreation, DateModification, IsDeleted) VALUES (2, 'PAID', GETDATE(), NULL, 0);
SET IDENTITY_INSERT BillStates OFF
GO
SET IDENTITY_INSERT BillServiceTypes ON
Insert into BillServiceTypes (Id, Name, DateCreation, DateModification, IsDeleted) VALUES (1, 'ELECTRICITY', GETDATE(), NULL, 0);
Insert into BillServiceTypes (Id, Name, DateCreation, DateModification, IsDeleted) VALUES (2, 'WATER', GETDATE(), NULL, 0);
Insert into BillServiceTypes (Id, Name, DateCreation, DateModification, IsDeleted) VALUES (3, 'GARBAGE', GETDATE(), NULL, 0);
Insert into BillServiceTypes (Id, Name, DateCreation, DateModification, IsDeleted) VALUES (4, 'SEWER', GETDATE(), NULL, 0);
Insert into BillServiceTypes (Id, Name, DateCreation, DateModification, IsDeleted) VALUES (5, 'TELEPHONE', GETDATE(), NULL, 0);
Insert into BillServiceTypes (Id, Name, DateCreation, DateModification, IsDeleted) VALUES (6, 'GAS', GETDATE(), NULL, 0);
SET IDENTITY_INSERT BillServiceTypes OFF
GO
Insert into Bills Values (100, 1, 100, 1,1,'2021-11-03', NULL);
Insert into Bills Values (100, 1, 100, 1,1,'2021-11-04', NULL);
Insert into Bills Values (100, 1, 150, 1,1,'2021-11-10', NULL);
Insert into Bills Values (100, 1, 100, 1,2,'2021-11-04', NULL);
Insert into Bills Values (200, 1, 101, 1,2,'2021-11-04', NULL);
Insert into Bills Values (300, 1, 102, 1,3,'2021-11-05', NULL);
Insert into Bills Values (400, 1, 103, 1,4,'2021-11-06', NULL);
Insert into Bills Values (500, 1, 104, 1,5,'2021-11-07', NULL);
Insert into Bills Values (100, 1, 105, 1,6,'2021-11-08', NULL);
Insert into Bills Values (200, 1, 106, 1,1,'2021-11-09', NULL);
Insert into Bills Values (300, 1, 107, 1,2,'2021-11-10', NULL);
Insert into Bills Values (400, 1, 108, 1,3,'2021-11-11', NULL);
Insert into Bills Values (500, 1, 109, 1,4,'2021-11-12', NULL);
Insert into Bills Values (100, 1, 110, 1,5,'2021-11-13', NULL);
Insert into Bills Values (200, 1, 111, 1,6,'2021-11-14', NULL);
Insert into Bills Values (300, 1, 112, 1,1,'2021-11-15', NULL);
Insert into Bills Values (400, 1, 113, 1,2,'2021-11-16', NULL);
Insert into Bills Values (500, 1, 114, 1,3,'2021-11-17', NULL);
Insert into Bills Values (100, 1, 115, 1,4,'2021-11-18', NULL);
Insert into Bills Values (200, 1, 116, 1,5,'2021-11-19', NULL);
Insert into Bills Values (300, 1, 117, 1,6,'2021-11-20', NULL);
Insert into Bills Values (400, 1, 118, 1,1,'2021-11-21', NULL);
Insert into Bills Values (500, 1, 119, 1,2,'2021-11-22', NULL);
Insert into Bills Values (100, 1, 120, 1,3,'2021-11-23', NULL);
Insert into Bills Values (200, 1, 121, 1,4,'2021-11-24', NULL);
Insert into Bills Values (300, 1, 122, 1,5,'2021-11-25', NULL);
Insert into Bills Values (400, 1, 123, 1,6,'2021-11-26', NULL);
Insert into Bills Values (500, 1, 124, 1,1,'2021-11-27', NULL);
Insert into Bills Values (100, 1, 125, 1,2,'2021-11-28', NULL);
Insert into Bills Values (200, 1, 126, 1,3,'2021-11-29', NULL);
Insert into Bills Values (300, 1, 127, 1,4,'2021-11-30', NULL);
Insert into Bills Values (400, 1, 128, 1,5,'2021-12-01', NULL);
Insert into Bills Values (500, 1, 129, 1,6,'2021-12-02', NULL);
Insert into Bills Values (100, 1, 130, 1,1,'2021-12-03', NULL);
Insert into Bills Values (200, 1, 131, 1,2,'2021-12-04', NULL);
Insert into Bills Values (300, 1, 132, 1,3,'2021-12-05', NULL);
Insert into Bills Values (400, 1, 133, 1,4,'2021-12-06', NULL);
Insert into Bills Values (500, 1, 134, 1,5,'2021-12-07', NULL);
Insert into Bills Values (100, 1, 135, 1,6,'2021-12-08', NULL);
Insert into Bills Values (200, 1, 136, 1,1,'2021-12-09', NULL);
Insert into Bills Values (300, 1, 137, 1,2,'2021-12-10', NULL);
Insert into Bills Values (400, 1, 138, 1,3,'2021-12-11', NULL);
Insert into Bills Values (500, 1, 139, 1,4,'2021-12-12', NULL);
Insert into Bills Values (100, 1, 140, 1,5,'2021-12-13', NULL);
Insert into Bills Values (200, 1, 141, 1,6,'2021-12-14', NULL);
Insert into Bills Values (300, 1, 142, 1,1,'2021-12-15', NULL);
Insert into Bills Values (400, 1, 143, 1,2,'2021-12-16', NULL);
Insert into Bills Values (500, 1, 144, 1,3,'2021-12-17', NULL);
Insert into Bills Values (100, 1, 145, 1,4,'2021-12-18', NULL);
Insert into Bills Values (200, 1, 146, 1,5,'2021-12-19', NULL);
Insert into Bills Values (300, 1, 147, 1,6,'2021-12-20', NULL);
Insert into Bills Values (400, 1, 148, 1,1,'2021-12-21', NULL);
Insert into Bills Values (500, 1, 149, 1,2,'2021-12-22', NULL);
Insert into Bills Values (100, 1, 150, 1,3,'2021-12-23', NULL);
Insert into Bills Values (200, 1, 151, 1,4,'2021-12-24', NULL);
Insert into Bills Values (300, 1, 152, 1,5,'2021-12-25', NULL);
Insert into Bills Values (400, 1, 153, 1,6,'2021-12-26', NULL);
Insert into Bills Values (500, 1, 154, 1,1,'2021-12-27', NULL);
Insert into Bills Values (100, 1, 155, 1,2,'2021-12-28', NULL);
Insert into Bills Values (200, 1, 156, 1,3,'2021-12-29', NULL);
Insert into Bills Values (300, 1, 157, 1,4,'2021-12-30', NULL);
Insert into Bills Values (400, 1, 158, 1,5,'2021-12-31', NULL);
Insert into Bills Values (500, 1, 159, 1,6,'2022-01-01', NULL);
Insert into Bills Values (100, 1, 160, 1,1,'2022-01-02', NULL);


