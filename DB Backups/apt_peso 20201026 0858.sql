-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.5.5-10.1.34-MariaDB


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema apt_peso
--

CREATE DATABASE IF NOT EXISTS apt_peso;
USE apt_peso;

--
-- Definition of table `accounts`
--

DROP TABLE IF EXISTS `accounts`;
CREATE TABLE `accounts` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `designation` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `accounts`
--

/*!40000 ALTER TABLE `accounts` DISABLE KEYS */;
INSERT INTO `accounts` (`id`,`username`,`password`,`designation`) VALUES 
 (1,'master','M@st3rk3y','Administrator'),
 (2,'SRA','SRA','SRA & Job Fair Focal Person'),
 (4,'COLLEGE','COLLEGE','College Schoolar Focal Person'),
 (5,'HS','HS','HS Schoolar Focal Person'),
 (6,'child labor','child labor','Child Labor Focal Person'),
 (7,'spes','spes','SPES Focal Person'),
 (8,'ofw','ofw','OFW Focal Person'),
 (9,'rwa','rwa','RWA Focal Person'),
 (10,'pwd','pwd','PWD Focal Person'),
 (11,'1','1','Administrator'),
 (12,'nsrp','nsrp','NSRP Focal Person'),
 (13,'2','2','Administrator');
/*!40000 ALTER TABLE `accounts` ENABLE KEYS */;


--
-- Definition of table `child_labor`
--

