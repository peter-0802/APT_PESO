-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.5.33


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema apt_nknhs
--

CREATE DATABASE IF NOT EXISTS apt_nknhs;
USE apt_nknhs;

--
-- Temporary table structure for view `v_post_test`
--
DROP TABLE IF EXISTS `v_post_test`;
DROP VIEW IF EXISTS `v_post_test`;
CREATE TABLE `v_post_test` (
  `LRN` varchar(45),
  `NAME` varchar(45),
  `GRADE` varchar(45),
  `WRS` varchar(45),
  `WRL` varchar(45),
  `WCS` varchar(45),
  `WCL` varchar(45),
  `OP` varchar(45),
  `CODE` varchar(45),
  `SY` varchar(45),
  `STATUS` varchar(45)
);

--
-- Temporary table structure for view `v_pre_test`
--
DROP TABLE IF EXISTS `v_pre_test`;
DROP VIEW IF EXISTS `v_pre_test`;
CREATE TABLE `v_pre_test` (
  `LRN` varchar(45),
  `NAME` varchar(45),
  `GRADE` varchar(45),
  `WRS` varchar(45),
  `WRL` varchar(45),
  `WCS` varchar(45),
  `WCL` varchar(45),
  `OP` varchar(45),
  `CODE` varchar(45),
  `SY` varchar(45),
  `STATUS` varchar(45)
);

--
-- Temporary table structure for view `v_remediation`
--
DROP TABLE IF EXISTS `v_remediation`;
DROP VIEW IF EXISTS `v_remediation`;
CREATE TABLE `v_remediation` (
  `LRN` varchar(45),
  `NAME` varchar(45),
  `GRADE` varchar(45),
  `M1` double,
  `M2` double,
  `M3` double,
  `M4` double,
  `M5` double,
  `REMARKS` varchar(45),
  `SY` varchar(45),
  `CODE` varchar(45),
  `STATUS` varchar(45)
);

--
-- Temporary table structure for view `v_students`
--
DROP TABLE IF EXISTS `v_students`;
DROP VIEW IF EXISTS `v_students`;
CREATE TABLE `v_students` (
  `LRN` varchar(45),
  `NAME` varchar(184),
  `GRADE LEVEL` varchar(45),
  `SECTION` varchar(45)
);

--
-- Definition of table `accounts`
--

DROP TABLE IF EXISTS `accounts`;
CREATE TABLE `accounts` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `accounts`
--

/*!40000 ALTER TABLE `accounts` DISABLE KEYS */;
INSERT INTO `accounts` (`id`,`username`,`password`) VALUES 
 (1,'admin','@dm!n');
/*!40000 ALTER TABLE `accounts` ENABLE KEYS */;


--
-- Definition of table `addminpass`
--

DROP TABLE IF EXISTS `addminpass`;
CREATE TABLE `addminpass` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `adminpass` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `addminpass`
--

/*!40000 ALTER TABLE `addminpass` DISABLE KEYS */;
INSERT INTO `addminpass` (`id`,`adminpass`) VALUES 
 (1,'letmein');
/*!40000 ALTER TABLE `addminpass` ENABLE KEYS */;


--
-- Definition of table `documents`
--

DROP TABLE IF EXISTS `documents`;
CREATE TABLE `documents` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(45) NOT NULL,
  `school_year` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `IX_UNIQUE_CODE` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `documents`
--

/*!40000 ALTER TABLE `documents` DISABLE KEYS */;
INSERT INTO `documents` (`id`,`code`,`school_year`) VALUES 
 (1,'001','2021');
/*!40000 ALTER TABLE `documents` ENABLE KEYS */;


--
-- Definition of table `post_test`
--

