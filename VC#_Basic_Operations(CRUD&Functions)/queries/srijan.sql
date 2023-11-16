CREATE OR REPLACE FUNCTION gymm(memb_id VARCHAR2, memb_type VARCHAR2)
RETURN VARCHAR2
AS
  gym_memid VARCHAR2(20);
BEGIN
  SELECT mem_id INTO gym_memid FROM gym WHERE gym.mem_id = memb_id and mem_type = memb_type;
  RETURN 'FOUND';
EXCEPTION
    WHEN NO_DATA_FOUND THEN
    RETURN 'NOT FOUND';
    WHEN OTHERS THEN
    RETURN 'ERROR';
END gymm;
/