DROP TABLE IF EXISTS `child_labor`;
CREATE TABLE `child_labor` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `event` varchar(100) NOT NULL,
  `event_date` varchar(100) NOT NULL,
  `host` varchar(100) DEFAULT NULL,
  `veneu` varchar(100) DEFAULT NULL,
  `surname` varchar(50) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `middlename` varchar(50) NOT NULL,
  `gender` varchar(45) NOT NULL,
  `purok` varchar(50) DEFAULT NULL,
  `address` varchar(50) NOT NULL,
  `dob` varchar(45) DEFAULT NULL,
  `contact` varchar(100) NOT NULL,
  `work_type` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UN-CONTACT` (`surname`,`firstname`,`middlename`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `child_labor`
--

/*!40000 ALTER TABLE `child_labor` DISABLE KEYS */;
INSERT INTO `child_labor` (`id`,`event`,`event_date`,`host`,`veneu`,`surname`,`firstname`,`middlename`,`gender`,`purok`,`address`,`dob`,`contact`,`work_type`) VALUES 
 (4,'event','2020-10-24','host','veneu','imboy','peter jay','encinares','Male','purok 7','NEW OPON','08/02/1996','09104698404','Driver'),
 (5,'event','2020-10-24','host','veneu','dalisay','Ricardo','borja','Female','putok 6','KANAPOLO','07/05/1996','09998','actress'),
 (6,'ads','2020-10-26','ad','dsa','asd','dsa','dsad','Male','asd','GLAMANG','23','32','23'),
 (7,'ads','2020-10-26','ad','dsa','sdsdfd','ssd','asd','Female','3r4','SAN ISIDRO','34','d','er');
/*!40000 ALTER TABLE `child_labor` ENABLE KEYS */;


--
-- Definition of table `college`
--

DROP TABLE IF EXISTS `college`;
CREATE TABLE `college` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `contact_id` int(10) unsigned NOT NULL,
  `school` varchar(100) NOT NULL,
  `course` varchar(100) NOT NULL,
  `underg` tinyint(3) unsigned NOT NULL,
  `yearlvl` varchar(45) NOT NULL,
  `yearg` varchar(45) NOT NULL,
  `awards` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `college`
--

/*!40000 ALTER TABLE `college` DISABLE KEYS */;
/*!40000 ALTER TABLE `college` ENABLE KEYS */;


--
-- Definition of table `colschoolar`
--

DROP TABLE IF EXISTS `colschoolar`;
CREATE TABLE `colschoolar` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `date` varchar(50) NOT NULL,
  `code` varchar(50) NOT NULL,
  `surname` varchar(50) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `middlename` varchar(50) NOT NULL,
  `gender` varchar(45) NOT NULL,
  `dob` varchar(45) NOT NULL,
  `mother` varchar(45) NOT NULL,
  `father` varchar(45) NOT NULL,
  `address` varchar(100) NOT NULL,
  `contact` varchar(45) NOT NULL,
  `school` varchar(45) NOT NULL,
  `yearlevel` varchar(45) NOT NULL,
  `ave` varchar(45) NOT NULL,
  `status` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UN-CONTACT` (`surname`,`firstname`,`middlename`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `colschoolar`
--

/*!40000 ALTER TABLE `colschoolar` DISABLE KEYS */;
INSERT INTO `colschoolar` (`id`,`date`,`code`,`surname`,`firstname`,`middlename`,`gender`,`dob`,`mother`,`father`,`address`,`contact`,`school`,`yearlevel`,`ave`,`status`) VALUES 
 (3,'2020-10-26','HSS - 3','ASD','SDA','AS','MALE','2020-10-24','ASD','SDA','SAN ISIDRO','ASD','DSA','ASD','DSA','OLD SCHOOLAR'),
 (7,'2020-10-24','HSS - 5','DSAD','SAD','ASD','MALE','2020-10-24','ASD','ASD','BALNATE','ASD','ASD','ASD','ASD','OLD SCHOOLAR'),
 (8,'2020-10-24','HSS - 1','ASD334343','ADS','ASD','MALE','2020-10-24','ASD','SDA','BALNATE','ASD','ASD','ASD','ASD','OLD SCHOOLAR');
/*!40000 ALTER TABLE `colschoolar` ENABLE KEYS */;


--
-- Definition of table `contact_programs`
--

DROP TABLE IF EXISTS `contact_programs`;
CREATE TABLE `contact_programs` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `timestamp` date NOT NULL,
  `program_id` int(10) unsigned NOT NULL,
  `contact_id` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `contact_programs`
--

/*!40000 ALTER TABLE `contact_programs` DISABLE KEYS */;
/*!40000 ALTER TABLE `contact_programs` ENABLE KEYS */;


--
-- Definition of table `contacts`
--

DROP TABLE IF EXISTS `contacts`;
CREATE TABLE `contacts` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(45) NOT NULL,
  `surname` varchar(45) DEFAULT NULL,
  `firstname` varchar(45) DEFAULT NULL,
  `middlename` varchar(45) DEFAULT NULL,
  `suffix` varchar(45) DEFAULT NULL,
  `dob` date DEFAULT NULL,
  `sex` varchar(45) DEFAULT NULL,
  `civil_status` varchar(45) DEFAULT NULL,
  `religion` varchar(45) DEFAULT NULL,
  `birthplace` varchar(45) DEFAULT NULL,
  `mother` varchar(45) DEFAULT NULL,
  `father` varchar(45) DEFAULT NULL,
  `house_no` varchar(100) DEFAULT NULL,
  `brgy` varchar(45) DEFAULT NULL,
  `Municipality` varchar(45) DEFAULT NULL,
  `province` varchar(45) DEFAULT NULL,
  `tin` varchar(45) DEFAULT NULL,
  `gsis_sss` varchar(45) DEFAULT NULL,
  `pagibig` varchar(45) DEFAULT NULL,
  `philhealth` varchar(45) DEFAULT NULL,
  `height` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `landline_no` varchar(45) DEFAULT NULL,
  `cp_no` varchar(45) DEFAULT NULL,
  `activeseek` varchar(45) DEFAULT NULL,
  `period` varchar(45) DEFAULT NULL,
  `willtoworkem` varchar(45) DEFAULT NULL,
  `nowhen` varchar(45) DEFAULT NULL,
  `pppp` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `IX_CODE` (`code`),
  UNIQUE KEY `UN-CONTACT` (`surname`,`firstname`,`middlename`)
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `contacts`
--

/*!40000 ALTER TABLE `contacts` DISABLE KEYS */;
INSERT INTO `contacts` (`id`,`code`,`surname`,`firstname`,`middlename`,`suffix`,`dob`,`sex`,`civil_status`,`religion`,`birthplace`,`mother`,`father`,`house_no`,`brgy`,`Municipality`,`province`,`tin`,`gsis_sss`,`pagibig`,`philhealth`,`height`,`email`,`landline_no`,`cp_no`,`activeseek`,`period`,`willtoworkem`,`nowhen`,`pppp`) VALUES 
 (16,'CON - 1','4','4','4',NULL,NULL,'MALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (18,'CON - 17','ASD','DSA','AD',NULL,NULL,'MALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (19,'CON - 19','IMBOY','PETER JAY','E',NULL,NULL,'MALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (20,'CON - 20','DALISAY','CARDO','BORJA',NULL,NULL,'MALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (21,'CON - 21','DALISAY','RICAE','BORJA',NULL,NULL,'MALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (22,'CON - 22','ASD','DSA','ASD',NULL,NULL,'FEMALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (23,'CON - 23','DSA','DSA','SDA',NULL,NULL,'FEMALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (24,'CON - 24','IMBOY','PETER JAY','ENCINARES',NULL,NULL,'MALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (25,'CON - 25','ASD','ASD','AD',NULL,NULL,'MALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (26,'CON - 26','1','1','1',NULL,NULL,'MALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (27,'CON - 27','AD','SD','ASD',NULL,NULL,'MALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (28,'CON - 28','DSA','SAD','ASD',NULL,NULL,'FEMALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (30,'CON - 29','AD','DSA','ASD',NULL,NULL,'MALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (31,'CON - 31','ASD','SA','DSA',NULL,NULL,'FEMALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (32,'CON - 32','imboy','oe','asd',NULL,NULL,'Male',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (34,'CON - 33','asd','dsa','dsad',NULL,NULL,'Male',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (35,'CON - 35','sdsdfd','ssd','asd',NULL,NULL,'Female',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (36,'CON - 36','IMBOY','PETER','ENCINARES',NULL,NULL,'MALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (37,'CON - 37','ASD','ASD','AS',NULL,NULL,'MALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (38,'CON - 38','ASD','ASD','ASD',NULL,NULL,'MALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (39,'CON - 39','ASD','ADS','ASD',NULL,NULL,'MALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (40,'CON - 40','as','ds','asd',NULL,NULL,'FEMALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (41,'CON - 41','ASD','SDA','AS',NULL,NULL,'MALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (42,'CON - 42','ASD','SAD','ASD',NULL,NULL,'MALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (44,'CON - 43','DSAD','SAD','ASD',NULL,NULL,'MALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (45,'CON - 45','123','123','123',NULL,NULL,'MALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
 (46,'CON - 46','A','A','1',NULL,NULL,'MALE',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `contacts` ENABLE KEYS */;


--
-- Definition of table `contacts_job`
--

DROP TABLE IF EXISTS `contacts_job`;
CREATE TABLE `contacts_job` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `contact_id` int(10) unsigned NOT NULL,
  `local_abroad` varchar(100) NOT NULL,
  `job` varchar(100) NOT NULL,
  `location` varchar(100) NOT NULL,
  `expectedsal` decimal(10,0) NOT NULL,
  `passportno` varchar(45) NOT NULL,
  `expirydate` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `contacts_job`
--

/*!40000 ALTER TABLE `contacts_job` DISABLE KEYS */;
/*!40000 ALTER TABLE `contacts_job` ENABLE KEYS */;


--
-- Definition of table `disability`
--

DROP TABLE IF EXISTS `disability`;
CREATE TABLE `disability` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `contact_id` varchar(45) NOT NULL,
  `disability` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `disability`
--

/*!40000 ALTER TABLE `disability` DISABLE KEYS */;
/*!40000 ALTER TABLE `disability` ENABLE KEYS */;


--
-- Definition of table `elementary`
--

DROP TABLE IF EXISTS `elementary`;
CREATE TABLE `elementary` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `contact_id` int(10) unsigned NOT NULL,
  `school` varchar(100) NOT NULL,
  `underg` tinyint(3) unsigned NOT NULL,
  `yearlvl` varchar(45) NOT NULL,
  `yearg` varchar(45) NOT NULL,
  `awards` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `elementary`
--

/*!40000 ALTER TABLE `elementary` DISABLE KEYS */;
/*!40000 ALTER TABLE `elementary` ENABLE KEYS */;


--
-- Definition of table `eligibility`
--

DROP TABLE IF EXISTS `eligibility`;
CREATE TABLE `eligibility` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `contact_id` varchar(45) NOT NULL,
  `eligibility` varchar(45) DEFAULT NULL,
  `rating` double DEFAULT NULL,
  `exp_d` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `eligibility`
--

/*!40000 ALTER TABLE `eligibility` DISABLE KEYS */;
/*!40000 ALTER TABLE `eligibility` ENABLE KEYS */;


--
-- Definition of table `emp_status_type`
--

DROP TABLE IF EXISTS `emp_status_type`;
CREATE TABLE `emp_status_type` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `contact_id` int(10) unsigned NOT NULL,
  `status` varchar(45) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `emp_status_type`
--

/*!40000 ALTER TABLE `emp_status_type` DISABLE KEYS */;
/*!40000 ALTER TABLE `emp_status_type` ENABLE KEYS */;


--
-- Definition of table `grad`
--

DROP TABLE IF EXISTS `grad`;
CREATE TABLE `grad` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `contact_id` int(10) unsigned NOT NULL,
  `school` varchar(100) NOT NULL,
  `course` varchar(100) NOT NULL,
  `underg` tinyint(3) unsigned NOT NULL,
  `yearlvl` varchar(45) NOT NULL,
  `yearg` varchar(45) NOT NULL,
  `awards` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `grad`
--

/*!40000 ALTER TABLE `grad` DISABLE KEYS */;
/*!40000 ALTER TABLE `grad` ENABLE KEYS */;


--
-- Definition of table `hs`
--

DROP TABLE IF EXISTS `hs`;
CREATE TABLE `hs` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `contact_id` int(10) unsigned NOT NULL,
  `school` varchar(100) NOT NULL,
  `underg` tinyint(3) unsigned NOT NULL,
  `yearlvl` varchar(45) NOT NULL,
  `yearg` varchar(45) NOT NULL,
  `awards` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `hs`
--

/*!40000 ALTER TABLE `hs` DISABLE KEYS */;
/*!40000 ALTER TABLE `hs` ENABLE KEYS */;


--
-- Definition of table `hsshcoolar`
--

DROP TABLE IF EXISTS `hsshcoolar`;
CREATE TABLE `hsshcoolar` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `date` varchar(50) NOT NULL,
  `code` varchar(50) NOT NULL,
  `surname` varchar(50) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `middlename` varchar(50) NOT NULL,
  `gender` varchar(45) NOT NULL,
  `dob` varchar(45) NOT NULL,
  `mother` varchar(45) NOT NULL,
  `father` varchar(45) NOT NULL,
  `address` varchar(100) NOT NULL,
  `contact` varchar(45) NOT NULL,
  `school` varchar(45) NOT NULL,
  `yearlevel` varchar(45) NOT NULL,
  `ave` varchar(45) NOT NULL,
  `status` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UN-CONTACT` (`surname`,`firstname`,`middlename`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `hsshcoolar`
--

/*!40000 ALTER TABLE `hsshcoolar` DISABLE KEYS */;
INSERT INTO `hsshcoolar` (`id`,`date`,`code`,`surname`,`firstname`,`middlename`,`gender`,`dob`,`mother`,`father`,`address`,`contact`,`school`,`yearlevel`,`ave`,`status`) VALUES 
 (1,'2020-10-24','HSS - 1','123','123','123','MALE','2020-10-24','123`','123','POBLACION','1A','HOLY CROSS OF MAG., INC.','GRADE 8','ASD','NEW SCHOOLAR'),
 (2,'2020-10-24','HSS - 2','A','A','1','MALE','2020-10-24','SD','SD','POBLACION','DF','BANGKAL NHS','GRADE 8','ASD','OLD SCHOOLAR');
/*!40000 ALTER TABLE `hsshcoolar` ENABLE KEYS */;


--
-- Definition of table `jobfair`
--

DROP TABLE IF EXISTS `jobfair`;
CREATE TABLE `jobfair` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(50) NOT NULL,
  `event_date` varchar(100) NOT NULL,
  `host` varchar(100) NOT NULL,
  `surname` varchar(50) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `middlename` varchar(50) NOT NULL,
  `address` varchar(100) NOT NULL,
  `gender` varchar(45) NOT NULL,
  `tel_no` varchar(100) NOT NULL,
  `job_position` varchar(100) NOT NULL,
  `hiring_company` varchar(100) NOT NULL,
  `location` varchar(100) NOT NULL,
  `status` varchar(100) NOT NULL,
  `remarks` varchar(200) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UN-CONTACT` (`surname`,`firstname`,`middlename`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `jobfair`
--

/*!40000 ALTER TABLE `jobfair` DISABLE KEYS */;
INSERT INTO `jobfair` (`id`,`code`,`event_date`,`host`,`surname`,`firstname`,`middlename`,`address`,`gender`,`tel_no`,`job_position`,`hiring_company`,`location`,`status`,`remarks`) VALUES 
 (1,'JF - 1','2020-10-08','PESSO','2','2','2','KASUGA','MALE','23','32','232','LOCAL','HIRED','32'),
 (2,'JF - 2','2020-10-20','asd','4','4','4','DALAWINON','FEMALE','4','4','4','ABROAD','NOT HIRED','4');
/*!40000 ALTER TABLE `jobfair` ENABLE KEYS */;


--
-- Definition of table `kasambahay`
--

DROP TABLE IF EXISTS `kasambahay`;
CREATE TABLE `kasambahay` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `date` varchar(100) NOT NULL,
  `code` varchar(50) NOT NULL,
  `surname` varchar(50) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `middlename` varchar(50) NOT NULL,
  `address` varchar(100) NOT NULL,
  `gender` varchar(100) NOT NULL,
  `contact_no` varchar(45) NOT NULL,
  `status` varchar(45) NOT NULL,
  `remarks` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UN-CONTACT` (`surname`,`firstname`,`middlename`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `kasambahay`
--

/*!40000 ALTER TABLE `kasambahay` DISABLE KEYS */;
INSERT INTO `kasambahay` (`id`,`date`,`code`,`surname`,`firstname`,`middlename`,`address`,`gender`,`contact_no`,`status`,`remarks`) VALUES 
 (7,'2020-10-23','KAS - 1','AD','SD','ASD','DALUMAY','MALE','ASD','ACTIVE','ASD'),
 (8,'2020-10-23','KAS - 8','DSA','SAD','ASD','DALAWINON','FEMALE','ASD','INACTIVE','ASD');
/*!40000 ALTER TABLE `kasambahay` ENABLE KEYS */;


--
-- Definition of table `language`
--

DROP TABLE IF EXISTS `language`;
CREATE TABLE `language` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `contact_id` int(10) unsigned NOT NULL,
  `language` varchar(45) DEFAULT 'NO',
  `read` varchar(45) DEFAULT 'NO',
  `write` varchar(45) DEFAULT 'NO',
  `speak` varchar(45) DEFAULT 'No',
  `understand` varchar(45) DEFAULT 'No',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `language`
--

/*!40000 ALTER TABLE `language` DISABLE KEYS */;
/*!40000 ALTER TABLE `language` ENABLE KEYS */;


--
-- Definition of table `ofw`
--

DROP TABLE IF EXISTS `ofw`;
CREATE TABLE `ofw` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `date` varchar(100) NOT NULL,
  `code` varchar(50) NOT NULL,
  `surname` varchar(50) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `middlename` varchar(50) NOT NULL,
  `address` varchar(100) NOT NULL,
  `gender` varchar(100) NOT NULL,
  `country` varchar(45) NOT NULL,
  `passport` varchar(45) NOT NULL,
  `type` varchar(45) NOT NULL,
  `contact_no` varchar(45) NOT NULL,
  `status` varchar(45) NOT NULL,
  `remarks` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UN-CONTACT` (`surname`,`firstname`,`middlename`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ofw`
--

/*!40000 ALTER TABLE `ofw` DISABLE KEYS */;
INSERT INTO `ofw` (`id`,`date`,`code`,`surname`,`firstname`,`middlename`,`address`,`gender`,`country`,`passport`,`type`,`contact_no`,`status`,`remarks`) VALUES 
 (1,'2020-10-23','OFW - 1','AD','DSA','ASD','ASD','MALE','ASD','ASD','SEA BASE','AS','ACTIVE','23'),
 (3,'2020-10-26','OFW - 2','ASD','SA','DSA','AD','FEMALE','SDA','ASD','LAND BASE','ASD','ACTIVE','ASD');
/*!40000 ALTER TABLE `ofw` ENABLE KEYS */;


--
-- Definition of table `prc`
--

DROP TABLE IF EXISTS `prc`;
CREATE TABLE `prc` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `contact_id` varchar(45) NOT NULL,
  `prc` varchar(45) DEFAULT NULL,
  `valid_til` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `prc`
--

/*!40000 ALTER TABLE `prc` DISABLE KEYS */;
/*!40000 ALTER TABLE `prc` ENABLE KEYS */;


--
-- Definition of table `programs_type_map`
--

DROP TABLE IF EXISTS `programs_type_map`;
CREATE TABLE `programs_type_map` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `description` varchar(60) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `programs_type_map`
--

/*!40000 ALTER TABLE `programs_type_map` DISABLE KEYS */;
INSERT INTO `programs_type_map` (`id`,`description`) VALUES 
 (1,'Child Labor');
/*!40000 ALTER TABLE `programs_type_map` ENABLE KEYS */;


--
-- Definition of table `pwd`
--

DROP TABLE IF EXISTS `pwd`;
CREATE TABLE `pwd` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `date` varchar(100) NOT NULL,
  `code` varchar(50) NOT NULL,
  `surname` varchar(50) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `middlename` varchar(50) NOT NULL,
  `address` varchar(100) NOT NULL,
  `gender` varchar(100) NOT NULL,
  `age` varchar(100) NOT NULL,
  `contact` varchar(100) NOT NULL,
  `disability` varchar(100) NOT NULL,
  `remarks` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UN-CONTACT` (`surname`,`firstname`,`middlename`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pwd`
--

/*!40000 ALTER TABLE `pwd` DISABLE KEYS */;
INSERT INTO `pwd` (`id`,`date`,`code`,`surname`,`firstname`,`middlename`,`address`,`gender`,`age`,`contact`,`disability`,`remarks`) VALUES 
 (1,'2020-10-24','PWD - 1','IMBOY','PETER','ENCINARES','NEW OPON','MALE','24','09104698404','BLIND','HARDWORKING');
/*!40000 ALTER TABLE `pwd` ENABLE KEYS */;


--
-- Definition of table `rwa`
--

DROP TABLE IF EXISTS `rwa`;
CREATE TABLE `rwa` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `date` varchar(45) NOT NULL,
  `code` varchar(100) NOT NULL,
  `establishment_name` varchar(100) NOT NULL,
  `acronym` varchar(45) NOT NULL,
  `tin` varchar(45) NOT NULL,
  `employer_type` varchar(100) NOT NULL,
  `work_force` varchar(45) DEFAULT NULL,
  `business_line` varchar(100) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `municipality` varchar(100) DEFAULT NULL,
  `province` varchar(100) DEFAULT NULL,
  `contact_person` varchar(45) DEFAULT NULL,
  `position` varchar(45) DEFAULT NULL,
  `tel` varchar(45) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `rwa`
--

/*!40000 ALTER TABLE `rwa` DISABLE KEYS */;
INSERT INTO `rwa` (`id`,`date`,`code`,`establishment_name`,`acronym`,`tin`,`employer_type`,`work_force`,`business_line`,`address`,`municipality`,`province`,`contact_person`,`position`,`tel`,`type`,`email`) VALUES 
 (2,'2020-10-23','RWA - 1','AD','SAD','AD','Government','Medium (100-199)','ASD','ASD','ASD','ASD','ASD','ASD','ASD','Registered','DSA');
/*!40000 ALTER TABLE `rwa` ENABLE KEYS */;


--
-- Definition of table `skills`
--

DROP TABLE IF EXISTS `skills`;
CREATE TABLE `skills` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `contact_id` int(10) unsigned NOT NULL,
  `skills` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `skills`
--

/*!40000 ALTER TABLE `skills` DISABLE KEYS */;
/*!40000 ALTER TABLE `skills` ENABLE KEYS */;


--
-- Definition of table `spes`
--

DROP TABLE IF EXISTS `spes`;
CREATE TABLE `spes` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `event` varchar(100) NOT NULL,
  `event_date` varchar(100) NOT NULL,
  `host` varchar(100) NOT NULL,
  `veneu` varchar(100) NOT NULL,
  `surname` varchar(50) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `middlename` varchar(50) NOT NULL,
  `address` varchar(45) NOT NULL,
  `gender` varchar(45) NOT NULL,
  `age` varchar(45) NOT NULL,
  `contact` varchar(45) NOT NULL,
  `type` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UN-CONTACT` (`surname`,`firstname`,`middlename`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `spes`
--

/*!40000 ALTER TABLE `spes` DISABLE KEYS */;
/*!40000 ALTER TABLE `spes` ENABLE KEYS */;


--
-- Definition of table `sra`
--

DROP TABLE IF EXISTS `sra`;
CREATE TABLE `sra` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Agency` varchar(100) NOT NULL,
  `sra_no` varchar(100) NOT NULL,
  `event_date` varchar(100) NOT NULL,
  `host` varchar(100) NOT NULL,
  `veneu` varchar(100) NOT NULL,
  `address_branch` varchar(100) NOT NULL,
  `rep_contact` varchar(100) NOT NULL,
  `surname` varchar(50) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `middlename` varchar(50) NOT NULL,
  `address` varchar(100) NOT NULL,
  `age` varchar(45) NOT NULL,
  `gender` varchar(45) NOT NULL,
  `position` varchar(45) NOT NULL,
  `jobsite` varchar(45) NOT NULL,
  `remarks` varchar(45) NOT NULL,
  `notes` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UN-CONTACT` (`surname`,`firstname`,`middlename`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sra`
--

/*!40000 ALTER TABLE `sra` DISABLE KEYS */;
INSERT INTO `sra` (`id`,`Agency`,`sra_no`,`event_date`,`host`,`veneu`,`address_branch`,`rep_contact`,`surname`,`firstname`,`middlename`,`address`,`age`,`gender`,`position`,`jobsite`,`remarks`,`notes`) VALUES 
 (6,'asd','asd','2020-10-20','asd','asd','asd','asd','1','1','1','DALUMAY','12','MALE','12','12','12','notes'),
 (7,'1','1','2020-10-24','1','1','11','1','as','ds','asd','MABINI','23','FEMALE','ew','23','23','notes');
/*!40000 ALTER TABLE `sra` ENABLE KEYS */;


--
-- Definition of table `tech_voc`
--

DROP TABLE IF EXISTS `tech_voc`;
CREATE TABLE `tech_voc` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `contact_id` int(10) unsigned NOT NULL,
  `course` varchar(45) DEFAULT NULL,
  `duration` varchar(100) DEFAULT NULL,
  `training_ins` varchar(100) DEFAULT NULL,
  `cert` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tech_voc`
--

/*!40000 ALTER TABLE `tech_voc` DISABLE KEYS */;
/*!40000 ALTER TABLE `tech_voc` ENABLE KEYS */;


--
-- Definition of table `test`
--

DROP TABLE IF EXISTS `test`;
CREATE TABLE `test` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `year` varchar(45) NOT NULL,
  `bears` varchar(45) NOT NULL,
  `dolhins` varchar(45) NOT NULL,
  `whales` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `test`
--

/*!40000 ALTER TABLE `test` DISABLE KEYS */;
INSERT INTO `test` (`id`,`year`,`bears`,`dolhins`,`whales`) VALUES 
 (1,'2017','8','150','80'),
 (2,'2018','54','77','54'),
 (3,'2019','93','32','100'),
 (4,'2020','116','11','76'),
 (5,'2021','137','6','93'),
 (6,'2022','184','1','72');
/*!40000 ALTER TABLE `test` ENABLE KEYS */;


--
-- Definition of table `todo`
--

DROP TABLE IF EXISTS `todo`;
CREATE TABLE `todo` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `title` varchar(45) NOT NULL,
  `desc` varchar(200) NOT NULL,
  `assignee` varchar(45) NOT NULL,
  `flag` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `todo`
--

/*!40000 ALTER TABLE `todo` DISABLE KEYS */;
INSERT INTO `todo` (`id`,`title`,`desc`,`assignee`,`flag`) VALUES 
 (1,'A','a','A',0),
 (2,'4','4','123',0),
 (3,'ADA','sdasdasdasdadasdasddddddddddddddddddddddddddd','ADASD',0);
/*!40000 ALTER TABLE `todo` ENABLE KEYS */;


--
-- Definition of table `work_exp`
--

DROP TABLE IF EXISTS `work_exp`;
CREATE TABLE `work_exp` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `contact_id` int(10) unsigned NOT NULL,
  `company_name` varchar(45) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `position` varchar(45) DEFAULT NULL,
  `inclusive_date` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `work_exp`
--

/*!40000 ALTER TABLE `work_exp` DISABLE KEYS */;
/*!40000 ALTER TABLE `work_exp` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
