use AskAMech
go 

--Roles Data 
insert into Roles(Description ) values('Admin')
insert into Roles(Description ) values('Mechanic')
insert into Roles(Description ) values('General User')


--Admin/Super User for setup
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('admin@askamech.co.za', 'Password@1', 1, null, '2020-09-01', '2020-09-01', '2020-09-01');


--Employee Data
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Martha', 'Hughlin', '7086855588764', 'MarthaHughlin@askamech.co.za', 1, 1000, '2020-12-19 11:07:14', 1000, '2020-08-01 19:09:12', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Rosabel', 'Munehay', '7357065693463', 'RosabelMunehay@askamech.co.za', 1, 1000, '2020-10-15 06:12:43', 1000, '2020-09-13 22:07:31', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Ulysses', 'Twitchings', '1975427202569', 'UlyssesTwitchings@askamech.co.za', 1, 1000, '2020-12-16 18:05:17', 1000, '2020-10-19 19:22:19', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Germaine', 'Chazier', '9617374856580', 'GermaineChazier@askamech.co.za', 1, 1000, '2020-12-26 08:37:45', 1000, '2020-10-24 21:17:19', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Karlotta', 'Downgate', '6398711774858', 'KarlottaDowngate@askamech.co.za', 1, 1000, '2020-10-14 04:58:24', 1000, '2020-01-19 21:31:59', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Danella', 'Emilien', '2166651629750', 'DanellaEmilien@askamech.co.za', 1, 1000, '2020-01-25 09:16:12', 1000, '2020-10-06 03:47:05', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Orv', 'Iverson', '0970558717472', 'OrvIverson@askamech.co.za', 1, 1000, '2020-12-26 01:06:44', 1000, '2020-02-09 01:26:32', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Woody', 'Holywell', '3347691528890', 'WoodyHolywell@askamech.co.za', 1, 1000, '2020-12-16 07:17:21', 1000, '2020-09-28 01:16:23', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Ivonne', 'Ramard', '7881083056928', 'IvonneRamard@askamech.co.za', 1, 1000, '2020-08-26 19:37:52', 1000, '2020-01-22 13:26:48', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Guntar', 'Divisek', '9224846139475', 'GuntarDivisek@askamech.co.za', 1, 1000, '2020-10-30 04:47:33', 1000, '2020-02-14 09:42:02', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Emlynn', 'Lawranson', '3015128163069', 'EmlynnLawranson@askamech.co.za', 1, 1000, '2020-10-01 15:54:45', 1000, '2020-11-02 04:49:57', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Martita', 'Liggins', '0991765775121', 'MartitaLiggins@askamech.co.za', 1, 1000, '2020-12-20 01:39:17', 1000, '2020-04-14 20:54:49', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Osborn', 'Scattergood', '6679034396392', 'OsbornScattergood@askamech.co.za', 1, 1000, '2020-11-18 19:40:44', 1000, '2020-04-26 17:12:11', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Paolina', 'Thoma', '6982355315592', 'PaolinaThoma@askamech.co.za', 1, 1000, '2020-03-31 13:54:30', 1000, '2020-11-04 19:13:41', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Aldridge', 'Haresign', '1825412131437', 'AldridgeHaresign@askamech.co.za', 1, 1000, '2020-02-26 13:12:54', 1000, '2020-09-18 07:03:53', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Marne', 'Poole', '8399212400061', 'MarnePoole@askamech.co.za', 1, 1000, '2020-10-19 12:06:44', 1000, '2020-12-02 23:12:18', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Scot', 'Thackham', '6019422934669', 'ScotThackham@askamech.co.za', 1, 1000, '2020-07-21 15:52:11', 1000, '2020-08-28 09:52:02', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Jacquenette', 'Dalley', '6513589441678', 'JacquenetteDalley@askamech.co.za', 1, 1000, '2020-10-16 01:38:57', 1000, '2020-10-31 01:17:03', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Erik', 'Aykroyd', '6013261908015', 'ErikAykroyd@askamech.co.za', 1, 1000, '2020-11-02 21:06:53', 1000, '2020-03-29 14:37:45', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Grace', 'Newcom', '8181314467990', 'GraceNewcom@askamech.co.za', 1, 1000, '2020-02-20 14:11:05', 1000, '2020-11-25 21:05:59', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Cicely', 'Hardes', '8087998571178', 'CicelyHardes@askamech.co.za', 1, 1000, '2020-05-23 12:37:41', 1000, '2020-09-06 16:13:20', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Paulo', 'Pratley', '5194295929224', 'PauloPratley@askamech.co.za', 1, 1000, '2020-05-15 22:35:27', 1000, '2020-10-20 08:29:36', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Malinde', 'Folks', '1729805979806', 'MalindeFolks@askamech.co.za', 1, 1000, '2020-07-10 18:39:52', 1000, '2020-03-11 01:38:58', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Lulu', 'Whitney', '8148193458861', 'LuluWhitney@askamech.co.za', 1, 1000, '2020-02-22 07:25:25', 1000, '2020-09-01 08:17:43', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Oran', 'Bossons', '8137390921489', 'OranBossons@askamech.co.za', 1, 1000, '2020-11-04 21:02:02', 1000, '2020-01-05 04:29:48', 1);


