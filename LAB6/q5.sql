SET SERVEROUTPUT ON
CREATE OR REPLACE PROCEDURE display_accident_info(place Varchar2)
IS
    var accident%rowtype;
BEGIN
    select report_number,accd_date,location
    into var.report_number,var.accd_date,var.location
    from accident
    where location=place;
    dbms_output.put_line('Report No: '|| var.report_number || '  Accident Date: '|| var.accd_date || '  Location: '|| var.location);
END;
/