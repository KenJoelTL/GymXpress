-- phpMyAdmin SQL Dump
-- version 4.5.4.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Dec 11, 2017 at 04:23 PM
-- Server version: 5.7.11
-- PHP Version: 5.6.18

SET FOREIGN_KEY_CHECKS=0;
SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `gymxpress`
--

-- --------------------------------------------------------

--
-- Table structure for table `compte`
--

DROP TABLE IF EXISTS `compte`;
CREATE TABLE IF NOT EXISTS `compte` (
  `ID_COMPTE` int(11) NOT NULL AUTO_INCREMENT,
  `ROLE` int(11) NOT NULL DEFAULT '0',
  `COURRIEL` varchar(255) NOT NULL,
  `MOT_PASSE` varchar(11) NOT NULL,
  PRIMARY KEY (`ID_COMPTE`),
  UNIQUE KEY `COMPTE_UQ_COURRIEL` (`COURRIEL`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `compte`
--

INSERT INTO `compte` (`ID_COMPTE`, `ROLE`, `COURRIEL`, `MOT_PASSE`) VALUES
(1, 2, 'admin@mail.com', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `dispo`
--

DROP TABLE IF EXISTS `dispo`;
CREATE TABLE IF NOT EXISTS `dispo` (
  `ID_DISPO` int(11) NOT NULL AUTO_INCREMENT,
  `ID_ENTRAINEUR` int(11) NOT NULL,
  `HEURE_DEBUT` varchar(255) NOT NULL,
  `HEURE_FIN` varchar(255) NOT NULL,
  `DATE` varchar(255) NOT NULL,
  PRIMARY KEY (`ID_DISPO`),
  KEY `ID_ENTRAINEUR_FK` (`ID_ENTRAINEUR`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `plan_entrainement`
--

DROP TABLE IF EXISTS `plan_entrainement`;
CREATE TABLE IF NOT EXISTS `plan_entrainement` (
  `ID_PLAN_ENTRAINEMENT` int(11) NOT NULL AUTO_INCREMENT,
  `ID_COMPTE` int(11) DEFAULT NULL,
  `ID_ENTRAINEUR` int(11) DEFAULT NULL,
  `NOM` varchar(50) DEFAULT 'Plan - Sans Nom',
  PRIMARY KEY (`ID_PLAN_ENTRAINEMENT`),
  KEY `ID_COMPTE` (`ID_COMPTE`),
  KEY `ID_ENTRAINEUR` (`ID_ENTRAINEUR`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `rendezvous`
--

DROP TABLE IF EXISTS `rendezvous`;
CREATE TABLE IF NOT EXISTS `rendezvous` (
  `ID_RENDEZ_VOUS` int(11) NOT NULL AUTO_INCREMENT,
  `ID_DISPO` int(11) NOT NULL,
  `ID_CLIENT` int(11) NOT NULL,
  PRIMARY KEY (`ID_RENDEZ_VOUS`),
  KEY `ID_DISPO_FK` (`ID_DISPO`),
  KEY `ID_CLIENT_FK` (`ID_CLIENT`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `dispo`
--
ALTER TABLE `dispo`
  ADD CONSTRAINT `DISPO_FK1` FOREIGN KEY (`ID_ENTRAINEUR`) REFERENCES `compte` (`ID_COMPTE`) ON DELETE CASCADE;

--
-- Constraints for table `plan_entrainement`
--
ALTER TABLE `plan_entrainement`
  ADD CONSTRAINT `PLAN_ENTRAINEMENT_FK1` FOREIGN KEY (`ID_COMPTE`) REFERENCES `compte` (`ID_COMPTE`) ON DELETE SET NULL,
  ADD CONSTRAINT `PLAN_ENTRAINEMENT_FK2` FOREIGN KEY (`ID_ENTRAINEUR`) REFERENCES `compte` (`ID_COMPTE`) ON DELETE SET NULL;

--
-- Constraints for table `rendezvous`
--
ALTER TABLE `rendezvous`
  ADD CONSTRAINT `RENDEZVOUS_FK1` FOREIGN KEY (`ID_DISPO`) REFERENCES `dispo` (`ID_DISPO`) ON DELETE CASCADE,
  ADD CONSTRAINT `RENDEZVOUS_FK2` FOREIGN KEY (`ID_CLIENT`) REFERENCES `compte` (`ID_COMPTE`) ON DELETE CASCADE;
SET FOREIGN_KEY_CHECKS=1;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
