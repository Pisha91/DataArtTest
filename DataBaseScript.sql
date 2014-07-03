USE [master]
GO
/****** Object:  Database [DataArtATM]    Script Date: 7/3/2014 12:39:47 PM ******/
CREATE DATABASE [DataArtATM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DataArtATM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DataArtATM.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DataArtATM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DataArtATM_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DataArtATM] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DataArtATM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DataArtATM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DataArtATM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DataArtATM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DataArtATM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DataArtATM] SET ARITHABORT OFF 
GO
ALTER DATABASE [DataArtATM] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DataArtATM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DataArtATM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DataArtATM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DataArtATM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DataArtATM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DataArtATM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DataArtATM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DataArtATM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DataArtATM] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DataArtATM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DataArtATM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DataArtATM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DataArtATM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DataArtATM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DataArtATM] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DataArtATM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DataArtATM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DataArtATM] SET  MULTI_USER 
GO
ALTER DATABASE [DataArtATM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DataArtATM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DataArtATM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DataArtATM] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DataArtATM] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DataArtATM]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 7/3/2014 12:39:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cards]    Script Date: 7/3/2014 12:39:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cards](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Number] [bigint] NOT NULL,
	[PinCode] [nvarchar](max) NULL,
	[Balance] [decimal](18, 2) NOT NULL,
	[IsBlocked] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Cards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 7/3/2014 12:39:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Amount] [decimal](18, 2) NULL,
	[Date] [datetime] NOT NULL,
	[CardId] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201407030601542_InitDatabase', N'DataArtATM.DataContext.Migrations.Configuration', 0x1F8B0800000000000400D559CD6EE33610BE17E83B083AB545D6B2B345B10DEC5D244EB230BA4E82D8D9F616D012ED104B915A924A6D147DB21EFA487D850EF54B51B22D393F68918B42723E7266BEE10CC7FFFCF5F7F0C33AA4CE23169270367207BDBEEB60E6F380B0D5C88DD5F2CD3BF7C3FB6FBF195E04E1DAF99CAF7BABD781249323F741A9E8C4F3A4FF8043247B21F105977CA97A3E0F3D1470EFB8DFFFD91B0C3C0C102E6039CEF036668A8438F907FE1D73E6E348C5884E7980A9CCC6616696A03A5728C432423E1EB9E748A153A14EE7D39EFE045185D7CA754E2941709A19A64BD7418C7185149CF5E44EE299129CAD66110C203ADF4418D62D119538D3E1A45CDE569DFEB156C72B0573283F968A871D01076F33FB78B6F84156760BFB81052FC0D26AA3B54EAC3872C74804AE636F7432A6422FAA1878CC05EEA52EE969B123C79A3C2A2801CCD17F47CE38A62A1678C470AC04A247CE4DBCA0C4FF056FE6FC0B662316536A1E108E0873950118BA113CC2426D6EF1323BF6040EED55E53C5BB010336452A5264CFDF4A3EB5CC1E6684171E17FC30033050A7DC40C0BA470708394C282690C9C58B0B6BBB5D7551C2EB0D8B7DF6E8C1BC2C660ED1C04780B61E83A53B4FE84D94A3D8C5CF8749D4BB2C6413E9201DF3102510B424AC47BF739431441C4E5FB9C639F8488BACE8D80AFEC2678E73A331FE9A31F77D66322CF28F7BFE0C2FC679C538CD87EA02BF44856893F2CC8B9404C225FCF48D7B9C53459241F4894C67CCF58709F52FC52F0F096D3AA7032773F476285E1D298F32D0B663C16BE75BCA157C6D2CE0833D00E083443FA7F1D6F6F9B78F37CF1A6DD54EEF7312641679A5662CDE2503AD711F034E490D85E2CAC800C65CCC2F71C52E813422A8D92A786521E295B43298FB576A11487CD8194FA63222F295A95E9BB7D706964693BF8D9E20BAEDF000BBA81EBDAE47FD51153AC33446EFC07EC7F29EEE1CF88C63038A839AF22F32B510F8140BF4F39C39B42E8B86EDAD488E6E0A994DC27898DEAB64D9D5CDDF88205CE3E8F37060EA42BB01889C046E0E091FB434DA71DD0C5BD5C42A704AC62F67BBD81ADB5A161FD72D6552222ACB064E9F64A0D59A313148F19A36496596D5534FA0C2B23A4203D95E4AE2851B34355B89AE26A18151B5B5086F28D7859181BCBB685BA9D185AF0A0D0C356C1EB00967BDE00CB8C6927A1AAAE0D974AE1ECF219E1A5EF88FCBDE16D79700CA7288A20868D074836E2CCD2D7C7F8CDAC7B491EA6189E2F1B2AF3E2B4C54E9017D10A5BB369B6BA24422A4DD905D2D7DF38086BCB9AA9BD8579F99E267BEB4ECB8998AFD6DF761C998FB15E13934A5B5E827A2124F944536C39BC2E96BC02E1A2140DC5C698D33864DB0A965DD279B96E22E463ED518A82DD842906DBE31489C0C42906DBE3188577C534E5701D6BE8597EB109E0D5186045A44DA75664AB5C15CFC039F37AEC4EBD9DD22FC3C0BC803511F2B10E2835FA75E55E5EB49A18F9587B94B4363531D291D7E75B353F6C255D9612BBF02A13E9C01D9DF1B63F642B99AF6EA7569C4B209A28A3CD54EC7DC0B1B2EC7EE0B13A9F08CC1D90A43C9D48FDA2294AFC16CADA35419D16B5D2C05E5290B22811AC526098A5E5FD0DCA5A9E4E97E867207F2481CED1B38D54384C68D69B7DA5634AB08EB67CC11431B2C452A50F0CF7B83F38B6FA9BFF9D5EA32765405B341C5FBD03B1202BA28DBAB7CDD0F1115EEDF3E5BBD45E0E137810AE47EE1F89D48933F9ED3E153C027EDF31F23586C1393C289C3F9FDA25648F48F80F487C17A2F5F726D8019DC0E0C53B810BA2F6801CD4667B757ABD08B7AA3DAD38A10949C0964473EE09FDADE4BC4F6A673D3B37CC765600DFAA553BABC164F7F5A86F118F99E491732DE0CE3D71FAD550AC47CF36623EA1B752D6209DBA1DDB9ED287F764202CB0D044431472A45402B264AD30BB1184F92442D43C7DBD4068136ADA9A059C3D738E23CC34ED1B346CB3DD8E9AA880B6027F9FFE1DFB4BF5B7FAFEBED1D6B6515A3F408C2C3838386567736F644747695F43A969935DDD9C5769399966293B042DFB4ADB1A532FD351AA9787402AE3576E20B524AB124217BC0CFB153A156B266CC9735A5B27CA9758D7E0142B14A40F18B2043D61DAC752263F1F667DE20B283F8209BB8E55142B5019870B5AF9954547C7AEFD93B659F5CCC3EB2861C773A800C7243A0D5CB3B398D0A038F7654389B00542875D968EB52F954ECBABB2537EC5594BA0CC7CC56D31C76144014C5EB3197AC4879CED4EE24F7885FC4D5EE56F07D9EF88AAD987E704AD040A658651CAC3BFC0E1205CBFFF1799FD0089EC210000, N'6.1.1-30610')
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201407030745349_ChangeCardIdTypeInTransaction', N'DataArtATM.DataContext.Migrations.Configuration', 0x1F8B0800000000000400D559CD6EE33610BE17E83B083AB545D64AB245B10DEC5D244E52185D2741EC6C7B0B6869EC104B915A924A6D147DB21EFA487D850EF54B49B6253B3FE8221785E47C2467BE19CE8CFFFDFB9FFE8765C89C47908A0A3E708F7A87AE03DC1701E58B811BEBF99B77EE87F7DF7ED3BF08C2A5F3295FF7D6AC4349AE06EE83D6D189E729FF0142A27A21F5A55062AE7BBE083D1208EFF8F0F067EFE8C803847011CB71FAB731D73484E41FFC7728B80F918E091B8B0098CAC6716692A03A57240415111F06EE39D1E454EAD3E9B8673E5154C352BBCE29A3044F330136771DC2B9D044E3594FEE144CB4147C31897080B0E92A025C37274C417687937279D7EB1C1E9BEB78A5600EE5C74A8B7047C0A3B7997EBCBAF85E5A760BFDA1062F50D37A656E9D6871E00E890C5CA7BED1C99049B3A8A2E0A190D04B4DD23362074E6DF2A0A00432C7FC1D38C398E958C28043AC256107CE4D3C63D4FF155653F119F880C78CD907C423E25C6500876EA48840EAD52DCCB3638FF0D05E55CEAB0B1662964C7AA911D73FFDE83A57B839993128EC6F2960A2F142BF000749340437446B90DC6040A2C1C6EEB5BDAEE27006B26DBFED1837940F51DB3908F216DDD075C664F911F8423F0C5CFC749D4BBA84201FC980EF3845AF45212DE3D67DCE0823E871F93EE7E0D39030D7B991F895458277AE33F18939FAF1CEF718A93326FCCF50A8FF4C080684B7035D9147BA48EC51839C4AC215F1CD8C729D5B60C922F540A3D4E77BD682FB94E2975284B782558593B9FB29910BC0A031151B164C442CFDDAF1FA5EE94B5B3DCC42DBC3D12CE9AFDADFDEAEE3CDF3F99B3153BB7FB760D8CE5623513AB723E06928F065EBEE57DBD1D0F8A58FE2F7149FCC27B850EA154F759DDC3336BA4EEE5BDD5C270ED73B4EAAFE91BA6464513ED7DD9DC920ABBA3D9FCD9F30DC0620D90AC3B3CDF7AA21C6605E845CF90FE07F2EE2EE27C2621C3C6A18AF22F31BD50F81247F8C0587552174DC546DAA447BF05429E1D344474DDDA646AE6E7CC103A7CDE26BFD049F27D4188D504768E081FB43E34E5BA08B385C42A704AC621EB9F57875CDCF818106E7D44FB3AC21513E099ADE80DA09AA2318E2409A184318268F0A8D4CB96EC643CA7D1A11D672F29A5CC7486ACE55EC509F398708B809822DF6E8B2751E249BDB17BBD4D4D5A69DBE6751ABF90A9A741C250A0A97FE5649D61B7E8C597AE6CA2A4B61EA1C32E813D0D6C5300F28A34A853D0D025685ABB94403A342EE1A9475F9B57859FCB4966D8AB1758B7470C0E21EF52B34CCDBC1E52CB04C9975CFA9DE754D342F8C5DD66B5E5AB0E5859DB7A1B2EB8F491461F0B42ABD6CC499A465DEF0CD64F7DA274C313C5FAD29818AD3163B61024216509B4DB3824B2A9536949D11F3EE0C83B0B16C3DB537302FDFD3666FD3683911F3D5E6BBEE4776D5DB5BC7A452979778BDD0049224D5AA19BC299694DBF842C93559DD50B038E49BE3D966E9BC2EB211F2B1EE28456564C31483DD718A17D8C62906BBE358154E4535E57013ABEFD5ECD208CA0D0634DEB22A9D3A91AD122A9E81737678DC9D7A5BA55F8681F92368236C7A18B7A034E8B72BF7F2E2C0C6C8C7BAA3A445818D918EBC32DF1A6F407D49B17BF116D4627E3F8BBFED2DBF46404E9798BA4A3CD2C004E3C94A6908139EF6265FD89051306ACD178C09A773503A4DE1DDE3C3A3E35AC7F0FFD3BDF3940A588716DEABD7F433BAA046A9AD85FB8E4573B57396EFD248114798AE2E07EE9F89D48933FAFD3E153CC02AF18ED32F310E4E317374FE7A6ADF8D3F12E93F10F95D4896DFDB607BF4D68217EFADCDA86E01D9AB71F5EAF47A116E55BB443B702B153C70AE25868F13E7700F56D9944AB67D523369172275E1A9DD5C0AF05BB7379736F1E809CD86B45C7ACDF27F6D69B47F7363AF6EC286B4FD255B075F47BBA0597AB5B701367601D22C01D93D1368DF94D5EB4BDD2D0D82B6FEC0BA4DB615E7AFD241B0D552167C1DDB049BFA0C2FD320682681482AEBD761E4B4A28B12C2FC56CCC1AFD0A95833E27391B3BA76A27C492D0A8E419320AD73E81CEF89D33E2895FCEC96F55B2F30C90846FC3AD651ACF1CA10CE58E5D709E31DDBF64FBA20D533F7AFA3841DCF71053C263501FC9A9FC59405C5B92FD704F00D10C6EDB247D7D8529BC77751769CAF04EF0894A9AF88165308238660EA9A4FC823EC73B63B051F6141FC559ECB6F0669374455EDFD734A1692842AC328E5F15FE470102EDFFF07DA308E8624210000, N'6.1.1-30610')
SET IDENTITY_INSERT [dbo].[Cards] ON 

