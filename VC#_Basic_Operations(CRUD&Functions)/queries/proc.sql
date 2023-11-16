SET SERVEROUTPUT ON
CREATE OR REPLACE PROCEDURE siddharth_chutiya(city VARCHAR2) AS
    cursor c1 is select * from accident where location=city;
BEGIN   
    for c2 in c1 loop
        INSERT INTO temporary values(c2.report_number,c2.accd_date,c2.location);
        commit;
    end loop;
end;
/