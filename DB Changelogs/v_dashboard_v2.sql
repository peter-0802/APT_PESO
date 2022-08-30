DROP VIEW IF EXISTS `apt_peso`.`v_dashboard_v2`;
CREATE VIEW `apt_peso`.`v_dashboard_v2` AS

select
(select count(0) from `child_labor`) AS `child_labor`,
(select count(0) from `hsshcoolar`) AS `hsshcoolar`,
(select count(0) from `jobfair2`) AS `jobfair`,
(select count(0) from `kasambahay2`) AS `kasambahay`,
(select count(0) from `ofw2`) AS `ofw`,
(select count(0) from `pwd`) AS `pwd`,
(select count(0) from `rwa`) AS `rwa`,
(select count(0) from `schoolar_coll`) AS `schoolar_coll`,
(select count(0) from `spes`) AS `spes`,
(select count(0) from `sra2`) AS `sra`,
(select count(0) from `contact2`) AS `contact`
;