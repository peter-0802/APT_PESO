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
-- Create schema apt_peso
--

CREATE DATABASE IF NOT EXISTS apt_peso;
USE apt_peso;

--
-- Temporary table structure for view `v_dashboard`
--
DROP TABLE IF EXISTS `v_dashboard`;
DROP VIEW IF EXISTS `v_dashboard`;
CREATE TABLE `v_dashboard` (
  `sra` bigint(21),
  `pwd` bigint(21)
);

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
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `accounts`
--

/*!40000 ALTER TABLE `accounts` DISABLE KEYS */;
INSERT INTO `accounts` (`id`,`username`,`password`,`designation`) VALUES 
 (1,'master','M@st3rk3y','Administrator'),
 (11,'1','1','Administrator'),
 (15,'2','2','TESTER');
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `child_labor`
--

/*!40000 ALTER TABLE `child_labor` DISABLE KEYS */;
/*!40000 ALTER TABLE `child_labor` ENABLE KEYS */;


--
-- Definition of table `contact2`
--

DROP TABLE IF EXISTS `contact2`;
CREATE TABLE `contact2` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(45) NOT NULL,
  `date` varchar(45) DEFAULT NULL,
  `surname` varchar(45) DEFAULT NULL,
  `firstname` varchar(45) DEFAULT NULL,
  `middlename` varchar(45) DEFAULT NULL,
  `dob` date DEFAULT NULL,
  `age` varchar(45) DEFAULT NULL,
  `sex` varchar(45) DEFAULT NULL,
  `civil_status` varchar(45) DEFAULT NULL,
  `religion` varchar(45) DEFAULT NULL,
  `birthplace` varchar(45) DEFAULT NULL,
  `brgy` varchar(45) DEFAULT NULL,
  `Municipality` varchar(45) DEFAULT NULL,
  `province` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `cp_no` varchar(45) DEFAULT NULL,
  `4ps` varchar(45) DEFAULT NULL,
  `emp_status` varchar(45) DEFAULT NULL,
  `job_pre` varchar(45) DEFAULT NULL,
  `educ_level` varchar(45) DEFAULT NULL,
  `skills` varchar(45) DEFAULT NULL,
  `from` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `IX_CODE` (`code`),
  UNIQUE KEY `UN-CONTACT` (`surname`,`firstname`,`middlename`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `contact2`
--

/*!40000 ALTER TABLE `contact2` DISABLE KEYS */;
/*!40000 ALTER TABLE `contact2` ENABLE KEYS */;


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
  `remarks` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UN-CONTACT` (`surname`,`firstname`,`middlename`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `hsshcoolar`
--

/*!40000 ALTER TABLE `hsshcoolar` DISABLE KEYS */;
INSERT INTO `hsshcoolar` (`id`,`date`,`code`,`surname`,`firstname`,`middlename`,`gender`,`dob`,`mother`,`father`,`address`,`contact`,`school`,`yearlevel`,`ave`,`status`,`remarks`) VALUES 
 (1,'2022-07-11','HSS - 1','2','2','2','MALE','2022-07-11','2','2','DALUMAY','2','LO. BALA NHS','GRADE 10','2','NEW SCHOOLAR','2');
/*!40000 ALTER TABLE `hsshcoolar` ENABLE KEYS */;


--
-- Definition of table `jobfair2`
--

DROP TABLE IF EXISTS `jobfair2`;
CREATE TABLE `jobfair2` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(50) NOT NULL,
  `event_date` varchar(100) NOT NULL,
  `host` varchar(100) NOT NULL,
  `surname` varchar(45) NOT NULL,
  `firstname` varchar(45) NOT NULL,
  `middlename` varchar(45) NOT NULL,
  `dob` varchar(45) DEFAULT NULL,
  `age` varchar(45) DEFAULT NULL,
  `sex` varchar(45) DEFAULT NULL,
  `civil_status` varchar(45) DEFAULT NULL,
  `religion` varchar(45) DEFAULT NULL,
  `brgy` varchar(45) DEFAULT NULL,
  `Municipality` varchar(45) DEFAULT NULL,
  `province` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `cp_no` varchar(45) DEFAULT NULL,
  `4ps` varchar(45) DEFAULT NULL,
  `emp_status` varchar(45) DEFAULT NULL,
  `job_pre` varchar(45) DEFAULT NULL,
  `educ_level` varchar(45) DEFAULT NULL,
  `skills` varchar(45) DEFAULT NULL,
  `position` varchar(45) DEFAULT NULL,
  `hiring_company` varchar(100) NOT NULL,
  `jobsite` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `remarks` varchar(45) DEFAULT NULL,
  `from` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UN-CONTACT` (`surname`,`firstname`,`middlename`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `jobfair2`
--

/*!40000 ALTER TABLE `jobfair2` DISABLE KEYS */;
/*!40000 ALTER TABLE `jobfair2` ENABLE KEYS */;


--
-- Definition of table `kasambahay2`
--

DROP TABLE IF EXISTS `kasambahay2`;
CREATE TABLE `kasambahay2` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `date` varchar(45) NOT NULL,
  `code` varchar(45) NOT NULL,
  `surname` varchar(45) NOT NULL,
  `firstname` varchar(45) NOT NULL,
  `middlename` varchar(45) NOT NULL,
  `dob` date DEFAULT NULL,
  `age` varchar(45) DEFAULT NULL,
  `sex` varchar(45) DEFAULT NULL,
  `civil_status` varchar(45) DEFAULT NULL,
  `religion` varchar(45) DEFAULT NULL,
  `birthplace` varchar(45) DEFAULT NULL,
  `brgy` varchar(45) DEFAULT NULL,
  `Municipality` varchar(45) DEFAULT 'MAGSAYSAY',
  `province` varchar(45) DEFAULT 'DAVAO DEL SUR',
  `email` varchar(45) DEFAULT NULL,
  `cp_no` varchar(45) DEFAULT NULL,
  `4ps` varchar(45) DEFAULT NULL,
  `emp_status` varchar(45) DEFAULT NULL,
  `job_pre` varchar(45) DEFAULT NULL,
  `educ_level` varchar(45) DEFAULT NULL,
  `skills` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `remarks` varchar(45) DEFAULT NULL,
  `from` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `IX_CODE` (`code`),
  UNIQUE KEY `UN-CONTACT` (`surname`,`firstname`,`middlename`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `kasambahay2`
--

/*!40000 ALTER TABLE `kasambahay2` DISABLE KEYS */;
/*!40000 ALTER TABLE `kasambahay2` ENABLE KEYS */;


--
-- Definition of table `ofw2`
--

DROP TABLE IF EXISTS `ofw2`;
CREATE TABLE `ofw2` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `date` varchar(45) NOT NULL,
  `code` varchar(45) NOT NULL,
  `surname` varchar(45) NOT NULL,
  `firstname` varchar(45) NOT NULL,
  `middlename` varchar(45) NOT NULL,
  `dob` date DEFAULT NULL,
  `age` varchar(45) DEFAULT NULL,
  `sex` varchar(45) DEFAULT NULL,
  `civil_status` varchar(45) DEFAULT NULL,
  `religion` varchar(45) DEFAULT NULL,
  `birthplace` varchar(45) DEFAULT NULL,
  `brgy` varchar(45) DEFAULT NULL,
  `Municipality` varchar(45) DEFAULT 'MAGSAYSAY',
  `province` varchar(45) DEFAULT 'DAVAO DEL SUR',
  `email` varchar(45) DEFAULT NULL,
  `cp_no` varchar(45) DEFAULT NULL,
  `4ps` varchar(45) DEFAULT NULL,
  `emp_status` varchar(45) DEFAULT NULL,
  `job_pre` varchar(45) DEFAULT NULL,
  `educ_level` varchar(45) DEFAULT NULL,
  `skills` varchar(45) DEFAULT NULL,
  `country` varchar(45) DEFAULT NULL,
  `passport` varchar(45) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `remarks` varchar(45) DEFAULT NULL,
  `from` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `IX_CODE` (`code`),
  UNIQUE KEY `UN-CONTACT` (`surname`,`firstname`,`middlename`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ofw2`
--

/*!40000 ALTER TABLE `ofw2` DISABLE KEYS */;
/*!40000 ALTER TABLE `ofw2` ENABLE KEYS */;


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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pwd`
--

/*!40000 ALTER TABLE `pwd` DISABLE KEYS */;
INSERT INTO `pwd` (`id`,`date`,`code`,`surname`,`firstname`,`middlename`,`address`,`gender`,`age`,`contact`,`disability`,`remarks`) VALUES 
 (1,'2022-07-08','PWD - 1','23','32','23','BARAYONG','FEMALE','32','23','23','32'),
 (2,'2022-07-08','PWD - 2','32','2','3','DALAWINON','FEMALE','32','23','23','23');
/*!40000 ALTER TABLE `pwd` ENABLE KEYS */;


--
-- Definition of table `rwa`
--

DROP TABLE IF EXISTS `rwa`;
CREATE TABLE `rwa` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `date` varchar(45) NOT NULL,
  `code` varchar(100) NOT NULL,
  `reg_no` varchar(100) DEFAULT NULL,
  `establishment_name` varchar(100) NOT NULL,
  `acronym` varchar(45) DEFAULT NULL,
  `tin` varchar(45) DEFAULT NULL,
  `employer_type` varchar(100) DEFAULT NULL,
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `rwa`
--

/*!40000 ALTER TABLE `rwa` DISABLE KEYS */;
/*!40000 ALTER TABLE `rwa` ENABLE KEYS */;


--
-- Definition of table `schoolar_coll`
--

DROP TABLE IF EXISTS `schoolar_coll`;
CREATE TABLE `schoolar_coll` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `date` varchar(45) DEFAULT NULL,
  `code` varchar(45) NOT NULL,
  `surname` varchar(45) DEFAULT NULL,
  `firstname` varchar(45) DEFAULT NULL,
  `middlename` varchar(45) DEFAULT NULL,
  `dob` varchar(45) DEFAULT NULL,
  `age` varchar(45) DEFAULT NULL,
  `sex` varchar(45) DEFAULT NULL,
  `civil_status` varchar(45) DEFAULT NULL,
  `religion` varchar(45) DEFAULT NULL,
  `birthplace` varchar(45) DEFAULT NULL,
  `brgy` varchar(45) DEFAULT NULL,
  `Municipality` varchar(45) DEFAULT 'MAGSAYSAY',
  `province` varchar(45) DEFAULT 'DAVAO DEL SUR',
  `email` varchar(45) DEFAULT NULL,
  `cp_no` varchar(45) DEFAULT NULL,
  `mother` varchar(45) NOT NULL,
  `father` varchar(45) NOT NULL,
  `school` varchar(45) NOT NULL,
  `yearlevel` varchar(45) NOT NULL,
  `ave` varchar(45) NOT NULL,
  `status` varchar(45) NOT NULL,
  `4ps` varchar(45) DEFAULT NULL,
  `remarks` varchar(45) DEFAULT NULL,
  `emp_status` varchar(45) DEFAULT NULL,
  `job_pre` varchar(45) DEFAULT NULL,
  `educ_level` varchar(45) DEFAULT NULL,
  `skills` varchar(45) DEFAULT NULL,
  `from` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `IX_CODE` (`code`),
  UNIQUE KEY `UN-CONTACT` (`surname`,`firstname`,`middlename`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `schoolar_coll`
--

/*!40000 ALTER TABLE `schoolar_coll` DISABLE KEYS */;
/*!40000 ALTER TABLE `schoolar_coll` ENABLE KEYS */;


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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `spes`
--

/*!40000 ALTER TABLE `spes` DISABLE KEYS */;
/*!40000 ALTER TABLE `spes` ENABLE KEYS */;


--
-- Definition of table `sra2`
--

DROP TABLE IF EXISTS `sra2`;
CREATE TABLE `sra2` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Agency` varchar(100) NOT NULL,
  `sra_no` varchar(100) NOT NULL,
  `event_date` varchar(100) NOT NULL,
  `host` varchar(100) NOT NULL,
  `veneu` varchar(100) NOT NULL,
  `address_branch` varchar(100) NOT NULL,
  `rep_contact` varchar(100) NOT NULL,
  `surname` varchar(45) NOT NULL,
  `firstname` varchar(45) NOT NULL,
  `middlename` varchar(45) NOT NULL,
  `dob` varchar(45) DEFAULT NULL,
  `age` varchar(45) DEFAULT NULL,
  `sex` varchar(45) DEFAULT NULL,
  `civil_status` varchar(45) DEFAULT NULL,
  `religion` varchar(45) DEFAULT NULL,
  `brgy` varchar(45) DEFAULT NULL,
  `Municipality` varchar(45) DEFAULT NULL,
  `province` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `cp_no` varchar(45) DEFAULT NULL,
  `4ps` varchar(45) DEFAULT NULL,
  `emp_status` varchar(45) DEFAULT NULL,
  `job_pre` varchar(45) DEFAULT NULL,
  `educ_level` varchar(45) DEFAULT NULL,
  `skills` varchar(45) DEFAULT NULL,
  `position` varchar(45) DEFAULT NULL,
  `jobsite` varchar(45) DEFAULT NULL,
  `remarks` varchar(45) DEFAULT NULL,
  `from` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UN-CONTACT` (`surname`,`firstname`,`middlename`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sra2`
--

/*!40000 ALTER TABLE `sra2` DISABLE KEYS */;
INSERT INTO `sra2` (`id`,`Agency`,`sra_no`,`event_date`,`host`,`veneu`,`address_branch`,`rep_contact`,`surname`,`firstname`,`middlename`,`dob`,`age`,`sex`,`civil_status`,`religion`,`brgy`,`Municipality`,`province`,`email`,`cp_no`,`4ps`,`emp_status`,`job_pre`,`educ_level`,`skills`,`position`,`jobsite`,`remarks`,`from`) VALUES 
 (2,'2','2','2022-07-07','2','2','2','2','2','2','2','2','2','FEMALE','2','2','KANAPOLO','MAGSAYSAY','DAVAO DEL SUR','2','2','2','2','2','2','2','2','2','2','SRA'),
 (3,'32','323','2022-07-08','32','23','23','23','23','23','32','23','23','FEMALE','23','23','GLAMANG','MAGSAYSAY','DAVAO DEL SUR','2','2','2','2','2','2','2','2','2','2','SRA');
/*!40000 ALTER TABLE `sra2` ENABLE KEYS */;


--
-- Definition of table `todo`
--

DROP TABLE IF EXISTS `todo`;
CREATE TABLE `todo` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(45) NOT NULL,
  `title` varchar(45) NOT NULL,
  `desc` varchar(200) NOT NULL,
  `assignee` varchar(45) NOT NULL,
  `flag` varchar(20) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `IX - TITLE` (`title`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `todo`
--

/*!40000 ALTER TABLE `todo` DISABLE KEYS */;
/*!40000 ALTER TABLE `todo` ENABLE KEYS */;


--
-- Definition of view `v_dashboard`
--

DROP TABLE IF EXISTS `v_dashboard`;
DROP VIEW IF EXISTS `v_dashboard`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_dashboard` AS select (select count(0) from `sra2`) AS `sra`,(select count(0) from `pwd`) AS `pwd`;



/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
