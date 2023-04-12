-- phpMyAdmin SQL Dump
-- version 4.9.4
-- https://www.phpmyadmin.net/
--
-- Počítač: localhost
-- Vytvořeno: Úte 14. úno 2023, 13:45
-- Verze serveru: 10.3.25-MariaDB-0+deb10u1
-- Verze PHP: 5.6.36-0+deb8u1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databáze: `4c2_grisadaniel_db1`
--

-- --------------------------------------------------------

--
-- Struktura tabulky `Admins`
--

CREATE TABLE `Admins` (
  `id` int(11) NOT NULL,
  `username` varchar(255) COLLATE utf8_czech_ci NOT NULL,
  `password` varchar(255) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Admins`
--

INSERT INTO `Admins` (`id`, `username`, `password`) VALUES
(1, 'admin', 'admin');

-- --------------------------------------------------------

--
-- Struktura tabulky `Categories`
--

CREATE TABLE `Categories` (
  `id` int(11) NOT NULL,
  `name` varchar(255) COLLATE utf8_czech_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Categories`
--

INSERT INTO `Categories` (`id`, `name`) VALUES
(3, 'Pánské'),
(4, 'Dámské');

-- --------------------------------------------------------

--
-- Struktura tabulky `Colors`
--

CREATE TABLE `Colors` (
  `id` int(11) NOT NULL,
  `color` varchar(255) COLLATE utf8_czech_ci NOT NULL,
  `hex` varchar(255) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Colors`
--

INSERT INTO `Colors` (`id`, `color`, `hex`) VALUES
(2, 'žlutá', '#F1DC3E'),
(3, 'černá', '#A020F0'),
(4, 'modrá', '#0000FF');

-- --------------------------------------------------------

--
-- Struktura tabulky `Images`
--

CREATE TABLE `Images` (
  `id` int(11) NOT NULL,
  `product_id` int(11) DEFAULT NULL,
  `path` varchar(255) COLLATE utf8_czech_ci DEFAULT NULL,
  `priority` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Images`
--

INSERT INTO `Images` (`id`, `product_id`, `path`, `priority`) VALUES
(22, 4, '\\images\\products\\fd42ae17-9ee6-44f1-b6ee-4d04b0176c94.webp', 2),
(23, 4, '\\images\\products\\12d2f563-504a-419d-8f1d-8cc03bc225f3.webp', 2),
(24, 4, '\\images\\products\\a42179b6-f276-43fa-b7ce-91479feaa689.webp', 2),
(25, 4, '\\images\\products\\855dbb0b-e3cc-4aa1-9ec0-79e120f9166d.webp', 1),
(26, 5, '\\images\\products\\a8fb6841-821d-46ce-ba4f-4ec1546faf1e.webp', 2),
(27, 5, '\\images\\products\\234df1f5-936e-4e59-aff1-d3f19ee4efa0.jpg', 2),
(28, 5, '\\images\\products\\e92a9121-33e2-4d01-933f-d6e2617296bd.jpg', 1),
(29, 6, '\\images\\products\\18de922f-0a88-49a2-8089-1c7375adca3b.jpg', 2),
(30, 6, '\\images\\products\\ffd4b8a8-6481-45eb-a324-06af9d1141d1.webp', 2),
(31, 6, '\\images\\products\\13392a9d-3f18-4336-a5fa-7f767ad37772.webp', 2),
(32, 6, '\\images\\products\\35d7e9dc-8329-43b1-9dbc-fe1ae6e512f1.webp', 1),
(33, 7, '\\images\\products\\013823c6-1c08-4a6d-a584-9b3d11bf59b2.png', 2),
(34, 7, '\\images\\products\\52c79354-21eb-49c3-b01a-96d07393f65b.png', 2),
(35, 7, '\\images\\products\\c3a7185c-6248-479a-98cc-30a06d48b3eb.png', 2),
(36, 7, '\\images\\products\\65929c96-aa1d-419a-ad2d-0ef9acb9d551.png', 1),
(37, 8, '\\images\\products\\613b4ae6-c96e-4e34-8109-f3db5e0bd977.jpg', 2),
(38, 8, '\\images\\products\\448b39a8-89fe-4655-99a1-ba1b7427f2e6.jpg', 2),
(39, 8, '\\images\\products\\23143df0-f579-4639-af93-2e9d50252368.jpg', 2),
(40, 8, '\\images\\products\\565ddf23-5291-48f4-ad84-cfe1ad22231d.jpg', 1);

-- --------------------------------------------------------

--
-- Struktura tabulky `Orders`
--

CREATE TABLE `Orders` (
  `id` int(11) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `status` varchar(255) COLLATE utf8_czech_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Orders`
--

INSERT INTO `Orders` (`id`, `user_id`, `status`) VALUES
(11, 11, 'zpracovávání'),
(12, 12, 'Hotovo');

-- --------------------------------------------------------

--
-- Struktura tabulky `OrdersItems`
--

CREATE TABLE `OrdersItems` (
  `id` int(11) NOT NULL,
  `order_id` int(11) DEFAULT NULL,
  `totalProduct_id` int(11) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `unitPrice` decimal(10,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `OrdersItems`
--

INSERT INTO `OrdersItems` (`id`, `order_id`, `totalProduct_id`, `quantity`, `unitPrice`) VALUES
(4, 11, 16, 2, 1550),
(5, 11, 12, 1, 1700),
(6, 12, 15, 3, 1550),
(7, 12, 13, 2, 1700);

-- --------------------------------------------------------

--
-- Struktura tabulky `Products`
--

CREATE TABLE `Products` (
  `id` int(11) NOT NULL,
  `name` varchar(255) COLLATE utf8_czech_ci DEFAULT NULL,
  `desc` text COLLATE utf8_czech_ci DEFAULT NULL,
  `SKU` varchar(255) COLLATE utf8_czech_ci DEFAULT NULL,
  `price` decimal(10,0) DEFAULT NULL,
  `category_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Products`
--

INSERT INTO `Products` (`id`, `name`, `desc`, `SKU`, `price`, `category_id`) VALUES
(4, 'Jordan', 'Kultovní střih, nejlepší jakost, nadčasová barva - Air Jordan 1 Mid SE mají vše, co potřebujete. Charakteristický nízký svršek je vyroben z měkké a odolné přírodní kůže. Polstrovaný límec a šněrování odpovědně stabilizuje nohu. Osvědčený systém AIR odpovídá za odpružení na různorodém povrchu, zatímco gumový dezén tvoří dokonalou přilnavost', '45654465', 1200, 3),
(5, 'Jordan X', 'Už jsou to čtyři dekády, co tenisky Nike Dunk spatřily poprvé světlo světa. Zprvu pomáhaly legendárním basketbalistům ovládnout prostor mezi dvěma koši a později svoji auru úspěchu přenesly také do ulic. Jde o jedny z tenisek Nike, které se dočkaly vůbec nejvíce variant úp', '56484655', 1700, 4),
(6, 'Nike Terminator', 'Kůže: je snad tím nejlepším materiálem k výrobě obuvi – udržuje si tvar, je prodyšná a tím výčet jejích pozitivních vlastností ani zdaleka nekončí.', '456564556', 1550, 3),
(7, 'Air Force', 'Kotníkové tenisky od značky Nike s názvem W Air Force 1 High SE v zeleném provedení s bílými logy a podrážkou.', '54658456', 1250, 3),
(8, 'Jordan 1', 'Jordan Brand představuje model Air Jordan 1 v mimořádně oblíbené verzi Zoom CMFT . Svršek barevného provedení \"Neutral Olive\" je vyroben z vysoce kvalitní kůže a semiše a celé barevné provedení je podzimní barevná kombinace oscilující kolem bílé a olivově zelené. Logo Nike vyříznuté do materiálu je vyrobeno z kaštanového materiálu, díky kterému vyniká nad ostatními. Vše bylo osazeno na klasické bílé podrážce s oranžovou spodní stranou.', '4564554656', 2500, 3);

-- --------------------------------------------------------

--
-- Struktura tabulky `Sizes`
--

CREATE TABLE `Sizes` (
  `id` int(11) NOT NULL,
  `size` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Sizes`
--

INSERT INTO `Sizes` (`id`, `size`) VALUES
(7, 41),
(8, 42),
(9, 43);

-- --------------------------------------------------------

--
-- Struktura tabulky `TotalProduct`
--

CREATE TABLE `TotalProduct` (
  `id` int(11) NOT NULL,
  `product_id` int(11) DEFAULT NULL,
  `color_id` int(11) DEFAULT NULL,
  `size_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `TotalProduct`
--

INSERT INTO `TotalProduct` (`id`, `product_id`, `color_id`, `size_id`) VALUES
(10, 4, 3, 7),
(11, 4, 2, 9),
(12, 5, 2, 7),
(13, 5, 2, 8),
(14, 5, 2, 9),
(15, 6, 3, 8),
(16, 6, 4, 7),
(17, 7, 2, 7),
(18, 8, 2, 9),
(19, 8, 3, 7);

-- --------------------------------------------------------

--
-- Struktura tabulky `Users`
--

CREATE TABLE `Users` (
  `id` int(11) NOT NULL,
  `name` varchar(255) COLLATE utf8_czech_ci DEFAULT NULL,
  `surname` varchar(255) COLLATE utf8_czech_ci DEFAULT NULL,
  `telephone` int(11) DEFAULT NULL,
  `datumZalozeniUctu` datetime DEFAULT NULL,
  `address1` varchar(255) COLLATE utf8_czech_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Users`
--

INSERT INTO `Users` (`id`, `name`, `surname`, `telephone`, `datumZalozeniUctu`, `address1`) VALUES
(1, 'dsa', 'das', 5, NULL, '1'),
(8, 'dsa', 'das', 20, NULL, '1'),
(9, 'xx', 'aa', 4450, NULL, '1'),
(11, 'Pepa', 'Nový', 556456454, NULL, '1'),
(12, 'Pepik', 'Novotny', 5564156, NULL, '1');

--
-- Klíče pro exportované tabulky
--

--
-- Klíče pro tabulku `Admins`
--
ALTER TABLE `Admins`
  ADD PRIMARY KEY (`id`);

--
-- Klíče pro tabulku `Categories`
--
ALTER TABLE `Categories`
  ADD PRIMARY KEY (`id`);

--
-- Klíče pro tabulku `Colors`
--
ALTER TABLE `Colors`
  ADD PRIMARY KEY (`id`);

--
-- Klíče pro tabulku `Images`
--
ALTER TABLE `Images`
  ADD PRIMARY KEY (`id`),
  ADD KEY `product_id` (`product_id`);

--
-- Klíče pro tabulku `Orders`
--
ALTER TABLE `Orders`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Orders_ibfk_1` (`user_id`);

--
-- Klíče pro tabulku `OrdersItems`
--
ALTER TABLE `OrdersItems`
  ADD PRIMARY KEY (`id`),
  ADD KEY `totalProduct_id` (`totalProduct_id`),
  ADD KEY `OrdersItems_ibfk_1` (`order_id`);

--
-- Klíče pro tabulku `Products`
--
ALTER TABLE `Products`
  ADD PRIMARY KEY (`id`),
  ADD KEY `category_id` (`category_id`);

--
-- Klíče pro tabulku `Sizes`
--
ALTER TABLE `Sizes`
  ADD PRIMARY KEY (`id`);

--
-- Klíče pro tabulku `TotalProduct`
--
ALTER TABLE `TotalProduct`
  ADD PRIMARY KEY (`id`),
  ADD KEY `product_id` (`product_id`),
  ADD KEY `color_id` (`color_id`),
  ADD KEY `size_id` (`size_id`);

--
-- Klíče pro tabulku `Users`
--
ALTER TABLE `Users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT pro tabulky
--

--
-- AUTO_INCREMENT pro tabulku `Admins`
--
ALTER TABLE `Admins`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pro tabulku `Categories`
--
ALTER TABLE `Categories`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT pro tabulku `Colors`
--
ALTER TABLE `Colors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT pro tabulku `Images`
--
ALTER TABLE `Images`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT pro tabulku `Orders`
--
ALTER TABLE `Orders`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT pro tabulku `OrdersItems`
--
ALTER TABLE `OrdersItems`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT pro tabulku `Products`
--
ALTER TABLE `Products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT pro tabulku `Sizes`
--
ALTER TABLE `Sizes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT pro tabulku `TotalProduct`
--
ALTER TABLE `TotalProduct`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT pro tabulku `Users`
--
ALTER TABLE `Users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Omezení pro exportované tabulky
--

--
-- Omezení pro tabulku `Images`
--
ALTER TABLE `Images`
  ADD CONSTRAINT `Images_ibfk_1` FOREIGN KEY (`product_id`) REFERENCES `Products` (`id`);

--
-- Omezení pro tabulku `Orders`
--
ALTER TABLE `Orders`
  ADD CONSTRAINT `Orders_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `Users` (`id`) ON DELETE CASCADE;

--
-- Omezení pro tabulku `OrdersItems`
--
ALTER TABLE `OrdersItems`
  ADD CONSTRAINT `OrdersItems_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `Orders` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `OrdersItems_ibfk_2` FOREIGN KEY (`totalProduct_id`) REFERENCES `TotalProduct` (`id`);

--
-- Omezení pro tabulku `Products`
--
ALTER TABLE `Products`
  ADD CONSTRAINT `Products_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `Categories` (`id`);

--
-- Omezení pro tabulku `TotalProduct`
--
ALTER TABLE `TotalProduct`
  ADD CONSTRAINT `TotalProduct_ibfk_1` FOREIGN KEY (`product_id`) REFERENCES `Products` (`id`),
  ADD CONSTRAINT `TotalProduct_ibfk_2` FOREIGN KEY (`color_id`) REFERENCES `Colors` (`id`),
  ADD CONSTRAINT `TotalProduct_ibfk_3` FOREIGN KEY (`size_id`) REFERENCES `Sizes` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
