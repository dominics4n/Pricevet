-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 16-11-2024 a las 03:08:23
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `vetprice`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos`
--

CREATE TABLE `productos` (
  `ID_Productos` int(11) NOT NULL,
  `Nombre_Producto` varchar(100) DEFAULT 'a',
  `Proveedor_Producto` varchar(100) DEFAULT 'g',
  `Presentacion_Producto` varchar(100) DEFAULT 'c',
  `Precio_Publico` float DEFAULT 0,
  `Precio_Farmacia` float DEFAULT 0,
  `Descuento_Porcentaje` int(11) DEFAULT 0,
  `Existencias` int(11) DEFAULT 0,
  `proveedores_ID_Proveedores` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `productos`
--

INSERT INTO `productos` (`ID_Productos`, `Nombre_Producto`, `Proveedor_Producto`, `Presentacion_Producto`, `Precio_Publico`, `Precio_Farmacia`, `Descuento_Porcentaje`, `Existencias`, `proveedores_ID_Proveedores`) VALUES
(1, 'ABSORBINE LINIMENTO', 'FYNSA', '473 ML', 394, 276, NULL, 12, 1),
(5, 'ARENA FANCY CAT', 'FYNSA', '5 KG', 75, 60, NULL, 9, 1),
(6, 'BACK 2 NATURE ADULTO R.P.', 'FYNSA', '6 KG', 1223.5, 795, NULL, 5, 1),
(7, 'DOLOVET', 'KIRON', '20 TABS', 225, 180, NULL, 56, 3),
(8, 'EMICINA LIQUIDA', 'KIRON', '100 ML', 573, 459, NULL, 65, 3),
(9, 'ENZIMAX', 'KIRON', '(2 BLIST/ 10 COMP)', 497, 347, NULL, 58, 3),
(10, 'DOCARPINA', 'PISA', '100 mg', 2337, 1635, NULL, 12, 2),
(11, 'CARPROFENO', 'PISA', '25 mg', 1093, 765, NULL, 48, 2),
(12, 'PREDNISONA', 'PISA', '50 mg', 372, 261, NULL, 196, 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos_has_ventas_detalle`
--

