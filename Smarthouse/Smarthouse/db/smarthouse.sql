create table ApplianceGroup(
appgroupnum INTEGER PRIMARY KEY AUTOINCREMENT,
name TEXT,
command TEXT,
gesture TEXT,
proporties TEXT );

create table Appliance(
appnum INTEGER PRIMARY KEY AUTOINCREMENT,
name TEXT,
commands TEXT,
gestures TEXT,
appgroup INTEGER,
FOREIGN KEY(appgroup) REFERENCES ApplianceGroup(appgroupnum));

create table Feature(
featurenum INTEGER PRIMARY KEY AUTOINCREMENT,
name TEXT,
enum TEXT,
appnum INTEGER,
value TEXT,
FOREIGN KEY(appnum) REFERENCES Appliance(appnum));

insert into ApplianceGroup (name, command ) values ( "coffee machine", "On,Off,Add" );
insert into Appliance(name,commands,appgroup) values("coffee one","modify,delete",1);
insert into Feature(name,enum,value,appnum) values("Temperature","Cold,Warm,Hot,very Hot"," ",1);
insert into Feature(name,enum,value,appnum) values("Sugar","0,1,2,3,4"," ",1);
insert into Feature(name,enum,value,appnum) values("Milk","0,1,2,3,4"," ",1);
insert into Feature(name,enum,value,appnum) values("ShortLong","0,1"," ",1);
insert into Feature(name,enum,value,appnum) values("null"," "," ",1);
insert into Feature(name,enum,value,appnum) values("null"," "," ",1);
