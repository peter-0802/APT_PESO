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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `accounts`
--

/*!40000 ALTER TABLE `accounts` DISABLE KEYS */;
INSERT INTO `accounts` (`id`,`username`,`password`,`designation`) VALUES 
 (1,'master','master','Administrator'),
 (2,'SRA','SRA','SRA & Job Fair Focal Person'),
 (3,'1','1','tester'),
 (4,'COLLEGE','COLLEGE','College Schoolar Focal Person'),
 (5,'HS','HS','HS Schoolar Focal Person');
/*!40000 ALTER TABLE `accounts` ENABLE KEYS */;


--
-- Definition of table `child_labor`
--

DROP TABLE IF EXISTS `child_labor`;
CREATE TABLE `child_labor` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `event` varchar(100) NOT NULL,
  `event_date` varchar(100) NOT NULL,
  `host` varchar(100) NOT NULL,
  `veneu` varchar(100) NOT NULL,
  `surname` varchar(50) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `middlename` varchar(50) NOT NULL,
  `gender` varchar(45) NOT NULL,
  `notes` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UN-CONTACT` (`surname`,`firstname`,`middlename`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `child_labor`
--

/*!40000 ALTER TABLE `child_labor` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `colschoolar`
--

/*!40000 ALTER TABLE `colschoolar` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `contacts`
--

/*!40000 ALTER TABLE `contacts` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `hsshcoolar`
--

/*!40000 ALTER TABLE `hsshcoolar` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `jobfair`
--

/*!40000 ALTER TABLE `jobfair` DISABLE KEYS */;
/*!40000 ALTER TABLE `jobfair` ENABLE KEYS */;


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
  `contact_no` varchar(45) NOT NULL,
  `status` varchar(45) NOT NULL,
  `remarks` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UN-CONTACT` (`surname`,`firstname`,`middlename`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ofw`
--

/*!40000 ALTER TABLE `ofw` DISABLE KEYS */;
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
  `fax` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `rwa`
--

/*!40000 ALTER TABLE `rwa` DISABLE KEYS */;
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
  `gender` varchar(45) NOT NULL,
  `notes` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UN-CONTACT` (`surname`,`firstname`,`middlename`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sra`
--

/*!40000 ALTER TABLE `sra` DISABLE KEYS */;
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
