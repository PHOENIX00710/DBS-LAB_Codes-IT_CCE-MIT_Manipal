SET SERVEROUTPUT ON
CREATE OR REPLACE TRIGGER display_info
AFTER INSERT ON participated
FOR EACH ROW -- Specify FOR EACH ROW to access the :new values
DECLARE 
    driver_name person.name%TYPE;
    driver_id person.driver_id#%TYPE;
    driver_address person.address%TYPE;
BEGIN
    IF inserting THEN
        SELECT name, driver_id#, address
        INTO driver_name, driver_id, driver_address
        FROM person
        WHERE person.driver_id# = :new.driver_id#;
        
        -- Use :new to access the values of the newly inserted row
        dbms_output.put_line('driver_id: ' || driver_id || ' address: ' || driver_address || ' name: ' || driver_name);
    END IF;
END;
/
