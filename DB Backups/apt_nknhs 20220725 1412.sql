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
 (1,'1','1');
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `documents`
--

/*!40000 ALTER TABLE `documents` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pre_test`
--

/*!40000 ALTER TABLE `pre_test` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `remediation`
--

/*!40000 ALTER TABLE `remediation` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `students`
--

/*!40000 ALTER TABLE `students` DISABLE KEYS */;
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
/*
#roping FKs to enable truncate table
ALTER TABLE `apt_nknhs`.`pre_test` DROP FOREIGN KEY `FK_PRE_DOC_ID`;
ALTER TABLE `apt_nknhs`.`post_test` DROP FOREIGN KEY `FK_POST_DOC_ID`;
ALTER TABLE `apt_nknhs`.`remediation` DROP FOREIGN KEY `FK_REM_DOC_ID`;
*/
#resetting tables
truncate documents;
truncate pre_test;
truncate remediation;
truncate post_test;
truncate students;

/*
#re-adding the earlier dropped FKs
ALTER TABLE `apt_nknhs`.`pre_test` ADD CONSTRAINT `FK_PRE_DOC_ID` FOREIGN KEY `FK_PRE_DOC_ID` (`document_id`)
REFERENCES `documents` (`id`)
ON DELETE RESTRICT
ON UPDATE RESTRICT;

ALTER TABLE `apt_nknhs`.`post_test` ADD CONSTRAINT `FK_POST_DOC_ID` FOREIGN KEY `FK_POST_DOC_ID` (`document_id`)
REFERENCES `documents` (`id`)
ON DELETE RESTRICT
ON UPDATE RESTRICT;

ALTER TABLE `apt_nknhs`.`remediation` ADD CONSTRAINT `FK_REM_DOC_ID` FOREIGN KEY `FK_REM_DOC_ID` (`document_id`)
REFERENCES `documents` (`id`)
ON DELETE RESTRICT
ON UPDATE RESTRICT;
*/
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