--Employee User Data
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('MarthaHughlin@askamech.co.za', 'Password@1', 2, 100000, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('RosabelMunehay@askamech.co.za', 'Password@1', 2, 100001,'2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('UlyssesTwitchings@askamech.co.za', 'Password@1', 2, 100002, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('GermaineChazier@askamech.co.za', 'Password@1', 2, 100003,'2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('KarlottaDowngate@askamech.co.za', 'Password@1', 2, 100004, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('DanellaEmilien@askamech.co.za', 'Password@1', 2, 100005, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('OrvIverson@askamech.co.za', 'Password@1', 2, 100006, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('WoodyHolywell@askamech.co.za', 'Password@1', 2, 100007, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('IvonneRamard@askamech.co.za', 'Password@1', 2, 100008, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('GuntarDivisek@askamech.co.za', 'Password@1', 2, 100009, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('EmlynnLawranson@askamech.co.za', 'Password@1', 2, 100010, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('MartitaLiggins@askamech.co.za', 'Password@1', 2, 100011, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('OsbornScattergood@askamech.co.za', 'Password@1', 2, 100012, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('PaolinaThoma@askamech.co.za', 'Password@1', 2, 100013, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('AldridgeHaresign@askamech.co.za', 'Password@1', 2, 100014, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('MarnePoole@askamech.co.za', 'Password@1', 2, 100015, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('ScotThackham@askamech.co.za', 'Password@1', 2, 100016, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('JacquenetteDalley@askamech.co.za', 'Password@1', 2, 100017, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('ErikAykroyd@askamech.co.za', 'Password@1', 2, 100018, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('GraceNewcom@askamech.co.za', 'Password@1', 2, 100019, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('CicelyHardes@askamech.co.za', 'Password@1', 2, 100020, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('PauloPratley@askamech.co.za', 'Password@1', 2, 100021, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('MalindeFolks@askamech.co.za', 'Password@1', 2, 100022, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('LuluWhitney@askamech.co.za', 'Password@1', 2, 100023, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('OranBossons@askamech.co.za', 'Password@1', 2, 100024, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');


--General User Data
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('jackswift@gmail.com', 'Password@1', 3, null, getdate() - 1, '2020-09-28 13:17:58', '2020-09-28 13:17:58');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('delfitt1@epa.gov', 'JXypLq', 3, null, getdate() - 2, '2020-11-11 08:19:52', '2020-11-11 08:19:52');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('amandajackson@netscape.com', 'brJiOwV', 3, null, getdate() - 3, '2020-10-18 10:20:36', '2020-10-18 10:20:36');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('elvis.john@proronmail.com', 'OnwY5m2H9', 3, null, getdate() - 4, '2020-10-19 09:33:39', '2020-10-19 09:33:39');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('wjaycocks4@google.it', 'wq1ZFiIJ', 3, null, getdate() - 5, '2020-09-04 05:49:40', '2020-09-04 05:49:40');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('jessicaadmas@yahoo.com', 'VTa2RE7VIZ', 3, null, getdate() - 5, '2020-09-29 05:29:00', '2020-10-18 23:42:33');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('dquaife6@google.cn', 'xb17ZyOFUS', 3, null, getdate() - 4, '2020-11-16 17:43:29', '2020-11-16 17:43:29');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('fgoney7@bandcamp.com', 'kpFsckNOnXQD', 3, null, getdate() - 3, '2020-01-20 10:35:48', '2020-09-25 15:31:55');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('epodmore8@noaa.gov', '3njWr2gpw2LM', 3, null, getdate() - 2, '2020-10-30 10:59:28', '2020-10-30 10:59:28');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('johnnyglock@gmail.com', 'GSbbZIspok', 3, null, getdate() - 1, '2020-09-15 00:42:01', '2020-09-15 00:42:01');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('dpapaminasa@disqus.com', 'nz3OjyC9bK', 3, null, getdate(), '2020-04-30 08:24:05', '2020-10-15 17:08:40');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('kennymab@uol.com.br', 'wPxnDm', 3, null, getdate(), '2020-10-27 06:42:31', '2020-10-09 18:02:27');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('ptasselerc@examiner.com', '9DLxAluTHyf', 3, null, getdate() - 1, '2020-09-02 13:14:05', '2020-09-02 13:14:05');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('aelverstond@csmonitor.com', 'jv5D0EtUD4', 3, null, getdate() - 2, '2020-11-17 23:19:16', '2020-11-17 23:19:16');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('pgegguse@dropbox.com', 'gWPU4PtD', 3, null, getdate(), '2020-11-27 00:31:23', '2020-11-27 00:31:23');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('lquinseef@sogou.com', 'bbybRuFR', 3, null, getdate() - 3, '2020-10-28 22:33:19', '2020-10-28 22:33:19');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('lbrydellg@homestead.com', 'fUSn07g', 3, null, getdate() - 10, '2020-10-08 05:40:08', '2020-10-08 05:40:08');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('cvasilich@ft.com', 'UKEfEXUyF7LA', 3, null, getdate() - 15, '2020-09-17 13:06:34', '2020-09-17 13:06:34');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('hdebretti@slideshare.net', '1hBY43fDTte', 3, null, getdate(), '2020-09-15 06:11:29', '2020-09-15 06:11:29');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('amckeownj@163.com', 'aSjd1jf', 3, null, getdate() - 7, '2020-09-26 18:05:46', '2020-09-26 18:05:46');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('jfarguhark@yahoo.com', '2CD4KBhiUf0N', 3, null, getdate() - 5, '2020-10-24 07:53:22', '2020-10-24 07:53:22');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('ivashkanaidu@gmail.com', 'BXEJWN2iyMJ', 3, null, getdate() - 2, '2020-11-12 17:55:36', '2020-11-12 17:55:36');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('kthorouggoodm@protonmail.com', 'QGWqxp', 3, null, getdate(), '2020-10-27 11:25:33', '2020-10-27 11:25:33');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('rhencken@bbc.co.uk', 'VwuOCpzWF8l', 3, null, getdate() - 20, '2020-09-29 09:14:39', '2020-09-29 09:14:39');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('mlattieo@bloglines.com', 'HFy84e4', 3, null, getdate() - 12, '2020-10-21 18:00:43', '2020-10-21 18:00:43');


--User Profile Data 
insert into UserProfile(UserId, Username, About, DateLastModified) values(1001, 'Martha Hughlin', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1002, 'Rosabel Munehay', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1003, 'Ulysses Twitchings', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1004, 'Germaine Chazier', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1005, 'Karlotta Downgate', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1006, 'Danella Emilien', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1007, 'Orv Iverson', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1008, 'Woody Holywell', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1009, 'Ivonne Ramard', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1010, 'Guntar Divisek', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1011, 'Emlynn Lawranson', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1012, 'Martita Liggins', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1013, 'Osborn Scattergood', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1014, 'Paolina Thoma', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1015, 'Aldridge Haresign', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1016, 'Marne Poole', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1017, 'Scot Thackham', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1018, 'Jacquenette Dalley', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1019, 'Erik Aykroyd', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1020, 'Grace Newcom', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1021, 'Cicely Hardes', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1022, 'Paulo Pratley', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1023, 'Malinde Folks', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1024, 'Lulu hitney', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1025, 'Oran Bossons', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')/**/
insert into UserProfile(UserId, Username, About, DateLastModified) values(1026, 'Gunslinger', 'I once had tea with the queen of England', '2020-09-28 13:17:58')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1027, 'Dragonightmare', 'I bread fire!!!', '2020-11-11 08:19:52')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1028, 'OldSaint', 'Knowledge is power', '2020-10-18 10:20:36')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1029, 'BigBadTucan', 'I am the one, the choosen one', '2020-10-19 09:33:39')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1030, 'YoungPotato', 'I like potato', '2020-09-04 05:49:40')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1031, 'ShadyBerry', 'Who dares look', '2020-09-29 05:29:00')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1032, 'HammerHalfling', 'Its hammer time', '2020-11-16 17:43:29')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1033, 'Havoccultist', 'Zzz', '2020-11-20 10:35:48')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1034, 'LiquidSlingshot', 'I do not know what to say here', '2020-10-30 10:59:28')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1035, 'GiantWerewolf', 'The night is near', '2020-09-15 00:42:01')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1036, 'AcrobaticPug', 'I like bacon', '2020-11-30 08:24:05')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1037, 'Death-Shadow-007', 'Too much power is just enough', '2020-10-27 06:42:31')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1038, 'Shady_Manatee', 'V8 power all the way', '2020-09-02 13:14:05')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1039, 'Midnight Wizard', 'Dead man walking', '2020-11-17 23:19:16')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1040, 'Steam Watermelon', 'I like cars and woman', '2020-11-27 00:31:23')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1041, 'Sailoreal', 'A sailor of the seven seas', '2020-10-28 22:33:19')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1042, 'DopeyGoose', 'The dope life', '2020-10-08 05:40:08')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1043, 'AmusingBull', 'Yes Sir!', '2020-09-17 13:06:34')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1044, 'Hexecutioner', 'The man who sold the world', '2020-09-15 06:11:29')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1045, 'Phantomato', 'The pain, the sorrow, the end', '2020-09-26 18:05:46')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1046, 'EmotionalBee', ':)', '2020-10-24 07:53:22')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1047, 'AdviceChamp', 'The Champ is here', '2020-11-12 17:55:36')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1048, 'CorruptChicken', 'Corruption is the root of all evil', '2020-10-27 11:25:33')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1049, 'Loud-Pumpkin-01', 'I see, I hear, I...', '2020-09-29 09:14:39')
insert into UserProfile(UserId, Username, About, DateLastModified) values(1050, 'EnchantingPepper', 'Nothing but you on my mind', '2020-10-21 18:00:43')


--Category Data 
insert into Category(Description) values('Engine')
insert into Category(Description) values('Transmission')
insert into Category(Description) values('Suspension')
insert into Category(Description) values('Tyres and Brakes')
insert into Category(Description) values('Auto Electrical')
insert into Category(Description) values('General Maintenance')

--Questions Data
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Engine data
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Slave cylinder connection to clutch', 'What does the slave cylinder have in connection to a clutch?',1, 1027, getdate() - 30, getdate() - 30)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Exciter wire power source', 'Where does Exciter wire get power from on a engine? Can I test it unplugged from alternator?',1, 1026, getdate() - 28, getdate() - 28)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Gas pours out of the breather when engone starts up', 'My 2002 jaguar x type v6 3.0 starts up and gas pours out of the breather. Please help. Changed gaskets on the intake top and bottom but it still just pours out', 1, 1028, getdate() - 26, getdate() - 26)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Engine wont start in cold temp', 'Car will not start in the morning when temp is cold. Battery checks out good.', 1, 1029, getdate() - 24, getdate() - 24)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Oil pressure release valve replacement procedure', 'How is the oil pressure release valve replaced if it is popped out while doing a oil change?' ,1 ,1030, getdate() - 22, getdate() - 22)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Too much water in coolant', 'What happens if I think there is too much water in my coolant?',1, 1031, getdate() - 20, getdate() - 20)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Blower motor location', 'Where would I be able to locate the blower motot on a jetta?',1, 1032, getdate() - 18, getdate() - 18)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Engine not starting when hot on Toyota Hilux', 'I have a 2011 Toyota Hilux 3.0 diseal double cab and It cranks but does not start when the engine is hot. It starts easily when the engine is cold. What might the problem be?',1, 1033, getdate() - 17, getdate() - 17)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Engine sucking air', 'what makes my engine suck air when I push the gas down', 1, 1034, getdate() - 16, getdate() - 16)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Engine and traction light comes on and off', 'A month or 2 into getting my car back my engine light and traction light comes on then the next day or 2 after goes off what does that mean? Should I be worried?', 1, 1035, getdate() - 15, getdate() - 15)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Oil coming back up after change', 'Recently had an oil change, used 5W40 and have had instrument cluster problems in the past. Oil comes back up when accelerating not sure why', 1, 1036, getdate() - 12, getdate() - 12)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Flash engine light and loss of power', 'I was driving and my flash engine light came on and lost power and barley made it home and its hard to crank up, anyone know why this would be the case?', 1, 1037, getdate() - 10, getdate() - 10)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Audi A4 motor shakes on start up', 'My Audi A4 starts up but motor shakes I unplug the cylinder 4-5-6 cable it still run but no power to those cable what can that be?', 1, 1038, getdate() - 8, getdate() - 8)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Mitsubishi Outlander engine wont start after fuel pump and relay change', 'My Mitsubishi Outlander died while driving it and I replaced fuel pump and relays and fuses and it still wont start, I have checked if it is getting fuel to the engine via the fuel lines and it is so I am not sure what the problem is', 1, 1039, getdate() - 6, getdate() - 6)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Engine Wont Start', 'My engine makes a clunky noise when I attempt to start it and it just swings, I have had my battery tested and it seems fine so I am not sure what the problem might be, does anyone have some suggestions?', 1, 1040, getdate() - 4, getdate() - 4)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Engine Overheating', 'The engine of my vehicle seems to start to really overheat when I drive it for more than half an hour, this never used to be the case and I always send my vehicle for servicing so I am not sure what the prblem is, does anyone have any feedback on this?', 1, 1041, getdate() - 2, getdate() - 2)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Oil change ', 'How often should the oil in a vehicle be changed?', 1, 1027, getdate(), getdate())


