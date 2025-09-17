# AoC2021

DIT ZIJN DE OPLOSSINGEN VOOR Advent Of Code 2021, Day 1 en Day 25

TestCases eerst toegevoegd, begonnen aan Day 25 solution,
Day 25 was lastig om aan te vangen, testcases hielpen om structuur te krijgen
Uiteindelijk was het redelijk goed te doen

CLI project ingericht
 is te draaien door (bash):
	=> dotnet run --project src/AoC2021.Cli -- [dag] [DagNr].txt
	=> dotnet run --project src/AoC2021.Cli -- day25 Day25.txt
	=> dotnet run --project src/AoC2021.Cli -- day1 Day1.txt

Vervolgens Day 1 solution uitgewerkt.
Oplossing 1 was makkelijk en zo gepiept,
Oplossing 2 had wat meer voeten in de aarde maar na ingeving, achteraf makkelijk en logisch

Teruggekeken naar Day25 logica. Hierbij miste ik een visuele representatie. Dus besloten om een WebApp toe te voegen.
(met hulp van AI) draait op localhost en geeft een visuele representatie van de simulatie van migrerende ZeeKomkommers

kleine aanpassingen nodig in Day25, testen ook licht aangepast
Volledige webapplicatie met knoppen voor dag 1 of dag 25, Input bestanden kunnen worden gelezen 
Day25:	- bovenste venster geeft input weer zoals in tekst bestand.
		- zonder tekstbestand wordt er een voorbeeld ingeladen
		- Bij initialiseer owrdt het grid opgebouwd
		- Bij start draait hij in variabele snelheid de simulatie af van de input.