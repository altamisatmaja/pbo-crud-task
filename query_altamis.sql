create table penjual_laptop (
	id_penjual int primary key,
	nama_laptop varchar(20),
	harga_satuan int,
	stok_laptop int
);

create table pembeli_laptop (
	id_pembeli int primary key,
	nama_pembeli varchar(20),
	laptop_dibeli varchar(20),
	harga_laptop int,
	stok_laptop_dibeli int
);

select penjual_laptop.id_penjual, penjual_laptop.nama_laptop, penjual_laptop.harga_satuan, penjual_laptop.stok_laptop, pembeli_laptop.id_pembeli, pembeli_laptop.nama_pembeli, pembeli_laptop.laptop_dibeli, pembeli_laptop.harga_laptop, pembeli_laptop.stok_laptop_dibeli from penjual_laptop inner join pembeli_laptop on penjual_laptop.nama_laptop = pembeli_laptop.laptop_dibeli;