CREATE TABLE `productos_has_ventas_detalle` (
  `productos_ID_Productos` int(11) NOT NULL,
  `Ventas_Detalle_ID_Ven_Detalle` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `productos_has_ventas_detalle`
--

INSERT INTO `productos_has_ventas_detalle` (`productos_ID_Productos`, `Ventas_Detalle_ID_Ven_Detalle`) VALUES
(1, 10),
(5, 9),
(9, 8),
(5, 7),
(10, 6),
(5, 5),
(5, 4),
(11, 3),
(10, 2),
(8, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedores`
--

CREATE TABLE `proveedores` (
  `ID_Proveedores` int(11) NOT NULL,
  `Nombre_Proveedor` varchar(100) NOT NULL,
  `Descripcion_Proveedor` text NOT NULL,
  `Sitio_Web` varchar(1000) NOT NULL,
  `Correo_Contacto` varchar(100) NOT NULL,
  `Telefono_Contacto` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `proveedores`
--

INSERT INTO `proveedores` (`ID_Proveedores`, `Nombre_Proveedor`, `Descripcion_Proveedor`, `Sitio_Web`, `Correo_Contacto`, `Telefono_Contacto`) VALUES
(1, 'FYNSA', 'FYNSA S.A. DE C.V.\nUn universo de productos para el mundo animal.\nCon más de 50 años en el mercado nos hemos consolidado como una de las principales compañías distribuidoras de productos para la industria veterinaria, tanto en el área metropolitana, como en las principales ciudades del interior de la República Mexicana.\n\n«La gama de productos más completa para la alimentación, salud e higiene de pequeñas y grandes especies.»', 'https://fynsa.mx/', 'hola@fynsa.mx / atencion@fynsa.mx', '5557697500 / 5557149400 / 5557149310\r\n5557143648 / 5557690994 / 8002239672'),
(2, 'PiSA', 'PiSA Salud Animal\r\nPor 3 décadas y gracias a los profesionales de la salud animal, en PiSA Salud Animal hemos ofrecido soluciones veterinarias con estándares que satisfacen la necesidades de nuestros clientes más exigentes.\r\n\r\nTrabajamos muy de cerca de los productores y médicos veterinarios\r\na quienes escuchamos y asesoramos para mejorar la salud de sus animales y para hacerlos más productivos, por medio de expertos que los apoyan en los servicios de valor agregado.', 'https://pisasaludanimal.com.mx/', 'saludanimal@pisa.com.mx', '800 8327 266'),
(3, 'Kiron', 'Laboratorios Kirón México es una empresa farmacéutica veterinaria que nace con la filosofía de mejorar la calidad de vida de los animales y de sus propietarios, ofreciendo productos innovadores y de calidad con responsabilidad.', 'https://kironmexico.com/', 'esantiago@kironmexico.com', '55 5743 3839');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventas_cuenta`
--

CREATE TABLE `ventas_cuenta` (
  `ID_Cuenta` int(11) NOT NULL,
  `Total` float DEFAULT NULL,
  `Fecha` date DEFAULT current_timestamp(),
  `Forma_Pago` varchar(100) DEFAULT 'Efectivo'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `ventas_cuenta`
--

INSERT INTO `ventas_cuenta` (`ID_Cuenta`, `Total`, `Fecha`, `Forma_Pago`) VALUES
(1, 5000, '2024-10-26', 'Efectivo'),
(2, 1980, '2024-10-26', 'Tarjeta'),
(3, 9999, '2024-10-26', 'Tarjeta'),
(4, 45, '2024-11-15', 'Efectivo'),
(5, 455, '2024-11-15', 'Tarjeta');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventas_detalle`
--

CREATE TABLE `ventas_detalle` (
  `ID_Ven_Detalle` int(11) NOT NULL,
  `Producto` varchar(100) DEFAULT NULL,
  `Cantidad` int(11) DEFAULT 1,
  `Precio_Individual` float DEFAULT NULL,
  `Precio_Total` float DEFAULT NULL,
  `Descuento_Total` float DEFAULT NULL,
  `Ventas_Cuenta_ID_Cuenta` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `ventas_detalle`
--

INSERT INTO `ventas_detalle` (`ID_Ven_Detalle`, `Producto`, `Cantidad`, `Precio_Individual`, `Precio_Total`, `Descuento_Total`, `Ventas_Cuenta_ID_Cuenta`) VALUES
(1, 'Productos1', 5, 24, 120, NULL, 1),
(2, 'Mas productos', 42, 10, 420, NULL, 1),
(3, 'Triple cosas', 12, 20, 240, NULL, 1),
(4, 'Cosas caras', 3, 1000, 3000, NULL, 2),
(5, 'Mas cosas caras', 4, 2000, 8000, NULL, 1),
(6, 'Tacos', 2, 10, 20, NULL, 3),
(7, 'pepsi', 1, 15, 15, NULL, 3),
(8, 'Tortas', 100, 50, 5000, NULL, 3),
(9, 'Servilleta', 1, 0.5, 0.5, NULL, 3),
(10, 'Cosas triplecaras', 100, 200, 20000, NULL, 2);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `productos`
--
ALTER TABLE `productos`
  ADD PRIMARY KEY (`ID_Productos`),
  ADD KEY `fk_productos_proveedores_idx` (`proveedores_ID_Proveedores`);

--
-- Indices de la tabla `productos_has_ventas_detalle`
--
ALTER TABLE `productos_has_ventas_detalle`
  ADD KEY `fk_productos_has_Ventas_Detalle_productos1_idx` (`productos_ID_Productos`),
  ADD KEY `fk_productos_has_Ventas_Detalle_Ventas_Detalle1_idx` (`Ventas_Detalle_ID_Ven_Detalle`);

--
-- Indices de la tabla `proveedores`
--
ALTER TABLE `proveedores`
  ADD PRIMARY KEY (`ID_Proveedores`);

--
-- Indices de la tabla `ventas_cuenta`
--
ALTER TABLE `ventas_cuenta`
  ADD PRIMARY KEY (`ID_Cuenta`);

--
-- Indices de la tabla `ventas_detalle`
--
ALTER TABLE `ventas_detalle`
  ADD PRIMARY KEY (`ID_Ven_Detalle`),
  ADD KEY `fk_Ventas_Detalle_Ventas_Cuenta1_idx` (`Ventas_Cuenta_ID_Cuenta`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `productos`
--
ALTER TABLE `productos`
  MODIFY `ID_Productos` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de la tabla `ventas_cuenta`
--
ALTER TABLE `ventas_cuenta`
  MODIFY `ID_Cuenta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `ventas_detalle`
--
ALTER TABLE `ventas_detalle`
  MODIFY `ID_Ven_Detalle` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `productos`
--
ALTER TABLE `productos`
  ADD CONSTRAINT `fk_productos_proveedores` FOREIGN KEY (`proveedores_ID_Proveedores`) REFERENCES `proveedores` (`ID_Proveedores`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `productos_has_ventas_detalle`
--
ALTER TABLE `productos_has_ventas_detalle`
  ADD CONSTRAINT `fk_productos_has_Ventas_Detalle_Ventas_Detalle1` FOREIGN KEY (`Ventas_Detalle_ID_Ven_Detalle`) REFERENCES `ventas_detalle` (`ID_Ven_Detalle`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_productos_has_Ventas_Detalle_productos1` FOREIGN KEY (`productos_ID_Productos`) REFERENCES `productos` (`ID_Productos`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `ventas_detalle`
--
ALTER TABLE `ventas_detalle`
  ADD CONSTRAINT `fk_Ventas_Detalle_Ventas_Cuenta1` FOREIGN KEY (`Ventas_Cuenta_ID_Cuenta`) REFERENCES `ventas_cuenta` (`ID_Cuenta`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
