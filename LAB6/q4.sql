SET SERVEROUTPUT ON
CREATE OR REPLACE PROCEDURE total_damage_in_year(driver_id Varchar2,given_year number)
IS
    amount int;
BEGIN
    SELECT sum(damage_amount) INTO amount
    FROM participated natural join accident
    WHERE driver_id#=driver_id AND EXTRACT(year from accd_date)=given_year;
    dbms_output.put_line('Total damage amount: '|| amount);
END;
/
