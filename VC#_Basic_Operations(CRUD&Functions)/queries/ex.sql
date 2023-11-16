SET SERVEROUTPUT ON
declare
person_age varchar2(20);
BEGIN   
    update_age(person_age);
    dbms_output.put_line('Age: '|| person_age);
end;
/