--Transmission
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Ford Ranger Wildtrak transmission filter and gasket', 'I have a 2015 Ford Ranger Wildtrak and was wondering what size transmission filter and gasket do I need for the?', 2, 1042, getdate() - 10, getdate() - 10)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Toyota Yaris auto transmission replacement', 'How to replace the gear shift lever on auto transmission of a toyota yaris 2015 model',2, 1043,  getdate() - 10, getdate() - 10)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Transmission not engaging', 'Car is automatic. It shifts threw all gears. But does not engage transmission. It is a 2001 ford mustang coupe, any one has any ideas why?', 2, 1044, getdate() - 9, getdate() - 9)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Nissan March / Micra transmission interchange', 'Can the transmission from a 2008 / 2009 Nissan March / Micra work in a 2010 model or which models are interchangeable?', 2, 1045,  getdate() - 8, getdate() - 8)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Mitsubishi eclipse transmission', 'Will a transmission from a 2006 Mitsubishi eclipse work on a 2006 Mitsubishi lancer OZ rally 2.0', 2, 1046,  getdate() - 6, getdate() - 6)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('1996 ford escort transmission slipping in drive', '1996 ford escort I bought had been sitting for awhile and it ran fine for two days and then started slipping in drive and I am not sure why, any suggestions?', 2, 1047, getdate() - 4, getdate() - 4)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('BMW M135i N54 Transmission Fluid', 'What Transmission Fluid goes into a BMW M135i N54 Engine', 2, 1026,  getdate() - 2, getdate() - 2)


