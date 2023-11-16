SET SERVEROUTPUT ON
CREATE OR REPLACE FUNCTION return_count(given_year number)
RETURN number AS accd_count number;
BEGIN
    select count(distinct report_number) into accd_count
    from accident
    where EXTRACT(YEAR FROM accd_date) = given_year;
    return accd_count;
end;
/

/*   select return_count(2022) from dual;      */