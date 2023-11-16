CREATE OR REPLACE FUNCTION chutiya_kshiteesh
RETURN VARCHAR2 AS person_age VARCHAR2(20);
kshi varchar2(5);
BEGIN
    select age into person_age
    from test
    where name='Srijan';
    RETURN person_age;
end;
/

/*     D:/210911292/queries/test.sql   chutiya_kshiteesh     */