-- General Maintenance
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('E46 BMW M3 dash lights not going off', 'I recently purchased a E46 BMW M3 and found that the dash lights arent turning off when i take the key out, why is this happening?', 6, 1048,   getdate() - 30, getdate() - 30)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('2008 Ford Focus ST heating/cooling fan issues', 'Has Anyone Ever Had Issues With The Heating/cooling Fan In 2008 Ford Focus ST?', 6, 1049, getdate() - 25, getdate() - 25)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Thermostat housing bolt replacement', 'I lost a bolt on my thermostat housing and need to replace it, where would I be able to find a replacement?', 6, 1050, getdate() - 20, getdate() - 20)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('2002 Mini Cooper hood', 'Can you use a 2002 Mini Cooper hood on a 2005 mini?', 6, 1027, getdate() - 18, getdate() - 18)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Vehicle hood latch broken', 'Hood latch will not open the hood. Is this something I can fix myself?', 6, 1028, getdate() - 15, getdate() - 15)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Heat and air gauge shows stange numbers', 'Gauge that shows heat & air shows strange numbers, does this need to be calibrated some how?', 6, 1029, getdate() - 12, getdate() - 12)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Types of Oil', 'What are the differences between the different types of Oils out there as I am not sure which oil is best suitable for my vehicle', 6, 1030, getdate() - 10, getdate() - 10)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('How to prevent rust', 'I have recently notices that my vehicle has started to get rust spots and this has become concerning for me, I would like to know what recomendations people have for dealing with rust', 6, 1031, getdate(), getdate())


