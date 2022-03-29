use master
go
create database QLHangHoa
go
use QLHangHoa
Go
Create table HangHoa(
	MaHang int identity primary key,
	TenHang nvarchar(50) not null,
	Thue int not null check(Thue>0),
	Gianhap float not null check(Gianhap>0),
	Giaban float not null check(Giaban>0),
	Theloai nvarchar(30) not null,
	Soluonghientai int check(Soluonghientai>0)
)