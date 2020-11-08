-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 31 Okt 2020 pada 07.10
-- Versi server: 10.4.13-MariaDB
-- Versi PHP: 7.4.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_tokoe`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_barang`
--

CREATE TABLE `tb_barang` (
  `id` varchar(20) NOT NULL,
  `nama` varchar(40) NOT NULL,
  `harga` int(11) NOT NULL,
  `merk` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `tb_barang`
--

INSERT INTO `tb_barang` (`id`, `nama`, `harga`, `merk`) VALUES
('BR-2020080', 'Gamis', 45000, 'Baju'),
('BR-202008071128', 'Jeans', 80000, 'Celana'),
('BR-20200807137', 'Cadar', 35000, 'Baju'),
('BR-20200808953', 'Jeans New', 50000, 'Celana');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_transaksi`
--

CREATE TABLE `tb_transaksi` (
  `no_nota` varchar(25) NOT NULL,
  `id` varchar(20) NOT NULL,
  `pembeli` varchar(30) NOT NULL,
  `nama` varchar(30) NOT NULL,
  `harga` int(11) NOT NULL,
  `tgl` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `tb_transaksi`
--

INSERT INTO `tb_transaksi` (`no_nota`, `id`, `pembeli`, `nama`, `harga`, `tgl`) VALUES
('NO-202008071019', 'BR-20200807137', 'no name', 'Gamis New', 50000, '2020-08-06'),
('NO-202008071025', 'BR-2020080', 'no name', 'Gamis', 45000, '2020-08-07'),
('NO-202008071042', 'BR-2008070', 'no name', 'Jilbab', 25000, '2020-08-07'),
('NO-202008071047', 'BR-20200807137', 'no name', 'Gamis New', 50000, '2020-08-07'),
('NO-202008071054', 'BR-20200807137', 'no name', 'Gamis New', 50000, '2020-08-07'),
('NO-202008071139', 'BR-2008070', 'no name', 'Jilbab', 25000, '2020-08-07'),
('NO-202008071143', 'BR-202008071128', 'no name', 'Jeans', 80000, '2020-08-07'),
('NO-20200807814', 'BR-2008070', 'Sandi', 'Jilbab', 25000, '2020-08-07'),
('NO-20200807822', 'BR-20200807137', 'Budi', 'Gamis New', 50000, '2020-08-07'),
('NO-20200807823', 'BR-2020080', 'no name', 'Gamis', 45000, '2020-08-07'),
('NO-2020080783', 'BR-2020080', 'Sandi', 'Gamis', 45000, '2020-08-07'),
('NO-20200807832', 'BR-2008070', 'Budi', 'Jilbab', 25000, '2020-08-07'),
('NO-20200807835', 'BR-20200807137', 'Sandi', 'Gamis New', 50000, '2020-08-07'),
('NO-20200807846', 'BR-2008070', 'no name', 'Jilbab', 25000, '2020-08-07'),
('NO-20200807847', 'BR-2008070', 'Sandi', 'Jilbab', 25000, '2020-08-07'),
('NO-202008081012', 'BR-202008071128', 'Sandi', 'Jeans', 80000, '2020-08-08'),
('NO-202008081030', 'BR-20200808953', 'Abrian', 'Jeans New', 50000, '2020-08-08'),
('NO-20200808104', 'BR-20200807137', 'Iqbal', 'Cadar', 35000, '2020-08-08'),
('NO-202008081043', 'BR-2020080', 'Abrian', 'Gamis', 45000, '2020-08-08'),
('NO-202008081049', 'BR-20200807137', 'Abrian', 'Cadar', 35000, '2020-08-08'),
('NO-202008081053', 'BR-20200808953', 'Iqbal', 'Jeans New', 50000, '2020-08-08'),
('NO-20200808108', 'BR-20200808953', 'Abrian', 'Jeans New', 50000, '2020-08-08'),
('NO-202008081131', 'BR-202008071128', 'Mesi', 'Jeans', 80000, '2020-08-08'),
('NO-202008081147', 'BR-20200807137', 'Mesi', 'Cadar', 35000, '2020-08-08'),
('NO-202008081158', 'BR-2020080', 'Nana', 'Gamis', 45000, '2020-08-08'),
('NO-20200808119', 'BR-202008071128', 'Imam', 'Jeans', 80000, '2020-08-08'),
('NO-2020080890', 'BR-20200808953', 'Suadi', 'Jeans New', 50000, '2020-08-08'),
('NO-20200808922', 'BR-20200808953', 'Suadi', 'Jeans New', 50000, '2020-08-08'),
('NO-20200808936', 'BR-20200807137', 'Suadi', 'Cadar', 35000, '2020-08-08'),
('NO-20200928825', 'BR-20200807137', 'no name', 'Cadar', 35000, '2020-09-28'),
('NO-2020092886', 'BR-202008071128', 'budi', 'Jeans', 80000, '2020-09-28'),
('NO-20201005844', 'BR-202008071128', 'yong', 'Jeans', 80000, '2020-10-05'),
('NO-202010201036', 'BR-20200807137', 'no name', 'Cadar', 35000, '2020-10-20'),
('NO-20201020107', 'BR-20200807137', 'no name', 'Cadar', 35000, '2020-10-20');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_transaksi_dtl`
--

CREATE TABLE `tb_transaksi_dtl` (
  `id_transaksi` int(11) NOT NULL,
  `no_nota` varchar(20) NOT NULL,
  `id` varchar(20) NOT NULL,
  `pembeli` varchar(30) NOT NULL,
  `nama` varchar(30) NOT NULL,
  `harga` int(11) NOT NULL,
  `qty` int(11) NOT NULL,
  `total_harga` int(11) NOT NULL,
  `tgl` date NOT NULL,
  `kembalian` int(11) NOT NULL,
  `uang` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `tb_transaksi_dtl`
--

INSERT INTO `tb_transaksi_dtl` (`id_transaksi`, `no_nota`, `id`, `pembeli`, `nama`, `harga`, `qty`, `total_harga`, `tgl`, `kembalian`, `uang`) VALUES
(5, 'NO-20200807853', 'BR-20200807137', 'Sandi', 'Gamis New', 50000, 2, 100000, '2020-08-07', 25000, 0),
(6, 'NO-20200807853', 'BR-2008070', 'Sandi', 'Jilbab', 25000, 3, 75000, '2020-08-07', 25000, 0),
(7, 'NO-202008071031', 'BR-20200807137', 'no name', 'Gamis New', 50000, 1, 50000, '2020-08-06', 0, 0),
(8, 'NO-202008071033', 'BR-2020080', 'no name', 'Gamis', 45000, 1, 45000, '2020-08-07', 5000, 0),
(9, 'NO-202008071048', 'BR-2008070', 'no name', 'Jilbab', 25000, 4, 100000, '2020-08-07', 0, 0),
(10, 'NO-202008071054', 'BR-20200807137', 'no name', 'Gamis New', 50000, 1, 50000, '2020-08-07', 0, 0),
(11, 'NO-202008071011', 'BR-20200807137', 'no name', 'Gamis New', 50000, 1, 50000, '2020-08-07', 0, 0),
(12, 'NO-202008071144', 'BR-2008070', 'no name', 'Jilbab', 25000, 2, 50000, '2020-08-07', 0, 0),
(13, 'NO-202008071153', 'BR-202008071128', 'no name', 'Jeans', 80000, 1, 80000, '2020-08-07', 20000, 0),
(14, 'NO-20200808131', 'BR-202008071128', 'Imam', 'Jeans', 80000, 1, 80000, '2020-08-08', 20000, 0),
(15, 'NO-20200808910', 'BR-20200808953', 'Suadi', 'Jeans New', 50000, 1, 50000, '2020-08-08', 0, 0),
(16, 'NO-202008081011', 'BR-20200808953', 'Iqbal', 'Jeans New', 50000, 2, 100000, '2020-08-08', 0, 0),
(17, 'NO-202008081054', 'BR-20200808953', 'Abrian', 'Jeans New', 50000, 1, 50000, '2020-08-08', 35000, 200000),
(18, 'NO-202008081054', 'BR-2020080', 'Abrian', 'Gamis', 45000, 1, 45000, '2020-08-08', 35000, 200000),
(19, 'NO-202008081054', 'BR-20200807137', 'Abrian', 'Cadar', 35000, 2, 70000, '2020-08-08', 35000, 200000),
(20, 'NO-20200808105', 'BR-20200808953', 'Abrian', 'Jeans New', 50000, 1, 50000, '2020-08-08', 0, 50000),
(21, 'NO-202008081020', 'BR-20200807137', 'Iqbal', 'Cadar', 35000, 2, 70000, '2020-08-08', 10000, 80000),
(22, 'NO-202008081043', 'BR-202008071128', 'Sandi', 'Jeans', 80000, 1, 80000, '2020-08-08', 20000, 100000),
(23, 'NO-202008081122', 'BR-2020080', 'Nana', 'Gamis', 45000, 1, 45000, '2020-08-08', 5000, 50000),
(24, 'NO-202008081153', 'BR-202008071128', 'Mesi', 'Jeans', 80000, 2, 160000, '2020-08-08', 5000, 200000),
(25, 'NO-202008081153', 'BR-20200807137', 'Mesi', 'Cadar', 35000, 1, 35000, '2020-08-08', 5000, 200000),
(26, 'NO-20200928836', 'BR-20200807137', 'no name', 'Cadar', 35000, 2, 70000, '2020-09-28', 30000, 100000),
(27, 'NO-2020092884', 'BR-202008071128', 'budi', 'Jeans', 80000, 2, 160000, '2020-09-28', 40000, 200000),
(28, 'NO-2020100581', 'BR-202008071128', 'yong', 'Jeans', 80000, 2, 160000, '2020-10-05', 40000, 200000),
(29, 'NO-202010201049', 'BR-20200807137', 'no name', 'Cadar', 35000, 1, 35000, '2020-10-20', 15000, 50000),
(30, 'NO-202010201022', 'BR-20200807137', 'no name', 'Cadar', 35000, 1, 35000, '2020-10-20', 15000, 50000);

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `tb_barang`
--
ALTER TABLE `tb_barang`
  ADD PRIMARY KEY (`id`);

--
-- Indeks untuk tabel `tb_transaksi`
--
ALTER TABLE `tb_transaksi`
  ADD PRIMARY KEY (`no_nota`);

--
-- Indeks untuk tabel `tb_transaksi_dtl`
--
ALTER TABLE `tb_transaksi_dtl`
  ADD PRIMARY KEY (`id_transaksi`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `tb_transaksi_dtl`
--
ALTER TABLE `tb_transaksi_dtl`
  MODIFY `id_transaksi` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
