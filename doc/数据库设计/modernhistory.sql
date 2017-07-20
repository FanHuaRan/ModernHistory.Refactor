/*
Navicat MySQL Data Transfer

Source Server         : LocalConnect
Source Server Version : 50707
Source Host           : localhost:3306
Source Database       : modernhistory

Target Server Type    : MYSQL
Target Server Version : 50707
File Encoding         : 65001

Date: 2017-07-16 20:05:38
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for famousperson
-- ----------------------------
DROP TABLE IF EXISTS `famousperson`;
CREATE TABLE `famousperson` (
  `FamousPersonId` int(11) NOT NULL AUTO_INCREMENT,
  `PersonName` varchar(20) NOT NULL,
  `Gender` tinyint(3) unsigned NOT NULL,
  `Province` varchar(20) NOT NULL,
  `Nation` varchar(10) NOT NULL,
  `BornDate` datetime NOT NULL,
  `BornPlace` longtext NOT NULL,
  `BornX` double NOT NULL,
  `BornY` double NOT NULL,
  `DeadDate` datetime NOT NULL,
  `FamousPersonTypeId` int(11) NOT NULL,
  PRIMARY KEY (`FamousPersonId`),
  KEY `IX_FamousPersonTypeId` (`FamousPersonTypeId`) USING HASH,
  CONSTRAINT `FK_FamousPerson_FamousPersonType_FamousPersonTypeId` FOREIGN KEY (`FamousPersonTypeId`) REFERENCES `famouspersontype` (`FamousPersonTypeId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for famouspersontype
-- ----------------------------
DROP TABLE IF EXISTS `famouspersontype`;
CREATE TABLE `famouspersontype` (
  `FamousPersonTypeId` int(11) NOT NULL AUTO_INCREMENT,
  `FamousPersonTypeName` longtext NOT NULL,
  PRIMARY KEY (`FamousPersonTypeId`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for historyevent
-- ----------------------------
DROP TABLE IF EXISTS `historyevent`;
CREATE TABLE `historyevent` (
  `HistoryEventId` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(30) NOT NULL,
  `Detail` varchar(1030) NOT NULL,
  `OccurDate` datetime NOT NULL,
  `Province` varchar(20) NOT NULL,
  `Place` longtext NOT NULL,
  `OccurX` double NOT NULL,
  `OccurY` double NOT NULL,
  `HistoryEventTypeId` int(11) NOT NULL,
  PRIMARY KEY (`HistoryEventId`),
  KEY `IX_HistoryEventTypeId` (`HistoryEventTypeId`) USING HASH,
  CONSTRAINT `FK_HistoryEvent_HistoryEventType_HistoryEventTypeId` FOREIGN KEY (`HistoryEventTypeId`) REFERENCES `historyeventtype` (`HistoryEventTypeId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for historyeventtype
-- ----------------------------
DROP TABLE IF EXISTS `historyeventtype`;
CREATE TABLE `historyeventtype` (
  `HistoryEventTypeId` int(11) NOT NULL AUTO_INCREMENT,
  `HistoryEventTypeName` longtext NOT NULL,
  PRIMARY KEY (`HistoryEventTypeId`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for mhuser
-- ----------------------------
DROP TABLE IF EXISTS `mhuser`;
CREATE TABLE `mhuser` (
  `MhUserId` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` longtext NOT NULL,
  `Password` longtext NOT NULL,
  `RealName` longtext NOT NULL,
  `Email` longtext,
  PRIMARY KEY (`MhUserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for personeventrelation
-- ----------------------------
DROP TABLE IF EXISTS `personeventrelation`;
CREATE TABLE `personeventrelation` (
  `PersonEventRelationId` int(11) NOT NULL AUTO_INCREMENT,
  `FamousPersonId` int(11) NOT NULL,
  `HistoryEventId` int(11) NOT NULL,
  PRIMARY KEY (`PersonEventRelationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for __migrationhistory
-- ----------------------------
DROP TABLE IF EXISTS `__migrationhistory`;
CREATE TABLE `__migrationhistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ContextKey` varchar(300) NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
