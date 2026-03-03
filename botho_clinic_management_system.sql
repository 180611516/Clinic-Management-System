-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 07, 2025 at 09:57 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `botho_clinic_management_system`
--

-- --------------------------------------------------------

--
-- Table structure for table `appointments`
--

CREATE TABLE `appointments` (
  `appointment_id` int(11) NOT NULL,
  `student_id` int(11) NOT NULL,
  `provider_id` int(11) NOT NULL,
  `appointment_date` date NOT NULL,
  `appointment_time` time NOT NULL,
  `reason` varchar(255) DEFAULT NULL,
  `status` enum('Pending','Completed','Cancelled') DEFAULT 'Pending',
  `created_at` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `appointments`
--

INSERT INTO `appointments` (`appointment_id`, `student_id`, `provider_id`, `appointment_date`, `appointment_time`, `reason`, `status`, `created_at`) VALUES
(12, 233002, 1, '2025-10-31', '12:00:00', 'headaches', 'Completed', '2025-10-24 02:38:09'),
(13, 233002, 1, '2025-10-24', '15:00:00', 'back pains', 'Completed', '2025-10-24 14:08:06'),
(14, 233002, 1, '2025-10-27', '12:00:00', 'flue', 'Completed', '2025-10-27 08:48:35'),
(15, 233002, 5, '2025-10-27', '10:00:00', 'rist work', 'Pending', '2025-10-27 08:57:28'),
(16, 233002, 1, '2025-10-28', '12:00:00', 'hlooho', 'Completed', '2025-10-28 11:25:39');

-- --------------------------------------------------------

--
-- Table structure for table `backup_providers`
--

CREATE TABLE `backup_providers` (
  `provider_id` int(11) NOT NULL DEFAULT 0,
  `user_id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `full_name` varchar(150) NOT NULL,
  `specialization` varchar(100) DEFAULT NULL,
  `shift_schedule` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `backup_providers`
--

INSERT INTO `backup_providers` (`provider_id`, `user_id`, `username`, `full_name`, `specialization`, `shift_schedule`) VALUES
(1, 7, '', 'Maama Phatela', NULL, NULL),
(5, 29, 'maellen.thulo', 'Maellen Thulo', NULL, NULL),
(6, 30, 'lerato.sebilo', 'Lerato Sebilo', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `backup_students`
--

CREATE TABLE `backup_students` (
  `student_id` int(11) NOT NULL DEFAULT 0,
  `user_id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `full_name` varchar(150) NOT NULL,
  `student_number` int(11) DEFAULT NULL,
  `date_of_birth` date DEFAULT NULL,
  `gender` varchar(10) DEFAULT NULL,
  `address` varchar(200) DEFAULT NULL,
  `emergency_contact` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `backup_students`
--

INSERT INTO `backup_students` (`student_id`, `user_id`, `username`, `full_name`, `student_number`, `date_of_birth`, `gender`, `address`, `emergency_contact`) VALUES
(233001, 24, 'sebata.moeti', 'Sebata Moeti', NULL, NULL, NULL, NULL, NULL),
(233002, 25, 'lerato.senauoana', 'Lerato Senauoana', NULL, NULL, NULL, NULL, NULL),
(233003, 26, 'themba.mhlozana', 'Themba Mhlozana', NULL, NULL, NULL, NULL, NULL),
(233004, 27, 'litsila.koatsi', 'Litsila Koatsi', NULL, NULL, NULL, NULL, NULL),
(233005, 28, 'mphuthi.phafoli', 'Mphuthi Phafoli', NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `backup_users`
--

CREATE TABLE `backup_users` (
  `user_id` int(11) NOT NULL DEFAULT 0,
  `username` varchar(100) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `full_name` varchar(150) NOT NULL,
  `contact_info` varchar(100) DEFAULT NULL,
  `role` enum('Admin','Provider','Student') NOT NULL,
  `is_active` tinyint(1) DEFAULT 1,
  `created_at` datetime DEFAULT current_timestamp(),
  `must_change_password` bit(1) DEFAULT b'1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `backup_users`
--

INSERT INTO `backup_users` (`user_id`, `username`, `password_hash`, `full_name`, `contact_info`, `role`, `is_active`, `created_at`, `must_change_password`) VALUES
(6, 'kolisang.phatela', '3eb3fe66b31e3b4d10fa70b5cad49c7112294af6ae4e476a1c405155d45aa121', 'kolisang phatela', '62626912', 'Admin', 1, '2025-10-14 08:34:02', b'0'),
(7, 'maama.phatela', '81a83544cf93c245178cbc1620030f1123f435af867c79d87135983c52ab39d9', 'Maama Phatela', '56828040', 'Provider', 1, '2025-10-14 08:34:51', b'0'),
(24, 'sebata.moeti', '81a83544cf93c245178cbc1620030f1123f435af867c79d87135983c52ab39d9', 'Sebata Moeti', '56465645', 'Student', 1, '2025-10-21 07:57:02', b'0'),
(25, 'lerato.senauoana', '81a83544cf93c245178cbc1620030f1123f435af867c79d87135983c52ab39d9', 'Lerato Senauoana', '57498989', 'Student', 1, '2025-10-21 09:47:58', b'0'),
(26, 'themba.mhlozana', '9a4aabf0e5cf71cae2cea646613ce7e2a5919fa758e56819704be25a3a2c1f0b', 'Themba Mhlozana', '574989809', 'Student', 1, '2025-10-21 09:48:31', b'1'),
(27, 'litsila.koatsi', '9a4aabf0e5cf71cae2cea646613ce7e2a5919fa758e56819704be25a3a2c1f0b', 'Litsila Koatsi', '67557767', 'Student', 1, '2025-10-21 09:48:55', b'1'),
(28, 'mphuthi.phafoli', '9a4aabf0e5cf71cae2cea646613ce7e2a5919fa758e56819704be25a3a2c1f0b', 'Mphuthi Phafoli', '66775566', 'Student', 1, '2025-10-21 09:49:22', b'1'),
(29, 'maellen.thulo', '9a4aabf0e5cf71cae2cea646613ce7e2a5919fa758e56819704be25a3a2c1f0b', 'Maellen Thulo', '6775890', 'Provider', 1, '2025-10-21 20:17:49', b'1'),
(30, 'lerato.sebilo', '81a83544cf93c245178cbc1620030f1123f435af867c79d87135983c52ab39d9', 'Lerato Sebilo', '67778898', 'Provider', 1, '2025-10-24 04:19:22', b'0');

-- --------------------------------------------------------

--
-- Table structure for table `consultations`
--

CREATE TABLE `consultations` (
  `consultation_id` int(11) NOT NULL,
  `appointment_id` int(11) NOT NULL,
  `student_id` int(11) NOT NULL,
  `provider_id` int(11) NOT NULL,
  `consultation_date` datetime DEFAULT current_timestamp(),
  `temperature` decimal(5,2) DEFAULT NULL,
  `blood_pressure` varchar(20) DEFAULT NULL,
  `weight` decimal(5,2) DEFAULT NULL,
  `pulse` int(5) DEFAULT NULL,
  `notes` text DEFAULT NULL,
  `diagnosis` varchar(255) DEFAULT NULL,
  `recorded_at` datetime DEFAULT current_timestamp(),
  `vitals` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `consultations`
--

INSERT INTO `consultations` (`consultation_id`, `appointment_id`, `student_id`, `provider_id`, `consultation_date`, `temperature`, `blood_pressure`, `weight`, `pulse`, `notes`, `diagnosis`, `recorded_at`, `vitals`) VALUES
(2, 12, 0, 0, '2025-10-28 15:25:57', NULL, NULL, NULL, NULL, 'home', 'every day', '2025-10-28 15:25:57', 'Temp: 34, BP: 89, Weight: 67, Pulse: 45'),
(3, 14, 0, 0, '2025-10-28 15:35:46', NULL, NULL, NULL, NULL, 'hey you', 'khama', '2025-10-28 15:35:46', 'Temp: 36, BP: 67, Weight: 67, Pulse: 98'),
(4, 16, 0, 0, '2025-10-28 17:13:01', NULL, NULL, NULL, NULL, 'come on', 'yes', '2025-10-28 17:13:01', 'Temp: 37, BP: 120, Weight: 58, Pulse: 78'),
(5, 13, 0, 0, '2025-11-02 02:48:15', NULL, NULL, NULL, NULL, 'patient reports mild headache, fatigue, and occassional diziness. no visible signs of infection. appetide normal. no alegies ', 'mild dehydration and fatigue. advised rest, increased fluid intake, and monitor symptoms.', '2025-11-02 02:48:15', 'Temp: 36, BP: 120/80, Weight: 67, Pulse: 75');

-- --------------------------------------------------------

--
-- Table structure for table `medications`
--

CREATE TABLE `medications` (
  `medication_id` int(11) NOT NULL,
  `medication_name` varchar(100) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  `created_at` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `medications`
--

INSERT INTO `medications` (`medication_id`, `medication_name`, `description`, `created_at`) VALUES
(1, 'Paracetamol (500mg)', NULL, '2025-10-27 08:37:44'),
(2, 'Ibuprofen (400mg)', NULL, '2025-10-27 08:37:44'),
(3, 'Amoxicillin (250mg)', NULL, '2025-10-27 08:37:44'),
(4, 'Omeprazole (20mg)', NULL, '2025-10-27 08:37:44'),
(5, 'Cetirizine (10mg)', NULL, '2025-10-27 08:37:44');

-- --------------------------------------------------------

--
-- Table structure for table `password_reset_tokens`
--

CREATE TABLE `password_reset_tokens` (
  `token_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `token` varchar(100) NOT NULL,
  `expires_at` datetime NOT NULL,
  `used` tinyint(1) DEFAULT 0,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `prescriptions`
--

CREATE TABLE `prescriptions` (
  `prescription_id` int(11) NOT NULL,
  `consultation_id` int(11) NOT NULL,
  `medication_name` varchar(100) DEFAULT NULL,
  `dosage` varchar(50) DEFAULT NULL,
  `instructions` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `prescriptions`
--

INSERT INTO `prescriptions` (`prescription_id`, `consultation_id`, `medication_name`, `dosage`, `instructions`) VALUES
(1, 3, 'Amoxicillin (250mg)', '78', '4'),
(2, 4, 'Ibuprofen (400mg)', '89', '4'),
(3, 5, 'Amoxicillin (250mg)', '2', '20'),
(4, 5, 'Omeprazole (20mg)', '1', '10'),
(5, 5, 'Cetirizine (10mg)', '2', '20');

-- --------------------------------------------------------

--
-- Table structure for table `providers`
--

CREATE TABLE `providers` (
  `provider_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `full_name` varchar(150) NOT NULL,
  `specialization` varchar(100) DEFAULT NULL,
  `shift_schedule` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `providers`
--

INSERT INTO `providers` (`provider_id`, `user_id`, `username`, `full_name`, `specialization`, `shift_schedule`) VALUES
(1, 7, '', 'Maama Phatela', NULL, NULL),
(5, 29, 'maellen.thulo', 'Maellen Thulo', NULL, NULL),
(6, 30, 'lerato.sebilo', 'Lerato Sebilo', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `provider_details`
--

CREATE TABLE `provider_details` (
  `provider_detail_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `staff_number` varchar(20) DEFAULT NULL,
  `department` varchar(100) DEFAULT NULL,
  `position` varchar(100) DEFAULT NULL,
  `specialization` varchar(100) DEFAULT NULL,
  `office_location` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `provider_details`
--

INSERT INTO `provider_details` (`provider_detail_id`, `user_id`, `staff_number`, `department`, `position`, `specialization`, `office_location`) VALUES
(1, 7, NULL, NULL, NULL, NULL, NULL),
(2, 29, NULL, NULL, NULL, NULL, NULL),
(3, 30, NULL, NULL, NULL, NULL, NULL),
(4, 7, '229990909', 'Health', 'Doctor', 'therapist', 'L01 R08');

-- --------------------------------------------------------

--
-- Table structure for table `reminders`
--

CREATE TABLE `reminders` (
  `reminder_id` int(11) NOT NULL,
  `provider_id` int(11) NOT NULL,
  `student_id` int(11) NOT NULL,
  `message` text NOT NULL,
  `reminder_date` datetime NOT NULL,
  `status` enum('pending','completed') DEFAULT 'pending',
  `is_read` tinyint(1) DEFAULT 0,
  `date_sent` timestamp NOT NULL DEFAULT current_timestamp(),
  `user_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `reminders`
--

INSERT INTO `reminders` (`reminder_id`, `provider_id`, `student_id`, `message`, `reminder_date`, `status`, `is_read`, `date_sent`, `user_id`) VALUES
(1, 1, 233002, 'yes boy come and see me today', '2025-11-04 13:43:57', 'pending', 1, '2025-11-04 11:44:21', 25),
(2, 1, 233002, 'good morning oyoohh yohh yohh', '2025-11-04 14:46:54', 'pending', 1, '2025-11-04 12:47:14', 25);

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE `students` (
  `student_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `full_name` varchar(150) NOT NULL,
  `student_number` int(11) DEFAULT NULL,
  `date_of_birth` date DEFAULT NULL,
  `gender` varchar(10) DEFAULT NULL,
  `address` varchar(200) DEFAULT NULL,
  `emergency_contact` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`student_id`, `user_id`, `username`, `full_name`, `student_number`, `date_of_birth`, `gender`, `address`, `emergency_contact`) VALUES
(233001, 24, 'sebata.moeti', 'Sebata Moeti', NULL, NULL, NULL, NULL, NULL),
(233002, 25, 'lerato.senauoana', 'Lerato Senauoana', NULL, NULL, NULL, NULL, NULL),
(233003, 26, 'themba.mhlozana', 'Themba Mhlozana', NULL, NULL, NULL, NULL, NULL),
(233004, 27, 'litsila.koatsi', 'Litsila Koatsi', NULL, NULL, NULL, NULL, NULL),
(233005, 28, 'mphuthi.phafoli', 'Mphuthi Phafoli', NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `student_details`
--

CREATE TABLE `student_details` (
  `student_detail_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `student_number` varchar(20) DEFAULT NULL,
  `faculty` varchar(100) DEFAULT NULL,
  `program` varchar(100) DEFAULT NULL,
  `year_of_study` int(11) DEFAULT NULL,
  `gender` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `student_details`
--

INSERT INTO `student_details` (`student_detail_id`, `user_id`, `student_number`, `faculty`, `program`, `year_of_study`, `gender`) VALUES
(1, 24, '233001', NULL, NULL, NULL, NULL),
(2, 25, '233002', 'FET', 'Software engineering', 3, 'Male'),
(3, 26, '233003', NULL, NULL, NULL, NULL),
(4, 27, '233004', NULL, NULL, NULL, NULL),
(5, 28, '233005', NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `full_name` varchar(150) NOT NULL,
  `contact_info` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `phone_number` varchar(20) DEFAULT NULL,
  `date_of_birth` date DEFAULT NULL,
  `address` text DEFAULT NULL,
  `emergency_contact_name` varchar(100) DEFAULT NULL,
  `emergency_contact_phone` varchar(20) DEFAULT NULL,
  `role` enum('Admin','Provider','Student') NOT NULL,
  `is_active` tinyint(1) DEFAULT 1,
  `created_at` datetime DEFAULT current_timestamp(),
  `must_change_password` bit(1) DEFAULT b'1',
  `last_updated` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `username`, `password_hash`, `full_name`, `contact_info`, `email`, `phone_number`, `date_of_birth`, `address`, `emergency_contact_name`, `emergency_contact_phone`, `role`, `is_active`, `created_at`, `must_change_password`, `last_updated`) VALUES
(6, 'kolisang.phatela', '3eb3fe66b31e3b4d10fa70b5cad49c7112294af6ae4e476a1c405155d45aa121', 'kolisang phatela', '62626912', 'kolisang.phatela@gmail.com', '62626912', '2006-05-17', 'Maseru \r\nKhubelu', '59701787', '50626319', 'Admin', 1, '2025-10-14 08:34:02', b'0', '2025-11-04 07:14:09'),
(7, 'maama.phatela', '81a83544cf93c245178cbc1620030f1123f435af867c79d87135983c52ab39d9', 'Maama Phatela', '56828040', 'maama.phatela@gmail.com', '56828040', '1996-10-05', 'Ha Phatela \r\nTebellong \r\nQacha \'s Nek', '50626677', '57408184', 'Provider', 1, '2025-10-14 08:34:51', b'0', '2025-11-04 11:43:08'),
(24, 'sebata.moeti', '81a83544cf93c245178cbc1620030f1123f435af867c79d87135983c52ab39d9', 'Sebata Moeti', '56465645', NULL, '56465645', NULL, NULL, NULL, NULL, 'Student', 1, '2025-10-21 07:57:02', b'0', '2025-11-04 06:13:22'),
(25, 'lerato.senauoana', '0d6d561ca467645da3f0fa65553043069986bfde3536094dc2a2dc57d46e620a', 'Lerato Senauoana', '57498989', 'lerato.senauoana@gmail.com', '57498989', '1991-07-18', 'Motse Mocha\r\nQacha \'s Nek', '50626677', '56828040', 'Student', 1, '2025-10-21 09:47:58', b'0', '2025-11-06 08:10:44'),
(26, 'themba.mhlozana', '9a4aabf0e5cf71cae2cea646613ce7e2a5919fa758e56819704be25a3a2c1f0b', 'Themba Mhlozana', '574989809', NULL, '574989809', NULL, NULL, NULL, NULL, 'Student', 1, '2025-10-21 09:48:31', b'1', '2025-11-04 06:13:22'),
(27, 'litsila.koatsi', '9a4aabf0e5cf71cae2cea646613ce7e2a5919fa758e56819704be25a3a2c1f0b', 'Litsila Koatsi', '67557767', NULL, '67557767', NULL, NULL, NULL, NULL, 'Student', 1, '2025-10-21 09:48:55', b'1', '2025-11-04 06:13:22'),
(28, 'mphuthi.phafoli', '81a83544cf93c245178cbc1620030f1123f435af867c79d87135983c52ab39d9', 'Mphuthi Phafoli', '66775566', NULL, '66775566', NULL, NULL, NULL, NULL, 'Student', 1, '2025-10-21 09:49:22', b'0', '2025-11-04 06:13:22'),
(29, 'maellen.thulo', '9a4aabf0e5cf71cae2cea646613ce7e2a5919fa758e56819704be25a3a2c1f0b', 'Maellen Thulo', '6775890', NULL, '6775890', NULL, NULL, NULL, NULL, 'Provider', 1, '2025-10-21 20:17:49', b'1', '2025-11-04 06:13:22'),
(30, 'lerato.sebilo', '81a83544cf93c245178cbc1620030f1123f435af867c79d87135983c52ab39d9', 'Lerato Sebilo', '67778898', NULL, '67778898', NULL, NULL, NULL, NULL, 'Provider', 1, '2025-10-24 04:19:22', b'0', '2025-11-04 06:13:22');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `appointments`
--
ALTER TABLE `appointments`
  ADD PRIMARY KEY (`appointment_id`),
  ADD KEY `student_id` (`student_id`),
  ADD KEY `provider_id` (`provider_id`);

--
-- Indexes for table `consultations`
--
ALTER TABLE `consultations`
  ADD PRIMARY KEY (`consultation_id`),
  ADD UNIQUE KEY `appointment_unique` (`appointment_id`);

--
-- Indexes for table `medications`
--
ALTER TABLE `medications`
  ADD PRIMARY KEY (`medication_id`);

--
-- Indexes for table `password_reset_tokens`
--
ALTER TABLE `password_reset_tokens`
  ADD PRIMARY KEY (`token_id`),
  ADD KEY `idx_token` (`token`),
  ADD KEY `idx_user_id` (`user_id`);

--
-- Indexes for table `prescriptions`
--
ALTER TABLE `prescriptions`
  ADD PRIMARY KEY (`prescription_id`),
  ADD KEY `consultation_id` (`consultation_id`);

--
-- Indexes for table `providers`
--
ALTER TABLE `providers`
  ADD PRIMARY KEY (`provider_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `provider_details`
--
ALTER TABLE `provider_details`
  ADD PRIMARY KEY (`provider_detail_id`),
  ADD UNIQUE KEY `staff_number` (`staff_number`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `reminders`
--
ALTER TABLE `reminders`
  ADD PRIMARY KEY (`reminder_id`),
  ADD KEY `provider_id` (`provider_id`),
  ADD KEY `student_id` (`student_id`),
  ADD KEY `idx_reminders_user_id` (`user_id`);

--
-- Indexes for table `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`student_id`),
  ADD UNIQUE KEY `student_number` (`student_number`),
  ADD UNIQUE KEY `student_number_2` (`student_number`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `student_details`
--
ALTER TABLE `student_details`
  ADD PRIMARY KEY (`student_detail_id`),
  ADD UNIQUE KEY `student_number` (`student_number`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `appointments`
--
ALTER TABLE `appointments`
  MODIFY `appointment_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `consultations`
--
ALTER TABLE `consultations`
  MODIFY `consultation_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `medications`
--
ALTER TABLE `medications`
  MODIFY `medication_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `password_reset_tokens`
--
ALTER TABLE `password_reset_tokens`
  MODIFY `token_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `prescriptions`
--
ALTER TABLE `prescriptions`
  MODIFY `prescription_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `providers`
--
ALTER TABLE `providers`
  MODIFY `provider_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `provider_details`
--
ALTER TABLE `provider_details`
  MODIFY `provider_detail_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `reminders`
--
ALTER TABLE `reminders`
  MODIFY `reminder_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `students`
--
ALTER TABLE `students`
  MODIFY `student_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=233006;

--
-- AUTO_INCREMENT for table `student_details`
--
ALTER TABLE `student_details`
  MODIFY `student_detail_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `appointments`
--
ALTER TABLE `appointments`
  ADD CONSTRAINT `appointments_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `students` (`student_id`),
  ADD CONSTRAINT `appointments_ibfk_2` FOREIGN KEY (`provider_id`) REFERENCES `providers` (`provider_id`);

--
-- Constraints for table `consultations`
--
ALTER TABLE `consultations`
  ADD CONSTRAINT `consultations_ibfk_1` FOREIGN KEY (`appointment_id`) REFERENCES `appointments` (`appointment_id`),
  ADD CONSTRAINT `fk_consultation_appointment` FOREIGN KEY (`appointment_id`) REFERENCES `appointments` (`appointment_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `password_reset_tokens`
--
ALTER TABLE `password_reset_tokens`
  ADD CONSTRAINT `password_reset_tokens_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE;

--
-- Constraints for table `prescriptions`
--
ALTER TABLE `prescriptions`
  ADD CONSTRAINT `prescriptions_ibfk_1` FOREIGN KEY (`consultation_id`) REFERENCES `consultations` (`consultation_id`);

--
-- Constraints for table `providers`
--
ALTER TABLE `providers`
  ADD CONSTRAINT `providers_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`);

--
-- Constraints for table `provider_details`
--
ALTER TABLE `provider_details`
  ADD CONSTRAINT `provider_details_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE;

--
-- Constraints for table `reminders`
--
ALTER TABLE `reminders`
  ADD CONSTRAINT `fk_reminders_user_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`),
  ADD CONSTRAINT `reminders_ibfk_1` FOREIGN KEY (`provider_id`) REFERENCES `providers` (`provider_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `reminders_ibfk_2` FOREIGN KEY (`student_id`) REFERENCES `students` (`student_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `students`
--
ALTER TABLE `students`
  ADD CONSTRAINT `students_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`);

--
-- Constraints for table `student_details`
--
ALTER TABLE `student_details`
  ADD CONSTRAINT `student_details_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
