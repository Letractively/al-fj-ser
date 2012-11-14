-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Servidor: localhost
-- Tiempo de generación: 14-11-2012 a las 03:22:55
-- Versión del servidor: 5.5.24-log
-- Versión de PHP: 5.4.3

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de datos: `centro_computo`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `administrador`
--

CREATE TABLE IF NOT EXISTS `administrador` (
  `Matricula_adm` int(4) NOT NULL,
  `Nombre` varchar(15) COLLATE utf8_spanish2_ci NOT NULL,
  `Password` varchar(25) COLLATE utf8_spanish2_ci NOT NULL,
  PRIMARY KEY (`Matricula_adm`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `alumnos`
--

CREATE TABLE IF NOT EXISTS `alumnos` (
  `Matricula` int(4) NOT NULL,
  `Nombre` varchar(15) COLLATE utf8_spanish2_ci NOT NULL,
  `Semestre` varchar(15) COLLATE utf8_spanish2_ci NOT NULL,
  `Materia` varchar(35) COLLATE utf8_spanish2_ci NOT NULL,
  `Periodo` varchar(20) COLLATE utf8_spanish2_ci NOT NULL,
  `Licenciatura` varchar(40) COLLATE utf8_spanish2_ci NOT NULL,
  PRIMARY KEY (`Matricula`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `computadoras`
--

CREATE TABLE IF NOT EXISTS `computadoras` (
  `id_computadora` int(4) NOT NULL,
  `id_sala` int(4) NOT NULL,
  `Marca` varchar(15) COLLATE utf8_spanish2_ci NOT NULL,
  PRIMARY KEY (`id_computadora`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estadisticas`
--

CREATE TABLE IF NOT EXISTS `estadisticas` (
  `Fecha` date NOT NULL,
  `Licenciatura` varchar(35) COLLATE utf8_spanish2_ci NOT NULL,
  `id_profesor` int(4) NOT NULL,
  `id_sala` int(4) NOT NULL,
  `Tiempo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `mantenimiento`
--

CREATE TABLE IF NOT EXISTS `mantenimiento` (
  `fecha` date NOT NULL,
  `Motivo` varchar(35) COLLATE utf8_spanish2_ci NOT NULL,
  `id_computadora` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `profesores`
--

CREATE TABLE IF NOT EXISTS `profesores` (
  `id_profesor` int(4) NOT NULL,
  `Materia` varchar(35) COLLATE utf8_spanish2_ci NOT NULL,
  `Horario` int(5) NOT NULL,
  PRIMARY KEY (`id_profesor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sala_computo`
--

CREATE TABLE IF NOT EXISTS `sala_computo` (
  `id_sala` int(4) NOT NULL,
  `Num_computadoras` int(3) NOT NULL,
  PRIMARY KEY (`id_sala`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `administrador`
--
ALTER TABLE `administrador`
  ADD CONSTRAINT `administrador_ibfk_1` FOREIGN KEY (`Matricula_adm`) REFERENCES `sala_computo` (`id_sala`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `alumnos`
--
ALTER TABLE `alumnos`
  ADD CONSTRAINT `alumnos_ibfk_1` FOREIGN KEY (`Matricula`) REFERENCES `sala_computo` (`id_sala`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `computadoras`
--
ALTER TABLE `computadoras`
  ADD CONSTRAINT `computadoras_ibfk_1` FOREIGN KEY (`id_computadora`) REFERENCES `sala_computo` (`id_sala`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `profesores`
--
ALTER TABLE `profesores`
  ADD CONSTRAINT `profesores_ibfk_1` FOREIGN KEY (`id_profesor`) REFERENCES `sala_computo` (`id_sala`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `sala_computo`
--
ALTER TABLE `sala_computo`
  ADD CONSTRAINT `sala_computo_ibfk_4` FOREIGN KEY (`id_sala`) REFERENCES `computadoras` (`id_computadora`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