--Auto Electrical
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Car battery voltage','How many volts should a fully charged automotive battery produce?', 5, 1026, getdate() - 60, getdate() - 60)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Type of current of a car battery','What type of current does a car battery produce?', 5, 1001, getdate() - 50 , getdate() - 50)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Voltage of a charging system','How many volts should a properly operating charging system produce?', 5, 1002, getdate() - 40, getdate() -40)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Component responsible for charging','Which component produces the electricity to charge the battery?', 5, 1003, getdate() - 30, getdate() -30)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Negative side of battery','What is the negative side of the battery connected to?', 5, 1004, getdate() -20, getdate() - 20)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Battery terminal color codes','How are the positive and negative battery terminals color coded?', 5, 1005, getdate() - 10, getdate() - 10)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Component with most amperage in a vehicle','Which component uses the most amperage in a vehicle?', 5, 1006, getdate() -5, getdate() -5)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Dim lights','When I drive at night my vehicle lighsts seem to go dim on their own and on some days they seem fine, does anyone know why this might be the case?', 5, 1035, getdate() - 2, getdate() -2)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Vehicle stalls when plugging anything to power outlet','When I use the power outlet on my vehicle to charge my phone while my vheicle is on the vehicle just dies and stalls and sometimes takes a while to start after a few swings for some reason, any suggestions as to why this may be the case as my car starts perfectily after being on stadnby?', 5, 1042, getdate(), getdate())