DROP TABLE IF EXISTS `post_test`;
CREATE TABLE `post_test` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `document_id` int(10) unsigned NOT NULL,
  `lrn` varchar(45) NOT NULL,
  `student_name` varchar(45) NOT NULL,
  `grade_level` varchar(45) DEFAULT NULL,
  `word_reading_score` varchar(45) DEFAULT NULL,
  `word_reading_level` varchar(45) DEFAULT NULL,
  `reading_comprehension_score` varchar(45) DEFAULT NULL,
  `reading_comprehension_level` varchar(45) DEFAULT NULL,
  `overall_profile` varchar(45) DEFAULT NULL,
  `banked` varchar(45) NOT NULL DEFAULT 'Editable',
  PRIMARY KEY (`id`),
  KEY `FK_POST_DOC_ID` (`document_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `post_test`
--

/*!40000 ALTER TABLE `post_test` DISABLE KEYS */;
/*!40000 ALTER TABLE `post_test` ENABLE KEYS */;


--
-- Definition of table `pre_test`
--

DROP TABLE IF EXISTS `pre_test`;
CREATE TABLE `pre_test` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `document_id` int(10) unsigned NOT NULL,
  `lrn` varchar(45) NOT NULL,
  `student_name` varchar(45) NOT NULL,
  `grade_level` varchar(45) DEFAULT NULL,
  `word_reading_score` varchar(45) DEFAULT NULL,
  `word_reading_level` varchar(45) DEFAULT NULL,
  `reading_comprehension_score` varchar(45) DEFAULT NULL,
  `reading_comprehension_level` varchar(45) DEFAULT NULL,
  `overall_profile` varchar(45) DEFAULT NULL,
  `banked` varchar(45) NOT NULL DEFAULT 'Editable',
  PRIMARY KEY (`id`),
  KEY `FK_DOC_ID` (`document_id`)
) ENGINE=InnoDB AUTO_INCREMENT=158 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pre_test`
--

/*!40000 ALTER TABLE `pre_test` DISABLE KEYS */;
INSERT INTO `pre_test` (`id`,`document_id`,`lrn`,`student_name`,`grade_level`,`word_reading_score`,`word_reading_level`,`reading_comprehension_score`,`reading_comprehension_level`,`overall_profile`,`banked`) VALUES 
 (4,2,'128935130002','AYAP, CARL JOHN BUNGAN ','Grade 7','50','Frustration','50','Frustration','Frustration','Editable'),
 (5,2,'129018140016','BATION, KHEM JAMES BANOL ','Grade 7','51','Frustration','52','Frustration','Frustration','Editable'),
 (87,1,'128935130002','AYAP, CARL JOHN BUNGAN ','Grade 7','80','Frustration','57','Frustration','Frustration','Editable'),
 (88,1,'129018140016','BATION, KHEM JAMES BANOL ','Grade 7','76','Frustration','60','Instructional','Frustration','Editable'),
 (89,1,'128935140003','BUGTO, PAUL CLARK  AGOSTO ','Grade 7','77','Frustration','57','Frustration','Frustration','Editable'),
 (90,1,'129018140023','FERRER, ROLAND CLARK Z ','Grade 7','76','Frustration','59','Instructional','Frustration','Editable'),
 (91,1,'205024120014','IGLESIAS, JOHN MICHAEL DIAMBOLANG ','Grade 7','76','Frustration','59','Instructional','Frustration','Editable'),
 (92,1,'128935100023','LUCA, ALDREN MALBAS ','Grade 7','76','Frustration','56','Frustration','Frustration','Editable'),
 (93,1,'129018130065','VILLACORTE, CHARLES MONDIDO ','Grade 7','74','Frustration','61','Instructional','Frustration','Editable'),
 (94,1,'129023140012','GONZAGA, REGINE COLLANGO ','Grade 7','56','Frustration','70','Instructional','Frustration','Editable'),
 (95,1,'128938140029','CAMSON, HANIE JOY NAVARRO ','Grade 7','50','Frustration','59','Instructional','Frustration','Editable'),
 (96,1,'210504130175','MAAMBONG, GERALD MARIQUIT ','Grade 7','45','Frustration','57','Frustration','Frustration','Editable'),
 (97,1,'129018140040','DUERME, JERICHO INTEROMPA ','Grade 7','53','Frustration','70','Instructional','Frustration','Editable'),
 (98,1,'129018140058','PARADERO, HONEY JOY AMAMANGPANG ','Grade 7','55','Frustration','56','Frustration','Frustration','Editable'),
 (99,1,'130091150104','VILLAFUERTE, JENIROSE TEMONIO ','Grade 7','56','Frustration','60','Instructional','Frustration','Editable'),
 (100,1,'129018140043','AMAMANGPANG, SYRA  BARCUMA ','Grade 7','56','Frustration','67','Instructional','Frustration','Editable'),
 (101,1,'131293140338','ALBARICO, JHUN LEE BADOL ','Grade 7','50','Frustration','60','Instructional','Frustration','Editable'),
 (102,1,'129018140041','ALICABA, REAHJANE BRASAN ','Grade 7','45','Frustration','50','Frustration','Frustration','Editable'),
 (103,1,'129018140028','MENDIOLA, REXYL CABACANG ','Grade 7','56','Frustration','62','Instructional','Frustration','Editable'),
 (104,1,'128934100023','NADONZA, WARYLE RUPECIO ','Grade 7','56','Frustration','60','Instructional','Frustration','Editable'),
 (105,1,'129018140020','CENTILLAS, EJ EZRA PACIENTE ','Grade 7','57','Frustration','51','Frustration','Frustration','Editable'),
 (106,1,'129715130446','TAMPON, PRINCE JOWILYN LORD  ','Grade 7','50','Frustration','56','Frustration','Frustration','Editable'),
 (107,1,'129018140029','ODIONG , KHENT DEVON AMANDORON ','Grade 7','90','Instructional','69','Instructional','Instructional','Editable'),
 (108,1,'129018140017','BAYOGA, JEFFERSON BANOL ','Grade 7','91','Instructional','83','Independent','Instructional','Editable'),
 (109,1,'129018140022','EPE, GLEHNNFORD MONDIDO ','Grade 7','97','Independent','91','Independent','Independent','Editable'),
 (110,1,'121860130044','MACAY, D JAY DENSING ','Grade 8','78','Frustration','50','Frustration','Frustration','Editable'),
 (111,1,'128935130008','SAAVDERA, JOHN HENRITCH SAMPLING ','Grade 8','76','Frustration','65','Instructional','Frustration','Editable'),
 (112,1,'129018130072','SUIZO, RC BOY JOROLAN ','Grade 8','50','Frustration','56','Frustration','Frustration','Editable'),
 (113,1,'129018120062','CONAHAP, EDCEL SATHOSE  ','Grade 8','56','Frustration','62','Instructional','Frustration','Editable'),
 (114,1,'129018130045','TANUDTANUD, JERIMIAH GENTORALIZO ','Grade 8','58','Frustration','60','Instructional','Frustration','Editable'),
 (115,1,'129018130029','BENAVENTE , CARL JAMES LLEVADO ','Grade 8','56','Frustration','62','Instructional','Frustration','Editable'),
 (116,1,'129018130003','AMANDORON, KEVIN GORDULA ','Grade 8','58','Frustration','60','Instructional','Frustration','Editable'),
 (117,1,'129478130290','AQUINO, GIAN CARLO SUMAKOTE ','Grade 8','57','Frustration','62','Instructional','Frustration','Editable'),
 (118,1,'129018130048','LLEVADO, JERALD LLURENTE ','Grade 8','55','Frustration','57','Frustration','Frustration','Editable'),
 (119,1,'129018130038','MAHUSAY, EMMANUEL JHAY GASE ','Grade 8','52','Frustration','58','Frustration','Frustration','Editable'),
 (120,1,'129018130034','ORCULLO, JHIAN ORLY LANGUIDO ','Grade 8','50','Frustration','57','Frustration','Frustration','Editable'),
 (121,1,'129018130030','TRAZONA, KARL WAPER ','Grade 8','53','Frustration','59','Instructional','Frustration','Editable'),
 (122,1,'129018130078','DIACOSTA, MICHELLE  ','Grade 8','52','Frustration','55','Frustration','Frustration','Editable'),
 (123,1,'129018130028','BENIVENTE, PAULO  ','Grade 8','90','Instructional','90','Independent','Instructional','Editable'),
 (124,1,'129018130057','RIVERA , EUGENE RHENE ECEL ','Grade 8','90','Instructional','95','Independent','Instructional','Editable'),
 (125,1,'129018130051','CALAYON, ROSALIN POROL ','Grade 8','95','Instructional','90','Independent','Instructional','Editable'),
 (126,1,'128935130019','LAUSA, SAIRA JEAN PARBA ','Grade 8','90','Instructional','90','Independent','Instructional','Editable'),
 (127,1,'129018130058','SENTILLAS, JHIAN  ABAYON ','Grade 8','90','Instructional','90','Independent','Instructional','Editable'),
 (128,1,'129018130076','CALIBAY, CRISTY JOY LASIB ','Grade 8','100','Independent','90','Independent','Independent','Editable'),
 (129,1,'129018130054','ARTIAGA , JONNEL RAY HELACIO ','Grade 8','100','Independent','85','Independent','Independent','Editable'),
 (130,1,'129018120002','ALBARICO, JIMMY  ','Grade 8','100','Independent','90','Independent','Independent','Editable'),
 (131,1,'128954130091','PARDILLO, CINDY BIMUS ','Grade 8','100','Independent','85','Independent','Independent','Editable'),
 (132,1,'129018120111','AMADORON, JADE MOSES LANGOMES ','Grade 9','100','Independent','90','Independent','Independent','Editable'),
 (133,1,'205024120090','CABISTANTE, REYMOND TANTING ','Grade 9','50','Frustration','60','Instructional','Frustration','Editable'),
 (134,1,'209018120012','JAPSON, JONRIE DIAN ','Grade 9','100','Independent','90','Independent','Independent','Editable'),
 (135,1,'129015120010','MILLAN, JESTONIE CAROMBA ','Grade 9','90','Instructional','70','Instructional','Instructional','Editable'),
 (136,1,'129018120025','SUIZO , PRINCE REYMOND JOROLAN ','Grade 9','80','Frustration','57','Frustration','Frustration','Editable'),
 (137,1,'205024120003','CABISTANTE, DANNY  ','Grade 9','67','Frustration','60','Instructional','Frustration','Editable'),
 (138,1,'129018090027','LASIB, JAMES MART  ','Grade 9','56','Frustration','70','Instructional','Frustration','Editable'),
 (139,1,'129018120014','LOON, DOMINADOR MADUYAG ','Grade 9','60','Frustration','70','Instructional','Frustration','Editable'),
 (140,1,'129018110053','TANO, REZAN  ','Grade 9','65','Frustration','75','Instructional','Frustration','Editable'),
 (141,1,'130779100009','BAYA , ALJINE GRAYN ','Grade 9','100','Independent','80','Independent','Independent','Editable'),
 (142,1,'129018120046','POGOY, GLAYDEY VELOSO ','Grade 9','90','Instructional','90','Independent','Instructional','Editable'),
 (143,1,'129018110010','BAYOGA , CALGEN  ','Grade 9','70','Frustration','60','Instructional','Frustration','Editable'),
 (144,1,'128935110012','BUNGAOS, FRITZ  ','Grade 9','60','Frustration','68','Instructional','Frustration','Editable'),
 (145,1,'129018120103','RIVERA, JERALDSON ECEL ','Grade 9','90','Instructional','90','Independent','Instructional','Editable'),
 (146,1,'129018120105','PIA, DARREN  ','Grade 9','60','Frustration','60','Instructional','Frustration','Editable'),
 (147,1,'129018120073','WAPPER, FLORA MAE CALAYON ','Grade 10','90','Instructional','100','Independent','Instructional','Editable'),
 (148,1,'205024120013','IGLESIAS, JANNEL JR. DIAMBOLANG ','Grade 10','100','Independent','90','Independent','Independent','Editable'),
 (149,1,'134728120087','ALBIOS, AIMA  ','Grade 10','60','Frustration','56','Frustration','Frustration','Editable'),
 (150,1,'129018110007','AMAMANGPANG, KYLE  BARCOMA ','Grade 10','56','Frustration','60','Instructional','Frustration','Editable'),
 (151,1,'129018100044','LASIB , FRINES MARIEL CUENCO ','Grade 10','60','Frustration','20','Frustration','Frustration','Editable'),
 (152,1,'129018120055','MALBAS, MARLON FLORIDA ','Grade 10','56','Frustration','40','Frustration','Frustration','Editable'),
 (153,1,'129018090008','AMANDORON, HECTOR MALBAS ','Grade 10','60','Frustration','70','Instructional','Frustration','Editable'),
 (154,1,'129018110041','ODIONG, JAYVER BENAVENTE ','Grade 10','90','Instructional','70','Instructional','Instructional','Editable'),
 (155,1,'129018110019','EMOY, LAURENCE MILLAN ','Grade 10','60','Frustration','40','Frustration','Frustration','Editable'),
 (156,1,'129018120081','TANO, ZAYRIL CALAYON ','Grade 10','90','Instructional','70','Instructional','Instructional','Editable'),
 (157,1,'129018100015','BENAVENTE, KATE TRAYA ','Grade 10','100','Independent','90','Independent','Independent','Editable');
/*!40000 ALTER TABLE `pre_test` ENABLE KEYS */;


--
-- Definition of table `remediation`
--

DROP TABLE IF EXISTS `remediation`;
CREATE TABLE `remediation` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `document_id` int(10) unsigned NOT NULL,
  `lrn` varchar(45) NOT NULL,
  `student_name` varchar(45) NOT NULL,
  `grade_level` varchar(45) NOT NULL,
  `m1` double DEFAULT NULL,
  `m2` double DEFAULT NULL,
  `m3` double DEFAULT NULL,
  `m4` double DEFAULT NULL,
  `m5` double DEFAULT NULL,
  `remarks` varchar(45) DEFAULT NULL,
  `banked` varchar(45) NOT NULL DEFAULT 'Editable',
  PRIMARY KEY (`id`),
  KEY `FK_DOC_ID` (`document_id`)
) ENGINE=InnoDB AUTO_INCREMENT=76 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `remediation`
--

