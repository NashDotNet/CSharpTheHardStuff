using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaLabExcercises.Data
{
    public static class Employees
    {
        private static List<Employee> _cache;

        public static IEnumerable<Employee> GetAll()
        {
            if (_cache == null)
            {
                var rawData = GetRawData();

                var lines = rawData.Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
                var cells = lines.Select(x => x.Split(new char[] {'\t'}, StringSplitOptions.None));

                _cache = cells.Select(x => new Employee
                                               {
                                                   Id = x[0],
                                                   FirstName = x[1],
                                                   LastName = x[2],
                                                   EmailAddress = x[3],
                                                   Phone = x[4],
                                                   MaritalStatus =
                                                       (x[5] == "M") 
                                                           ? MaritalStatus.Married 
                                                           : MaritalStatus.Single,
                                                   Gender = (x[6] == "M") 
                                                       ? Gender.Male 
                                                       : Gender.Female,
                                                   BirthDate = DateTime.Parse(x[7]),
                                                   HireDate = DateTime.Parse(x[8]),
                                                   Street = x[9],
                                                   StateProvinceID = Int32.Parse(x[10]),
                                                   PostalCode = x[11],
                                               }).ToList();
            }
            return _cache;
        }

        private static string GetRawData()
        {
            return @"20269531	Ben	Miller	ben0@adventure-works.com	151-555-0113	M	M	1963-07-05 00:00:00.000	2000-04-09 00:00:00.000	101 Candy Rd.	79	98052
234474252	Garrett	Vargas	garrett1@adventure-works.com	922-555-0165	M	M	1965-03-07 00:00:00.000	2001-07-01 00:00:00.000	10203 Acorn Avenue	1	T2P 2G8
440379437	Gabe	Mares	gabe0@adventure-works.com	310-555-0117	M	M	1978-06-11 00:00:00.000	1999-04-09 00:00:00.000	1061 Buskrik Avenue	79	98020
370989364	Reuben	D'sa	reuben0@adventure-works.com	191-555-0112	M	M	1977-09-27 00:00:00.000	1999-01-16 00:00:00.000	1064 Slow Creek Road	79	98104
466142721	Gordon	Hee	gordon0@adventure-works.com	230-555-0144	M	M	1956-12-30 00:00:00.000	2000-02-12 00:00:00.000	108 Lakeside Court	79	98004
834186596	Karan	Khanna	karan0@adventure-works.com	447-555-0186	S	M	1960-04-07 00:00:00.000	2000-01-23 00:00:00.000	1102 Ravenwood	79	98104
643805155	François	Ajenstat	françois0@adventure-works.com	785-555-0110	S	M	1965-06-17 00:00:00.000	1999-02-18 00:00:00.000	1144 Paradise Ct.	79	98027
95958330	Sariya	Harnpadoungsataya	sariya0@adventure-works.com	399-555-0176	S	M	1977-06-21 00:00:00.000	1999-01-13 00:00:00.000	1185 Dallas Drive	79	98201
275962311	Kirk	Koenigsbauer	kirk0@adventure-works.com	669-555-0150	S	M	1975-03-10 00:00:00.000	1999-01-16 00:00:00.000	1220 Bradford Way	79	98104
420776180	Kim	Ralls	kim0@adventure-works.com	309-555-0129	S	F	1974-06-01 00:00:00.000	1999-01-27 00:00:00.000	1226 Shoe St.	79	98011
879342154	Michael	Raheem	michael6@adventure-works.com	330-555-2568	M	M	1975-01-01 00:00:00.000	1999-06-04 00:00:00.000	1234 Seaside Way	9	94109
480951955	Mike	Seamans	mike0@adventure-works.com	927-555-0150	S	M	1969-08-01 00:00:00.000	1999-04-09 00:00:00.000	1245 Clay Road	79	98256
259388196	Reed	Koch	reed0@adventure-works.com	678-555-0110	M	M	1979-02-09 00:00:00.000	1999-03-06 00:00:00.000	1275 West Street	79	98052
212801092	Fadi	Fakhouri	fadi0@adventure-works.com	935-555-0116	S	M	1979-03-19 00:00:00.000	1999-02-05 00:00:00.000	1285 Greenbrier Street	79	98296
886023130	Paul	Singh	paul1@adventure-works.com	727-555-0112	M	M	1980-12-05 00:00:00.000	1999-02-18 00:00:00.000	1343 Prospect St	79	98004
634335025	Brenda	Diaz	brenda0@adventure-works.com	142-555-0139	M	F	1973-03-31 00:00:00.000	1999-04-06 00:00:00.000	1349 Steven Way	79	98104
60114406	Jack	Richins	jack0@adventure-works.com	552-555-0111	S	M	1973-07-23 00:00:00.000	1999-03-25 00:00:00.000	1356 Grove Way	79	98272
981597097	John	Evans	john1@adventure-works.com	172-555-0130	S	M	1968-07-01 00:00:00.000	1999-02-02 00:00:00.000	136 Balboa Court	79	98104
693168613	Ken	Myer	ken1@adventure-works.com	949-555-0174	M	M	1971-06-29 00:00:00.000	1999-03-28 00:00:00.000	1362 Somerset Place	79	98201
363910111	Barbara	Moreland	barbara1@adventure-works.com	822-555-0145	M	F	1966-02-04 00:00:00.000	1999-03-22 00:00:00.000	137 Mazatlan	79	98104
381073001	Eric	Kurjan	eric2@adventure-works.com	265-555-0195	S	M	1962-10-19 00:00:00.000	2000-02-28 00:00:00.000	1378 String Dr	79	98055
931190412	Bryan	Walton	bryan1@adventure-works.com	935-555-0199	S	M	1974-10-22 00:00:00.000	1999-02-25 00:00:00.000	1397 Paradise Ct.	79	98006
752513276	Steve	Masters	steve0@adventure-works.com	712-555-0170	S	M	1981-05-07 00:00:00.000	1999-03-19 00:00:00.000	1398 Yorba Linda	79	98104
20244403	Belinda	Newman	belinda0@adventure-works.com	319-555-0126	S	F	1959-10-19 00:00:00.000	1999-03-24 00:00:00.000	1399 Firestone Drive	79	98011
377784364	Alex	Nayberg	alex0@adventure-works.com	819-555-0198	M	M	1980-05-14 00:00:00.000	1999-03-12 00:00:00.000	1400 Gate Drive	79	98006
222400012	Don	Hall	don0@adventure-works.com	100-555-0174	M	M	1961-07-14 00:00:00.000	1999-03-17 00:00:00.000	1411 Ranch Drive	79	98014
860123571	David	Lawrence	david7@adventure-works.com	118-555-0177	M	M	1975-10-25 00:00:00.000	1999-03-18 00:00:00.000	158 Walnut Ave	79	98272
604664374	Sandra	Reátegui Alayo	sandra0@adventure-works.com	896-555-0168	M	F	1965-12-06 00:00:00.000	1999-01-27 00:00:00.000	1619 Stillman Court	79	98104
25011600	Samantha	Smith	samantha0@adventure-works.com	587-555-0114	M	F	1977-12-23 00:00:00.000	1999-03-08 00:00:00.000	1648 Eastgate Lane	79	98004
674171828	Jim	Scardelis	jim0@adventure-works.com	679-555-0113	M	M	1976-10-09 00:00:00.000	1999-01-20 00:00:00.000	172 Turning Dr.	79	98020
153479919	Jo	Berry	jo1@adventure-works.com	228-555-0159	M	F	1944-05-25 00:00:00.000	2000-04-07 00:00:00.000	1748 Bird Drive	79	98256
769680433	Ryan	Cornelsen	ryan0@adventure-works.com	208-555-0114	M	M	1962-07-15 00:00:00.000	1999-02-06 00:00:00.000	177 11th Ave	79	98074
545337468	Michael	Hines	michael0@adventure-works.com	218-555-0126	S	M	1974-12-19 00:00:00.000	1999-01-10 00:00:00.000	1792 Belmont Rd.	79	98272
131471224	Andreas	Berglund	andreas0@adventure-works.com	181-555-0124	M	M	1979-04-29 00:00:00.000	1999-03-06 00:00:00.000	1803 Olive Hill	79	98055
443968955	Steven	Selikoff	steven0@adventure-works.com	925-555-0114	M	M	1967-06-15 00:00:00.000	1999-01-02 00:00:00.000	181 Gaining Drive	79	98201
514829225	Laura	Steele	laura0@adventure-works.com	777-555-0141	S	F	1971-01-26 00:00:00.000	1999-02-04 00:00:00.000	1825 Corte Del Prado	79	98019
393421437	Christopher	Hill	christopher0@adventure-works.com	153-555-0166	M	M	1976-11-01 00:00:00.000	2000-03-11 00:00:00.000	1902 Santa Cruz	79	98011
671089628	Dan	Bacon	dan0@adventure-works.com	166-555-0159	M	M	1971-07-28 00:00:00.000	1999-02-12 00:00:00.000	1921 Ranch Road	79	98027
713403643	Yvonne	McKay	yvonne0@adventure-works.com	286-555-0189	M	F	1979-05-17 00:00:00.000	1999-01-10 00:00:00.000	1962 Cotton Ct.	79	98201
363996959	Michiko	Osada	michiko0@adventure-works.com	984-555-0148	S	M	1972-07-28 00:00:00.000	1999-02-27 00:00:00.000	1962 Ferndale Lane	79	98074
480168528	Thierry	D'Hers	thierry0@adventure-works.com	168-555-0183	M	M	1949-08-29 00:00:00.000	1998-01-11 00:00:00.000	1970 Napa Ct.	79	98011
398737566	Michael	Patten	michael2@adventure-works.com	441-555-0195	S	M	1964-06-03 00:00:00.000	1999-03-04 00:00:00.000	2038 Encino Drive	79	98020
410742000	Britta	Simon	britta0@adventure-works.com	955-555-0169	M	F	1979-10-30 00:00:00.000	1999-03-02 00:00:00.000	2046 Las Palmas	79	98020
19312190	Lorraine	Nay	lorraine0@adventure-works.com	845-555-0184	M	F	1978-12-28 00:00:00.000	1999-02-05 00:00:00.000	2059 Clay Rd	79	98020
830150469	Michael	Rothkugel	michael1@adventure-works.com	454-555-0119	S	M	1981-02-04 00:00:00.000	1999-02-11 00:00:00.000	207 Berry Court	79	98020
750246141	Margie	Shoop	margie0@adventure-works.com	818-555-0128	M	F	1976-06-20 00:00:00.000	1999-02-05 00:00:00.000	2080 Sycamore Drive	79	98020
271438431	Garrett	Young	garrett0@adventure-works.com	609-555-0179	S	M	1974-09-26 00:00:00.000	1999-01-08 00:00:00.000	2115 Passing	79	98296
476980013	Grant	Culbertson	grant0@adventure-works.com	955-555-0131	S	M	1966-05-18 00:00:00.000	1999-03-29 00:00:00.000	213 Stonewood Drive	79	98251
509647174	Roberto	Tamburello	roberto0@adventure-works.com	212-555-0187	M	M	1964-12-13 00:00:00.000	1997-12-12 00:00:00.000	2137 Birchwood Dr	79	98052
992874797	Paula	Nartker	paula1@adventure-works.com	476-555-0119	M	F	1977-03-13 00:00:00.000	1999-02-13 00:00:00.000	2144 San Rafael	79	98104
690627818	Ruth	Ellerbrock	ruth0@adventure-works.com	145-555-0130	M	F	1946-07-06 00:00:00.000	1998-02-06 00:00:00.000	2176 Apollo Way	79	98201
652779496	Jimmy	Bischoff	jimmy0@adventure-works.com	927-555-0168	M	M	1975-06-05 00:00:00.000	1999-03-30 00:00:00.000	2176 Brown Street	79	98055
28414965	Stuart	Macrae	stuart1@adventure-works.com	539-555-0149	M	M	1962-01-17 00:00:00.000	2000-04-05 00:00:00.000	2266 Greenwood Circle	79	98055
458159238	Bryan	Baker	bryan0@adventure-works.com	712-555-0113	S	M	1963-09-28 00:00:00.000	1999-02-22 00:00:00.000	2275 Valley Blvd.	79	98272
987554265	David	Campbell	david8@adventure-works.com	740-555-0182	S	M	1964-03-14 00:00:00.000	2001-07-01 00:00:00.000	2284 Azalea Avenue	79	98004
368691270	Brian	LaMee	brian1@adventure-works.com	313-555-0196	M	M	1974-09-12 00:00:00.000	1999-04-04 00:00:00.000	2294 West 39th St.	79	98201
717889520	Mary	Baker	mary1@adventure-works.com	283-555-0185	M	F	1976-10-20 00:00:00.000	2000-01-26 00:00:00.000	2354 Frame Ln.	79	98104
441044382	Jean	Trenary	jean0@adventure-works.com	685-555-0120	S	F	1966-01-13 00:00:00.000	1999-01-12 00:00:00.000	2383 Pepper Drive	79	98052
646304055	Pat	Coleman	pat0@adventure-works.com	720-555-0158	S	M	1961-01-03 00:00:00.000	2000-02-28 00:00:00.000	2425 Notre Dame Ave	79	98251
502097814	Stephen	Jiang	stephen0@adventure-works.com	238-555-0197	M	M	1941-11-17 00:00:00.000	2001-02-04 00:00:00.000	2427 Notre Dame Ave.	79	98052
413787783	Mihail	Frintu	mihail0@adventure-works.com	733-555-0128	S	M	1961-04-09 00:00:00.000	2000-01-30 00:00:00.000	2466 Clearland Circle	79	98020
364818297	Marc	Ingle	marc0@adventure-works.com	234-555-0169	M	M	1976-11-24 00:00:00.000	1999-02-17 00:00:00.000	2473 Orchard Way	79	98074
334834274	Michael	Entin	michael4@adventure-works.com	817-555-0186	S	M	1979-07-17 00:00:00.000	1999-03-29 00:00:00.000	2482 Buckingham Dr.	79	98052
191644724	Linda	Mitchell	linda3@adventure-works.com	883-555-0116	M	F	1970-03-30 00:00:00.000	2001-07-01 00:00:00.000	2487 Riverside Drive	74	84407
470689086	Alan	Brewer	alan0@adventure-works.com	438-555-0172	M	M	1974-04-30 00:00:00.000	1999-03-17 00:00:00.000	25 95th Ave NE	79	98028
885055826	Peng	Wu	peng0@adventure-works.com	164-555-0164	M	M	1966-04-19 00:00:00.000	1999-01-10 00:00:00.000	250 Race Court	79	98011
141165819	Gary	Altman	gary1@adventure-works.com	110-555-0112	M	M	1961-03-21 00:00:00.000	2000-01-03 00:00:00.000	2598 Breck Court	79	98055
370581729	Mandar	Samant	mandar0@adventure-works.com	140-555-0132	S	M	1976-04-21 00:00:00.000	1999-03-14 00:00:00.000	2598 La Vista Circle	79	98019
295971920	Fred	Northup	fred0@adventure-works.com	818-555-0192	S	M	1979-07-27 00:00:00.000	1999-01-13 00:00:00.000	2601 Cambridge Drive	79	98296
494170342	John	Campbell	john0@adventure-works.com	435-555-0113	M	M	1946-09-08 00:00:00.000	1998-04-18 00:00:00.000	2639 Anchor Court	79	98104
563680513	Angela	Barbariol	angela0@adventure-works.com	150-555-0194	S	F	1981-07-01 00:00:00.000	1999-02-21 00:00:00.000	2687 Ridge Road	79	98020
586486572	Susan	Eaton	susan0@adventure-works.com	943-555-0196	S	F	1968-03-20 00:00:00.000	1999-01-08 00:00:00.000	2736 Scramble Rd	79	98055
878395493	Michael	Vanderhyde	michael5@adventure-works.com	296-555-0121	M	M	1972-10-19 00:00:00.000	1999-03-30 00:00:00.000	2812 Mazatlan	79	98020
785853949	Erin	Hagens	erin0@adventure-works.com	842-555-0158	S	F	1961-02-04 00:00:00.000	2000-03-03 00:00:00.000	2947 Vine Lane	79	98004
414476027	Maciej	Dusza	maciej0@adventure-works.com	237-555-0128	S	M	1945-03-02 00:00:00.000	2000-03-01 00:00:00.000	3026 Anchor Drive	79	98020
322160340	Lane	Sacksteder	lane0@adventure-works.com	200-555-0117	M	M	1964-10-24 00:00:00.000	1999-02-12 00:00:00.000	3029 Pastime Dr	79	98104
264306399	Vidur	Luthra	vidur0@adventure-works.com	153-555-0186	S	M	1974-09-02 00:00:00.000	1999-02-02 00:00:00.000	3030 Blackburn Ct.	79	98006
332349500	Lori	Kane	lori0@adventure-works.com	289-555-0196	S	F	1970-08-19 00:00:00.000	1999-03-30 00:00:00.000	3066 Wallace Dr.	79	98052
90888098	Patrick	Wedge	patrick0@adventure-works.com	413-555-0124	S	M	1976-10-11 00:00:00.000	2000-03-04 00:00:00.000	3067 Maya	79	98004
476115505	George	Li	george0@adventure-works.com	518-555-0199	M	M	1967-05-18 00:00:00.000	1999-01-22 00:00:00.000	3074 Arbor Drive	79	98014
60517918	Candy	Spoon	candy0@adventure-works.com	920-555-0177	S	F	1966-03-26 00:00:00.000	1999-02-07 00:00:00.000	310 Winter Lane	79	98256
912265825	Barry	Johnson	barry0@adventure-works.com	206-555-0180	S	M	1946-04-27 00:00:00.000	1998-02-07 00:00:00.000	3114 Notre Dame Ave.	79	98296
260770918	Karen	Berge	karen0@adventure-works.com	746-555-0164	M	F	1966-01-25 00:00:00.000	1999-03-13 00:00:00.000	3127 El Camino Drive	79	98256
330211482	Rebecca	Laszlo	rebecca0@adventure-works.com	314-555-0113	M	F	1967-08-11 00:00:00.000	1999-01-30 00:00:00.000	3197 Thornhill Place	79	98004
72636981	Jill	Williams	jill0@adventure-works.com	510-555-0121	M	F	1969-07-19 00:00:00.000	1999-02-19 00:00:00.000	3238 Laguna Circle	79	98201
1300049	Nicole	Holliday	nicole0@adventure-works.com	508-555-0129	M	F	1976-05-10 00:00:00.000	1999-03-26 00:00:00.000	3243 Buckingham Dr.	79	98104
113695504	Alice	Ciccu	alice0@adventure-works.com	333-555-0173	M	F	1968-02-27 00:00:00.000	1999-01-08 00:00:00.000	3280 Pheasant Circle	79	98296
415823523	Suroor	Fatima	suroor0@adventure-works.com	932-555-0161	S	M	1968-03-28 00:00:00.000	1999-01-18 00:00:00.000	3281 Hillview Dr.	79	98020
54759846	Linda	Moschell	linda0@adventure-works.com	612-555-0171	M	F	1977-08-17 00:00:00.000	1999-01-26 00:00:00.000	3284 S. Blank Avenue	79	98004
370487086	Shammi	Mohamed	shammi0@adventure-works.com	793-555-0179	M	M	1970-11-05 00:00:00.000	1999-01-25 00:00:00.000	332 Laguna Niguel	79	98004
540688287	Tengiz	Kharatishvili	tengiz0@adventure-works.com	910-555-0116	S	M	1980-05-29 00:00:00.000	1999-01-17 00:00:00.000	3333 Madhatter Circle	79	98027
712885347	Jeff	Hay	jeff0@adventure-works.com	350-555-0167	M	M	1967-02-16 00:00:00.000	1999-02-22 00:00:00.000	3385 Crestview Drive	79	98201
486228782	Janice	Galvin	janice0@adventure-works.com	473-555-0117	M	F	1979-06-29 00:00:00.000	2001-01-23 00:00:00.000	3397 Rancho View Drive	79	98052
758596752	Lynn	Tsoflias	lynn0@adventure-works.com	1 (11) 500 555-0190	S	F	1961-04-18 00:00:00.000	2003-07-01 00:00:00.000	34 Waterloo Road	77	3000
345106466	Zainal	Arifin	zainal0@adventure-works.com	204-555-0115	M	M	1966-03-02 00:00:00.000	1999-02-05 00:00:00.000	342 San Simeon	79	98027
276751903	Simon	Rapier	simon0@adventure-works.com	963-555-0134	S	M	1980-06-17 00:00:00.000	1999-01-09 00:00:00.000	3421 Bouncing Road	79	98019
431859843	Nuan	Yu	nuan0@adventure-works.com	913-555-0184	S	M	1969-04-29 00:00:00.000	1999-02-07 00:00:00.000	3454 Bel Air Drive	79	98004
912141525	Elizabeth	Keyser	elizabeth0@adventure-works.com	318-555-0137	M	F	1980-02-26 00:00:00.000	1999-04-03 00:00:00.000	350 Pastel Drive	79	98031
879334904	Lori	Penor	lori1@adventure-works.com	295-555-0161	M	F	1960-08-31 00:00:00.000	2000-03-19 00:00:00.000	3514 Sunshine	79	98256
8066363	Randy	Reeves	randy0@adventure-works.com	961-555-0122	M	M	1960-05-29 00:00:00.000	2000-03-26 00:00:00.000	3632 Bank Way	79	98020
568626529	John	Frum	john3@adventure-works.com	663-555-0172	S	M	1972-04-24 00:00:00.000	1999-04-04 00:00:00.000	3665 Oak Creek Ct.	79	98201
277173473	Peter	Krebs	peter0@adventure-works.com	913-555-0196	M	M	1972-12-04 00:00:00.000	1999-01-02 00:00:00.000	3670 All Ways Drive	79	98004
778552911	Kok-Ho	Loh	kok-ho0@adventure-works.com	999-555-0155	S	M	1970-05-30 00:00:00.000	1999-01-28 00:00:00.000	3708 Montana	79	98004
45615666	Eric	Gubbels	eric0@adventure-works.com	260-555-0119	M	M	1975-02-20 00:00:00.000	1999-02-15 00:00:00.000	371 Apple Dr.	79	98020
993310268	Rostislav	Shabalin	rostislav0@adventure-works.com	751-555-0134	M	M	1967-10-15 00:00:00.000	1999-03-23 00:00:00.000	3711 Rollingwood Dr	79	98004
300946911	Shelley	Dyck	shelley0@adventure-works.com	991-555-0184	S	F	1977-01-08 00:00:00.000	1999-04-08 00:00:00.000	3747 W. Landing Avenue	79	98272
24756624	David	Bradley	david0@adventure-works.com	913-555-0172	S	M	1965-04-19 00:00:00.000	1998-01-20 00:00:00.000	3768 Door Way	79	98052
964089218	Ivo	Salmre	ivo0@adventure-works.com	115-555-0179	M	M	1972-02-04 00:00:00.000	1999-01-05 00:00:00.000	3841 Silver Oaks Place	79	98272
314747499	Ramesh	Meyyappan	ramesh0@adventure-works.com	182-555-0134	S	M	1978-04-14 00:00:00.000	1999-03-07 00:00:00.000	3848 East 39th Street	79	98027
663843431	Dragan	Tomic	dragan0@adventure-works.com	117-555-0185	M	M	1967-03-18 00:00:00.000	1999-03-15 00:00:00.000	3884 Beauty Street	79	98251
435234965	Douglas	Hite	douglas0@adventure-works.com	808-555-0172	M	M	1975-12-26 00:00:00.000	1999-01-28 00:00:00.000	390 Ridgewood Ct.	79	98014
551346974	Russell	King	russell1@adventure-works.com	517-555-0122	M	M	1972-03-14 00:00:00.000	1999-03-25 00:00:00.000	3919 Pinto Road	79	98004
767955365	Mary	Gibson	mary0@adventure-works.com	531-555-0183	M	F	1952-10-14 00:00:00.000	1999-02-13 00:00:00.000	3928 San Francisco	79	98201
305522471	John	Chen	john2@adventure-works.com	201-555-0163	M	M	1976-05-06 00:00:00.000	1999-03-13 00:00:00.000	3977 Central Avenue	79	98019
90836195	Tete	Mensa-Annan	tete0@adventure-works.com	615-555-0153	M	M	1968-02-06 00:00:00.000	2002-11-01 00:00:00.000	3997 Via De Luna	30	02139
750905084	David	Hamilton	david4@adventure-works.com	986-555-0177	S	M	1973-08-02 00:00:00.000	1999-02-04 00:00:00.000	4095 Cooper Dr.	79	98028
368920189	Nitin	Mirchandani	nitin0@adventure-works.com	143-555-0173	S	M	1977-01-01 00:00:00.000	1999-01-29 00:00:00.000	4096 San Remo	79	98074
343861179	Sootha	Charncherngkha	sootha0@adventure-works.com	325-555-0137	M	M	1957-01-05 00:00:00.000	2000-03-26 00:00:00.000	4155 Working Drive	79	98028
585408256	Benjamin	Martin	benjamin0@adventure-works.com	533-555-0111	S	M	1976-02-06 00:00:00.000	1999-02-28 00:00:00.000	4231 Spar Court	79	98296
273260055	Baris	Cetinok	baris0@adventure-works.com	164-555-0114	S	M	1980-11-07 00:00:00.000	1999-03-19 00:00:00.000	426 San Rafael	79	98104
943170460	Sandeep	Kaliyath	sandeep0@adventure-works.com	166-555-0156	S	M	1961-01-03 00:00:00.000	2000-02-18 00:00:00.000	4310 Kenston Dr.	79	98074
535145551	Paula	Barreto de Mattos	paula0@adventure-works.com	523-555-0175	M	F	1966-03-14 00:00:00.000	1999-01-07 00:00:00.000	4311 Clay Rd	79	98004
584205124	Matthias	Berndt	matthias0@adventure-works.com	139-555-0120	M	M	1963-12-13 00:00:00.000	1999-02-21 00:00:00.000	4312 Cambridge Drive	79	98055
295847284	Ken	Sánchez	ken0@adventure-works.com	697-555-0142	S	M	1959-03-02 00:00:00.000	1999-02-15 00:00:00.000	4350 Minute Dr.	79	98006
65848458	Andrew	Cencini	andrew1@adventure-works.com	207-555-0192	S	M	1978-10-26 00:00:00.000	1999-04-07 00:00:00.000	4444 Pepper Way	79	98074
121491555	Wendy	Kahn	wendy0@adventure-works.com	248-555-0134	S	F	1974-11-12 00:00:00.000	1999-01-26 00:00:00.000	4525 Benedict Ct.	79	98074
187369436	Janeth	Esteves	janeth0@adventure-works.com	540-555-0191	S	F	1962-08-25 00:00:00.000	1999-02-16 00:00:00.000	4566 La Jolla	79	98272
461786517	Ed	Dudenhoefer	ed0@adventure-works.com	919-555-0140	S	M	1961-10-12 00:00:00.000	2000-03-08 00:00:00.000	4598 Manila Avenue	79	98104
386315192	Cynthia	Randall	cynthia0@adventure-works.com	352-555-0138	S	F	1971-09-19 00:00:00.000	1999-02-28 00:00:00.000	463 H Stagecoach Rd.	79	98028
339712426	James	Kramer	james0@adventure-works.com	119-555-0117	M	M	1974-08-26 00:00:00.000	1999-01-28 00:00:00.000	4734 Sycamore Court	79	98272
811994146	Diane	Margheim	diane1@adventure-works.com	815-555-0138	S	F	1976-07-06 00:00:00.000	1999-01-30 00:00:00.000	475 Santa Maria	79	98201
764853868	Andy	Ruth	andy0@adventure-works.com	118-555-0110	M	M	1973-11-20 00:00:00.000	1999-03-04 00:00:00.000	4777 Rockne Drive	79	98004
109272464	Bonnie	Kearney	bonnie0@adventure-works.com	264-555-0150	M	F	1976-10-11 00:00:00.000	2000-02-02 00:00:00.000	4852 Chaparral Court	79	98296
857651804	Jun	Cao	jun0@adventure-works.com	299-555-0113	S	M	1969-08-06 00:00:00.000	1999-01-15 00:00:00.000	4909 Poco Lane	79	98052
862951447	Katie	McAskill-White	katie0@adventure-works.com	809-555-0133	S	F	1974-12-20 00:00:00.000	1999-03-24 00:00:00.000	4948 West 4th St	79	98104
982310417	Amy	Alberts	amy0@adventure-works.com	775-555-0164	M	F	1947-10-22 00:00:00.000	2002-05-18 00:00:00.000	5009 Orange Street	79	98055
319472946	Yuhong	Li	yuhong0@adventure-works.com	965-555-0155	M	M	1967-05-08 00:00:00.000	1999-03-05 00:00:00.000	502 Alexander Pl.	79	98104
746373306	David	Yalovsky	david3@adventure-works.com	373-555-0142	S	M	1971-09-04 00:00:00.000	1999-02-03 00:00:00.000	5025 Holiday Hills	79	98104
578953538	Rob	Caron	rob1@adventure-works.com	238-555-0116	S	M	1963-09-05 00:00:00.000	1999-03-17 00:00:00.000	5030 Blue Ridge Dr.	79	98272
233069302	Taylor	Maxwell	taylor0@adventure-works.com	508-555-0165	M	M	1946-05-03 00:00:00.000	1998-03-11 00:00:00.000	504 O St.	79	98020
398223854	Hazem	Abolrous	hazem0@adventure-works.com	869-555-0125	S	M	1967-11-27 00:00:00.000	1999-04-01 00:00:00.000	5050 Mt. Wilson Way	79	98028
697712387	Eric	Brown	eric1@adventure-works.com	680-555-0118	M	M	1957-01-08 00:00:00.000	2000-02-25 00:00:00.000	5086 Nottingham Place	79	98019
788456780	Jose	Lugo	jose0@adventure-works.com	587-555-0115	M	M	1974-09-01 00:00:00.000	1999-03-14 00:00:00.000	5125 Cotton Ct.	79	98104
82638150	Danielle	Tiedt	danielle0@adventure-works.com	500-555-0172	S	F	1976-10-08 00:00:00.000	2000-03-23 00:00:00.000	5203 Virginia Lane	79	98028
826454897	Tom	Vande Velde	tom0@adventure-works.com	295-555-0161	M	M	1976-11-01 00:00:00.000	2000-04-10 00:00:00.000	5242 Marvelle Ln.	79	98201
58317344	Karen	Berg	karen1@adventure-works.com	654-555-0177	S	F	1968-06-19 00:00:00.000	1999-03-20 00:00:00.000	5256 Chickpea Ct.	79	98027
537092325	Charles	Fitzgerald	charles0@adventure-works.com	931-555-0118	S	M	1961-10-03 00:00:00.000	2000-01-04 00:00:00.000	5263 Etcheverry Dr	79	98074
895209680	Sheela	Word	sheela0@adventure-works.com	210-555-0193	S	F	1968-03-13 00:00:00.000	2001-03-28 00:00:00.000	535 Greendell Pl	79	98074
827686041	Pete	Male	pete0@adventure-works.com	768-555-0123	S	M	1967-03-07 00:00:00.000	1999-02-12 00:00:00.000	5375 Clearland Circle	79	98104
211789056	Kitti	Lertpiriyasuwat	kitti0@adventure-works.com	785-555-0132	S	F	1977-07-07 00:00:00.000	1999-04-05 00:00:00.000	5376 Catanzaro Way	79	98104
152085091	Sameer	Tejani	sameer0@adventure-works.com	990-555-0172	M	M	1968-07-27 00:00:00.000	1999-03-15 00:00:00.000	5379 Treasure Island Way	79	98019
521265716	Pilar	Ackerman	pilar0@adventure-works.com	577-555-0185	S	M	1962-10-11 00:00:00.000	1999-02-03 00:00:00.000	5407 Cougar Way	79	98104
632092621	Rajesh	Patel	rajesh0@adventure-works.com	373-555-0137	M	M	1967-11-05 00:00:00.000	1999-02-01 00:00:00.000	5423 Champion Rd.	79	98020
332040978	Willis	Johnson	willis0@adventure-works.com	778-555-0141	S	M	1968-08-18 00:00:00.000	1999-01-14 00:00:00.000	5452 Corte Gilberto	79	98201
974026903	Ovidiu	Cracium	ovidiu0@adventure-works.com	719-555-0181	S	M	1968-02-18 00:00:00.000	2001-01-05 00:00:00.000	5458 Gladstone Drive	79	98028
565090917	Doris	Hartwig	doris0@adventure-works.com	328-555-0150	M	F	1946-05-06 00:00:00.000	1998-04-11 00:00:00.000	5553 Cash Avenue	79	98028
301435199	Merav	Netz	merav0@adventure-works.com	224-555-0187	M	F	1973-06-13 00:00:00.000	1999-04-04 00:00:00.000	5666 Hazelnut Lane	79	98104
652535724	Denise	Smith	denise0@adventure-works.com	869-555-0119	M	F	1978-08-07 00:00:00.000	1999-03-09 00:00:00.000	5669 Ironwood Way	79	98028
998320692	Jossef	Goldberg	jossef0@adventure-works.com	122-555-0189	M	M	1949-04-11 00:00:00.000	1998-02-24 00:00:00.000	5670 Bel Air Dr.	79	98055
294148271	Betsy	Stadick	betsy0@adventure-works.com	405-555-0171	S	F	1957-01-17 00:00:00.000	2000-01-19 00:00:00.000	5672 Hale Dr.	79	98011
754372876	Suchitra	Mohan	suchitra0@adventure-works.com	753-555-0129	M	F	1977-07-11 00:00:00.000	1999-03-20 00:00:00.000	5678 Clear Court	79	98004
112457891	Rob	Walters	rob0@adventure-works.com	612-555-0100	S	M	1965-01-23 00:00:00.000	1998-01-05 00:00:00.000	5678 Lakeview Blvd.	36	55402
947029962	Frank	Martinez	frank3@adventure-works.com	203-555-0196	M	M	1942-04-03 00:00:00.000	2000-03-08 00:00:00.000	5724 Victory Lane	79	98296
139397894	Shu	Ito	shu0@adventure-works.com	330-555-0120	M	M	1958-04-10 00:00:00.000	2001-07-01 00:00:00.000	5725 Glaze Drive	9	94109
132674823	Jeffrey	Ford	jeffrey0@adventure-works.com	984-555-0185	S	M	1946-08-12 00:00:00.000	1998-03-23 00:00:00.000	5734 Ashford Court	79	98272
599942664	Chad	Niswonger	chad0@adventure-works.com	559-555-0175	M	M	1980-09-04 00:00:00.000	1999-03-22 00:00:00.000	5747 Shirley Drive	79	98011
420023788	Bjorn	Rettig	bjorn0@adventure-works.com	199-555-0117	S	M	1979-12-08 00:00:00.000	1999-02-08 00:00:00.000	5802 Ampersand Drive	79	98104
929666391	Dan	Wilson	dan1@adventure-works.com	653-555-0144	M	M	1966-02-06 00:00:00.000	1999-02-23 00:00:00.000	5863 Sierra	79	98004
10708100	Frank	Miller	frank1@adventure-works.com	167-555-0139	S	M	1961-08-24 00:00:00.000	1999-03-27 00:00:00.000	591 Merriewood Drive	79	98296
525932996	Janaina	Bueno	janaina0@adventure-works.com	623-555-0155	M	F	1975-03-03 00:00:00.000	1999-01-24 00:00:00.000	5979 El Pueblo	79	98027
367453993	Frank	Pellow	frank2@adventure-works.com	163-555-0147	M	M	1942-06-13 00:00:00.000	2000-02-24 00:00:00.000	5980 Icicle Circle	79	98055
502058701	Gary	Yukish	gary0@adventure-works.com	901-555-0125	S	M	1978-06-17 00:00:00.000	1999-01-23 00:00:00.000	6057 Hill Street	79	98020
801365500	Kevin	Homer	kevin2@adventure-works.com	555-555-0113	S	M	1976-10-20 00:00:00.000	2000-01-26 00:00:00.000	6058 Hill Street	79	98004
407505660	Linda	Meisner	linda2@adventure-works.com	916-555-0165	M	F	1960-12-31 00:00:00.000	2000-01-18 00:00:00.000	6118 Grasswood Circle	79	98004
280633567	Reinout	Hillmann	reinout0@adventure-works.com	370-555-0163	M	M	1968-02-18 00:00:00.000	2001-01-25 00:00:00.000	620 Woodside Ct.	79	98004
52541318	Mary	Dempsey	mary2@adventure-works.com	124-555-0114	S	F	1968-03-01 00:00:00.000	2001-03-17 00:00:00.000	6307 Greenbelt Way	79	98004
61161660	Pamela	Ansman-Wolfe	pamela0@adventure-works.com	340-555-0193	S	F	1965-01-06 00:00:00.000	2001-07-01 00:00:00.000	636 Vine Hill Way	58	97205
437296311	Annette	Hill	annette0@adventure-works.com	125-555-0196	M	F	1968-03-01 00:00:00.000	2001-01-06 00:00:00.000	6369 Ellis Street	79	98052
843479922	Bob	Hohman	bob0@adventure-works.com	611-555-0116	S	M	1969-09-16 00:00:00.000	1999-01-25 00:00:00.000	6387 Scenic Avenue	79	98011
835460180	Stuart	Munson	stuart0@adventure-works.com	413-555-0136	S	M	1952-10-14 00:00:00.000	1999-01-03 00:00:00.000	6448 Castle Court	79	98004
578935259	Michael	Ray	michael3@adventure-works.com	156-555-0199	S	M	1979-03-02 00:00:00.000	1999-03-19 00:00:00.000	6498 Mining Rd.	79	98104
42487730	Michael	Sullivan	michael8@adventure-works.com	465-555-0156	S	M	1969-07-17 00:00:00.000	2001-01-30 00:00:00.000	6510 Hacienda Drive	79	98055
360868122	Zheng	Mu	zheng0@adventure-works.com	113-555-0173	S	M	1973-11-26 00:00:00.000	1999-01-04 00:00:00.000	6578 Woodhaven Ln.	79	98104
749389530	Ashvini	Sharma	ashvini0@adventure-works.com	656-555-0119	S	M	1967-04-28 00:00:00.000	1999-01-05 00:00:00.000	6580 Poor Ridge Court	79	98027
33237992	Andrew	Hill	andrew0@adventure-works.com	908-555-0159	S	M	1978-10-08 00:00:00.000	1999-03-26 00:00:00.000	6629 Polson Circle	79	98201
539490372	Chris	Preston	chris0@adventure-works.com	200-555-0112	M	M	1979-01-17 00:00:00.000	1999-02-23 00:00:00.000	6657 Sand Pointe Lane	79	98104
498138869	David	Johnson	david1@adventure-works.com	166-555-0162	S	M	1969-12-03 00:00:00.000	1999-01-03 00:00:00.000	6697 Ridge Park Drive	79	98028
621209647	William	Vong	william0@adventure-works.com	148-555-0145	M	M	1971-12-08 00:00:00.000	1999-02-08 00:00:00.000	6774 Bonanza	79	98004
456839592	Robert	Rounthwaite	robert0@adventure-works.com	589-555-0147	S	M	1975-04-01 00:00:00.000	1999-03-06 00:00:00.000	6843 San Simeon Dr.	79	98104
56772045	Krishna	Sunkammurali	krishna0@adventure-works.com	491-555-0183	S	M	1961-10-06 00:00:00.000	2000-03-16 00:00:00.000	6870 D Bel Air Drive	79	98020
519756660	Janet	Sheperdigian	janet0@adventure-works.com	393-555-0186	M	F	1969-04-09 00:00:00.000	1999-04-02 00:00:00.000	6871 Thornwood Dr.	79	98074
227319668	Carol	Philips	carol0@adventure-works.com	609-555-0153	M	F	1978-11-18 00:00:00.000	1999-03-16 00:00:00.000	6872 Thornwood Dr.	79	98011
63761469	Anibal	Sousa	anibal0@adventure-works.com	106-555-0120	S	F	1964-10-06 00:00:00.000	1999-03-27 00:00:00.000	6891 Ham Drive	79	98052
184188301	Laura	Norman	laura1@adventure-works.com	615-555-0110	M	F	1966-02-06 00:00:00.000	1999-03-04 00:00:00.000	6937 E. 42nd Street	79	98055
323403273	Wanida	Benshoof	wanida0@adventure-works.com	708-555-0141	M	F	1965-04-17 00:00:00.000	2001-02-07 00:00:00.000	6951 Harmony Way	79	98074
404159499	Terrence	Earls	terrence0@adventure-works.com	110-555-0115	S	M	1975-01-09 00:00:00.000	1999-03-20 00:00:00.000	6968 Wren Ave.	79	98004
134969118	Dylan	Miller	dylan0@adventure-works.com	181-555-0156	M	M	1977-03-27 00:00:00.000	1999-03-12 00:00:00.000	7048 Laurel	79	98028
113393530	Hung-Fu	Ting	hung-fu0@adventure-works.com	497-555-0181	S	M	1961-11-23 00:00:00.000	2000-02-07 00:00:00.000	7086 O St.	79	98074
309738752	JoLynn	Dobney	jolynn0@adventure-works.com	903-555-0145	S	F	1946-02-16 00:00:00.000	1998-01-26 00:00:00.000	7126 Ending Ct.	79	98104
761597760	Alejandro	McGuel	alejandro0@adventure-works.com	668-555-0130	S	M	1979-01-06 00:00:00.000	1999-01-07 00:00:00.000	7127 Los Gatos Court	79	98104
969985265	Barbara	Decker	barbara0@adventure-works.com	119-555-0192	M	F	1969-08-02 00:00:00.000	1999-02-23 00:00:00.000	7145 Matchstick Drive	79	98074
56920285	Sharon	Salavaria	sharon0@adventure-works.com	970-555-0138	M	F	1951-06-03 00:00:00.000	2001-02-18 00:00:00.000	7165 Brock Lane	79	98055
7201901	Cristian	Petculescu	cristian0@adventure-works.com	434-555-0133	M	M	1974-05-13 00:00:00.000	1999-01-23 00:00:00.000	7166 Brock Lane	79	98104
163347032	Olinda	Turner	olinda0@adventure-works.com	306-555-0186	S	F	1960-05-05 00:00:00.000	2000-04-04 00:00:00.000	7221 Peachwillow Street	79	98004
746201340	Brian	Lloyd	brian0@adventure-works.com	110-555-0182	S	M	1967-03-14 00:00:00.000	1999-03-02 00:00:00.000	7230 Vine Maple Street	79	98296
384162788	Paul	Komosinski	paul0@adventure-works.com	147-555-0160	S	M	1970-12-15 00:00:00.000	1999-01-05 00:00:00.000	7270 Pepper Way	79	98004
568596888	Hanying	Feng	hanying0@adventure-works.com	319-555-0139	S	M	1964-11-16 00:00:00.000	1999-01-17 00:00:00.000	7297 RisingView	79	98052
500412746	Thomas	Michaels	thomas0@adventure-works.com	278-555-0118	M	M	1976-02-11 00:00:00.000	1999-03-30 00:00:00.000	7338 Green St.	79	98020
872923042	Min	Su	min0@adventure-works.com	590-555-0152	M	M	1964-10-11 00:00:00.000	2000-02-25 00:00:00.000	7396 Stratton Circle	79	98004
199546871	Scott	Gode	scott0@adventure-works.com	391-555-0138	M	M	1977-03-13 00:00:00.000	1999-02-09 00:00:00.000	7403 N. Broadway	79	98104
858323870	Stephanie	Conroy	stephanie0@adventure-works.com	594-555-0110	S	F	1974-04-26 00:00:00.000	1999-03-08 00:00:00.000	7435 Ricardo	79	98027
571658797	Kendall	Keil	kendall0@adventure-works.com	138-555-0128	M	M	1976-06-30 00:00:00.000	1999-01-06 00:00:00.000	7439 Laguna Niguel	79	98104
481044938	Syed	Abbas	syed0@adventure-works.com	926-555-0182	M	M	1965-02-11 00:00:00.000	2003-04-15 00:00:00.000	7484 Roundtree Drive	79	98011
582347317	Michael	Zwilling	michael7@adventure-works.com	582-555-0148	S	M	1963-10-07 00:00:00.000	2000-03-26 00:00:00.000	7511 Cooper Dr.	79	98020
245797967	Terri	Duffy	terri0@adventure-works.com	819-555-0175	S	F	1961-09-01 00:00:00.000	1998-03-03 00:00:00.000	7559 Worth Ct.	79	98055
918737118	Kevin	Liu	kevin1@adventure-works.com	714-555-0138	S	M	1976-01-26 00:00:00.000	1999-01-18 00:00:00.000	7594 Alexander Pl.	79	98104
718299860	Russell	Hunter	russell0@adventure-works.com	786-555-0144	M	M	1962-12-27 00:00:00.000	1999-01-13 00:00:00.000	7616 Honey Court	79	98104
363923697	Deborah	Poe	deborah0@adventure-works.com	602-555-0194	M	F	1966-04-07 00:00:00.000	1999-01-19 00:00:00.000	7640 First Ave.	79	98201
416679555	Hao	Chen	hao0@adventure-works.com	806-555-0136	S	M	1967-05-19 00:00:00.000	1999-03-10 00:00:00.000	7691 Benedict Ct.	79	98027
812797414	Linda	Randall	linda1@adventure-works.com	696-555-0157	S	F	1967-11-06 00:00:00.000	1999-03-07 00:00:00.000	77 Birchwood	79	98104
14417807	Guy	Gilbert	guy1@adventure-works.com	320-555-0195	M	M	1972-05-15 00:00:00.000	1996-07-31 00:00:00.000	7726 Driftwood Drive	79	98272
399658727	Lionel	Penuchot	lionel0@adventure-works.com	450-555-0152	S	M	1978-04-15 00:00:00.000	1999-03-30 00:00:00.000	7765 Sunsine Drive	79	98104
112432117	Brian	Welcker	brian3@adventure-works.com	716-555-0127	S	M	1967-07-08 00:00:00.000	2001-03-18 00:00:00.000	7772 Golden Meadow	79	98027
658797903	Gigi	Matthew	gigi0@adventure-works.com	185-555-0186	M	F	1969-02-21 00:00:00.000	1999-02-17 00:00:00.000	7808 Brown St.	79	98004
693325305	Nancy	Anderson	nancy0@adventure-works.com	970-555-0118	M	F	1978-12-21 00:00:00.000	1999-02-03 00:00:00.000	7820 Bird Drive	79	98074
801758002	Annik	Stahl	annik0@adventure-works.com	499-555-0125	M	M	1967-01-27 00:00:00.000	1999-01-18 00:00:00.000	7842 Ygnacio Valley Road	79	98104
253022876	Kevin	Brown	kevin0@adventure-works.com	150-555-0189	S	M	1977-06-03 00:00:00.000	1997-02-26 00:00:00.000	7883 Missing Canyon Court	79	98201
701156975	Sylvester	Valdez	sylvester0@adventure-works.com	492-555-0174	M	M	1960-12-13 00:00:00.000	2000-01-12 00:00:00.000	7902 Grammercy Lane	79	98004
87268837	Eugene	Zabokritski	eugene0@adventure-works.com	241-555-0191	S	M	1977-08-15 00:00:00.000	1999-02-22 00:00:00.000	7939 Bayview Court	79	98074
403414852	Sean	Alexander	sean0@adventure-works.com	420-555-0173	S	M	1966-04-07 00:00:00.000	1999-01-29 00:00:00.000	7985 Center Street	79	98055
615389812	Jillian	Carson	jillian0@adventure-works.com	517-555-0117	S	F	1952-09-29 00:00:00.000	2001-07-01 00:00:00.000	80 Sunview Terrace	36	55802
999440576	Brandon	Heidepriem	brandon0@adventure-works.com	429-555-0137	M	M	1967-02-11 00:00:00.000	1999-03-12 00:00:00.000	8000 Crane Court	79	98052
553069203	Christian	Kleinerman	christian0@adventure-works.com	846-555-0157	M	M	1966-02-18 00:00:00.000	1999-01-15 00:00:00.000	8036 Summit View Dr.	79	98251
981495526	Sairaj	Uddin	sairaj0@adventure-works.com	500-555-0159	M	M	1978-01-22 00:00:00.000	1999-02-27 00:00:00.000	8040 Hill Ct	79	98052
204035155	Lolan	Song	lolan0@adventure-works.com	582-555-0178	M	M	1963-02-25 00:00:00.000	1999-02-13 00:00:00.000	8152 Claudia Dr.	79	98020
841560125	Michael	Blythe	michael9@adventure-works.com	257-555-0154	S	M	1959-01-26 00:00:00.000	2001-07-01 00:00:00.000	8154 Via Mexico	35	48226
1662732	Brian	Goldstein	brian2@adventure-works.com	730-555-0117	S	M	1961-01-23 00:00:00.000	2000-01-12 00:00:00.000	8157 W. Book	79	98011
92096924	Diane	Tibbott	diane2@adventure-works.com	361-555-0180	S	F	1979-09-10 00:00:00.000	1999-02-19 00:00:00.000	8192 Seagull Court	79	98028
561196580	John	Kane	john4@adventure-works.com	254-555-0114	S	M	1976-10-29 00:00:00.000	2000-03-30 00:00:00.000	8209 Green View Court	79	98019
749211824	Frank	Lee	frank0@adventure-works.com	158-555-0191	M	M	1977-10-07 00:00:00.000	1999-02-18 00:00:00.000	8290 Margaret Ct.	79	98104
716374314	Tsvi	Reiter	tsvi0@adventure-works.com	664-555-0112	M	M	1964-02-19 00:00:00.000	2001-07-01 00:00:00.000	8291 Crossbow Way	72	38103
160739235	Jian Shuo	Wang	jianshuo0@adventure-works.com	952-555-0178	S	M	1973-08-27 00:00:00.000	1999-01-08 00:00:00.000	8310 Ridge Circle	79	98272
455563743	Ebru	Ersan	ebru0@adventure-works.com	202-555-0187	S	M	1976-10-23 00:00:00.000	2000-01-07 00:00:00.000	8316 La Salle St.	79	98074
138280935	Carole	Poland	carole0@adventure-works.com	688-555-0192	M	F	1973-11-19 00:00:00.000	1999-01-20 00:00:00.000	8411 Mt. Orange Place	79	98020
621932914	Stefen	Hesse	stefen0@adventure-works.com	165-555-0113	S	M	1966-01-21 00:00:00.000	1999-04-01 00:00:00.000	8463 Vista Avenue	79	98019
442121106	Chris	Okelberry	chris2@adventure-works.com	315-555-0144	S	M	1976-09-07 00:00:00.000	1999-04-08 00:00:00.000	8467 Clifford Court	79	98052
381772114	Mark	Harrington	mark0@adventure-works.com	147-555-0179	S	M	1976-05-31 00:00:00.000	1999-02-16 00:00:00.000	8585 Los Gatos Ct.	79	98027
587567941	Jan	Miksovsky	jan0@adventure-works.com	139-555-0131	S	M	1964-12-16 00:00:00.000	1999-04-06 00:00:00.000	8624 Pepper Way	79	98201
390124815	Kimberly	Zimmerman	kimberly0@adventure-works.com	123-555-0167	S	F	1976-10-14 00:00:00.000	2000-02-13 00:00:00.000	8656 Lakespring Place	79	98104
243322160	Terry	Eminhizer	terry0@adventure-works.com	138-555-0118	M	M	1976-03-07 00:00:00.000	1999-04-03 00:00:00.000	8668 Via Neruda	79	98004
687685941	Greg	Alderson	greg0@adventure-works.com	332-555-0150	S	M	1960-11-18 00:00:00.000	1999-01-03 00:00:00.000	8684 Military East	79	98004
58791499	Jack	Creasey	jack1@adventure-works.com	521-555-0113	S	M	1963-09-30 00:00:00.000	2000-04-03 00:00:00.000	874 Olivera Road	79	98104
482810518	Fukiko	Ogisu	fukiko0@adventure-works.com	520-555-0177	M	M	1960-12-25 00:00:00.000	2000-02-05 00:00:00.000	8751 Norse Drive	79	98004
63179277	Jay	Adams	jay0@adventure-works.com	407-555-0165	S	M	1966-03-14 00:00:00.000	1999-04-06 00:00:00.000	896 Southdale	79	98272
231203233	David	Barber	david5@adventure-works.com	477-555-0132	S	M	1954-07-23 00:00:00.000	1999-02-13 00:00:00.000	8967 Hamilton Ave.	79	98006
9659517	Diane	Glimp	diane0@adventure-works.com	202-555-0151	M	F	1946-04-30 00:00:00.000	1998-04-29 00:00:00.000	9006 Woodside Way	79	98052
399771412	José	Saraiva	josé1@adventure-works.com	185-555-0169	M	M	1954-01-11 00:00:00.000	2001-07-01 00:00:00.000	9100 Sheppard Avenue North	57	K4B 1T7
351069889	Susan	Metters	susan1@adventure-works.com	639-555-0164	S	F	1973-05-03 00:00:00.000	1999-01-15 00:00:00.000	9104 Mt. Sequoia Ct.	79	98074
167554340	Kathie	Flood	kathie0@adventure-works.com	446-555-0118	M	F	1980-12-02 00:00:00.000	1999-02-28 00:00:00.000	9241 St George Dr.	79	98201
844973625	Sidney	Higa	sidney0@adventure-works.com	424-555-0189	M	M	1946-10-01 00:00:00.000	1998-03-05 00:00:00.000	9277 Country View Lane	79	98020
685233686	A. Scott	Wright	ascott0@adventure-works.com	992-555-0194	S	M	1958-10-19 00:00:00.000	1999-01-13 00:00:00.000	9297 Kenston Dr.	79	98006
36151748	David	Ortiz	david2@adventure-works.com	712-555-0119	M	M	1975-01-30 00:00:00.000	1999-01-16 00:00:00.000	931 Corte De Luna	79	98104
242381745	Sean	Chai	sean1@adventure-works.com	205-555-0132	S	M	1977-04-12 00:00:00.000	1999-02-23 00:00:00.000	9314 Icicle Way	79	98027
733022683	Jason	Watters	jason0@adventure-works.com	571-555-0179	S	M	1979-01-08 00:00:00.000	1999-02-15 00:00:00.000	9320 Teakwood Dr.	79	98004
339233463	Prasanna	Samarawickrama	prasanna0@adventure-works.com	129-555-0199	M	M	1943-06-01 00:00:00.000	2000-02-23 00:00:00.000	9322 Driving Drive	79	98052
134219713	Ranjit	Varkey Chudukatil	ranjit0@adventure-works.com	1 (11) 500 555-0117	S	M	1965-10-31 00:00:00.000	2002-07-01 00:00:00.000	94, rue Descartes	119	33000
695256908	Gail	Erickson	gail0@adventure-works.com	849-555-0139	M	F	1942-10-29 00:00:00.000	1998-02-06 00:00:00.000	9435 Breck Court	79	98004
792847334	Arvind	Rao	arvind0@adventure-works.com	848-555-0163	M	M	1964-09-21 00:00:00.000	1999-04-01 00:00:00.000	9495 Limewood Place	79	98055
672243793	Peter	Connelly	peter1@adventure-works.com	310-555-0133	S	M	1970-06-29 00:00:00.000	1999-03-27 00:00:00.000	9530 Vine Lane	79	98027
552560652	Magnus	Hedlund	magnus0@adventure-works.com	583-555-0182	M	M	1961-09-27 00:00:00.000	2000-01-22 00:00:00.000	9533 Working Drive	79	98055
988315686	Patrick	Cook	patrick1@adventure-works.com	425-555-0117	M	M	1964-01-24 00:00:00.000	2000-03-15 00:00:00.000	9537 Ridgewood Drive	79	98104
603686790	Mikael	Sandberg	mikael0@adventure-works.com	309-555-0170	S	M	1974-09-18 00:00:00.000	1999-03-14 00:00:00.000	9539 Glenside Dr	79	98011
30845	David	Liu	david6@adventure-works.com	646-555-0185	M	M	1973-08-08 00:00:00.000	1999-03-03 00:00:00.000	9605 Pheasant Circle	79	98251
519899904	James	Hamilton	james1@adventure-works.com	870-555-0122	S	M	1973-02-07 00:00:00.000	1999-03-07 00:00:00.000	9652 Los Angeles	79	98272
630184120	Jinghao	Liu	jinghao0@adventure-works.com	794-555-0159	S	M	1979-03-09 00:00:00.000	1999-01-09 00:00:00.000	9666 Northridge Ct.	79	98014
619308550	Mindy	Martin	mindy0@adventure-works.com	522-555-0147	M	F	1974-12-22 00:00:00.000	1999-01-26 00:00:00.000	9687 Shakespeare Drive	79	98006
446466105	Jo	Brown	jo0@adventure-works.com	632-555-0129	S	F	1946-11-09 00:00:00.000	1998-03-30 00:00:00.000	9693 Mellowood Street	79	98019
551834634	Shane	Kim	shane0@adventure-works.com	810-555-0178	S	M	1980-06-24 00:00:00.000	1999-03-12 00:00:00.000	9745 Bonita Ct.	79	98004
6298838	Kim	Abercrombie	kim1@adventure-works.com	208-555-0114	M	F	1957-01-14 00:00:00.000	2000-02-17 00:00:00.000	9752 Jeanne Circle	79	98014
97728960	Raymond	Sam	raymond0@adventure-works.com	226-555-0197	M	M	1957-04-02 00:00:00.000	1999-01-24 00:00:00.000	9784 Mt Etna Drive	79	98020
342607223	Mindaugas	Krapauskas	mindaugas0@adventure-works.com	637-555-0120	M	M	1968-06-07 00:00:00.000	1999-02-14 00:00:00.000	9825 Coralie Drive	79	98020
337752649	Vamsi	Kuppa	vamsi0@adventure-works.com	937-555-0137	M	M	1967-04-19 00:00:00.000	1999-01-08 00:00:00.000	9833 Mt. Dias Blv.	79	98011
948320468	Mark	McArthur	mark1@adventure-works.com	417-555-0154	S	M	1969-10-26 00:00:00.000	1999-02-24 00:00:00.000	9863 Ridge Place	79	98052
153288994	Houman	Pournasseh	houman0@adventure-works.com	180-555-0136	M	M	1961-09-30 00:00:00.000	1999-02-26 00:00:00.000	9882 Clay Rde	79	98052
260805477	Chris	Norred	chris1@adventure-works.com	575-555-0126	M	M	1977-06-26 00:00:00.000	1999-04-07 00:00:00.000	989 Crown Ct	79	98027
222969461	John	Wood	john5@adventure-works.com	486-555-0150	S	M	1968-04-06 00:00:00.000	2001-03-10 00:00:00.000	9906 Oak Grove Road	79	98052
66073987	Eugene	Kogan	eugene1@adventure-works.com	173-555-0179	S	M	1966-03-13 00:00:00.000	1999-03-12 00:00:00.000	991 Vista Verde	79	98019
436757988	Tawana	Nusbaum	tawana0@adventure-works.com	368-555-0113	S	M	1979-12-12 00:00:00.000	1999-03-09 00:00:00.000	9964 North Ridge Drive	79	98104
668991357	Jae	Pak	jae0@adventure-works.com	1 (11) 500 555-0145	M	F	1958-04-18 00:00:00.000	2002-07-01 00:00:00.000	Downshire Way	14	BA5 3HX
954276278	Rachel	Valdez	rachel0@adventure-works.com	1 (11) 500 555-0140	S	F	1965-08-09 00:00:00.000	2003-07-01 00:00:00.000	Pascalstr 951	20	14111
";

        }
    }
}