CREATE DATABASE  IF NOT EXISTS `yazlab_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `yazlab_db`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: yazlab_db
-- ------------------------------------------------------
-- Server version	8.0.35

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `ders_programi`
--

DROP TABLE IF EXISTS `ders_programi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ders_programi` (
  `hoca_ad_soyad` varchar(45) NOT NULL,
  `ders_kod_ad` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ders_programi`
--

LOCK TABLES `ders_programi` WRITE;
/*!40000 ALTER TABLE `ders_programi` DISABLE KEYS */;
INSERT INTO `ders_programi` VALUES ('Süleyman  Eken','AYM201 Ayrık Matematik'),('Alper Metin','BSAT201 Bilişim Sistemleri Analizi'),('Halil  Yiğit','STC203 Bilgisayar Mimarisi ve Organizasyonu'),('Önder Yakut','BLS201 Bulut Bilişim'),('Önder Yakut','WEB301 Web Tasarım');
/*!40000 ALTER TABLE `ders_programi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ders_programi2`
--

DROP TABLE IF EXISTS `ders_programi2`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ders_programi2` (
  `hoca_ad_soyad` varchar(45) NOT NULL,
  `ders_kod_ad` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ders_programi2`
--

LOCK TABLES `ders_programi2` WRITE;
/*!40000 ALTER TABLE `ders_programi2` DISABLE KEYS */;
INSERT INTO `ders_programi2` VALUES ('Zeynep Hilal Kilimci','PRO101 Algoritma ve Programlama -1'),('Hikmet Hakan Gürel','YBS101 Yönetim Bilişim Sistemleri'),('Alper Metin','ING101 İngilizce -1'),('Hikmet Hakan Gürel','FZK101 Fizik -1'),('Adnan  Sondaş','MAT101 Matematik -1');
/*!40000 ALTER TABLE `ders_programi2` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dersler`
--

DROP TABLE IF EXISTS `dersler`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dersler` (
  `id_ders` int NOT NULL AUTO_INCREMENT,
  `ders_kodu` varchar(45) NOT NULL,
  `ders_ad` varchar(45) NOT NULL,
  `ders_kredi` varchar(45) NOT NULL,
  PRIMARY KEY (`id_ders`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dersler`
--

LOCK TABLES `dersler` WRITE;
/*!40000 ALTER TABLE `dersler` DISABLE KEYS */;
INSERT INTO `dersler` VALUES (12,'BLS201','Bulut Bilişim','4'),(13,'YZK225','Yapay Zeka ','3'),(14,'AYM201','Ayrık Matematik','2'),(15,'BSAT201','Bilişim Sistemleri Analizi','4'),(16,'LNX215','Linux Yönetim Sistemleri','5'),(17,'VTYS201','Veritabanı Yönetim Sistemleri','3'),(20,'SAY211','Sayısal Analiz','3'),(21,'VHAB211','Veri Haberleşmesi','5'),(22,'ETİC211','E-Ticaret ve Uygulamaları','5'),(23,'OS301','İşletim Sistemleri','3'),(24,'WEB301','Web Tasarım','3');
/*!40000 ALTER TABLE `dersler` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dersler_2`
--

DROP TABLE IF EXISTS `dersler_2`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dersler_2` (
  `id_ders_2` int NOT NULL AUTO_INCREMENT,
  `ders_kodu` varchar(45) NOT NULL,
  `ders_ad` varchar(45) NOT NULL,
  `ders_kredi` varchar(45) NOT NULL,
  PRIMARY KEY (`id_ders_2`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dersler_2`
--

LOCK TABLES `dersler_2` WRITE;
/*!40000 ALTER TABLE `dersler_2` DISABLE KEYS */;
INSERT INTO `dersler_2` VALUES (1,'FZK101','Fizik -1','5'),(3,'MAT101','Matematik -1','5'),(4,'FZK201','Fizik -2','5'),(5,'MAT201','Matematik -2','5'),(6,'TBT101','Temel Bilgi Teknolojileri','3'),(7,'TLE101','Temel Elektronik','4'),(8,'YBS101','Yönetim Bilişim Sistemleri','3'),(9,'KRY101','Kariyer Planlama','2'),(10,'ING101','İngilizce -1','2'),(11,'ING201','İngilizce -2','2'),(12,'PRO101','Algoritma ve Programlama -1','4'),(14,'PRO201','Algoritma ve Programlama -2','4');
/*!40000 ALTER TABLE `dersler_2` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hocalar`
--

DROP TABLE IF EXISTS `hocalar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hocalar` (
  `id_hoca` int NOT NULL AUTO_INCREMENT,
  `ad_hoca` varchar(45) NOT NULL,
  `soyad_hoca` varchar(45) NOT NULL,
  `brans_hoca` varchar(45) NOT NULL,
  PRIMARY KEY (`id_hoca`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hocalar`
--

LOCK TABLES `hocalar` WRITE;
/*!40000 ALTER TABLE `hocalar` DISABLE KEYS */;
INSERT INTO `hocalar` VALUES (3,'Alper','Metin','İngilizce'),(4,'Süleyman ','Eken','Donanım'),(5,'Halil ','Yiğit','Elektronik'),(7,'Serdar','Solak','Teknik'),(11,'Zeynep Hilal','Kilimci','Yazılım'),(14,'Adnan ','Sondaş','Gömülü'),(15,'Önder','Yakut','Web'),(16,'Mehmet','Yıldırım','Başkan'),(17,'Hikmet Hakan','Gürel','Fizik'),(18,'Mustafa Bilge','Uçar','Elektrik'),(19,'Yavuz Selim','Fatihoğlu','AR');
/*!40000 ALTER TABLE `hocalar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'yazlab_db'
--

--
-- Dumping routines for database 'yazlab_db'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-06 23:06:28
