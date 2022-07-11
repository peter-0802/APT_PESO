DROP VIEW IF EXISTS `apt_peso`.`v_dashboard`;
CREATE VIEW `apt_peso`.`v_dashboard` AS
select
(select count(*) from sra2) as sra,
(select count(*) from pwd) as pwd
;