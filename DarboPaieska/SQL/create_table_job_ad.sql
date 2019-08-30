create table job_ad(
Id int Identity (1,1) Primary key,
CompanyId int,
CategoryId int,
Position varchar (255),
JobDescription varchar (255),
City varchar (255)
)