/*!40000 ALTER TABLE `remediation` DISABLE KEYS */;
INSERT INTO `remediation` (`id`,`document_id`,`lrn`,`student_name`,`grade_level`,`m1`,`m2`,`m3`,`m4`,`m5`,`remarks`,`banked`) VALUES 
 (72,1,'128935130002','AYAP, CARL JOHN BUNGAN ','Grade 7',10,15,15,15,5,'?????','Editable'),
 (73,1,'129018140016','BATION, KHEM JAMES BANOL ','Grade 7',5,15,20,20,20,'?????','Editable'),
 (74,1,'128935140003','BUGTO, PAUL CLARK  AGOSTO ','Grade 7',8,15,10,15,15,'?????','Editable'),
 (75,1,'129018140023','FERRER, ROLAND CLARK Z ','Grade 7',10,18,20,50,50,'?????','Editable');
/*!40000 ALTER TABLE `remediation` ENABLE KEYS */;


--
-- Definition of table `students`
--

DROP TABLE IF EXISTS `students`;
CREATE TABLE `students` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `lrn` varchar(45) NOT NULL,
  `lastname` varchar(45) NOT NULL,
  `firstname` varchar(45) NOT NULL,
  `middlename` varchar(45) NOT NULL,
  `ext` varchar(45) NOT NULL,
  `grade_level` varchar(45) NOT NULL,
  `section` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `IX_UNIQUE_LRN` (`lrn`)
) ENGINE=InnoDB AUTO_INCREMENT=83 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `students`
--

