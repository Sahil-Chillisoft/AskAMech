use AskAMech
go 

--Roles Data 
insert into Roles(Description ) values('Admin')
insert into Roles(Description ) values('Mechanic')
insert into Roles(Description ) values('General User')


--Admin/Super User for setup
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('admin@askamech.co.za', 'Admin', 1, null, '2020-09-01', '2020-09-01', '2020-09-01');


--Employee Data
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Martha', 'Hughlin', '7086855588764', 'MarthaHughlin@askamech.co.za', 1, '2020-12-19 11:07:14', 1, '2020-08-01 19:09:12', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Rosabel', 'Munehay', '7357065693463', 'RosabelMunehay@askamech.co.za', 1, '2020-10-15 06:12:43', 1, '2020-09-13 22:07:31', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Ulysses', 'Twitchings', '1975427202569', 'UlyssesTwitchings@askamech.co.za', 1, '2020-12-16 18:05:17', 1, '2020-10-19 19:22:19', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Germaine', 'Chazier', '9617374856580', 'GermaineChazier@askamech.co.za', 1, '2020-12-26 08:37:45', 1, '2020-10-24 21:17:19', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Karlotta', 'Downgate', '6398711774858', 'KarlottaDowngate@askamech.co.za', 1, '2020-10-14 04:58:24', 1, '2020-01-19 21:31:59', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Danella', 'Emilien', '2166651629750', 'DanellaEmilien@askamech.co.za', 1, '2020-01-25 09:16:12', 1, '2020-10-06 03:47:05', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Orv', 'Iverson', '0970558717472', 'OrvIverson@askamech.co.za', 1, '2020-12-26 01:06:44', 1, '2020-02-09 01:26:32', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Woody', 'Holywell', '3347691528890', 'WoodyHolywell@askamech.co.za', 1, '2020-12-16 07:17:21', 1, '2020-09-28 01:16:23', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Ivonne', 'Ramard', '7881083056928', 'IvonneRamard@askamech.co.za', 1, '2020-08-26 19:37:52', 1, '2020-01-22 13:26:48', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Guntar', 'Divisek', '9224846139475', 'GuntarDivisek@askamech.co.za', 1, '2020-10-30 04:47:33', 1, '2020-02-14 09:42:02', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Emlynn', 'Lawranson', '3015128163069', 'EmlynnLawranson@askamech.co.za', 1, '2020-10-01 15:54:45', 1, '2020-11-02 04:49:57', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Martita', 'Liggins', '0991765775121', 'MartitaLiggins@askamech.co.za', 1, '2020-12-20 01:39:17', 1, '2020-04-14 20:54:49', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Osborn', 'Scattergood', '6679034396392', 'OsbornScattergood@askamech.co.za', 1, '2020-11-18 19:40:44', 1, '2020-04-26 17:12:11', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Paolina', 'Thoma', '6982355315592', 'PaolinaThoma@askamech.co.za', 1, '2020-03-31 13:54:30', 1, '2020-11-04 19:13:41', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Aldridge', 'Haresign', '1825412131437', 'AldridgeHaresign@askamech.co.za', 1, '2020-02-26 13:12:54', 1, '2020-09-18 07:03:53', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Marne', 'Poole', '8399212400061', 'MarnePoole@askamech.co.za', 1, '2020-10-19 12:06:44', 1, '2020-12-02 23:12:18', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Scot', 'Thackham', '6019422934669', 'ScotThackham@askamech.co.za', 1, '2020-07-21 15:52:11', 1, '2020-08-28 09:52:02', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Jacquenette', 'Dalley', '6513589441678', 'JacquenetteDalley@askamech.co.za', 1, '2020-10-16 01:38:57', 1, '2020-10-31 01:17:03', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Erik', 'Aykroyd', '6013261908015', 'ErikAykroyd@askamech.co.za', 1, '2020-11-02 21:06:53', 1, '2020-03-29 14:37:45', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Grace', 'Newcom', '8181314467990', 'GraceNewcom@askamech.co.za', 1, '2020-02-20 14:11:05', 1, '2020-11-25 21:05:59', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Cicely', 'Hardes', '8087998571178', 'CicelyHardes@askamech.co.za', 1, '2020-05-23 12:37:41', 1, '2020-09-06 16:13:20', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Paulo', 'Pratley', '5194295929224', 'PauloPratley@askamech.co.za', 1, '2020-05-15 22:35:27', 1, '2020-10-20 08:29:36', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Malinde', 'Folks', '1729805979806', 'MalindeFolks@askamech.co.za', 1, '2020-07-10 18:39:52', 1, '2020-03-11 01:38:58', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Lulu', 'Whitney', '8148193458861', 'LuluWhitney@askamech.co.za', 1, '2020-02-22 07:25:25', 1, '2020-09-01 08:17:43', 1);
insert into Employee (FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated , LastModifiedByUserId, DateLastModified, IsActive ) values ('Oran', 'Bossons', '8137390921489', 'OranBossons@askamech.co.za', 1, '2020-11-04 21:02:02', 1, '2020-01-05 04:29:48', 1);


