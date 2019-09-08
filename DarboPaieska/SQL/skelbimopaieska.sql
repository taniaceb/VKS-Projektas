select d.FirstName,d.LastName, d.Age,d.Phone,d.Email, d.CvFile 
from(select a.FirstName, a.LastName, a.Email, a.Phone, a.Age, b.CvFile,c.job_ad_Id
from jobseeker as a
inner join cv as b
on a.Id=b.JobSeekerId
inner join apply_cv as c
on a.Id = c.jobseekerId) as d
inner join job_ad as e
on d.job_ad_Id = e.Id and e.CompanyId = 1 and e.Id =2



