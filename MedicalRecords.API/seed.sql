begin tran

delete from MedicalRecords.dbo.County

SET IDENTITY_INSERT MedicalRecords.dbo.County ON

insert into MedicalRecords.dbo.County(CountyId, CountyName)
select CountyFIPS, CountyName from BBTSmartcareSetup.dbo.Counties where StateFIPS = 48

select * from MedicalRecords.dbo.County


ROLLBACK

begin tran
insert into MedicalRecords.dbo.Boxes (DepartmentId, CountyId) 
VALUES(1, 48491)

insert into MedicalRecords.dbo.Boxes (DepartmentId, CountyId) 
VALUES(2, 48021)

insert into MedicalRecords.dbo.Boxes (DepartmentId, CountyId) 
VALUES(3, 48053)


insert into MedicalRecords.dbo.Files(BoxId, Description, Destroyed)
values (19, 'Test 1', 0)
insert into MedicalRecords.dbo.Files(BoxId, Description, Destroyed)
values (19, 'Test 2', 0)
insert into MedicalRecords.dbo.Files(BoxId, Description, Destroyed)
values (19, 'Test 3', 0)
insert into MedicalRecords.dbo.Files(BoxId, Description, Destroyed)
values (20, 'Test 4', 0)
insert into MedicalRecords.dbo.Files(BoxId, Description, Destroyed)
values (20, 'Test 5', 1)
insert into MedicalRecords.dbo.Files(BoxId, Description, Destroyed)
values (20, 'Test 6', 0)
insert into MedicalRecords.dbo.Files(BoxId, Description, Destroyed)
values (21, 'Test 7', 0)
insert into MedicalRecords.dbo.Files(BoxId, Description, Destroyed)
values (21, 'Test 8', 1)
insert into MedicalRecords.dbo.Files(BoxId, Description, Destroyed)
values (21, 'Test 9', 0)

select * from MedicalRecords.dbo.Files
ROLLBACK