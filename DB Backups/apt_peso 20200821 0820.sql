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
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `accounts`
--

/*!40000 ALTER TABLE `accounts` DISABLE KEYS */;
INSERT INTO `accounts` (`id`,`username`,`password`) VALUES 
 (1,'master','master'),
 (2,'1','1');
/*!40000 ALTER TABLE `accounts` ENABLE KEYS */;


--
-- Definition of table `college`
--

DROP TABLE IF EXISTS `college`;
CREATE TABLE `college` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `contact_id` int(10) unsigned NOT NULL,
  `school` varchar(100) NOT NULL,
  `underg` tinyint(3) unsigned NOT NULL,
  `yearlvl` varchar(45) NOT NULL,
  `yearg` varchar(45) NOT NULL,
  `awards` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `college`
--

/*!40000 ALTER TABLE `college` DISABLE KEYS */;
INSERT INTO `college` (`id`,`contact_id`,`school`,`underg`,`yearlvl`,`yearg`,`awards`) VALUES 
 (1,1,'dsa',0,'N/A','2018','dsad');
/*!40000 ALTER TABLE `college` ENABLE KEYS */;


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
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `contacts`
--

/*!40000 ALTER TABLE `contacts` DISABLE KEYS */;
INSERT INTO `contacts` (`id`,`code`,`surname`,`firstname`,`middlename`,`suffix`,`dob`,`sex`,`civil_status`,`religion`,`birthplace`,`house_no`,`brgy`,`Municipality`,`province`,`tin`,`gsis_sss`,`pagibig`,`philhealth`,`height`,`email`,`landline_no`,`cp_no`,`activeseek`,`period`,`willtoworkem`,`nowhen`,`pppp`) VALUES 
 (1,'CON - 1','IMBOY','PETER JAY','ENCINARES','','2020-08-21','Male','Widowed','Roman Catholic','bansalan, davao del sur','brgy site','Barangay 2','Bansalan','Davao De Oro','TIM','sss','love','health','taas','email','landline','cp','Yes','','No','december','');
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `contacts_job`
--

/*!40000 ALTER TABLE `contacts_job` DISABLE KEYS */;
INSERT INTO `contacts_job` (`id`,`contact_id`,`local_abroad`,`job`,`location`,`expectedsal`,`passportno`,`expirydate`) VALUES 
 (1,1,'Abroad','mason','dubai','0','pas','0000-00-00 00:00:00'),
 (2,1,'Abroad','cook','japan','0','pas','0000-00-00 00:00:00');
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `disability`
--

/*!40000 ALTER TABLE `disability` DISABLE KEYS */;
INSERT INTO `disability` (`id`,`contact_id`,`disability`) VALUES 
 (1,'1','Visual'),
 (2,'1','Physical');
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `elementary`
--

/*!40000 ALTER TABLE `elementary` DISABLE KEYS */;
INSERT INTO `elementary` (`id`,`contact_id`,`school`,`underg`,`yearlvl`,`yearg`,`awards`) VALUES 
 (1,1,'ads',1,'4','2020','');
/*!40000 ALTER TABLE `elementary` ENABLE KEYS */;


--
-- Definition of table `emp_status_type`
--

DROP TABLE IF EXISTS `emp_status_type`;
CREATE TABLE `emp_status_type` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `contact_id` int(10) unsigned NOT NULL,
  `status` varchar(45) NOT NULL,
  `type` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `emp_status_type`
--

/*!40000 ALTER TABLE `emp_status_type` DISABLE KEYS */;
INSERT INTO `emp_status_type` (`id`,`contact_id`,`status`,`type`) VALUES 
 (1,1,'Unemployed','Terminated abroad - Yemen');
/*!40000 ALTER TABLE `emp_status_type` ENABLE KEYS */;


--
-- Definition of table `grad`
--

DROP TABLE IF EXISTS `grad`;
CREATE TABLE `grad` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `contact_id` int(10) unsigned NOT NULL,
  `school` varchar(100) NOT NULL,
  `underg` tinyint(3) unsigned NOT NULL,
  `yearlvl` varchar(45) NOT NULL,
  `yearg` varchar(45) NOT NULL,
  `awards` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `grad`
--

/*!40000 ALTER TABLE `grad` DISABLE KEYS */;
INSERT INTO `grad` (`id`,`contact_id`,`school`,`underg`,`yearlvl`,`yearg`,`awards`) VALUES 
 (1,1,'dsa',0,'N/A','2017','asd');
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `hs`
--

/*!40000 ALTER TABLE `hs` DISABLE KEYS */;
INSERT INTO `hs` (`id`,`contact_id`,`school`,`underg`,`yearlvl`,`yearg`,`awards`) VALUES 
 (1,1,'dsa',1,'3','2020','');
/*!40000 ALTER TABLE `hs` ENABLE KEYS */;


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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `language`
--

/*!40000 ALTER TABLE `language` DISABLE KEYS */;
INSERT INTO `language` (`id`,`contact_id`,`language`,`read`,`write`,`speak`,`understand`) VALUES 
 (1,1,'English','Yes','No','Yes','No'),
 (2,1,'Filipino','No','Yes','No','Yes'),
 (3,1,'bisaya','Yes','No','Yes','No');
/*!40000 ALTER TABLE `language` ENABLE KEYS */;


--
-- Definition of table `programs`
--

DROP TABLE IF EXISTS `programs`;
CREATE TABLE `programs` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `description` varchar(60) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `programs`
--

/*!40000 ALTER TABLE `programs` DISABLE KEYS */;
/*!40000 ALTER TABLE `programs` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