--Suspension
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Wheel alignment affects suspension','Does poor wheel alignment affect the suspension of a vehicle?', 3 , 1026, getdate() -5, getdate() -5)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Difficulty steering','Not sure why but recently my vehicle seems to have a very stiff stering wheel when I try to turn adn take sharp corners, I suspect my suspension might be a problem, any ideas?', 3, 1045, getdate() -2, getdate() -2)


--Tyres and brakes 
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Brake Testing','How often should I have my brakes inspected?', 4, 1026, getdate() - 2, getdate() - 1)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('Brake hose','What’s a brake hose?', 4, 1049, getdate() - 1, getdate() - 1)
insert into Questions(Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified) values('What is brake fluid','What exactly is brake fluid?', 4, 1033, getdate(), getdate())
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


--Asnwers Data
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Engine data
insert into Answers(QuestionId, Description, AnsweredByUserId, IsAcceptedAnswer, DateCreated, DateLastModified) values(0, 'The exciter wire gets its power through the amp warning light. Key on, alt stopped, the bulb lights, once the alternator is turning it makes power and the amp light goes off', 0, '', '')
insert into Answers(QuestionId, Description, AnsweredByUserId, IsAcceptedAnswer, DateCreated, DateLastModified) values(0, 'It seems like a huge vacuum leak. It could be the intake manifold or base carburetor gasket. Your local auto parts store may loan you a smoke machine. Hook it up to the brake booster hose. Hope this helps.', 0, '', '')
insert into Answers(QuestionId, Description, AnsweredByUserId, IsAcceptedAnswer, DateCreated, DateLastModified) values(0, 'Chances are, your battery is at fault when your car will not start in the morning. Because below freezing temperatures can cause the chemical reaction in your vehicles battery to exponentially slow down, a weak battery can often cause your car not to start.', 0, '', '')
insert into Answers(QuestionId, Description, AnsweredByUserId, IsAcceptedAnswer, DateCreated, DateLastModified) values(0, 'If you’re seeing an overflow, it could be due to a radiator cap, thermostat, water pump, or radiator malfunction, Be sure you have the proper level of coolant in your vehicle. Overfilling may cause overflowing', 0, '', '')
insert into Answers(QuestionId, Description, AnsweredByUserId, IsAcceptedAnswer, DateCreated, DateLastModified) values(0, 'While the engine is running, oil is picked up from the reservoir or oil pan for most vehicles. The oil is drawn into the pump, compressed and distributed throughout the engine. At lower speeds the pump generates enough volume to support the rotating assembly. As the engine speed increases, so does pump output. At a certain point the pump is moving more oil than the engine is demanding and the pressure inside the system can reach a level where it can blow seals. 
The pressure relief valve opens to send oil back to the reservoir and keep the volume and pressure steady.', 0, '', '')


--Transmission
insert into Answers(QuestionId, Description, AnsweredByUserId, IsAcceptedAnswer, DateCreated, DateLastModified) values(0, 'You would need to know what transmission your truck has to get to the right filter kit You could have the 4L60 or 4L80 auto. More research is required.', 0, '', '')
insert into Answers(QuestionId, Description, AnsweredByUserId, IsAcceptedAnswer, DateCreated, DateLastModified) values(0, 'possibly linkage issue, if the bank was frozen and truck hit hard enuff to dislodge the shift linkage....but if electric stuff on newer vehicle, you will probably be at the mercy of your mechanic.', 0, '', '')
insert into Answers(QuestionId, Description, AnsweredByUserId, IsAcceptedAnswer, DateCreated, DateLastModified) values(0, 'Low transmission fluid is not only dangerous to drive with, but that low fluid could prevent your car from engaging the drive', 0, '', '')


-- General Maintenance
insert into Answers(QuestionId, Description, AnsweredByUserId, IsAcceptedAnswer, DateCreated, DateLastModified) values(0, 'Replace the switch - if that solves the problem - bingo!', 0, '', '')
insert into Answers(QuestionId, Description, AnsweredByUserId, IsAcceptedAnswer, DateCreated, DateLastModified) values(0, 'One of the reasons why dash lights stay on after key is removed includes a short in the control module for the lights.' ,0, '', '')
insert into Answers(QuestionId, Description, AnsweredByUserId, IsAcceptedAnswer, DateCreated, DateLastModified) values(0, 'If the lights are on even when the key to the ignition is taken out, the majority of times it is an issue with the ignition switch.', 0, '', '')
insert into Answers(QuestionId, Description, AnsweredByUserId, IsAcceptedAnswer, DateCreated, DateLastModified) values(0, 'Best bet would be to replace the fan speed control panel. It should come off as one section for the knobs but can sometimes be a pain to get to to remove it and you basically have to take out the entire head unit to do it. The panel should detach from the bottom of the head unit. That knob definitely has some faulty internals from the sounds of it. You can replace it new or try calling a few part yards and see if you can get it cheaper that way. Alot of those places will ship it to you if you are not too far away. Make sure to note if your ac controls are manual or automatic. That is a very important difference.', 0, '', '')
insert into Answers(QuestionId, Description, AnsweredByUserId, IsAcceptedAnswer, DateCreated, DateLastModified) values(0, 'The starter motor could be the problem, but first, you need to make sure the wire and cables are properly connected, and the starter is getting battery power', 0, '', '')