/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students` (`id`,`lrn`,`lastname`,`firstname`,`middlename`,`ext`,`grade_level`,`section`) VALUES 
 (1,'128935130002','AYAP','CARL JOHN','BUNGAN','','Grade 7','Mangrove'),
 (2,'129018140016','BATION','KHEM JAMES','BANOL','','Grade 7','Mangrove'),
 (3,'128935140003','BUGTO','PAUL CLARK ','AGOSTO','','Grade 7','Mangrove'),
 (4,'129018140023','FERRER','ROLAND CLARK','Z','','Grade 7','Mangrove'),
 (5,'205024120014','IGLESIAS','JOHN MICHAEL','DIAMBOLANG','','Grade 7','Mangrove'),
 (6,'128935100023','LUCA','ALDREN','MALBAS','','Grade 7','Mangrove'),
 (7,'129018130065','VILLACORTE','CHARLES','MONDIDO','','Grade 7','Mangrove'),
 (8,'129023140012','GONZAGA','REGINE','COLLANGO','','Grade 7','Mangrove'),
 (9,'128938140029','CAMSON','HANIE JOY','NAVARRO','','Grade 7','Mangrove'),
 (10,'210504130175','MAAMBONG','GERALD','MARIQUIT','','Grade 7','Almond'),
 (11,'129018140040','DUERME','JERICHO','INTEROMPA','','Grade 7','Almond'),
 (12,'129018140058','PARADERO','HONEY JOY','AMAMANGPANG','','Grade 7','Almond'),
 (13,'130091150104','VILLAFUERTE','JENIROSE','TEMONIO','','Grade 7','Almond'),
 (14,'129018140043','AMAMANGPANG','SYRA ','BARCUMA','','Grade 7','Mangrove'),
 (15,'129715130446','TAMPON','PRINCE JOWILYN LORD','','','Grade 7','Almond'),
 (16,'129018140015','CENTILLAS','CEDRIX ANTHONY','BATION','','Grade 7','Almond'),
 (17,'129018140018','BENAVENTE ','JAMES JERALD','EDROTE','','Grade 7','Almond'),
 (18,'129018130062','LANGUIDO','JOEZER','MANZANO','','Grade 7','Almond'),
 (19,'129018140024','FELOMINO','L G','LLEVADO','','Grade 7','Mangrove'),
 (20,'128306140014','MALBAS','HARVEY ','LURICA','','Grade 7','Mangrove'),
 (21,'129018140013','BAYA','MARY ANN','GRAYN','','Grade 7','Mangrove'),
 (22,'129018140029','ODIONG ','KHENT DEVON','AMANDORON','','Grade 7','Almond'),
 (23,'131293140338','ALBARICO','JHUN LEE','BADOL','','Grade 7','Almond'),
 (24,'129018140041','ALICABA','REAHJANE','BRASAN','','Grade 7','Almond'),
 (25,'129018140017','BAYOGA','JEFFERSON','BANOL','','Grade 7','Almond'),
 (26,'129018140028','MENDIOLA','REXYL','CABACANG','','Grade 7','Almond'),
 (27,'129018140022','EPE','GLEHNNFORD','MONDIDO','','Grade 7','Almond'),
 (28,'128934100023','NADONZA','WARYLE','RUPECIO','','Grade 7','Mangrove'),
 (29,'129018140020','CENTILLAS','EJ EZRA','PACIENTE','','Grade 7','Mangrove'),
 (30,'129018130002','AMANDORON ','CHARLIE MAGNE','SENTILLAS','','Grade 8','Bronze'),
 (31,'129018130055','DAVIS','GERALD','LLEVADO','','Grade 8','Bronze'),
 (32,'121860130044','MACAY','D JAY','DENSING','','Grade 8','Bronze'),
 (33,'128935130008','SAAVDERA','JOHN HENRITCH','SAMPLING','','Grade 8','Bronze'),
 (34,'129018130072','SUIZO','RC BOY','JOROLAN','','Grade 8','Bronze'),
 (35,'129018120062','CONAHAP','EDCEL SATHOSE','','','Grade 8','Bronze'),
 (36,'129018130045','TANUDTANUD','JERIMIAH','GENTORALIZO','','Grade 8','Bronze'),
 (37,'129018130028','BENIVENTE','PAULO','','','Grade 8','Bronze'),
 (38,'129018130003','AMANDORON','KEVIN','GORDULA','','Grade 8','Onyx'),
 (39,'130459130048','ANTIQUANDO','EDERSON','TUBOG','','Grade 8','Onyx'),
 (40,'129478130290','AQUINO','GIAN CARLO','SUMAKOTE','','Grade 8','Onyx'),
 (41,'129018130029','BENAVENTE ','CARL JAMES','LLEVADO','','Grade 8','Onyx'),
 (42,'129018130048','LLEVADO','JERALD','LLURENTE','','Grade 8','Onyx'),
 (43,'129018130038','MAHUSAY','EMMANUEL JHAY','GASE','','Grade 8','Onyx'),
 (44,'129018130034','ORCULLO','JHIAN ORLY','LANGUIDO','','Grade 8','Onyx'),
 (45,'129018130057','RIVERA ','EUGENE RHENE','ECEL','','Grade 8','Onyx'),
 (46,'129018130030','TRAZONA','KARL','WAPER','','Grade 8','Onyx'),
 (47,'129018130051','CALAYON','ROSALIN','POROL','','Grade 8','Onyx'),
 (48,'128935130019','LAUSA','SAIRA JEAN','PARBA','','Grade 8','Onyx'),
 (49,'129018130036','LUCTOG','JESSA ','ANTIQUANDO','','Grade 8','Onyx'),
 (50,'129018130078','DIACOSTA','MICHELLE','','','Grade 8','Bronze'),
 (51,'129018130076','CALIBAY','CRISTY JOY','LASIB','','Grade 8','Bronze'),
 (52,'129018130054','ARTIAGA ','JONNEL RAY','HELACIO','','Grade 8','Bronze'),
 (53,'129018130058','SENTILLAS','JHIAN ','ABAYON','','Grade 8','Onyx'),
 (54,'129018120002','ALBARICO','JIMMY','','','Grade 8','Bronze'),
 (55,'128954130091','PARDILLO','CINDY','BIMUS','','Grade 8','Bronze'),
 (56,'129018120111','AMADORON','JADE MOSES','LANGOMES','','Grade 9','Rizal'),
 (57,'205024120090','CABISTANTE','REYMOND','TANTING','','Grade 9','Rizal'),
 (58,'209018120012','JAPSON','JONRIE','DIAN','','Grade 9','Rizal'),
 (59,'129015120010','MILLAN','JESTONIE','CAROMBA','','Grade 9','Rizal'),
 (60,'129018120025','SUIZO ','PRINCE REYMOND','JOROLAN','','Grade 9','Rizal'),
 (61,'129018120103','RIVERA','JERALDSON','ECEL','','Grade 9','Rizal'),
 (62,'130779100009','BAYA ','ALJINE','GRAYN','','Grade 9','Rizal'),
 (63,'205024120003','CABISTANTE','DANNY','','','Grade 9','Roxas'),
 (64,'129018090027','LASIB','JAMES MART','','','Grade 9','Roxas'),
 (65,'129018120014','LOON','DOMINADOR','MADUYAG','','Grade 9','Roxas'),
 (66,'129018110053','TANO','REZAN','','','Grade 9','Roxas'),
 (67,'129018120046','POGOY','GLAYDEY','VELOSO','','Grade 9','Roxas'),
 (68,'129018110010','BAYOGA ','CALGEN','','','Grade 9','Roxas'),
 (69,'128935110012','BUNGAOS','FRITZ','','','Grade 9','Roxas'),
 (70,'129018120105','PIA','DARREN','','','Grade 9','Roxas'),
 (71,'129018120073','WAPPER','FLORA MAE','CALAYON','','Grade 10','Dahlia'),
 (72,'205024120013','IGLESIAS','JANNEL JR.','DIAMBOLANG','','Grade 10','Dahlia'),
 (73,'129018090008','AMANDORON','HECTOR','MALBAS','','Grade 10','Dahlia'),
 (74,'129018120081','TANO','ZAYRIL','CALAYON','','Grade 10','Dahlia'),
 (75,'129018100015','BENAVENTE','KATE','TRAYA','','Grade 10','Dahlia'),
 (76,'129018120055','MALBAS','MARLON','FLORIDA','','Grade 10','Rose'),
 (77,'129018110041','ODIONG','JAYVER','BENAVENTE','','Grade 10','Rose'),
 (78,'129018110019','EMOY','LAURENCE','MILLAN','','Grade 10','Rose'),
 (79,'129018110007','AMAMANGPANG','KYLE ','BARCOMA','','Grade 10','Orchid'),
 (80,'134728120087','ALBIOS','AIMA','','','Grade 10','Orchid'),
 (81,'129018100044','LASIB ','FRINES MARIEL','CUENCO','','Grade 10','Orchid'),
 (82,'128938140014','GERONDA','DENNIS','BANAGASO','','Grade 7','Almond');
/*!40000 ALTER TABLE `students` ENABLE KEYS */;


--
-- Definition of procedure `fix_illegal_mix_of_collations_mySQL_error`
--

DROP PROCEDURE IF EXISTS `fix_illegal_mix_of_collations_mySQL_error`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `fix_illegal_mix_of_collations_mySQL_error`()
BEGIN
SET collation_connection = 'utf8_general_ci';
ALTER DATABASE apt_nknhs CHARACTER SET utf8 COLLATE utf8_general_ci;
ALTER TABLE students CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Reset`
--

