
select top 15  job_ad.position, job_ad.City, company.CompName, category.CategName,job_ad.Id,company.Id,
isnull((select count(apply_cv.jobseekerId)  from apply_cv
 where job_ad.Id=apply_cv.job_ad_Id group by apply_cv.job_ad_id ),0) as cvcount 
from job_ad   inner join company on  job_ad.CompanyId = company.Id 
inner join category on job_ad.CategoryId = category.Id 
   
where company.CompEmail ='abc@abc.lt' and company.CompPassword = 'abc'

select job_ad_id, count(jobseekerId) as cvcount from apply_cv
group by job_ad_id
