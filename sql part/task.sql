
select  id,name
from employee
where employee.salary in (select max (salary)
                          from employee);


WITH RECURSIVE TempTable as (

    select id,chief_id,1 as level
    from employee
    where chief_id is null
    union
    select employee.id,employee.chief_id, TempTable.level+1 as lvl
    from TempTable
    join employee  on  TempTable.id=employee.chief_id

)

select max(level)
from TempTable;

select  d.name,sum(salary)
from employee
join public.department d on d.id = employee.department_id
group by  d.name
order by (sum(salary)) desc
limit 1;


select id,name
from employee
where name like 'Р%н'
