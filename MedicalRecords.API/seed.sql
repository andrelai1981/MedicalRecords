begin tran

delete from MedicalRecords.dbo.County

SET IDENTITY_INSERT MedicalRecords.dbo.County ON

insert into MedicalRecords.dbo.County(CountyId, CountyName)
select CountyFIPS, CountyName from BBTSmartcareSetup.dbo.Counties where StateFIPS = 48

select * from MedicalRecords.dbo.County


ROLLBACK

begin tran
insert into MedicalRecords.dbo.Box (DepartmentId, CountyId) 
VALUES(1, 48491)

insert into MedicalRecords.dbo.Box (DepartmentId, CountyId) 
VALUES(2, 48021)

insert into MedicalRecords.dbo.Box (DepartmentId, CountyId) 
VALUES(3, 48053)

select * from MedicalRecords.dbo.Box

ROLLBACK