--Employee User Data
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('MarthaHughlin@askamech.co.za', 'Password@1', 2, 1, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('RosabelMunehay@askamech.co.za', 'Password@1', 2, 2,'2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('RosabelMunehay@askamech.co.za', 'Password@1', 2, 3,'2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('UlyssesTwitchings@askamech.co.za', 'Password@1', 2, 4, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('KarlottaDowngate@askamech.co.za', 'Password@1', 2, 5, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('DanellaEmilien@askamech.co.za', 'Password@1', 2, 6, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('OrvIverson@askamech.co.za', 'Password@1', 2, 7, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('WoodyHolywell@askamech.co.za', 'Password@1', 2, 8, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('IvonneRamard@askamech.co.za', 'Password@1', 2, 9, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('GuntarDivisek@askamech.co.za', 'Password@1', 2, 10, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('EmlynnLawranson@askamech.co.za', 'Password@1', 2, 11, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('MartitaLiggins@askamech.co.za', 'Password@1', 2, 12, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('OsbornScattergood@askamech.co.za', 'Password@1', 2, 13, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('PaolinaThoma@askamech.co.za', 'Password@1', 2, 14, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('AldridgeHaresign@askamech.co.za', 'Password@1', 2, 15, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('MarnePoole@askamech.co.za', 'Password@1', 2, 16, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('ScotThackham@askamech.co.za', 'Password@1', 2, 17, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('JacquenetteDalley@askamech.co.za', 'Password@1', 2, 18, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('ErikAykroyd@askamech.co.za', 'Password@1', 2, 19, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('GraceNewcom@askamech.co.za', 'Password@1', 2, 20, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('CicelyHardes@askamech.co.za', 'Password@1', 2, 21, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('PauloPratley@askamech.co.za', 'Password@1', 2, 22, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('MalindeFolks@askamech.co.za', 'Password@1', 2, 23, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('LuluWhitney@askamech.co.za', 'Password@1', 2, 24, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');
insert into Users (Email , Password , UserRoleId, EmployeeId, DateLastLoggedIn , DateCreated , DateLastModified) values ('OranBossons@askamech.co.za', 'Password@1', 2, 25, '2020-09-01 00:00:0', '2020-09-01 00:00:0', '2020-09-01 00:00:0');


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
insert into UserProfile(UserId, Username, About, DateLastModified) values(2, 'Martha Hughlin', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(3, 'Rosabel Munehay', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(4, 'Rosabel Munehay', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(5, 'Ulysses Twitchings', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(6, 'Karlotta Downgate', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(7, 'Danella Emilien', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(8, 'Orv Iverson', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(9, 'Woody Holywell', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(10, 'Ivonne Ramard', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(11, 'Guntar Divisek', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(12, 'Emlynn Lawranson', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(13, 'Martita Liggins', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(14, 'Osborn Scattergood', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(15, 'Paolina Thoma', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(16, 'Aldridge Haresign', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(17, 'Marne Poole', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(18, 'Scot Thackham', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(19, 'Jacquenette Dalley', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(20, 'Erik Aykroyd', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(21, 'Grace Newcom', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(22, 'Cicely Hardes', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(23, 'Paulo Pratley', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(24, 'Malinde Folks', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(25, 'Lulu hitney', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(26, 'Oran Bossons', 'I am a certified mechanic for AskAMech', '2020-09-01 00:00:0')
insert into UserProfile(UserId, Username, About, DateLastModified) values(27, 'Sailoreal', 'A sailor of the seven seas', '2020-09-28 13:17:58')
insert into UserProfile(UserId, Username, About, DateLastModified) values(28, 'Dragonightmare', 'I bread fire!!!', '2020-11-11 08:19:52')
insert into UserProfile(UserId, Username, About, DateLastModified) values(29, 'OldSaint', 'Knowledge is power', '2020-10-18 10:20:36')
insert into UserProfile(UserId, Username, About, DateLastModified) values(30, 'BigBadTucan', 'I am the one, the choosen one', '2020-10-19 09:33:39')
insert into UserProfile(UserId, Username, About, DateLastModified) values(31, 'YoungPotato', 'I like potato', '2020-09-04 05:49:40')
insert into UserProfile(UserId, Username, About, DateLastModified) values(32, 'ShadyBerry', 'Who dares look', '2020-09-29 05:29:00')
insert into UserProfile(UserId, Username, About, DateLastModified) values(33, 'HammerHalfling', 'Its hammer time', '2020-11-16 17:43:29')
insert into UserProfile(UserId, Username, About, DateLastModified) values(34, 'Havoccultist', 'Zzz', '2020-11-20 10:35:48')
insert into UserProfile(UserId, Username, About, DateLastModified) values(35, 'LiquidSlingshot', 'I do not know what to say here', '2020-10-30 10:59:28')
insert into UserProfile(UserId, Username, About, DateLastModified) values(36, 'GiantWerewolf', 'The night is near', '2020-09-15 00:42:01')
insert into UserProfile(UserId, Username, About, DateLastModified) values(37, 'AcrobaticPug', 'I like bacon', '2020-11-30 08:24:05')
insert into UserProfile(UserId, Username, About, DateLastModified) values(38, 'Death-Shadow-007', 'Too much power is just enough', '2020-10-27 06:42:31')
insert into UserProfile(UserId, Username, About, DateLastModified) values(39, 'Shady_Manatee', 'V8 power all the way', '2020-09-02 13:14:05')
insert into UserProfile(UserId, Username, About, DateLastModified) values(40, 'Midnight Wizard', 'Dead man walking', '2020-11-17 23:19:16')
insert into UserProfile(UserId, Username, About, DateLastModified) values(41, 'Steam Watermelon', 'I like cars and woman', '2020-11-27 00:31:23')
insert into UserProfile(UserId, Username, About, DateLastModified) values(42, 'ConfusedBat', 'I am so confused', '2020-10-28 22:33:19')
insert into UserProfile(UserId, Username, About, DateLastModified) values(43, 'DopeyGoose', 'The dope life', '2020-10-08 05:40:08')
insert into UserProfile(UserId, Username, About, DateLastModified) values(44, 'AmusingBull', 'Yes Sir!', '2020-09-17 13:06:34')
insert into UserProfile(UserId, Username, About, DateLastModified) values(45, 'Hexecutioner', 'The man who sold the world', '2020-09-15 06:11:29')
insert into UserProfile(UserId, Username, About, DateLastModified) values(46, 'Phantomato', 'The pain, the sorrow, the end', '2020-09-26 18:05:46')
insert into UserProfile(UserId, Username, About, DateLastModified) values(47, 'EmotionalBee', ':)', '2020-10-24 07:53:22')
insert into UserProfile(UserId, Username, About, DateLastModified) values(48, 'AdviceChamp', 'The Champ is here', '2020-11-12 17:55:36')
insert into UserProfile(UserId, Username, About, DateLastModified) values(49, 'CorruptChicken', 'Corruption is the root of all evil', '2020-10-27 11:25:33')
insert into UserProfile(UserId, Username, About, DateLastModified) values(50, 'Loud-Pumpkin-01', 'I see, I hear, I...', '2020-09-29 09:14:39')
insert into UserProfile(UserId, Username, About, DateLastModified) values(51, 'EnchantingPepper', 'Nothing but you on my mind', '2020-10-21 18:00:43')


--Category Data 
insert into Category(Description) values('Engine')
insert into Category(Description) values('Transmission')
insert into Category(Description) values('Suspension')
insert into Category(Description) values('Tyres and Brakes')
insert into Category(Description) values('Auto Electrical')
insert into Category(Description) values('General Maintenance')


--Questions Data
--Engine data
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('Now what do I have to do to the slave cylinder on 2004 mini Cooper not changing slave cylinder changing cluch',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('Where does Exciter wire get power from? Can I test it unplugged from alternator?',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('My 2002 jaguar x type v6 3.0 starts up and gas pours out of the breather. Please help. Changed gaskets on the intake top and bottom but it still just pours out. Help !!!',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('Car will not start in the morning now that colder temps have started. Battery checks out good.',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('How is the oil pressure release valve replaced it popped out while doing the oil change on a 2012 Dodge Caravan',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('What happens if I think there is too much water in my coolant it is running weird is it from too much water in the coolant?',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('So on the blower motor question where about is the blower motor and the best way to access it I do know how to do what everyone has said just my second jetta and first one was a TDI',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('2007 mustang stopped in the middle of the road. Tried jumping it off since it would not start and it tries to crank but will not turn over. A belt was squeaking prior to this also.Any suggestions?',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('I have a 2007 Ford F250 6.0L powerstroke diesel pickup truck. It cranks but does not start when an engine is hot. It starts when the engine is cold. What is wrong with the truck?',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('what makes my engine suck air when I push the gas down',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('A month or 2 into getting my car back my engine light, VSC flashing & traction light comes on then the next day or 2 after goes off what does that mean? Should I be worried?',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('Recently had an oil change with reg oil (5W20) and have instrument cluster problems in the past. Oil comes back up when accelerating',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('I was driving and my flash engine light came on and lost power and barley made it home and its hard to crank up',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('I was driving and my flash engine light came on and lost power and barley made it home and its hard to crank up',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('Mu audi a4 starts up but motor shakes I unplug the cylinder 4-5-6 cable it still run but no power to those cable what can that be?',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('My Mitsubishi Outlander died while driving it and I replaced fuel pump and relays and fuses and it still wont start its getting gas but wont start',0,0,'','')

--Transmission
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('I have a 1994 Chevy Silverado 2500 4x4 HD and was wondering what size transmission filter and gasket do I need engine size 5.7 L V8',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('No reverse it stopped when I got stuck in snow bank',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('Will a 99 escalade FWD tranny go in a 01 Chevy Tahoe RWD',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('How to replace the gear shift lever on auto trans',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('Will a 2006 dodge durango 5.7 hemi transmission be interchangeable with a 2015 dodge durango 5.7?',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('Car is automatic. It shifts threw all gears. But does not engage transmission. It is a 2001 ford mustang coupe.',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('I have a 2005 Grand Prix ls4 5.3 V8 trans. that is bad, what car can I get a transmission from to replace mine??',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('Can the transmission from a 2008 / 2009 Nissan March / Micra work in a 2010? / Which models are interchangeable?',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('Someone told me the wrong dipstick for transmission fluid. I added a quart of tranny fluid where the oil dipstick goes',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('Someone told me the wrong dipstick for transmission fluid. I added a quart of tranny fluid where the oil dipstick goes',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('Will a transmission from a 2006 Mitsubishi eclipse work on a 2006 Mitsubishi lancer OZ rally 2.0',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('1996 ford escort I bought from a lady and it sit for awhile and it ran fine for two days and then started slipping in drive and overdrive it drives fine in low',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('What Transmission Fluid Goes In A M50d R1 Transmission In A 89 Ranger. Can I use a hypoid gear oil in',0,0,'','')
-- general maintenance
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('How do I find a passenger side window switch for my 2004 350 Z. I changed the motor and the window is still not working',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('My Dashboard Lights All Stay On',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('I recently purchased a 2003 saab 9-3 and I found out the dash lights arent turning off when i take the key out.',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('Has Anyone Ever Had Issues With The Heating/cooling Fan In 2016 Ram Pickup?',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('So Iam driving my vehicle and it just dies so replace the starter and now it cranks over twice and will not start is my battery bad or is it electrical problem',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('I was driving and my flash engine light came on and lost power and barley made it home and its hard to crank up',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('Just replaced fuel pump EEC and starter relay got the spark and fuel to the funeral still no start no',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('I lost a bolt on my thermostat housing and need to replace. I need to know size and where I would find it ?',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('Can you use a 2002 Mini Cooper hood on a 2005 mini?',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('Hood latch will not open the hood. Is this something I can fix myself?',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('Gage that shows heat & air shows strange numbers',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('Sometimes my truck will randomly turn off or when Iam turning but will turn back on after I turn key off and on?',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('Why is it that when indrive my 2002 Subaru Legacy it seems to want to die out almost completely?',0,0,'','')
insert into Questions(Description,CategoryId,CreatedByUserId,DateCreated,DateLastModified) values('My son was driving 60 miles per hour on the interstate and turned on his brights and car just shut down. Cruised to side of the road and it started right back up. What could it be',0,0,'','')

--Asnwers Data