INSERT [dbo].[Cards] ([Id], [Number], [PinCode], [Balance], [IsBlocked]) VALUES (2, 1111111111111111, N'b59c67bf196a4758191e42f76670ceba', CAST(900.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Cards] ([Id], [Number], [PinCode], [Balance], [IsBlocked]) VALUES (3, 2222222222222222, N'934b535800b1cba8f96a5d72f72f1611', CAST(2000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Cards] ([Id], [Number], [PinCode], [Balance], [IsBlocked]) VALUES (4, 3333333333333333, N'2be9bd7a3434f7038ca27d1918de58bd', CAST(1200.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Cards] ([Id], [Number], [PinCode], [Balance], [IsBlocked]) VALUES (5, 4444444444444444, N'dbc4d84bfcfe2284ba11beffb853a8c4', CAST(100.00 AS Decimal(18, 2)), 0)
SET IDENTITY_INSERT [dbo].[Cards] OFF
SET IDENTITY_INSERT [dbo].[Transactions] ON 

INSERT [dbo].[Transactions] ([Id], [Code], [Amount], [Date], [CardId]) VALUES (2, 1, NULL, CAST(N'2014-07-03 12:03:52.233' AS DateTime), 2)
INSERT [dbo].[Transactions] ([Id], [Code], [Amount], [Date], [CardId]) VALUES (3, 1, NULL, CAST(N'2014-07-03 12:13:34.377' AS DateTime), 2)
INSERT [dbo].[Transactions] ([Id], [Code], [Amount], [Date], [CardId]) VALUES (4, 2, CAST(100.00 AS Decimal(18, 2)), CAST(N'2014-07-03 12:20:47.490' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Transactions] OFF
/****** Object:  Index [IX_Number]    Script Date: 7/3/2014 12:39:47 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Number] ON [dbo].[Cards]
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CardId]    Script Date: 7/3/2014 12:39:47 PM ******/
CREATE NONCLUSTERED INDEX [IX_CardId] ON [dbo].[Transactions]
(
	[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Transactions_dbo.Cards_CardId] FOREIGN KEY([CardId])
REFERENCES [dbo].[Cards] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_dbo.Transactions_dbo.Cards_CardId]
GO
USE [master]
GO
ALTER DATABASE [DataArtATM] SET  READ_WRITE 
GO
