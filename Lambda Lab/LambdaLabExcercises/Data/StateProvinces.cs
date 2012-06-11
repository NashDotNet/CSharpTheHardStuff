using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaLabExcercises.Data
{
    public static class StateProvinces
    {
        private static List<StateProvince> _cache;

        public static IEnumerable<StateProvince> GetAll()
        {
            if (_cache == null)
            {
                string rawData = GetRawData();

                var lines = rawData.Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
                var cells = lines.Select(x => x.Split(new char[] {'\t'}, StringSplitOptions.None));

                _cache = cells.Select(x => new StateProvince
                                               {
                                                   StateProvinceID = Int32.Parse(x[0]),
                                                   Code = x[1],
                                                   Country = x[2],
                                                   Name = x[3]
                                               }).ToList();
            }

            return _cache;
        }

        private static string GetRawData()
        {
            return @"1	AB 	CA	Alberta
2	AK 	US	Alaska
3	AL 	US	Alabama
4	AR 	US	Arkansas
5	AS 	AS	American Samoa
6	AZ 	US	Arizona
7	BC 	CA	British Columbia
8	BY 	DE	Bayern
9	CA 	US	California
10	CO 	US	Colorado
11	CT 	US	Connecticut
12	DC 	US	District of Columbia
13	DE 	US	Delaware
14	ENG	GB	England
15	FL 	US	Florida
16	FM 	FM	Micronesia
17	GA 	US	Georgia
18	GU 	US	Guam
19	HE 	DE	Hessen
20	HH 	DE	Hamburg
21	HI 	US	Hawaii
22	IA 	US	Iowa
23	ID 	US	Idaho
24	IL 	US	Illinois
25	IN 	US	Indiana
26	KS 	US	Kansas
27	KY 	US	Kentucky
28	LA 	US	Louisiana
29	LB 	CA	Labrador
30	MA 	US	Massachusetts
31	MB 	CA	Manitoba
32	MD 	US	Maryland
33	ME 	US	Maine
34	MH 	MH	Marshall Islands
35	MI 	US	Michigan
36	MN 	US	Minnesota
37	MO 	US	Missouri
38	MP 	MP	Northern Mariana Islands
39	MS 	US	Mississippi
40	MT 	US	Montana
41	NB 	CA	Brunswick
42	NC 	US	North Carolina
43	ND 	US	North Dakota
44	NE 	US	Nebraska
45	NF 	CA	Newfoundland
46	NH 	US	New Hampshire
47	NJ 	US	New Jersey
48	NM 	US	New Mexico
49	NS 	CA	Nova Scotia
50	NSW	AU	New South Wales
51	NT 	CA	Northwest Territories
52	NV 	US	Nevada
53	NW 	DE	Nordrhein-Westfalen
54	NY 	US	New York
55	OH 	US	Ohio
56	OK 	US	Oklahoma
57	ON 	CA	Ontario
58	OR 	US	Oregon
59	PA 	US	Pennsylvania
60	PE 	CA	Prince Edward Island
61	PR 	US	Puerto Rico
62	PW 	PW	Palau
63	QC 	CA	Quebec
64	QLD	AU	Queensland
65	RI 	US	Rhode Island
66	SA 	AU	South Australia
67	SC 	US	South Carolina
68	SD 	US	South Dakota
69	SK 	CA	Saskatchewan
70	SL 	DE	Saarland
71	TAS	AU	Tasmania
72	TN 	US	Tennessee
73	TX 	US	Texas
74	UT 	US	Utah
75	VA 	US	Virginia
76	VI 	VI	Virgin Islands
77	VIC	AU	Victoria
78	VT 	US	Vermont
79	WA 	US	Washington
80	WI 	US	Wisconsin
81	WV 	US	West Virginia
82	WY 	US	Wyoming
83	YT 	CA	Yukon Territory
84	FR 	FR	France
85	BB 	DE	Brandenburg
86	SN 	DE	Saxony
87	01 	FR	Ain
88	02 	FR	Aisne
89	03 	FR	Allier
90	04 	FR	Alpes-de-Haute Provence
91	05 	FR	Alpes (Haute)
92	06 	FR	Alpes-Maritimes
93	07 	FR	Ardèche
94	08 	FR	Ardennes
95	09 	FR	Ariège
96	10 	FR	Aube
97	11 	FR	Aude
98	12 	FR	Aveyron
99	13 	FR	Bouches du Rhône
100	14 	FR	Calvados
101	15 	FR	Cantal
102	16 	FR	Charente
103	17 	FR	Charente-Maritime
104	18 	FR	Cher
105	19 	FR	Corrèze
106	20 	FR	Corse
107	21 	FR	Côte d'Or
108	22 	FR	Côtes-d'Armor
109	23 	FR	Creuse
110	24 	FR	Dordogne
111	25 	FR	Toubs
112	26 	FR	Drôme
113	27 	FR	Eure
114	28 	FR	Eure et Loir
115	29 	FR	Finistère
116	30 	FR	Gard
117	31 	FR	Garonne (Haute)
118	32 	FR	Gers
119	33 	FR	Gironde
120	34 	FR	Hérault
121	35 	FR	Ille et Vilaine
122	36 	FR	Indre
123	37 	FR	Indre et Loire
124	38 	FR	Isère
125	39 	FR	Jura
126	40 	FR	Landes
127	41 	FR	Loir et Cher
128	42 	FR	Loire
129	43 	FR	Loire (Haute)
130	44 	FR	Loire Atlantique
131	45 	FR	Loiret
132	46 	FR	Lot
133	47 	FR	Lot et Garonne
134	48 	FR	Lozère
135	49 	FR	Maine et Loire
136	50 	FR	Manche
137	51 	FR	Marne
138	52 	FR	Marne (Haute)
139	53 	FR	Mayenne
140	54 	FR	Meurthe et Moselle
141	55 	FR	Meuse
142	56 	FR	Morbihan
143	57 	FR	Moselle
144	58 	FR	Nièvre
145	59 	FR	Nord
146	60 	FR	Oise
147	61 	FR	Orne
148	62 	FR	Pas de Calais
149	63 	FR	Puy de Dôme
150	64 	FR	Pyrénées Atlantiques
151	65 	FR	Pyrénées (Hautes)
152	66 	FR	Pyrénées Orientales
153	67 	FR	Rhin (Bas)
154	68 	FR	Rhin (Haut)
155	69 	FR	Rhône
156	70 	FR	Saône (Haute)
157	71 	FR	Saône et Loire
158	72 	FR	Sarthe
159	73 	FR	Savoie
160	74 	FR	Savoie Haute
161	75 	FR	Seine (Paris)
162	76 	FR	Seine Maritime
163	77 	FR	Seine et Marne
164	78 	FR	Yveline
165	79 	FR	Sèvres (Deux)
166	80 	FR	Somme
167	81 	FR	Tarne
168	82 	FR	Tarne et Garonne
169	83 	FR	Var
170	84 	FR	Vaucluse
171	85 	FR	La Vendée
172	86 	FR	Vienne
173	87 	FR	Vienne (Haute)
174	88 	FR	Vosges
175	89 	FR	Yonne
176	90 	FR	Belford (Territoire de)
177	91 	FR	Essonne
178	92 	FR	Hauts de Seine
179	93 	FR	Seine Saint Denis
180	94 	FR	Val de Marne
181	95 	FR	Val d'Oise
";
        }
    }
}