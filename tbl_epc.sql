-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 07, 2022 at 12:46 PM
-- Server version: 10.4.19-MariaDB
-- PHP Version: 8.0.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `epc`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_epc`
--

CREATE TABLE `tbl_epc` (
  `time` datetime NOT NULL,
  `QI_BL1_1@PV` double NOT NULL,
  `QI_BL2_1@PV` double NOT NULL,
  `QI_BL3_1@PV` double NOT NULL,
  `QI_BL4_1@PV` double NOT NULL,
  `QI_BLA_1@PV` double NOT NULL,
  `QI_BL5_1@PV` double NOT NULL,
  `QI_BL6_1@PV` double NOT NULL,
  `QI_BL7_1@PV` double NOT NULL,
  `QI_NTU_1@PV` double NOT NULL,
  `QI_BP2_1@PV` double NOT NULL,
  `QI_FUS_1@PV` double NOT NULL,
  `QI_F2B@PV` double NOT NULL,
  `QI_MUD@PV` double NOT NULL,
  `QI_HOT@PV` double NOT NULL,
  `QI_BP3@PV` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_epc`
--
ALTER TABLE `tbl_epc`
  ADD PRIMARY KEY (`time`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
