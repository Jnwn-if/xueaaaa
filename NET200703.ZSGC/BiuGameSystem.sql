use master
go

if exists (select * from sys.databases where name ='bgDB')
	drop database bgDB
go

create database bgDB
go

use bgDB
go

--游戏分类表

create table GType
(
	id int primary key identity(1,1),--游戏分类ID
	name varchar(128) not null--分类名称 
)
go

--游戏厂商表
create table Studio
(
	id int primary key identity(1,1),--游戏厂商id
	sName varchar(64) not null,--厂家名称
	sTel varchar(64) not null--联系方式
)
go
--游戏库表
create table Game
(
	id int primary key identity(1,1),--游戏id
	gTid int references GType(id) not null,--游戏分类
	gSId int references Studio(id) not null,--游戏厂商
	gName varchar(128) not null,--游戏名称
	gPrice float not null,--游戏价格
	gState bit default(0) not null,--游戏上架状态 0代表已上架 1代表已下架
)
go
--用户信息表
create table Userinfo
(
	id int primary key identity(1,1),--用户id
	userName varchar(64) not null,--账号名
	userPwd varchar(64) not null,--密码
	uBalance float default(0) not null--余额
)
go
--订单明细表
create table Gorder
(
	id int primary key identity(1,1),--订单id
	oUid int references Userinfo(id) not null,--购买用户
	oGid int references Game(id) not null,--购买游戏
	oTime datetime not null--订单日期
)
go
--用户游戏库表
create table library
(
	id int primary key identity(1,1),--游戏库id
	lCollection bit default(0) not null,--是否在收藏夹，0表示不在收藏夹，1表示在收藏夹
	lhide bit default(0) not null,--是否将该游戏隐藏， 0表示显示，1表示隐藏
)
go
--游戏评论表
create table comment
(
	id int primary key identity(1,1),--评论id
	cgid int references Game(id) not null,--评论游戏
	cUid int references Userinfo(id) not null,--评论用户
	cment varchar(512) not null,--评论
	cTime datetime not null--评论时间
)
go
--管理员表
create table administrators
(
	id int primary key identity(1,1),--管理员id
	aName varchar(64) not null,--账户名
	aPwd varchar(64) not null--密码
)
go

--中间库
create table Userlibrary
(
	gid int references library(id) not null,--游戏
	[Uid] int references Userinfo(id) not null,--用户
	primary key(gid,[Uid])
)
go

insert into GType values ('动作类')
insert into GType values ('竞技类')
insert into GType values ('冒险类')
insert into GType values ('休闲类')
insert into GType values ('恐怖类')
insert into GType values ('射击类')
insert into GType values ('养成类')
insert into GType values ('体育类')
insert into GType values ('音乐类')
insert into GType values ('卡牌类')
go

insert into Studio values ('CAPCOM','+01 1**********')
insert into Studio values ('CDPROJEKT','+01 1**********')
insert into Studio values ('UBISOFT','+01 1**********')
insert into Studio values ('ROCKSTAR','+01 1**********')
insert into Studio values ('Naughty Dog','+01 1**********')
insert into Studio values ('gameloft','+01 1**********')
insert into Studio values ('microsoft','+01 1**********')
insert into Studio values ('activision','+01 1**********')
insert into Studio values ('blizzard','+01 1**********')
insert into Studio values ('Riot Games','+01 1**********')
go

insert into Game values (5,1,'生化危机',198,default)
insert into Game values (5,1,'生化危机2',198,default)
insert into Game values (3,2,'赛博朋克2077',198,default)
insert into Game values (3,2,'巫师3',198,default)
insert into Game values (6,3,'彩虹六号-围攻',198,default)
insert into Game values (3,3,'刺客信条奥德赛',198,default)
insert into Game values (4,4,'侠盗猎车手圣安地列斯',198,default)
insert into Game values (4,4,'侠盗猎车5',198,default)
insert into Game values (3,5,'神秘海域4',198,default)
insert into Game values (3,5,'最后生还者',198,default)
insert into Game values (4,6,'神偷奶爸：小黄人快跑',198,default)
insert into Game values (8,6,'狂野飙车8:极速凌云',198,default)
insert into Game values (2,7,'帝国时代3：民族的崛起',198,default)
insert into Game values (6,7,'战争机器4',198,default)
insert into Game values (6,8,'使命召唤:黑色行动4',198,default)
insert into Game values (1,8,'虐杀原形',198,default)
insert into Game values (2,9,'星际争霸',198,default)
insert into Game values (7,9,'魔兽世界',198,default)
insert into Game values (2,10,'英雄联盟',198,default)
insert into Game values (2,10,'符文大地传奇',198,1)
go

insert into Userinfo values ('user1','123',default)
insert into Userinfo values ('user2','123',default)
insert into Userinfo values ('user3','123',default)
insert into Userinfo values ('user4','123',default)
insert into Userinfo values ('user5','123',default)
go
--订单
insert into Gorder values (1,1,GETDATE())
insert into Gorder values (1,2,GETDATE())
insert into Gorder values (2,1,GETDATE())
insert into Gorder values (2,2,GETDATE())
--用户库
insert into library values (default,default)
go

insert into comment values (1,1,'真不辍',GETDATE())
go

insert into administrators values ('admin','123')
insert into administrators values ('admin2','123')
go

insert into  Userlibrary values (1,1)
go

select * from GType
select * from Studio
select * from Game
select * from Userinfo
select * from Gorder
select * from library
select * from administrators
select * from comment
select * from Userlibrary
go

select Studio.sName,GType.name,Game.* from Game,GType,Studio where Game.gTid=GType.id and Game.gSId=Studio.id 
select Studio.sName,GType.name,Game.* from Game,GType,Studio	
select Studio.sName,name,Game.* from Game,GType,Studio where Game.gTid=GType.id and Game.gSId=Studio.id and Game.gName like'%生化%'
select Studio.sName,GType.name,Game.* from Game,GType,Studio where Game.gTid=GType.id and Game.gSId=Studio.id and GType.id = 3 and Studio.id = 5 and Game.gState = 0 and Game.gName like '%最后%' 

--删除测试
--delete from comment where id =1 
--delete from Gorder where id =1 
--delete from library where id =1 
--delete from Userinfo where id =1 (无法直接删除用户表数据。需要删除前面三个表id相同的记录)

--delete from Game where id=1	(无法直接删除游戏表数据。需要删除Gorder表id相同的记录)
--delete from Studio where id=1	(无法直接删除厂商表数据。需要删除Game表id相同的记录)
--delete from GType where id=1	(无法直接删除厂商表数据。需要删除Game表id相同的记录)
--总结：需要在IDE中给页面添加删除条件，先查询，后删除。 
--删除用户表数据需要查询comment,Gorder,library三个表中是否有删除当前行id相同的记录，如果存在相同id的数据则禁止删除
--删除游戏表数据需要查询Gorder表中是否有删除当前行id相同的记录，如果存在相同id的数据则禁止删除
--删除GType和Studio都需要查询Game表中是否有删除当前行id相同的记录，如果存在相同id的数据则禁止删除
--如果不禁止将会提示外键约束错误


--select Studio.sName,GType.name,Game.* from Game,GType,Studio where Game.gTid=GType.id and Game.gSId=Studio.id
--select Game.gName,Userinfo.userName,Gorder.* from Gorder,Game,Userinfo where Game.id=Gorder.oGid and Userinfo.id=Gorder.oUid