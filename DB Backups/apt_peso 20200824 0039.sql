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
  `course` varchar(100) NOT NULL,
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
INSERT INTO `college` (`id`,`contact_id`,`school`,`course`,`underg`,`yearlvl`,`yearg`,`awards`) VALUES 
 (1,1,'hs','it',0,'N/A','2018','3');
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `contacts_job`
--

/*!40000 ALTER TABLE `contacts_job` DISABLE KEYS */;
INSERT INTO `contacts_job` (`id`,`contact_id`,`local_abroad`,`job`,`location`,`expectedsal`,`passportno`,`expirydate`) VALUES 
 (1,1,'Local','Driver','Bansalan','0','pass','0000-00-00 00:00:00'),
 (2,1,'Local','Cook','Bansalan','0','pass','0000-00-00 00:00:00'),
 (3,1,'Local','Cashier','Bansalan','0','pass','0000-00-00 00:00:00');
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
 (1,1,'el',0,'N/A','2020','1');
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
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `eligibility`
--

/*!40000 ALTER TABLE `eligibility` DISABLE KEYS */;
INSERT INTO `eligibility` (`id`,`contact_id`,`eligibility`,`rating`,`exp_d`) VALUES 
 (7,'1','asd',0,'2020-08-23'),
 (8,'1','',0,'2020-08-23');
/*!40000 ALTER TABLE `eligibility` ENABLE KEYS */;


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
  `course` varchar(100) NOT NULL,
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
INSERT INTO `grad` (`id`,`contact_id`,`school`,`course`,`underg`,`yearlvl`,`yearg`,`awards`) VALUES 
 (1,1,'hs','mit',0,'N/A','2017','4');
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
 (1,1,'hs',0,'N/A','2019','2');
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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `language`
--

/*!40000 ALTER TABLE `language` DISABLE KEYS */;
INSERT INTO `language` (`id`,`contact_id`,`language`,`read`,`write`,`speak`,`understand`) VALUES 
 (1,1,'English','Yes','No','Yes','No'),
 (2,1,'Filipino','No','Yes','No','Yes'),
 (3,1,'bisaya','Yes','No','Yes','No'),
 (4,1,'English','Yes','No','No','Yes'),
 (5,1,'Filipino','No','Yes','No','No'),
 (6,1,'','No','No','Yes','No');
/*!40000 ALTER TABLE `language` ENABLE KEYS */;


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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `prc`
--

/*!40000 ALTER TABLE `prc` DISABLE KEYS */;
INSERT INTO `prc` (`id`,`contact_id`,`prc`,`valid_til`) VALUES 
 (5,'1','asd',2020),
 (6,'1','',2020);
/*!40000 ALTER TABLE `prc` ENABLE KEYS */;


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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tech_voc`
--

/*!40000 ALTER TABLE `tech_voc` DISABLE KEYS */;
INSERT INTO `tech_voc` (`id`,`contact_id`,`course`,`duration`,`training_ins`,`cert`) VALUES 
 (1,1,'asd','08/23/2020 to 08/23/2020','dsa','asd'),
 (2,1,NULL,'08/23/2020 to 08/23/2020','',''),
 (3,1,NULL,'08/23/2020 to 08/23/2020','',NULL);
/*!40000 ALTER TABLE `tech_voc` ENABLE KEYS */;


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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `work_exp`
--

/*!40000 ALTER TABLE `work_exp` DISABLE KEYS */;
INSERT INTO `work_exp` (`id`,`contact_id`,`company_name`,`address`,`position`,`inclusive_date`,`status`) VALUES 
 (1,1,'asd','add','pos','2020-08-23 to 2020-08-27','Contractual');
/*!40000 ALTER TABLE `work_exp` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