DROP PROCEDURE IF EXISTS `Reset`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Reset`()
BEGIN


truncate documents;
truncate pre_test;
truncate remediation;
truncate post_test;
truncate students;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of view `v_post_test`
--

DROP TABLE IF EXISTS `v_post_test`;
DROP VIEW IF EXISTS `v_post_test`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_post_test` AS select `post_test`.`lrn` AS `LRN`,`post_test`.`student_name` AS `NAME`,`post_test`.`grade_level` AS `GRADE`,`post_test`.`word_reading_score` AS `WRS`,`post_test`.`word_reading_level` AS `WRL`,`post_test`.`reading_comprehension_score` AS `WCS`,`post_test`.`reading_comprehension_level` AS `WCL`,`post_test`.`overall_profile` AS `OP`,`documents`.`code` AS `CODE`,`documents`.`school_year` AS `SY`,`post_test`.`banked` AS `STATUS` from (`post_test` left join `documents` on((`documents`.`id` = `post_test`.`document_id`)));

--
-- Definition of view `v_pre_test`
--

DROP TABLE IF EXISTS `v_pre_test`;
DROP VIEW IF EXISTS `v_pre_test`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_pre_test` AS select `pre_test`.`lrn` AS `LRN`,`pre_test`.`student_name` AS `NAME`,`pre_test`.`grade_level` AS `GRADE`,`pre_test`.`word_reading_score` AS `WRS`,`pre_test`.`word_reading_level` AS `WRL`,`pre_test`.`reading_comprehension_score` AS `WCS`,`pre_test`.`reading_comprehension_level` AS `WCL`,`pre_test`.`overall_profile` AS `OP`,`documents`.`code` AS `CODE`,`documents`.`school_year` AS `SY`,`pre_test`.`banked` AS `STATUS` from (`pre_test` left join `documents` on((`documents`.`id` = `pre_test`.`document_id`)));

--
-- Definition of view `v_remediation`
--

DROP TABLE IF EXISTS `v_remediation`;
DROP VIEW IF EXISTS `v_remediation`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_remediation` AS select `remediation`.`lrn` AS `LRN`,`remediation`.`student_name` AS `NAME`,`remediation`.`grade_level` AS `GRADE`,`remediation`.`m1` AS `M1`,`remediation`.`m2` AS `M2`,`remediation`.`m3` AS `M3`,`remediation`.`m4` AS `M4`,`remediation`.`m5` AS `M5`,`remediation`.`remarks` AS `REMARKS`,`documents`.`school_year` AS `SY`,`documents`.`code` AS `CODE`,`remediation`.`banked` AS `STATUS` from (`remediation` left join `documents` on((`documents`.`id` = `remediation`.`document_id`)));

--
-- Definition of view `v_students`
--

DROP TABLE IF EXISTS `v_students`;
DROP VIEW IF EXISTS `v_students`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_students` AS select `students`.`lrn` AS `LRN`,concat(`students`.`lastname`,', ',`students`.`firstname`,' ',`students`.`middlename`,' ',`students`.`ext`) AS `NAME`,`students`.`grade_level` AS `GRADE LEVEL`,`students`.`section` AS `SECTION` from `students` order by `students`.`id` desc;



/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
