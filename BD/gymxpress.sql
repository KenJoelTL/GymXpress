-- phpMyAdmin SQL Dump
-- version 4.5.4.1
-- http://www.phpmyadmin.net
--
-- Client :  localhost
-- Généré le :  Sam 02 Décembre 2017 à 18:50
-- Version du serveur :  5.7.11
-- Version de PHP :  5.6.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `gymxpress`
--

-- --------------------------------------------------------

--
-- Structure de la table `compte`
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
-- RELATIONS POUR LA TABLE `compte`:
--

--
-- Vider la table avant d'insérer `compte`
--

TRUNCATE TABLE `compte`;
--
-- Contenu de la table `compte`
--

INSERT INTO `compte` (`ID_COMPTE`, `ROLE`, `COURRIEL`, `MOT_PASSE`) VALUES
(1, 1, 'admin@mail.com', 'admin');

-- --------------------------------------------------------

--
-- Structure de la table `plan_entrainement`
--

DROP TABLE IF EXISTS `plan_entrainement`;
CREATE TABLE IF NOT EXISTS `plan_entrainement` (
  `ID_PLAN_ENTRAINEMENT` int(11) NOT NULL AUTO_INCREMENT,
  `ID_COMPTE` int(11) NOT NULL,
  `ID_ENTRAINEUR` int(11) NOT NULL,
  `NOM` varchar(50) DEFAULT 'Plan - Sans Nom',
  PRIMARY KEY (`ID_PLAN_ENTRAINEMENT`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- RELATIONS POUR LA TABLE `plan_entrainement`:
--

--
-- Vider la table avant d'insérer `plan_entrainement`
--

TRUNCATE TABLE `plan_entrainement`;
--
-- Contenu de la table `plan_entrainement`
--


/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
